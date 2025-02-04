using System;
using System.Collections.Generic;

namespace Viewer.Runtime.Global
{
    static class StaticActionQueue<TObject, TValue>
    {
        static Queue<(TObject obj, TValue value)> data = new();

        public static void Enqueue(TObject obj, TValue value) => data.Enqueue((obj, value));

        private static void Process(Action<TObject, TValue> action)
        {
            while (data.Count > 0)
            {
                var (obj, value) = data.Dequeue();

                action(obj, value);
            }
        }

        public static void RegisterOnIngestData(Action<TObject, TValue> action) => Main.OnIngestData += () => Process(action);
    }
}