using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Viewer.Runtime
{
    public class PlatformActivation : MonoBehaviour
    {
        [InfoBox("If the current platform is in this list then the game object will be disabled")] [SerializeField]
        private List<RuntimePlatform> platforms = new();

        void Awake()
        {
            foreach (var platform in platforms.Where(platform => platform == Application.platform))
            {
                gameObject.SetActive(false);
            }
        }
    }
}