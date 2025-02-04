using UnityEngine;

namespace Viewer.Runtime.Widgets
{
    public sealed class TranslationCursor : MonoBehaviour
    {
        [SerializeField, Range(0, 500)] private float objectSize = 10f;

        private void Update()
        {
            transform.localScale = PixelScaleUtility.GetWorldScaleFromPixels(objectSize, transform.position) * PixelScaleUtility.DpiScaleFactor;
        }

        public void Hide() => gameObject.SetActive(false);

        public void ShowAt(Vector3 getPoint)
        {
            transform.position = getPoint;
            gameObject.SetActive(true);
        }
    }
}