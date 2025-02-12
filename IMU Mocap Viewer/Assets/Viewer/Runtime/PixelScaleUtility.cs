using System;
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
    }
}