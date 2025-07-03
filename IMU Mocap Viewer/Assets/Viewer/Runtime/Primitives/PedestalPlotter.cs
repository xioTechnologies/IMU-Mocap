using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Viewer.Runtime.Primitives
{
    public sealed class PedestalPlotter : MonoBehaviour
    {
        [SerializeField] private Pedestal prefab;

        private readonly List<Pedestal> objects = new();
        private int currentIndex;

        private ObjectPool<Pedestal> objectPool;

        private void Awake()
        {
            objectPool = new ObjectPool<Pedestal>(
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
            if (currentIndex == objects.Count) return;

            for (int i = currentIndex; i < objects.Count; i++)
            {
                objectPool.Release(objects[i]);
            }

            objects.RemoveRange(currentIndex, objects.Count - currentIndex);
        }

        public void Clear() => currentIndex = 0;

        public void Plot(Vector3 xyz)
        {
            Pedestal obj;

            if (currentIndex < objects.Count)
            {
                obj = objects[currentIndex];
            }
            else
            {
                obj = objectPool.Get();

                objects.Add(obj);
            }

            obj.Set(xyz);

            currentIndex++;
        }
    }
}