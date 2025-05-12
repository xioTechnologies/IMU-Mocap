using System;
using UnityEngine;

namespace Viewer.Runtime
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InfoBoxAttribute : PropertyAttribute
    {
        public readonly string Message;

        public readonly MessageType Type;

        public InfoBoxAttribute(string message, MessageType type = MessageType.Info)
        {
            Message = message;

            Type = type;
        }
    }

    public enum MessageType
    {
        None,
        Info,
        Warning,
        Error,
    }
}