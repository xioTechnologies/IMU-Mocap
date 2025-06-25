using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Viewer.Runtime.UI
{
    public class FlexibleLayout : LayoutGroup
    {
        [Header("Layout")] [SerializeField] private float itemHeight = 40;
        [SerializeField] private float preferredColumnSize = 300;

        [Header("Spacing")] [SerializeField] private float columnSpacing;
        [SerializeField] private float rowSpacing;

        private RectTransform parentRect;

        private int columnCount;
        private int maxColumnRowCount;

        protected override void Start()
        {
            base.Start();

            Assert.IsNotNull(rectTransform.parent);
            parentRect = rectTransform.parent.GetComponent<RectTransform>();
            Assert.IsNotNull(parentRect);
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            float parentWidth = parentRect.rect.width - padding.horizontal;
            float preferredColumnSizeWithSpacing = preferredColumnSize + columnSpacing;

            columnCount = Math.Max(Mathf.FloorToInt(parentWidth / preferredColumnSizeWithSpacing), 1);

            SetLayoutInputForAxis(parentWidth, parentWidth, -1, 0);
        }

        public override void CalculateLayoutInputVertical()
        {
            float parentHeight = parentRect.rect.height - padding.vertical;

            float itemHeightWithSpacing = itemHeight + rowSpacing;

            int maxRowsWithoutExpanding = Mathf.FloorToInt(parentHeight / itemHeightWithSpacing);

            int itemCount = rectChildren.Count;

            if (itemCount < maxRowsWithoutExpanding * columnCount)
                maxColumnRowCount = maxRowsWithoutExpanding;
            else
                maxColumnRowCount = Mathf.CeilToInt((float)itemCount / columnCount);

            float totalHeight = itemHeightWithSpacing * maxColumnRowCount + padding.vertical;

            SetLayoutInputForAxis(totalHeight, totalHeight, -1, 1);
        }

        public override void SetLayoutHorizontal() { }

        public override void SetLayoutVertical()
        {
            float itemHeightWithSpacing = itemHeight + rowSpacing;
            float columnSizeWithSpacing = preferredColumnSize + columnSpacing;

            int row = 0;
            int column = 0;

            foreach (var child in rectChildren)
            {
                float x = column * columnSizeWithSpacing + padding.left;
                float y = row * itemHeightWithSpacing + padding.top;

                SetChildAlongAxis(child, 0, x, preferredColumnSize);
                SetChildAlongAxis(child, 1, y, itemHeight);

                if (++row < maxColumnRowCount) continue;

                row = 0;
                column++;
            }
        }
    }
}