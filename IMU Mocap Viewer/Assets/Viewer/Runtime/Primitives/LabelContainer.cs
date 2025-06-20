using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Viewer.Runtime.Primitives
{
    [RequireComponent(typeof(RectTransform))]
    public class LabelContainer : MonoBehaviour
    {
        private static readonly DepthComparer Comparer = new();

        private readonly List<LabelGroup> groups = new();
        private readonly List<Label> sorted = new();
        private int count;

        [InfoBox("Visible children in the hierarchy has performance implications while in the editor")] [SerializeField]
        private bool visibleChildren = false;

        private RectTransform PrivateContainer { get; set; }

        public ILabelGroup CreateGroup(Label prefab)
        {
            var set = new LabelGroup(this, prefab);

            groups.Add(set);

            return set;
        }

        public void DestroyGroup(ILabelGroup set)
        {
            if (set is not LabelGroup group) return;

            if (groups.Remove(group) == false) return;

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

            ConfigureHierarchyFlags();
        }

        private void OnDestroy()
        {
            foreach (var group in groups) group.Destroy();

            groups.Clear();
        }

        private void AddToSorted(Label label)
        {
            sorted.Add(label);
        }

        private void LateUpdate()
        {
#if UNITY_EDITOR
            ConfigureHierarchyFlags();
#endif

            bool recache = false;

            count = 0;

            foreach (var group in groups)
            {
                recache |= group.Update();
                count += group.VisibleCount;
            }

            recache |= sorted.Count != count;

            if (recache == true)
            {
                sorted.Clear();

                if (sorted.Capacity < count) sorted.Capacity = count;

                foreach (var group in groups) group.AppendLabels(sorted);
            }

            Assert.AreEqual(count, sorted.Count);

            sorted.Sort(0, count, Comparer);

            for (int i = 0; i < count; i++)
            {
                var label = sorted[i];

                if (label.LastSiblingIndex == i) continue;

                label.transform.SetSiblingIndex(i);

                label.LastSiblingIndex = i;
            }
        }

        private void ConfigureHierarchyFlags()
        {
            var flags = visibleChildren ? HideFlags.None : HideFlags.HideInHierarchy;
            if (PrivateContainer.gameObject.hideFlags != flags) PrivateContainer.gameObject.hideFlags = flags;
        }

        private class DepthComparer : IComparer<Label>
        {
            public int Compare(Label a, Label b)
            {
                Assert.IsNotNull(a);
                Assert.IsNotNull(b);

                return b.Depth.CompareTo(a.Depth); // back to front
            }
        }

        private class LabelGroup : ILabelGroup
        {
            private readonly LabelContainer container;
            private readonly ObjectPool<Label> labelPool;
            private readonly List<Label> labels = new();
            private int count;

            public int VisibleCount => Visible ? count : 0;

            public bool Visible { get; set; } = true;

            public LabelGroup(LabelContainer container, Label prefab)
            {
                this.container = container;

                labelPool = new ObjectPool<Label>(
                    () => Instantiate(prefab, container.PrivateContainer),
                    obj => obj.gameObject.SetActive(true),
                    obj => obj.gameObject.SetActive(false),
                    obj => Object.Destroy(obj.gameObject),
                    false,
                    256,
                    1024 * 8
                );

                count = 0;
            }

            void ILabelGroup.Clear() => count = 0;

            Label ILabelGroup.Get()
            {
                Label obj;

                if (count < labels.Count)
                {
                    obj = labels[count];
                }
                else
                {
                    obj = labelPool.Get();

                    labels.Add(obj);

                    container.AddToSorted(obj);
                }

                count++;

                return obj;
            }

            public bool Update()
            {
                for (int i = 0; i < count; i++)
                {
                    if (Visible) labels[i].AdjustForCamera();
                    else labels[i].Hide();
                }

                if (count == labels.Count) return false;

                for (int i = count; i < labels.Count; i++)
                {
                    labelPool.Release(labels[i]);
                }

                labels.RemoveRange(count, labels.Count - count);

                return true;
            }

            public void Destroy()
            {
                foreach (var obj in labels) labelPool.Release(obj);

                labels.Clear();
                labelPool.Clear();
            }

            public void AppendLabels(List<Label> list)
            {
                for (int i = 0, e = VisibleCount; i < e; i++) list.Add(labels[i]);
            }
        }
    }
}