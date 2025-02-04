using System;
using UnityEngine;

namespace Viewer.Runtime.Global
{
    [CreateAssetMenu(menuName = "IMU Viewer/Global Setting", fileName = "Global Setting", order = -1000)]
    public sealed class GlobalSetting : ScriptableObject
    {
        [SerializeField] private string id = Guid.NewGuid().ToString();

        private GlobalSetting runtime;
        private GlobalSetting Runtime => runtime ??= KeyedSingleton<GlobalSetting>.ResolveInstance(id, this);

        private void OnEnable()
        {
            if (Runtime == this) Value = value;
        }

        [SerializeField] private bool value;

        private bool? runtimeValue;

        private Action<bool> onValueChanged;

        public bool Value
        {
            get => Runtime.runtimeValue ?? Runtime.value;
            set
            {
                Runtime.runtimeValue = value;
                Runtime.onValueChanged?.Invoke(value);
            }
        }

        public event Action<bool> OnValueChanged
        {
            add => Runtime.onValueChanged += value;
            remove => Runtime.onValueChanged -= value;
        }
    }
}