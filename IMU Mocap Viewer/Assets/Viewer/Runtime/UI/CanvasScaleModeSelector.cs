using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(CanvasScaler))]
    public sealed class CanvasScaleModeSelector : MonoBehaviour
    {
        [SerializeField] private float minimumWidthInPixels = 500f;

        private CanvasScaler canvasScaler;

        enum ScaleMode
        {
            None,
            TooSmallWidth,
            ConstantPixelSize
        }

        private ScaleMode mode = ScaleMode.None;

        private void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();

            mode = ScaleMode.None;

            CheckAndUpdateScaleMode();
        }

        private void Update() => CheckAndUpdateScaleMode();

        private void CheckAndUpdateScaleMode()
        {
            canvasScaler.scaleFactor = PixelScaleUtility.DpiScaleFactor;

            float currentScreenWidth = Screen.width;

            if (currentScreenWidth < minimumWidthInPixels * PixelScaleUtility.DpiScaleFactor)
            {
                if (mode == ScaleMode.TooSmallWidth) return;

                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                canvasScaler.referenceResolution = new Vector2(minimumWidthInPixels, canvasScaler.referenceResolution.y);
                canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                canvasScaler.matchWidthOrHeight = 0f;
                mode = ScaleMode.TooSmallWidth;

                return;
            }

            if (mode == ScaleMode.ConstantPixelSize) return;

            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
            mode = ScaleMode.ConstantPixelSize;
        }
    }
}