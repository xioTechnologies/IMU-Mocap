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
        private ProfilerMarker jsonParse = new(nameof(Connection));

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

            if (receiveTask.IsCompletedSuccessfully)
            {
                using (jsonParse.Auto())
                {
                    if (Paused == false) Parsing.ProcessPacket(plotter, receiveTask.Result);
                }
            }
            else
            {
                Debug.LogError("Error receiving UDP data.");
            }

            StartReceivingData();
        }

        void StartReceivingData()
        {
            receiveTask = listener.ReceiveAsync();
            isReceivingData = true;
        }
    }
}