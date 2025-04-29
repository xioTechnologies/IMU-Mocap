using UnityEngine;
using UnityEngine.Serialization;

namespace Viewer.Runtime.Primitives
{
    public class AngleStretchable : Stretchable
    {
        private const float AngleScale = 1f / 360f;

        [SerializeField, Range(-360, 360)] private float startAngle = 0;
        [SerializeField, Range(-360, 360)] private float endAngle = 360;

        public float StartAngle
        {
            get => startAngle;
            set
            {
                if (Mathf.Approximately(startAngle, value)) return;
                startAngle = value;
            }
        }

        public float EndAngle
        {
            get => endAngle;
            set
            {
                if (Mathf.Approximately(endAngle, value)) return;
                endAngle = value;
            }
        }

        protected override void UpdateProperties(Material materialInstance)
        {
            float start = Mathf.Min(startAngle, endAngle);
            float end = Mathf.Max(startAngle, endAngle);

            materialInstance.SetFloat(StretchableMaterial.StartAngleProperty, start * AngleScale);
            materialInstance.SetFloat(StretchableMaterial.EndAngleProperty, end * AngleScale);

            materialInstance.EnableAngles(true);
        }
    }
}