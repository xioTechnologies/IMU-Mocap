using UnityEditor;
using UnityEngine;
using Viewer.Runtime;
using MessageType = Viewer.Runtime.MessageType;

namespace Viewer.Editor
{
    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxDrawer : DecoratorDrawer
    {
        InfoBoxAttribute Info => attribute as InfoBoxAttribute;
        private float width = 200;

        static UnityEditor.MessageType Convert(MessageType type) =>
            type switch
            {
                MessageType.None => UnityEditor.MessageType.None,
                MessageType.Info => UnityEditor.MessageType.Info,
                MessageType.Warning => UnityEditor.MessageType.Warning,
                MessageType.Error => UnityEditor.MessageType.Error,
                _ => UnityEditor.MessageType.None
            };

        public override void OnGUI(Rect position)
        {
            EditorGUI.HelpBox(position, Info.Message, Convert(Info.Type));

            width = EditorGUIUtility.currentViewWidth;
        }

        public override float GetHeight()
        {
            var style = EditorStyles.helpBox;

            var content = new GUIContent(Info.Message);

            float height = style.CalcHeight(content, width);

            return height + EditorGUIUtility.singleLineHeight;
        }
    }
}