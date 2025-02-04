using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(Toggle))]
    public sealed class ToggleHighlighter : MonoBehaviour
    {
        [Header("Color Settings")] [SerializeField]
        private Color normalColor = Color.white;

        [SerializeField] private Color highlightColor = Color.yellow;
        private Toggle toggle;
        private Selectable selectable;
        private ColorBlock colors;

        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            selectable = GetComponent<Selectable>();
            colors = selectable.colors;

            toggle.onValueChanged.AddListener(OnToggleValueChanged);

            OnToggleValueChanged(toggle.isOn);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            colors.normalColor = isOn ? highlightColor : normalColor;
            colors.highlightedColor = isOn ? highlightColor : normalColor;
            colors.selectedColor = isOn ? highlightColor : normalColor;

            selectable.colors = colors;
        }

        private void OnDestroy()
        {
            if (toggle == null) return;

            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    }
}