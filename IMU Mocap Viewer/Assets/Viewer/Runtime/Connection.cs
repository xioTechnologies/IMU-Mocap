using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Unity.Profiling;
using UnityEngine;
using Viewer.Runtime.Json;

namespace Viewer.Runtime
{
    public sealed class Connection : MonoBehaviour
    {
        private static readonly ProfilerMarker JsonParseProfileMarker = new(nameof(Connection));

        [SerializeField] private Plotter plotter;

        [SerializeField] private int listenPort = 6000;
        private IPEndPoint endPoint;
        private bool isReceivingData;

        private UdpClient listener;

        private Task<UdpReceiveResult> receiveTask;

        public bool Paused { get; set; }

        private void Start()
        {
            listener = new UdpClient(listenPort);

            Main.OnIngestData += UpdatePlot;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();

            OnApplicationQuit();
        }

        private void OnApplicationQuit()
        {
            Main.OnIngestData -= UpdatePlot;

            if (listener == null) return;

            listener.Close();
            listener = null;
        }

        private void UpdatePlot()
        {
            if (isReceivingData == false) StartReceivingData();

            if (receiveTask.IsCompleted == false) return;

            isReceivingData = false;

            try
            {
                if (receiveTask.IsCompletedSuccessfully == false)
                {
                    Debug.LogError("Error receiving UDP data.");

                    return;
                }

                using (JsonParseProfileMarker.Auto())
                {
                    if (Paused) return;

                    JsonResult result = Parsing.ProcessPacket(plotter, receiveTask.Result);

                    if (result != JsonResult.Ok) Debug.LogError(JsonZero.ResultToString(result));
                }
            }
            finally
            {
                StartReceivingData();
            }
        }

        void StartReceivingData()
        {
            receiveTask = listener.ReceiveAsync();
            isReceivingData = true;
        }
    }
}