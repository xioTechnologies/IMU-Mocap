// Single file Plot Client for Unity

using System;
using System.Buffers;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class PlotClient : IDisposable
{
    private readonly UdpClient client;
    private bool disposed;
    
    private bool isFirstPrimitive = true;
    private readonly ArrayBufferWriter<byte> writer;
    
    public PlotClient(IPAddress ipAddress = null, int port = 6000)
    {
        client = new UdpClient();
        client.Connect(new IPEndPoint(ipAddress ?? IPAddress.Loopback, port));
        
        writer = new ArrayBufferWriter<byte>();
        WriteArrayOpen();
    }

    public void Dispose()
    {
        if (disposed) return;

        client?.Dispose();

        disposed = true;
    }

    public void Axis(Vector3 position, Quaternion orientation, float scale = 1f)
    {
        position = SwizzleFromUnity(position);
        orientation = SwizzleFromUnity(orientation);

        WriteCommaIfNeeded();
        Write("{" +
              "\"type\":\"axes\"" +
              $",\"xyz\":{{\"x\":{position.x:F6},\"y\":{position.y:F6},\"z\":{position.z:F6} }}" +
              $",\"quaternion\":{{\"w\":{orientation.w:F6},\"x\":{orientation.x:F6},\"y\":{orientation.y:F6},\"z\":{orientation.z:F6} }}" +
              $",\"scale\":{scale:F6}" +
              "}"
        );
    }

    public void Circle(Vector3 position, Vector3 axis, float radius)
    {
        position = SwizzleFromUnity(position);
        axis = SwizzleFromUnity(axis);

        WriteCommaIfNeeded();
        Write("{" +
              "\"type\":\"circle\"" +
              $",\"xyz\":{{\"x\":{position.x:F6},\"y\":{position.y:F6},\"z\":{position.z:F6} }}" +
              $",\"axis\":{{\"x\":{axis.x:F6},\"y\":{axis.y:F6},\"z\":{axis.z:F6} }}" +
              $",\"radius\":{radius:F6}" +
              "}"
        );
    }

    public void Dot(Vector3 position, int size = 1)
    {
        position = SwizzleFromUnity(position);

        WriteCommaIfNeeded();
        Write("{" +
              "\"type\":\"dot\"" +
              $",\"xyz\":{{\"x\":{position.x:F6},\"y\":{position.y:F6},\"z\":{position.z:F6} }}" +
              $",\"size\":{size:F6}" +
              "}"
        );
    }

    public void Label(Vector3 position, string text)
    {
        position = SwizzleFromUnity(position);

        WriteCommaIfNeeded();
        Write("{" +
              "\"type\":\"label\"" +
              $",\"xyz\":{{\"x\":{position.x:F6},\"y\":{position.y:F6},\"z\":{position.z:F6} }}" +
              $",\"text\":{JsonConvert.ToString(text)}" +
              "}",
            Math.Min(200 + text.Length, 512)
        );
    }

    public void Line(Vector3 start, Vector3 end)
    {
        start = SwizzleFromUnity(start);
        end = SwizzleFromUnity(end);

        WriteCommaIfNeeded();
        Write("{" +
              "\"type\":\"line\"" +
              $",\"start\":{{\"x\":{start.x:F6},\"y\":{start.y:F6},\"z\":{start.z:F6} }}" +
              $",\"end\":{{\"x\":{end.x:F6},\"y\":{end.y:F6},\"z\":{end.z:F6} }}" +
              "}"
        );
    }

    public void Send()
    {
        if (disposed) return;

        try
        {
            WriteArrayClose();
            
            byte[] data = writer.WrittenSpan.ToArray();
            
            client.Send(data, data.Length);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to send plot data: {e.Message}");
        }

        writer.Clear();
        WriteArrayOpen();
    }

    private Quaternion SwizzleFromUnity(Quaternion wxyz) => new(-wxyz.x, -wxyz.z, -wxyz.y, wxyz.w);

    private Vector3 SwizzleFromUnity(Vector3 v) => new(v.x, v.z, v.y);

    private void Write(ReadOnlySpan<byte> bytes)
    {
        Span<byte> span = writer.GetSpan(bytes.Length);
        bytes.CopyTo(span);
        writer.Advance(bytes.Length);
    }

    private void Write(string format, int sizeHint = 256)
    {
        Span<byte> buffer = stackalloc byte[sizeHint];

        int bytesWritten = Encoding.UTF8.GetBytes(format, buffer);

        Write(buffer[..bytesWritten]);
    }

    private void WriteArrayClose() => WriteChar(']');

    private void WriteArrayOpen()
    {
        WriteChar('[');
        isFirstPrimitive = true;
    }

    private void WriteChar(char character)
    {
        Span<byte> span = writer.GetSpan(1);
        span[0] = (byte)character;
        writer.Advance(1);
    }

    private void WriteCommaIfNeeded()
    {
        if (isFirstPrimitive)
        {
            isFirstPrimitive = false;
            return;
        }

        WriteChar(',');
    }
}