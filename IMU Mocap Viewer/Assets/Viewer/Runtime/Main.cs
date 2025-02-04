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

        private static bool FindPlayerLoopSystemIndex(PlayerLoopSystem playerLoop, Type systemType, out int index)
        {
            index = -1;

            if (playerLoop.subSystemList == null) return false;

            for (int i = 0; i < playerLoop.subSystemList.Length; i++)
            {
                if (playerLoop.subSystemList[i].type != systemType) continue;

                index = i;

                return true;
            }

            return false;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialize()
        {
            PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();

            if (FindPlayerLoopSystemIndex(playerLoop, typeof(PreUpdate), out int index))
            {
                InsertUpdateFunction(ref playerLoop.subSystemList[index], OnProcessDataFrameHandler);
            }

            if (FindPlayerLoopSystemIndex(playerLoop, typeof(EarlyUpdate), out index))
            {
                InsertUpdateFunction(ref playerLoop.subSystemList[index], OnIngestDataHandler);
            }

            PlayerLoop.SetPlayerLoop(playerLoop);
        }

        private static void InsertUpdateFunction(ref PlayerLoopSystem playerLoopSystem, PlayerLoopSystem.UpdateFunction updateFunction)
        {
            PlayerLoopSystem[] subSystems = playerLoopSystem.subSystemList ?? new PlayerLoopSystem[0];

            var newSubSystems = new PlayerLoopSystem[subSystems.Length + 1];

            Array.Copy(subSystems, newSubSystems, subSystems.Length);

            newSubSystems[subSystems.Length] = new PlayerLoopSystem
            {
                type = typeof(Main),
                updateDelegate = updateFunction
            };

            playerLoopSystem.subSystemList = newSubSystems;
        }

        private static void OnIngestDataHandler()
        {
            try
            {
                OnIngestData?.Invoke();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        private static void OnProcessDataFrameHandler()
        {
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
}