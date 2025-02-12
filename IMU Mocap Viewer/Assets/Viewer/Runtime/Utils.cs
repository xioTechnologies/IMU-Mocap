using UnityEngine;

namespace Viewer.Runtime
{
    static class Utils
    {
        public static float ClampAngle(float angle)
        {
            switch (angle)
            {
                case < 0f:
                    angle = 360f - -angle % 360f;
                    break;
                case > 360f:
                    angle %= 360f;
                    break;
            }

            return angle;
        }

        public static bool ConsumeFlag(ref bool flag)
        {
            if (flag == false) return false;

            flag = false;

            return true;
        }

        public static Bounds CircleBounds(Vector3 center, Vector3 axis, float radius)
        {
            axis.Normalize();

            bool axisCloseToVertical = Vector3.Dot(axis, Vector3.up) < 0.7071f; // if angle to vertical < 45 degrees

            Vector3 horizontalSpoke = Vector3.Cross(axis, axisCloseToVertical ? Vector3.forward : Vector3.up).normalized * radius;

            Vector3 highestSpoke = Vector3.Cross(horizontalSpoke, axis).normalized * radius;

            Vector3[] points =
            {
                center + horizontalSpoke + highestSpoke,
                center + horizontalSpoke - highestSpoke,
                center - horizontalSpoke + highestSpoke,
                center - horizontalSpoke - highestSpoke
            };

            // Compute AABB bounds from these points
            Vector3 min = points[0];
            Vector3 max = points[0];

            foreach (var point in points)
            {
                min = Vector3.Min(min, point);
                max = Vector3.Max(max, point);
            }

            return new Bounds((min + max) * 0.5f, max - min);
        }

        public static void Encapsulate(ref this Bounds? bounds, Vector3 xyz)
        {
            if (bounds.HasValue)
            {
                var b = bounds.Value;
                b.Encapsulate(xyz);
                bounds = b;
            }
            else bounds = new Bounds(xyz, Vector3.zero);
        }

        public static void Encapsulate(ref this Bounds? bounds, Bounds aabb)
        {
            if (bounds.HasValue)
            {
                var b = bounds.Value;
                b.Encapsulate(aabb);
                bounds = b;
            }
            else bounds = aabb;
        }
    }
}