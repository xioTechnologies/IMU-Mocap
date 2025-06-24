using TMPro;
using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScriptOverlayMessage : MonoBehaviour
    {
        private TMP_Text text;

        private void Awake() => text = GetComponent<TMP_Text>();

        private void Update() => text.text = ScriptsOverlay.Message;
    }
}