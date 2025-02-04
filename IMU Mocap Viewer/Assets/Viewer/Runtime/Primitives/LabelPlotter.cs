using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Viewer.Runtime.Primitives
{
    public sealed class LabelPlotter : MonoBehaviour
    {
        [SerializeField] private Label prefab;

        private readonly List<Label> objects = new();
        private int currentIndex;

        private ObjectPool<Label> objectPool;

        private void Awake()
        {
            objectPool = new ObjectPool<Label>(
                () => Instantiate(prefab, transform),
                obj => obj.gameObject.SetActive(true),
                obj => obj.gameObject.SetActive(false),
                obj => Destroy(obj.gameObject),
                false,
                256,
                1024 * 8
            );

            currentIndex = 0;
        }

        private void Update()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                objects[i].AdjustForCamera();
            }

            if (currentIndex == objects.Count) return;

            for (int i = currentIndex; i < objects.Count; i++)
            {
                objectPool.Release(objects[i]);
            }

            objects.RemoveRange(currentIndex, objects.Count - currentIndex);
        }

        public void Clear() => currentIndex = 0;

        public void Plot(Vector3 point, float scale, string text)
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
            }

            obj.transform.position = point;
            obj.Text = text;
            obj.Scale = scale;

            currentIndex++;
        }
    }
}