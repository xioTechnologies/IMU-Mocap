using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(ScriptOverlayButton))]
    public class OpenScriptsDirectory : MonoBehaviour
    {
        void Awake()
        {
            var button = GetComponent<ScriptOverlayButton>();

            button.Initialize(() => { }, ScriptsOverlay.OpenProjectsFile, "Add Directory");
        }
    }
}