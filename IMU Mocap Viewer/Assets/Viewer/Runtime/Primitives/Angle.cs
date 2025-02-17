using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public class Angle : Stretchable 
    {
        [SerializeField, Range(0, 360)] private float angle = 360;

        protected override Color GetNearColor() 
        {
            var color = base.GetNearColor();

            color.a = angle / 360f;
            
            return color;
        }
    }
}