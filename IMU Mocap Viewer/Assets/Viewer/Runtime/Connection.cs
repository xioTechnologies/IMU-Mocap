using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Viewer.Runtime
{
    public sealed class Connection : MonoBehaviour
    {
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
                ProcessPacket(receiveTask.Result);
            }
            else
            {
                Debug.LogError("Error receiving UDP data.");
            }

            StartReceivingData();

            return;

            void StartReceivingData()
            {
                receiveTask = listener.ReceiveAsync();
                isReceivingData = true;
            }

            void ProcessPacket(UdpReceiveResult result)
            {
                if (Paused) return;

                PlotObject[] objects = JsonConvert.DeserializeObject<PlotObject[]>(Encoding.ASCII.GetString(result.Buffer));

                plotter.Clear();

                foreach (PlotObject obj in objects)
                {
                    switch (obj.Type)
                    {
                        case "line":
                            plotter.Line(obj.Start._xzy(), obj.End._xzy());
                            break;

                        case "circle":
                            plotter.Circle(obj.Xyz._xzy(), obj.Axis._xzy(), obj.Radius);
                            break;

                        case "dot":
                            plotter.Dot(obj.Xyz._xzy(), obj.Size);
                            break;

                        case "axes":
                            plotter.Axes(obj.Xyz._xzy(), Swizzle(obj.Quaternion), obj.Scale);
                            break;

                        case "label":
                            plotter.Label(obj.Xyz._xzy(), obj.Text);
                            break;

                        case "angles":
                            AngleAndLimit? rotX = obj.RotX.HasValue ? new AngleAndLimit() { Angle = obj.RotX.Value, Limit = obj.LimitX } : null;
                            AngleAndLimit? rotY = obj.RotY.HasValue ? new AngleAndLimit() { Angle = obj.RotY.Value, Limit = obj.LimitY } : null;
                            AngleAndLimit? rotZ = obj.RotZ.HasValue ? new AngleAndLimit() { Angle = obj.RotZ.Value, Limit = obj.LimitZ } : null;

                            plotter.Angle(obj.Xyz._xzy(), Swizzle(obj.Quaternion), obj.Scale, rotX, rotY, rotZ);
                            break;

                        default:
                            Debug.LogError("Unknown primitive type: " + obj.Type);
                            break;
                    }
                }
            }
        }

        private Quaternion Swizzle(Quaternion wxyz) => new(-wxyz.x, -wxyz.z, -wxyz.y, wxyz.w);

        private struct PlotObject
        {
            public string Type;
            public Vector3 Start;
            public Vector3 End;
            public Vector3 Xyz;
            public Vector3 Axis;
            public float Radius;
            public float Size;
            public Quaternion Quaternion;
            public float Scale;

            [JsonProperty(PropertyName = "rot_x")] public float? RotX;
            [JsonProperty(PropertyName = "rot_y")] public float? RotY;
            [JsonProperty(PropertyName = "rot_z")] public float? RotZ;

            [JsonProperty(PropertyName = "limit_x")]
            public float[] LimitX;

            [JsonProperty(PropertyName = "limit_y")]
            public float[] LimitY;

            [JsonProperty(PropertyName = "limit_z")]
            public float[] LimitZ;

            public string Text;
        }
    }
}