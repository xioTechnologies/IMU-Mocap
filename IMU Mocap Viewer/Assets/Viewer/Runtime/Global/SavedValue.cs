using System;
using UnityEngine;

namespace Viewer.Runtime.Global
{
    [CreateAssetMenu(menuName = "IMU Viewer/Saved Value", fileName = "Saved Value", order = -1000)]
    public class SavedValue : ScriptableObject
    {
        [SerializeField] private string id = Guid.NewGuid().ToString();

        public bool HasValue() => PlayerPrefs.HasKey(id);

        public string GetString() => PlayerPrefs.GetString(id);

        public void SetString(string value) => PlayerPrefs.SetString(id, value);

        public TValue GetValue<TValue>(TValue defaultValue) where TValue : struct
        {
            try
            {
                return JsonUtility.FromJson<TValue>(PlayerPrefs.GetString(id, JsonUtility.ToJson(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public void SetValue<TValue>(TValue value) where TValue : struct => PlayerPrefs.SetString(id, JsonUtility.ToJson(value));
    }
}