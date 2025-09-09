using TMPro;
using UnityEngine;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Text : MonoBehaviour
    {
        private static string value;
        private static float endTime = 0;
        private TMP_Text text;

        public static void Set(string value, float seconds)
        {
            Text.value = value;

            if (seconds > 0) endTime = Time.unscaledTime + seconds;
            else endTime = float.MaxValue;
        }

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            if (endTime < Time.unscaledTime)
            {
                text.enabled = false;
                return;
            }

            text.text = value;
            text.enabled = true;
        }
    }
}