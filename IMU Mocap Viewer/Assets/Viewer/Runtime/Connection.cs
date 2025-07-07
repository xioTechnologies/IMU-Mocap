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
                            plotter.Line(SwizzleFromArray3(obj.Start), SwizzleFromArray3(obj.End));
                            break;

                        case "circle":
                            plotter.Circle(SwizzleFromArray3(obj.Xyz), SwizzleFromArray3(obj.Axis), obj.Radius);
                            break;

                        case "dot":
                            plotter.Dot(SwizzleFromArray3(obj.Xyz), obj.Size);
                            break;

                        case "axes":
                            plotter.Axes(SwizzleFromArray3(obj.Xyz), SwizzleFromArray4(obj.Quaternion), obj.Scale);
                            break;

                        case "label":
                            plotter.Label(SwizzleFromArray3(obj.Xyz), obj.Text);
                            break;

                        case "euler":
                            plotter.Euler(
                                SwizzleFromArray3(obj.Xyz),
                                SwizzleFromArray4(obj.Quaternion),
                                AngleAndLimit(obj.RotX, obj.LimitX),
                                AngleAndLimit(obj.RotY, obj.LimitY),
                                AngleAndLimit(obj.RotZ, obj.LimitZ),
                                obj.Scale,
                                obj.Mirror
                            );
                            break;

                        case "angle":
                            plotter.Angle(SwizzleFromArray3(obj.Xyz), SwizzleFromArray4(obj.Quaternion), obj.Angle, obj.Scale);
                            break;

                        case "pedestal":
                            plotter.Pedestal(SwizzleFromArray3(obj.Xyz));
                            break;

                        default:
                            Debug.LogError("Unknown primitive type: " + obj.Type);
                            break;
                    }
                }
            }
        }

        private static AngleAndLimit? AngleAndLimit(float? angle, float[] limit) => angle.HasValue ? new AngleAndLimit(angle.Value, limit) : null;

        private static Vector3 SwizzleFromArray3(float[] array)
        {
            if (array == null) return Vector3.zero;
            if (array.Length != 3) return Vector3.zero;

            return new Vector3(array[0], array[1], array[2])._xzy();
        }

        private static Quaternion SwizzleFromArray4(float[] array)
        {
            if (array == null) return Quaternion.identity;
            if (array.Length != 4) return Quaternion.identity;

            return Swizzle(new Quaternion(array[1], array[2], array[3], array[0]));
        }

        private static Quaternion Swizzle(Quaternion wxyz) => new Quaternion(-wxyz.x, -wxyz.z, -wxyz.y, wxyz.w).normalized;

        private struct PlotObject
        {
            public string Type;
            public float[] Start;
            public float[] End;
            public float[] Xyz;
            public float[] Axis;
            public float Radius;
            public float Size;
            public float[] Quaternion;
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

            public bool Mirror;

            public string Text;

            public float Angle;
        }
    }
}