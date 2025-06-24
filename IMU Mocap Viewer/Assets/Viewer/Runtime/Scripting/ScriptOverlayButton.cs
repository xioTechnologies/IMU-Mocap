using System;
using TMPro;
using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    public class ScriptOverlayButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private event Action RunAction;
        private event Action EditAction;

        public void Initialize(Action action, Action edit, string text)
        {
            RunAction += action;
            EditAction += edit;
            this.text.text = text;
        }

        public void Trigger() => RunAction?.Invoke();

        public void Edit() => EditAction?.Invoke();

        private void OnDestroy() => RunAction = null;
    }
}