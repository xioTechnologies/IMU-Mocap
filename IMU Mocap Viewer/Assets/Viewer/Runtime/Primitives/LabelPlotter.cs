using System;
using UnityEngine;
using Viewer.Runtime.Json;

namespace Viewer.Runtime.Primitives
{
    public sealed class LabelPlotter : MonoBehaviour
    {
        private ILabelGroup group;
        [SerializeField] private LabelContainer container;
        [SerializeField] private Label prefab;

        private void Awake() => group = container.CreateGroup(prefab);

        private void OnEnable()
        {
            if (group == null) return;

            group.Visible = true;
        }

        private void OnDisable()
        {
            if (group == null) return;

            group.Visible = false;
        }

        private void OnDestroy()
        {
            container.DestroyGroup(group);

            group = null;
        }

        public void Clear() => group.Clear();

        public void Plot(Vector3 xyz, ReadOnlySpan<char> textSpan, Color color)
        {
            Label obj = group.Get();

            obj.Position = xyz;
            obj.SetText(textSpan);
            obj.Color = color;
        }

        public void Plot(Vector3 xyz, ReadOnlySpan<char> textSpan, Color color, Vector3 marginDirection, float margin)
        {
            Label obj = group.Get();

            obj.Position = xyz;
            obj.SetText(textSpan);
            obj.Color = color;
            obj.MarginDirection = marginDirection;
            obj.Margin = margin;
        }
    }
}