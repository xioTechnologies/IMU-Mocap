using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public sealed class Line : Stretchable
    {
        [SerializeField] private Vector3 startPoint = Vector3.zero;

        [SerializeField] private Vector3 endPoint = Vector3.forward;

        protected override void UpdateTransform()
        {
            if (enabled == false) return;

            Vector3 direction = endPoint - startPoint;
            float length = direction.magnitude;

            if (length <= 0.00001f)
            {
                transform.localScale = Vector3.zero;
                return;
            }

            transform.localPosition = (startPoint + endPoint) / 2f;
            transform.rotation = Quaternion.LookRotation(direction.normalized);
            transform.localScale = new Vector3(length, length, length);
        }

        public void SetPoints(Vector3 start, Vector3 end)
        {
            if (startPoint == start && endPoint == end) return;

            startPoint = start;
            endPoint = end;

            SetDirty();
            UpdateTransform();
        }
    }
}