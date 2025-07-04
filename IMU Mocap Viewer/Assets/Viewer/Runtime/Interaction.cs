using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Viewer.Runtime.Global;
using Viewer.Runtime.Primitives;
using Viewer.Runtime.Widgets;

namespace Viewer.Runtime
{
    public sealed class Interaction : MonoBehaviour
    {
        [SerializeField] private GlobalSetting worldViewHasFocus;
        [SerializeField] private GlobalSetting showWidgets;

        [Header("Settings")] [SerializeField, Range(0f, 1000f)]
        private float maxDistance = 1000;

        [SerializeField, Range(0.1f, 10f)] private float angleSensitivity = 2f;
        [SerializeField, Range(0.1f, 10f)] private float heightSensitivity = 2f;
        [SerializeField] private int numberZoomTicks = 100;
        [SerializeField] private Vector2 distanceRange = new(0.1f, 10f);
        [SerializeField] private Vector2 initialAngle = new(120f, -30f);
        [SerializeField] private Vector2 angle = new(60f, -30f);
        [SerializeField, Range(1f, 3f)] private float margin = 1.125f;

        [Header("Target")] [SerializeField] private Transform target;
        [SerializeField] private Plotter plotter;

        [Header("Tracking")] [SerializeField] private bool tracking = true;

        [Header("Cursor")] [SerializeField] private TranslationCursor translationCursor;
        [SerializeField] private GlobalSetting notAllowedCursor;
        [SerializeField] private RotationCursor rotationCursor;
        [SerializeField] private Pedestal heightStick;
        [SerializeField] private BoundingBox boundingBox;

        private Tool active = Tool.None;

        private bool applicationHasFocus = true;

        private float zoomNotAllowedTimeout = 0;
        private float distance = 0.1f;
        private Bounds? cumulativeBounds;

        private Camera mainCamera;

        private (Vector3 offset, float azimuth)? rotationSettings;
        private bool clearTools;
        private bool clicksReleased;

        private bool shouldResetView;
        private (Vector3 origin, Vector3 hitPoint)? translationSettings;
        private (Vector3 origin, Vector3 hitPoint)? altitudeSettings;

        private ViewerInputs viewerInputs;

        public bool Tracking
        {
            get => tracking;
            set => tracking = value;
        }

        private void Awake()
        {
            if (worldViewHasFocus == null) throw new ArgumentNullException(nameof(worldViewHasFocus), "Disable Interaction global setting is not set.");

            if (showWidgets == null) throw new ArgumentNullException(nameof(showWidgets), "Allow Interaction global setting is not set.");

            viewerInputs = new ViewerInputs();

            viewerInputs.Enable();

            mainCamera = Camera.main;

            Reset();
        }

        private void Reset()
        {
            angle = initialAngle;
            distance = (float)Math.Pow(0.05f, 1f / 3f);

            target.position = Vector3.zero;

            ClearBounds();

            ClearToolStates();

            UpdateCamera();
        }

        private void OnEnable()
        {
            shouldResetView = true;

            clearTools = true;

            Main.OnProcessDataFrame += UpdateView;
        }

        private void OnDisable()
        {
            Main.OnProcessDataFrame -= UpdateView;

            clearTools = true;
        }

        private void OnDestroy() => viewerInputs.Dispose();

        private void OnApplicationFocus(bool hasFocus)
        {
            clearTools = true;

            applicationHasFocus = hasFocus;
        }

        private (bool click, bool rightClick, bool doubleClick, Vector2 point, Vector2 pointDelta, int scrollWheel, bool control) GetInput()
        {
            var noInput = (false, false, false, Vector2.zero, Vector2.zero, 0, false);

            bool click = viewerInputs.Plotter.Click.ReadValue<float>() > 0.5f;
            bool rightClick = viewerInputs.Plotter.RightClick.ReadValue<float>() > 0.5f;
            bool doubleClick = viewerInputs.Plotter.DoubleClick.triggered;

            if (showWidgets.Value == false)
            {
                clicksReleased = false;

                return noInput;
            }

            if (clicksReleased == false && (click || rightClick || doubleClick))
            {
                return noInput;
            }

            clicksReleased = true;

            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return noInput;

            return (
                click,
                rightClick,
                doubleClick,
                viewerInputs.Plotter.Point.ReadValue<Vector2>(),
                viewerInputs.Plotter.PointDelta.ReadValue<Vector2>(),
                (int)Mathf.Clamp(viewerInputs.Plotter.ScrollWheel.ReadValue<Vector2>().y, -1, 1),
                viewerInputs.Plotter.Control.ReadValue<float>() > 0.5f
            );
        }

