using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;


namespace Viewer.Runtime.Primitives
{
    [RequireComponent(typeof(RectTransform))]
    public class LabelContainer : MonoBehaviour
    {
        class DepthComparer : IComparer<Label>
        {
            public int Compare(Label a, Label b)
            {
                Assert.IsNotNull(a);
                Assert.IsNotNull(b);

                return b.Depth.CompareTo(a.Depth); // back to front
            }
        }

        private static readonly DepthComparer Comparer = new();

        private readonly List<LabelGroup> sets = new();
        private readonly List<Label> objectsSorted = new();
        private int currentCount;

        [SerializeField] private bool visibleChildren = false;

        private RectTransform PrivateContainer { get; set; }

        public ILabelGroup CreateGroup(Label prefab)
        {
            var set = new LabelGroup(this, prefab);

            sets.Add(set);

            return set;
        }

        public void Destroy(ILabelGroup set)
        {
            if (set is not LabelGroup group) return;

            if (sets.Remove(group) == false) return;

            group.Destroy();
        }

        private void Awake()
        {
            var containerObject = new GameObject($"Labels", typeof(RectTransform));

            PrivateContainer = containerObject.GetComponent<RectTransform>();

            PrivateContainer.SetParent(transform, false);
            PrivateContainer.anchorMin = Vector2.zero;
            PrivateContainer.anchorMax = Vector2.one;
            PrivateContainer.offsetMin = Vector2.zero;
            PrivateContainer.offsetMax = Vector2.zero;
        }

        private void AddToSorted(Label label)
        {
            objectsSorted.Add(label);
        }

        private void Update()
        {
#if UNITY_EDITOR
            var flags = visibleChildren ? HideFlags.None : HideFlags.HideInHierarchy;
            if (PrivateContainer.gameObject.hideFlags != flags) PrivateContainer.gameObject.hideFlags = flags;
#endif

            bool recache = false;

            currentCount = 0;

            foreach (var set in sets)
            {
                recache |= set.Update();
                currentCount += set.VisibleCount;
            }

            if (recache == true)
            {
                objectsSorted.Clear();

                if (objectsSorted.Capacity < currentCount) objectsSorted.Capacity = currentCount;

                foreach (var set in sets) set.AddToSorted(objectsSorted);
            }

            objectsSorted.Sort(0, currentCount, Comparer);

            for (int i = 0; i < currentCount; i++)
            {
                var label = objectsSorted[i];

                if (label.LastSiblingIndex == i) continue;

                label.transform.SetSiblingIndex(i);

                label.LastSiblingIndex = i;
            }
        }

        private class LabelGroup : ILabelGroup
        {
            private readonly LabelContainer container;
            private readonly ObjectPool<Label> objectPool;
            private readonly List<Label> objects = new();
            private int currentIndex;

            public int VisibleCount => Visible ? currentIndex : 0;

            public LabelGroup(LabelContainer container, Label prefab)
            {
                this.container = container;

                objectPool = new ObjectPool<Label>(
                    () => Object.Instantiate(prefab, container.PrivateContainer),
                    obj => obj.gameObject.SetActive(true),
                    obj => obj.gameObject.SetActive(false),
                    obj => Object.Destroy(obj.gameObject),
                    false,
                    256,
                    1024 * 8
                );

                currentIndex = 0;
            }

            public bool Visible { get; set; } = true;

            public void Clear()
            {
                currentIndex = 0;
            }

            public Label Get()
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

                    container.AddToSorted(obj);
                }

                currentIndex++;

                return obj;
            }

            internal bool Update()
            {
                int count = currentIndex;

                for (int i = 0; i < count; i++)
                {
                    if (Visible) objects[i].AdjustForCamera();
                    else objects[i].Hide();
                }

                if (count == objects.Count) return false;

                for (int i = count; i < objects.Count; i++)
                {
                    objectPool.Release(objects[i]);
                }

                objects.RemoveRange(count, objects.Count - count);

                return true;
            }

            internal void Destroy()
            {
                foreach (var obj in objects) objectPool.Release(obj);

                objects.Clear();
                objectPool.Clear();
            }

            internal void AddToSorted(List<Label> labels)
            {
                for (int i = 0, e = VisibleCount; i < e; i++) labels.Add(objects[i]);
            }
        }
    }
}