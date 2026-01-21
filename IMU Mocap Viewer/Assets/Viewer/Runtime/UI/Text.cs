using System;
using TMPro;
using UnityEngine;
using Viewer.Runtime.Json;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Text : MonoBehaviour
    {
        private static FixedString1k value;
        private static float endTime = 0;

        private readonly char[] buffer = new char[FixedString1k.MaxLength];
        private int bufferLength;
        private TMP_Text text;

        public static void Set(ref FixedString1k value, float seconds)
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

            SetText(ref value);

            text.enabled = true;
        }

        public void SetText(ref FixedString1k text)
        {
            if (bufferLength == text.Length
                && text.AsReadOnlySpan().SequenceEqual(buffer.AsSpan(0, bufferLength)))
            {
                return;
            }

            int truncated = Math.Min(text.Length, buffer.Length);

            text.AsReadOnlySpan().Slice(0, truncated).CopyTo(buffer);

            bufferLength = truncated;

            this.text.SetCharArray(buffer, 0, bufferLength);
        }
    }
}