        private void UpdateView()
        {
            PlotterSettings.Update();

            showWidgets.Value = applicationHasFocus && worldViewHasFocus.Value;

            (bool click, bool rightClick, bool doubleClick, Vector2 point, Vector2 pointDelta, int scrollWheel, bool control) = GetInput();

            Vector3 viewDelta = mainCamera.ScreenToViewportPoint(pointDelta);

            if (Utils.ConsumeFlag(ref clearTools))
            {
                ClearToolStates();
                return;
            }

            if (Utils.ConsumeFlag(ref shouldResetView) || doubleClick)
            {
                Reset();
                AccumulateBounds();
                FitZoomToDataBounds();

                return;
            }

            if (Tracking)
            {
                if (scrollWheel != 0) zoomNotAllowedTimeout = Time.time + 0.3f; // 0.3 seconds

                if (click && rightClick == false) // if left-click only
                {
                    if (active != Tool.NotAllowed && viewDelta.magnitude < 0.001f)
                        Idle();
                    else
                        NotAllowed();
                }
                else if (click == false && rightClick && control) // if right-click only and Ctrl key
                {
                    NotAllowed();
                }
                else if (click == false && rightClick) // if right-click only
                {
                    Orbit(viewDelta);
                    zoomNotAllowedTimeout = 0;
                }
                else if (zoomNotAllowedTimeout >= Time.time)
                {
                    NotAllowed();
                }
                else
                {
                    Idle();
                }

                AccumulateBounds();

                ClearSettingsOfUnusedTools();

                FitZoomToDataBounds();

                ShowBoundingBox();
            }
            else
            {
                zoomNotAllowedTimeout = 0;

                Zoom(scrollWheel);
                UpdateCamera();

                switch (click, rightClick, control: control)
                {
                    case (false, true, false):
                        Orbit(viewDelta);
                        break;
                    case (false, true, true):
                        Height(point);
                        break;
                    case (true, false, _):
                        Translate(point);
                        break;
                    default:
                        Idle();
                        break;
                }

                ClearBounds();

                ClearSettingsOfUnusedTools();

                UpdateCamera();
            }
        }

        private void AccumulateBounds()
        {
            if (plotter.IsEmpty == false) cumulativeBounds.Encapsulate(plotter.Bounds);
        }

        private void ClearBounds() => cumulativeBounds = null;

        private void ShowBoundingBox()
        {
            if (cumulativeBounds.HasValue == false) return;

            boundingBox.Bounds = cumulativeBounds.Value;
            boundingBox.Show();
        }

        private void FitZoomToDataBounds()
        {
            if (cumulativeBounds == null)
            {
                UpdateCamera();
                return;
            }

            target.position = cumulativeBounds.Value.center;

            UpdateCamera();

            float requiredDistance = PixelScaleUtility.CalculateRequiredDistance(mainCamera, cumulativeBounds.Value, margin);
            float newDistanceValue = Mathf.Pow(Mathf.InverseLerp(distanceRange.x, distanceRange.y, requiredDistance), 1f / 3f);

            distance = newDistanceValue;

            UpdateCamera();

            if (active == Tool.Orbit) SwitchToTool(Tool.Orbit, target.position);
        }

        private void UpdateCamera()
        {
            var azimuth = Quaternion.Euler(0, angle.x, 0);
            var elevation = Quaternion.Euler(angle.y, 0, 0);

            if (rotationSettings != null)
            {
                (Vector3 offset, float originalAzimuth) = rotationSettings.Value;

                var newAzimuth = Quaternion.Euler(0, angle.x - originalAzimuth, 0);

                target.position += newAzimuth * offset;
            }

            float distanceFromTarget = Mathf.Lerp(distanceRange.x, distanceRange.y, distance * distance * distance);

            mainCamera.transform.position = target.position + azimuth * (elevation * Vector3.forward * distanceFromTarget);
            mainCamera.transform.rotation = Quaternion.Euler(-angle.y, angle.x + 180f, 0);

            PixelScaleUtility.CalculateForCamera(mainCamera);
        }

        private void Idle() => SwitchToTool(Tool.None, Vector3.zero);

        private void Height(Vector2 pointer)
        {
            Ray ray = mainCamera.ScreenPointToRay(pointer);

            var plane = new Plane(mainCamera.transform.position._x0z() - target.position._x0z(), target.position);

            if (plane.Raycast(ray, out float intersection) == false || intersection > maxDistance)
            {
                SwitchToTool(Tool.Height, target.position);
                return;
            }

            Vector3 newHitPoint = ray.GetPoint(intersection);

            (Vector3 origin, Vector3 hitPoint) = altitudeSettings ??= (target.position, newHitPoint);

            float delta = newHitPoint.y - hitPoint.y;

            target.position = origin + new Vector3(0, delta * heightSensitivity, 0);

            SwitchToTool(Tool.Height, target.position);

            ClearSettingsOfUnusedTools();

            UpdateCamera();

            Ray reRay = mainCamera.ScreenPointToRay(pointer);

            if (plane.Raycast(reRay, out float reDistance) == false || reDistance > maxDistance)
            {
                altitudeSettings = null;
                return;
            }

            altitudeSettings = (target.position, reRay.GetPoint(reDistance));

            SwitchToTool(Tool.Height, target.position);

            ClearSettingsOfUnusedTools();

            UpdateCamera();
        }

