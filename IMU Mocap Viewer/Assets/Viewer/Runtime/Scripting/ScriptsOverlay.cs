using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    public class ScriptsOverlay : MonoBehaviour
    {
        public static string Scripts => Path.Combine(Application.persistentDataPath).Replace("\\", "/");

        public static string ScriptsDirectoriesFile => Path.Combine(Scripts, "Scripts Directories.txt").Replace("\\", "/");

        [SerializeField] private ScriptOverlayButton buttonPrefab;
        [SerializeField] private RectTransform container;

        private readonly List<ScriptOverlayButton> buttons = new();

        public static string Message
        {
            get
            {
                ExternalProcess.Check();
                return ExternalProcess.Message;
            }
        }

        public static void OpenProjectsFile()
        {
            TouchProjectsFile();

            ExternalProcess.Edit(ScriptsDirectoriesFile);
        }

        private void Cache()
        {
            if (Directory.Exists(Scripts) == false) Directory.CreateDirectory(Scripts);

            TouchProjectsFile();

            string[] additionalPaths = File.ReadAllLines(ScriptsDirectoriesFile)
                .Where(path => string.IsNullOrWhiteSpace(path) == false && Directory.Exists(path.Trim()))
                .ToArray();

            Debug.Log($"Loaded {additionalPaths.Length} from {ScriptsDirectoriesFile}");

            foreach (ScriptOverlayButton button in buttons) Destroy(button.gameObject);

            buttons.Clear();

            foreach (string path in additionalPaths) CacheDirectory(path);
        }

        private void CacheDirectory(string directory)
        {
            string[] pythonFiles = Directory.GetFiles(directory)
                .Where(path => Path.GetExtension(path) == ".py")
                .ToArray();

            foreach (var scriptPath in pythonFiles)
            {
                string scriptName = Path.GetFileName(scriptPath);

                var button = Instantiate(buttonPrefab, container);

                button.Initialize(
                    () => { ExternalProcess.Run(scriptPath); },
                    () => { ExternalProcess.Edit(scriptPath); },
                    scriptName
                );

                buttons.Add(button);

                button.gameObject.SetActive(true);
            }
        }

        private static void TouchProjectsFile()
        {
            if (File.Exists(ScriptsDirectoriesFile)) return;

            File.WriteAllText(ScriptsDirectoriesFile, "");
        }

        private void Start() => Cache();

        private void OnEnable() => Cache();

        private void OnDestroy() => ExternalProcess.Dispose();
    }
}