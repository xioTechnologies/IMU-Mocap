using TMPro;
using UnityEngine;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class VersionLabel : MonoBehaviour
    {
        void Start() => GetComponent<TMP_Text>().text = Application.version;
    }
}
