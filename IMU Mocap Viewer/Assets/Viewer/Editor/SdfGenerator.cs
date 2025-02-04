using System.IO;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEditor;
using UnityEngine;

namespace Viewer.Editor
{
    public class SdfGenerator
    {
        [MenuItem("Viewer/Generate Icon SDF (s)")]
        public static void GenerateAll()
        {
            const int resolution = 128;
            GenerateSDF("Axes", resolution);
            GenerateSDF("Dot", resolution);
            GenerateSDF("Grid", resolution);
            GenerateSDF("Label", resolution);
            GenerateSDF("Line", resolution);
            GenerateSDF("Tracking", resolution);
            GenerateSDF("Not allowed", resolution);
        }

        private static void GenerateSDF(string icon, int outputResolution)
        {
            string inputPath = $"Assets/Viewer/Resources/UI/Icons/{icon}.png";
            string outputPath = $"Assets/Viewer/Resources/UI/Icons/{icon}.exr";
            
            Texture2D inputTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(inputPath);
            if (inputTexture == null)
            {
                Debug.LogError("Input texture not found at " + inputPath);
                return;
            }
            
            string assetPath = AssetDatabase.GetAssetPath(inputTexture);
            var importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (importer != null && !importer.isReadable)
            {
                importer.isReadable = true;
                importer.SaveAndReimport();
            }

            int inputWidth = inputTexture.width;
            int inputHeight = inputTexture.height;
            
            Color[] inputPixels = inputTexture.GetPixels();
            NativeArray<float> binaryImage = new NativeArray<float>(inputWidth * inputHeight, Allocator.TempJob);
            NativeArray<float> distanceField = new NativeArray<float>(outputResolution * outputResolution, Allocator.TempJob);

            for (int i = 0; i < inputPixels.Length; i++)
            {
                binaryImage[i] = inputPixels[i].grayscale > 0.5f ? 0 : float.MaxValue;
            }

            float maxDistance = Mathf.Max(inputWidth, inputHeight) / 2f;

            DistanceFieldJob distanceFieldJob = new DistanceFieldJob
            {
                BinaryImage = binaryImage,
                DistanceField = distanceField,
                InputWidth = inputWidth,
                InputHeight = inputHeight,
                OutputWidth = outputResolution,
                OutputHeight = outputResolution,
                MaxDistance = maxDistance
            };

            JobHandle handle = distanceFieldJob.Schedule(outputResolution * outputResolution, 64);
            handle.Complete();
            
            Texture2D outputTexture = new Texture2D(outputResolution, outputResolution, TextureFormat.RGFloat, false);
            
            for (int i = 0; i < distanceField.Length; i++)
            {
                int x = i % outputResolution;
                int y = i / outputResolution;
                outputTexture.SetPixel(x, y, new Color(distanceField[i] / 10f, 0, 0, 1));
            }

            outputTexture.Apply();
            
            byte[] exrData = outputTexture.EncodeToEXR(Texture2D.EXRFlags.OutputAsFloat);
            File.WriteAllBytes(outputPath, exrData);
            AssetDatabase.Refresh();
            
            binaryImage.Dispose();
            distanceField.Dispose();

            Debug.Log($"SDF generated at {outputResolution}x{outputResolution} from {inputWidth}x{inputHeight} source and saved to {outputPath}");
        }

        [BurstCompile]
        private struct DistanceFieldJob : IJobParallelFor
        {
            [ReadOnly] public NativeArray<float> BinaryImage;
            public NativeArray<float> DistanceField;
            public int InputWidth;
            public int InputHeight;
            public int OutputWidth;
            public int OutputHeight;
            public float MaxDistance;

            public void Execute(int index)
            {
                int outX = index % OutputWidth;
                int outY = index / OutputWidth;
                
                // Map output coordinates to input texture space
                float u = outX / (float)(OutputWidth - 1) * (InputWidth - 1);
                float v = outY / (float)(OutputHeight - 1) * (InputHeight - 1);
                
                float minDistance = MaxDistance;

                int startX = Mathf.Max(0, (int)(u - MaxDistance));
                int endX = Mathf.Min(InputWidth, (int)(u + MaxDistance + 1));
                int startY = Mathf.Max(0, (int)(v - MaxDistance));
                int endY = Mathf.Min(InputHeight, (int)(v + MaxDistance + 1));

                // Check if we're inside a shape by sampling the nearest input pixel
                int nearestX = Mathf.RoundToInt(u);
                int nearestY = Mathf.RoundToInt(v);
                bool isInside = BinaryImage[nearestY * InputWidth + nearestX] == 0;

                if (isInside)
                {
                    DistanceField[index] = 0;
                    return;
                }

                for (int y = startY; y < endY; y++)
                {
                    for (int x = startX; x < endX; x++)
                    {
                        int inputIndex = y * InputWidth + x;
                        bool neighborInside = BinaryImage[inputIndex] == 0;

                        if (neighborInside == false) continue;
                        
                        float dx = u - x;
                        float dy = v - y;
                        float distance = Mathf.Sqrt(dx * dx + dy * dy);
                        minDistance = Mathf.Min(minDistance, distance);

                        if (minDistance <= 1e-5f)
                            break;
                    }
                }

                DistanceField[index] = Mathf.Min(minDistance, MaxDistance);
            }
        }
    }
}