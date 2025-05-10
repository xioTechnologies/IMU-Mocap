using UnityEngine;
using Viewer.Runtime.Primitives;

namespace Viewer.Runtime
{
    public static class PixelScaleUtility
    {
        public static float DpiScaleFactor { get; private set; } = 1f;

        private static float pixelScaleFactor = CalculatePixelScaleFactor(90, 640); // arbitrary default values
        private static Vector3 cameraPosition = Vector3.zero;
        private static Vector3 cameraForward = Vector3.forward;
        private static Camera camera;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void CalculateForCamera() => CalculateForCamera(Camera.main);

        public static void CalculateForCamera(Camera camera)
        {
            PixelScaleUtility.camera = camera;

            DpiScaleFactor = Screen.dpi / 96f; // 96 is the standard DPI for Windows TODO: Check for other platforms
            pixelScaleFactor = CalculatePixelScaleFactor(camera.fieldOfView, Screen.height);
            cameraPosition = camera.transform.position;
            cameraForward = camera.transform.forward;

            Shader.SetGlobalFloat(StretchableMaterial.PixelScaleFactor, pixelScaleFactor);
        }

        public static Vector3 GetWorldScaleFromPixels(float pixelSize, Vector3 worldPosition)
        {
            return Vector3.one * GetWorldSizeFromPixels(pixelSize, worldPosition);
        }

        public static float CalculateRequiredDistance(Camera camera, Bounds bounds, float margin = 1.0f)
        {
            Vector3 center = bounds.center;
            Vector3 extents = bounds.extents;

            Matrix4x4 virtualViewMatrix = Matrix4x4.TRS(center, camera.transform.rotation, Vector3.one).inverse;

            Vector3[] corners = new Vector3[8];
            for (int i = 0; i < 8; i++)
            {
                Vector3 offset = new Vector3(
                    ((i & 1) == 0) ? extents.x : -extents.x,
                    ((i & 2) == 0) ? extents.y : -extents.y,
                    ((i & 4) == 0) ? extents.z : -extents.z
                );
                corners[i] = virtualViewMatrix.MultiplyPoint3x4(center + offset);
            }

            float fov = camera.fieldOfView;
            float aspect = camera.aspect;
            float tanHalfFov = Mathf.Tan(Mathf.Deg2Rad * fov * 0.5f);

            float requiredDistance = 0;

            foreach (var corner in corners)
            {
                float x = Mathf.Abs(corner.x);
                float y = Mathf.Abs(corner.y);
                float z = corner.z;

                // If a point is behind the virtual camera, compute the correction
                float correction = Mathf.Min(z, 0);

                float requiredZForX = (x / (tanHalfFov * aspect)) - correction;
                float requiredZForY = (y / tanHalfFov) - correction;

                requiredDistance = Mathf.Max(requiredDistance, requiredZForX, requiredZForY);
            }

            return requiredDistance * margin;
        }

        static float CalculatePixelScaleFactor(float fov, float screenHeight) => (2.0f * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad)) / screenHeight;

        public static Vector3 WorldToViewportPoint(Vector3 position) => camera.WorldToViewportPoint(position);

        public static Vector3 WorldToScreenPoint(Vector3 position) => camera.WorldToScreenPoint(position);

        private static float GetWorldSizeFromPixels(float pixelSize, Vector3 worldPosition)
        {
            float zDepth = Vector3.Dot(worldPosition - cameraPosition, cameraForward);

            return pixelSize * pixelScaleFactor * zDepth;
        }
    }

    public enum DrawType
    {
        Opaque,
        Transparent
    }

    public enum StencilMode
    {
        None,
        Stencil,
    }
}