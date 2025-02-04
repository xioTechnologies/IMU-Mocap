using System.Collections.Generic;
using UnityEngine;

namespace Viewer.Runtime.Global
{
    static class KeyedSingleton<T> where T : ScriptableObject
    {
        private static readonly Dictionary<string, T> Instances = new();

        public static T ResolveInstance(string id, T instance = null)
        {
            if (Instances.TryGetValue(id, out var found)) return found;

            if (instance == null) return null;

            Instances[id] = instance;

            return instance;
        }
    }
}