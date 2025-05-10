using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

namespace Viewer.Runtime.Primitives
{
    public sealed class LabelPlotter : MonoBehaviour
    {
        private RectTransform privateContainer;
        [SerializeField] private RectTransform container;
        [SerializeField] private Label prefab;

        private readonly DepthComparer comparer = new();
        private readonly List<Label> objects = new();
        private readonly List<Label> objectsSorted = new();
        private int currentIndex;

        private ObjectPool<Label> objectPool;

        private void Awake()
        {
            var containerObject = new GameObject($"{gameObject.name} Labels", typeof(RectTransform));

            privateContainer = containerObject.GetComponent<RectTransform>();

            privateContainer.SetParent(container, false);
            privateContainer.anchorMin = Vector2.zero;
            privateContainer.anchorMax = Vector2.one;
            privateContainer.offsetMin = Vector2.zero;
            privateContainer.offsetMax = Vector2.zero;

            objectPool = new ObjectPool<Label>(
                () => Instantiate(prefab, privateContainer),
                obj => obj.gameObject.SetActive(true),
                obj => obj.gameObject.SetActive(false),
                obj => Destroy(obj.gameObject),
                false,
                256,
                1024 * 8
            );

            currentIndex = 0;
        }

        private void OnEnable()
        {
            if (privateContainer == null) return;

            privateContainer.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (privateContainer == null) return;

            privateContainer.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            Destroy(privateContainer.gameObject);

            privateContainer = null;
        }

        class DepthComparer : IComparer<Label>
        {
            public int Compare(Label a, Label b)
            {
                Assert.IsNotNull(a);
                Assert.IsNotNull(b);

                return b.Depth.CompareTo(a.Depth); // back to front
            }
        }

        private void Update()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                objects[i].AdjustForCamera();
            }

            if (currentIndex != objects.Count)
            {
                for (int i = currentIndex; i < objects.Count; i++)
                {
                    objectPool.Release(objects[i]);
                }

                objects.RemoveRange(currentIndex, objects.Count - currentIndex);
                
                objectsSorted.Clear();
                for (int i = 0; i < currentIndex; i++) objectsSorted.Add(objects[i]);
            }

            objectsSorted.Sort(0, currentIndex, comparer);

            for (int i = 0; i < currentIndex; i++)
            {
                var label = objectsSorted[i];

                if (label.LastSiblingIndex == i) continue;

                label.transform.SetSiblingIndex(i);

                label.LastSiblingIndex = i;
            }
        }

        public void Clear() => currentIndex = 0;

        public void Plot(Vector3 xyz, string text, Color color, float scale)
        {
            Label obj;

            if (currentIndex < objects.Count)
            {
                obj = objects[currentIndex];
            }
            else
            {
                obj = objectPool.Get();

                objects.Add(obj);
                objectsSorted.Add(obj);
            }

            obj.Position = xyz;
            obj.Text = text;
            obj.Scale = scale;
            obj.Color = color;

            currentIndex++;
        }

        public void Plot(Vector3 xyz, Color color, float scale, string text, Vector3 marginDirection, float margin)
        {
            Label obj;

            if (currentIndex < objects.Count)
            {
                obj = objects[currentIndex];
            }
            else
            {
                obj = objectPool.Get();

                objects.Add(obj);
                objectsSorted.Add(obj);
            }

            obj.Position = xyz;
            obj.Text = text;
            obj.Scale = scale;
            obj.Color = color;
            obj.MarginDirection = marginDirection;
            obj.Margin = margin;

            currentIndex++;
        }
    }
}