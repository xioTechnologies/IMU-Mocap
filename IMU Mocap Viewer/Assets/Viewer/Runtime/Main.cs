using System;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Viewer.Runtime
{
    static class Main
    {
        public static event Action OnIngestData;
        public static event Action OnProcessDataFrame;

        private static MainUpdater updater;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialize()
        {
            Application.targetFrameRate = -1; // unlimited
            QualitySettings.vSyncCount = 1; // use v sync to limit frame rate 
                            
            GameObject updaterObject = new GameObject("[Main Updater]");
            UnityEngine.Object.DontDestroyOnLoad(updaterObject);

            updater = updaterObject.AddComponent<MainUpdater>();
            updater.Initialize(Update);
        }

        private static void Update()
        {
            try
            {
                OnIngestData?.Invoke();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }

            try
            {
                OnProcessDataFrame?.Invoke();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }

    [DefaultExecutionOrder(int.MinValue)] // ensure the main updater runs before anything else 
    internal class MainUpdater : MonoBehaviour
    {
        private Action update;

        public void Initialize(Action update) => this.update = update;

        private void Update() => update?.Invoke();

        private void OnDestroy() => update = null;
    }
}