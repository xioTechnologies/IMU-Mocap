using UnityEngine;
using Viewer.Runtime.Primitives;

namespace Viewer.Runtime.Widgets
{
    public sealed class HeightStick : MonoBehaviour
    {
        [SerializeField] private Transform disc;
        [SerializeField] private Line stick;
        [SerializeField] private Stretchable handle;

        [SerializeField, Range(0f, 500f)] private float discSizeInPixels = 0.5f;
        [SerializeField, Range(0f, 500f)] private float lineWidthInPixels = 2f;
        [SerializeField, Range(0f, 500f)] private float knobSizeInPixels = 2f;

        private Vector3 head;

        private void Update()
        {
            var offset = head.y;

            transform.position = head._x0z();

            stick.LineWidthInPixels = lineWidthInPixels * PixelScaleUtility.DpiScaleFactor;
            stick.SetPoints(Vector3.zero, Vector3.up * offset);

            handle.transform.position = head;
            handle.LineWidthInPixels = knobSizeInPixels;

            disc.localScale = PixelScaleUtility.GetWorldScaleFromPixels(discSizeInPixels, disc.position) * PixelScaleUtility.DpiScaleFactor;
        }

        public void Hide() => gameObject.SetActive(false);

        public void ShowAt(Vector3 getPoint)
        {
            head = getPoint;
            gameObject.SetActive(true);
        }
    }
}