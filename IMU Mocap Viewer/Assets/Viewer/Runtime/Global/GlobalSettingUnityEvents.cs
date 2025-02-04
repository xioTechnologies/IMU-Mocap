using System;
using UnityEngine;
using UnityEngine.Events;
using ActionQueue = Viewer.Runtime.Global.StaticActionQueue<Viewer.Runtime.Global.GlobalSettingUnityEvents, bool>;

namespace Viewer.Runtime.Global
{
    public sealed class GlobalSettingUnityEvents : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void RegisterQueueProcessing() => ActionQueue.RegisterOnIngestData((obj, active) => obj.Invoke(active));

        [Serializable]
        class UnityEventBool : UnityEvent<bool> { }

        [SerializeField] private GlobalSetting setting;

        [SerializeField] private UnityEventBool valueChanged;
        [SerializeField] private UnityEventBool onTrue;
        [SerializeField] private UnityEventBool onFalse;

        private void Awake()
        {
            setting.OnValueChanged += OnValueChanged;

            OnValueChanged(setting.Value);
        }

        private void OnDestroy() => setting.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(bool obj) => ActionQueue.Enqueue(this, obj);

        private void Invoke(bool obj)
        {
            valueChanged.Invoke(obj);

            if (obj) onTrue.Invoke(true);
            else onFalse.Invoke(false);
        }
    }
}