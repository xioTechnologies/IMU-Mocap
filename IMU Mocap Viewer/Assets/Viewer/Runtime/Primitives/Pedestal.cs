using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public sealed class Pedestal : MonoBehaviour
    {
        [SerializeField] private Transform disc;
        [SerializeField] private Line stick;

        [SerializeField, Range(0f, 500f)] private float discSizeInPixels = 100f;
        [SerializeField, Range(0f, 500f)] private float lineWidthInPixels = 8f;

        private Vector3 head;

        private void LateUpdate()
        {
            var offset = head.y;

            transform.position = head._x0z();

            stick.LineWidthInPixels = lineWidthInPixels * PlotterSettings.UIScale;
            stick.SetPoints(Vector3.zero, Vector3.up * offset);

            disc.localScale = PixelScaleUtility.GetWorldScaleFromPixels(discSizeInPixels, disc.position) * PlotterSettings.UIScale;
        }

        public void Hide() => gameObject.SetActive(false);

        public void Set(Vector3 xyz)
        {
            head = xyz;
            gameObject.SetActive(true);
        }
    }
}