        private void Translate(Vector2 pointer)
        {
            Ray ray = mainCamera.ScreenPointToRay(pointer);

            var plane = new Plane(Vector3.up, transform.position);

            if (plane.Raycast(ray, out float intersection) == false || intersection > maxDistance)
            {
                SwitchToTool(Tool.None, Vector3.zero);
                ClearSettingsOfUnusedTools();
                return;
            }

            Vector3 newHitPoint = ray.GetPoint(intersection);

            translationSettings ??= (target.position, newHitPoint);

            (Vector3 origin, Vector3 hitPoint) = translationSettings.Value;

            Vector2 delta = hitPoint._xz() - newHitPoint._xz();

            target.position = origin + new Vector3(delta.x, 0, delta.y);

            UpdateCamera();

            Ray reRay = mainCamera.ScreenPointToRay(pointer);

            if (plane.Raycast(reRay, out float reDistance) == false || reDistance > maxDistance)
            {
                translationSettings = null;
                return;
            }

            translationSettings = (target.position, reRay.GetPoint(reDistance));

            SwitchToTool(Tool.Translate, translationSettings.Value.hitPoint);
        }

        private void NotAllowed()
        {
            SwitchToTool(Tool.NotAllowed, Vector3.zero);
        }

        private void Zoom(int ticks)
        {
            distance -= ticks * (1f / numberZoomTicks);

            distance = Mathf.Clamp01(distance);
        }

        private void Orbit(Vector3 viewPortDelta)
        {
            rotationSettings ??= (Vector3.zero, angle.x);

            float aspect = mainCamera.aspect;
            float fov = mainCamera.fieldOfView;

            Vector2 newAngle = new Vector2(aspect * viewPortDelta.x, viewPortDelta.y) * (fov * angleSensitivity);

            angle += new Vector2(newAngle.x, newAngle.y) * angleSensitivity;
            angle.y = Mathf.Clamp(angle.y, -90, 90f);
            angle.x = Utils.ClampAngle(angle.x);

            SwitchToTool(Tool.Orbit, target.position);
        }

        private void ClearToolStates()
        {
            SwitchToTool(Tool.None, Vector3.zero);

            HideTool(Tool.None);
            HideTool(Tool.Translate);
            HideTool(Tool.Orbit);
            HideTool(Tool.Height);
            HideTool(Tool.Zoom);
            HideTool(Tool.NotAllowed);

            ClearSettingsOfUnusedTools();
        }

        private void ClearSettingsOfUnusedTools()
        {
            if (active != Tool.Translate) translationSettings = null;
            if (active != Tool.Orbit) rotationSettings = null;
            if (active != Tool.Height) altitudeSettings = null;
            if (cumulativeBounds.HasValue == false) boundingBox.Hide();
        }

        private void SwitchToTool(Tool tool, Vector3 location)
        {
            bool InHeightGroup(Tool t) => t == Tool.Height || t == Tool.Orbit;

            if (InHeightGroup(active) == false || InHeightGroup(tool) == false && active != tool)
                HideTool(active);

            active = tool;

            ShowTool(tool, location);
        }

        private void HideTool(Tool tool)
        {
            switch (tool)
            {
                case Tool.None:
                    break;
                case Tool.Translate:
                    translationCursor.Hide();
                    break;
                case Tool.Orbit:
                    rotationCursor.Hide();
                    heightStick.Hide();
                    break;
                case Tool.Height:
                    rotationCursor.Hide();
                    heightStick.Hide();
                    break;
                case Tool.Zoom:
                    break;
                case Tool.NotAllowed:
                    notAllowedCursor.Value = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tool), tool, null);
            }
        }

        private void ShowTool(Tool tool, Vector3 location)
        {
            switch (tool)
            {
                case Tool.None:
                    break;
                case Tool.Translate:
                    translationCursor.ShowAt(location);
                    break;
                case Tool.Orbit:
                    rotationCursor.ShowAt(location);
                    heightStick.Set(location);
                    break;
                case Tool.Height:
                    rotationCursor.ShowAt(location);
                    heightStick.Set(location);
                    break;
                case Tool.Zoom:
                    break;
                case Tool.NotAllowed:
                    notAllowedCursor.Value = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tool), tool, null);
            }
        }

        private enum Tool
        {
            None,
            Translate,
            Orbit,
            Height,
            Zoom,
            NotAllowed,
        }
    }
}