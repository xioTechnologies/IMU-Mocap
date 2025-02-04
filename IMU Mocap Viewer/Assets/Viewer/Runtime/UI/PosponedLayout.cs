using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Viewer.Runtime.UI
{
    public sealed class PosponedLayout : MonoBehaviour
    {
        [SerializeField] Transform target;

        [SerializeField] int delayFrames = 3;
        int countDown;

        void Start()
        {
            target.gameObject.SetActive(false);

            countDown = delayFrames;
        }

        private void OnEnable()
        {
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(target.GetComponent<RectTransform>());
        }

        private void Update()
        {
            if (--countDown != 0) return; // will fail after 2^31 frames

            target.gameObject.SetActive(true);

            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(target.GetComponent<RectTransform>());
        }
    }
}