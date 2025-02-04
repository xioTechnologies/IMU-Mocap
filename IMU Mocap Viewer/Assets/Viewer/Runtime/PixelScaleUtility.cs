using UnityEngine;

namespace Viewer.Runtime
{
    public static class PixelScaleUtility
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void CalculateForCamera() => CalculateForCamera(Camera.main);

        public static void CalculateForCamera(Camera camera)
        {
            DpiScaleFactor = Screen.dpi / 96f; // 96 is the standard DPI for Windows TODO: Check for other platforms
            PixelScaleFactor = (2.0f * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad)) / Screen.height;
            CameraPosition = camera.transform.position;
            CameraForward = camera.transform.forward;
        }

        public static float DpiScaleFactor { get; private set; } = 1f;
        public static float PixelScaleFactor { get; private set; } = 1f;
        public static Vector3 CameraPosition { get; private set; } = Vector3.zero;
        public static Vector3 CameraForward { get; private set; } = Vector3.forward;

        public static float GetWorldSizeFromPixels(float pixelSize, Vector3 worldPosition)
        {
            float zDepth = Vector3.Dot(worldPosition - CameraPosition, CameraForward);
            return pixelSize * PixelScaleFactor * zDepth;
        }

        public static Vector3 GetWorldScaleFromPixels(float pixelSize, Vector3 worldPosition)
        {
            return Vector3.one * GetWorldSizeFromPixels(pixelSize, worldPosition);
        }

        public static float CalculateRequiredDistance(Camera camera, Bounds bounds, bool lockToGround = false, float margin = 1.0f)
        {
            var sphere = new BoundingSphere(bounds.center, bounds.extents.magnitude);

            float verticalFOV = camera.fieldOfView;
            float aspectRatio = camera.aspect;

            float verticalFOVRad = verticalFOV * Mathf.Deg2Rad;
            float horizontalFOVRad = 2f * Mathf.Atan(Mathf.Tan(verticalFOVRad / 2f) * aspectRatio);

            float radius = sphere.radius * margin;

            float distanceV = (lockToGround ? radius + Mathf.Abs(sphere.position.y) : radius) / Mathf.Sin(verticalFOVRad / 2f);
            float distanceH = radius / Mathf.Sin(horizontalFOVRad / 2f);

            return Mathf.Max(distanceV, distanceH);
        }
    }
}