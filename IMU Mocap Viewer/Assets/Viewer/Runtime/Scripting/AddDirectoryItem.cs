using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(ScriptListItem))]
    public class AddDirectoryItem : MonoBehaviour
    {
        void Awake() => GetComponent<ScriptListItem>().Initialize(() => { }, ScriptsOverlay.OpenProjectsFile, "Add Directory");
    }
}