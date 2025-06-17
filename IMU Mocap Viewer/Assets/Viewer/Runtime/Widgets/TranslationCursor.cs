using UnityEngine;

namespace Viewer.Runtime.Widgets
{
    public sealed class TranslationCursor : MonoBehaviour
    {
        [SerializeField, Range(0, 500)] private float objectSize = 10f;
        
        private bool shouldHide = false;
        
        void Update()
        {
            if (shouldHide)
            {
                gameObject.SetActive(false);
                
                return;
            }
            
            transform.localScale = PixelScaleUtility.GetWorldScaleFromPixels(objectSize, transform.position) * PlotterSettings.UIScale;
        }

        public void Hide() => shouldHide = true;

        public void ShowAt(Vector3 getPoint)
        {
            transform.position = getPoint;
            
            shouldHide = false;
            
            gameObject.SetActive(true);
        }
    }
}