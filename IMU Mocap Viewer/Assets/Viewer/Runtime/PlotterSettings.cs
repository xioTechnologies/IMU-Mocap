using System;
using System.IO;
using UnityEngine;

namespace Viewer.Runtime
{
    public class PlotterSettings : ScriptableObject
    {
        public static float UIScale { get; private set; }

        public static Color LabelColor { get; private set; }

        public static float LabelSizeInPoints { get; private set; }

        public static float PrimitiveScale { get; private set; }

        public static float LineWidthInPixels { get; private set; }

        public static float CircleLineWidthInPixels { get; private set; }

        public static float DotSizeInPixels { get; private set; }

        public static float AxesLineWidthInPixels { get; private set; }

        public static float AngleLineWidthInPixels { get; private set; }

        public static void Update()
        {
            UIScale = PixelScaleUtility.DpiScaleFactor * instance.uiScale;
            LabelColor = instance.labelColor;
            LabelSizeInPoints = instance.labelSizeInPoints;

            PrimitiveScale = PixelScaleUtility.DpiScaleFactor * instance.primitiveScale;
            LineWidthInPixels = PrimitiveScale * instance.lineWidthInPixels;
            CircleLineWidthInPixels = LineWidthInPixels * instance.circleLineWidthScaleFactor;
            DotSizeInPixels = PrimitiveScale * instance.dotSizeInPixels;
            AxesLineWidthInPixels = PrimitiveScale * instance.axesLineWidthInPixels;
            AngleLineWidthInPixels = PrimitiveScale * instance.angleLineWidthInPixels;
        }

        private const string ResourcePath = "Assets/Viewer/Resources/Plotter Settings.asset";
        private const string ResourceName = "Plotter Settings";

        private static PlotterSettings instance;

        [Header("UI")] [SerializeField, Range(0f, 10f)]
        private float uiScale = 1f;

        [Header("Label")] [SerializeField] private Color labelColor = Utils.ColorFromHex("E4E4E4");
        [SerializeField, Range(1f, 200f)] private float labelSizeInPoints = 14f;

        [Header("Primitives")] [SerializeField, Range(0f, 10f)]
        private float primitiveScale = 1f;

        [Header("Line")] [SerializeField, Range(0f, 10f)]
        private float lineWidthInPixels = 3f;

        [Header("Circle")] [SerializeField, Range(0f, 10f)]
        private float circleLineWidthScaleFactor = 1f;

        [Header("Dot")] [SerializeField, Range(0f, 100f)]
        private float dotSizeInPixels = 10f;

        [Header("Axes")] [SerializeField, Range(0f, 10f)]
        private float axesLineWidthInPixels = 2f;

        [Header("Angle")] [SerializeField, Range(0f, 10f)]
        private float angleLineWidthInPixels = 1f;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnRuntimeLoad()
        {
            instance = Resources.Load<PlotterSettings>(ResourceName);
            Update();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
        private static void OnEditorLoad()
        {
            try
            {
                instance = EnsureAssetExists();
                Update();
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }

        private static PlotterSettings EnsureAssetExists()
        {
            var directory = Path.GetDirectoryName(ResourcePath);

            if (Directory.Exists(directory) == false) Directory.CreateDirectory(directory!);

            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<PlotterSettings>(ResourcePath);

            if (asset != null) return asset;

            asset = CreateInstance<PlotterSettings>();

            UnityEditor.AssetDatabase.CreateAsset(asset, ResourcePath);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();

            return asset;
        }
#endif
    }
}