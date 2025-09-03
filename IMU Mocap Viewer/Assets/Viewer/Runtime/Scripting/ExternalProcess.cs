using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Process = System.Diagnostics.Process;

namespace Viewer.Runtime.Scripting
{
    internal static class ExternalProcess
    {
        private const string PreviousScriptKey = "PreviousScript";

        private static Process active;
        public static string BasePath => Path.Combine(Application.persistentDataPath);

        public static string PythonCommand => Path.Combine(BasePath, "Python Command.txt");

        public static string PreviousScript { get; private set; }

        public static bool CanRerun => PreviousScript != null;

        public static bool Running { get; private set; }

        public static string ScriptName { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadSettings()
        {
            var scriptPath = PlayerPrefs.HasKey(PreviousScriptKey) ? PlayerPrefs.GetString(PreviousScriptKey) : null;

            PreviousScript = scriptPath != null && File.Exists(scriptPath) ? scriptPath : null;

            ScriptName = PreviousScript != null ? Path.GetFileName(PreviousScript) : "";
        }

        public static event Action Started;

        public static event Action Stopped;

        public static void Check()
        {
            if (active is not { HasExited: true }) return;

            active = null;

            Running = false;

            Stopped?.Invoke();
        }

        public static void Edit(string filePath)
        {
            OpenFile(filePath);
        }

        public static void Rerun()
        {
            if (CanRerun == false) return;

            Run(PreviousScript);
        }

        public static void Run(string script)
        {
            if (active is { HasExited: false })
            {
                Debug.Log("Exiting the active process");

                Stop();
            }

            active = RunScript(script);
        }

        public static void Stop()
        {
            if (active == null) return;

            try
            {
                if (active.HasExited) return;

                if (active.CloseMainWindow() == false) active.Kill();

                if (active.WaitForExit(5000)) return;

                active.Kill();
                active.WaitForExit();
            }
            catch (InvalidOperationException)
            {
                // Process has already exited
            }
            finally
            {
                active?.Dispose();
                active = null;

                Running = false;
                Stopped?.Invoke();
            }
        }

        private static Process RunScript(string scriptPath)
        {
            if (File.Exists(scriptPath) == false)
            {
                ScriptName = "Script not found";

                Debug.LogError($"Script not found: {scriptPath}");

                return null;
            }

            EnsurePythonCommandFileExists();

            var commandLine = File.ReadAllText(PythonCommand);

            if (ParseCommandLine(commandLine, out var command, out var arguments) == false)
            {
                ScriptName = "Could not parse command line: " + commandLine;

                Debug.LogError(ScriptName);

                return null;
            }

            var workingDirectory = Path.GetDirectoryName(scriptPath);

            var argumentsWithScript = arguments
                .Replace("<working-directory>", workingDirectory)
                .Replace("<script>", scriptPath);

            Debug.Log($"{command} {argumentsWithScript}");


            var process = new Process
            {
                StartInfo =
                {
                    FileName = command,
                    Arguments = argumentsWithScript,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WorkingDirectory = workingDirectory!
                }
            };

            try
            {
                ScriptName = Path.GetFileName(scriptPath);
                PlayerPrefs.SetString(PreviousScriptKey, scriptPath);
                PreviousScript = scriptPath;

                process.Start();

                Running = true;
                Started?.Invoke();

                return process;
            }
            catch (Exception e)
            {
                ScriptName = $"Failed to run script: {e.Message}";

                Debug.LogError($"Failed to run script: {e.Message}");

                return null;
            }
        }

        private static void EnsurePythonCommandFileExists()
        {
            if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
            {
                if (File.Exists(PythonCommand)
                    && File.ReadAllText(PythonCommand).IndexOf("<script>", StringComparison.Ordinal) >= 0
                    && File.ReadAllText(PythonCommand).IndexOf("<working-directory>", StringComparison.Ordinal) >= 0)
                    return;

                File.WriteAllText(PythonCommand,
                    "osascript -e \"tell application \\\"Terminal\\\" to do script \\\"cd '<working-directory>'; python3 '<script>'\\\"\"");

                return;
            }

            if (File.Exists(PythonCommand) && File.ReadAllText(PythonCommand).IndexOf("<script>", StringComparison.Ordinal) >= 0) return;

            File.WriteAllText(PythonCommand, "python \"<script>\"");
        }

        private static bool ParseCommandLine(string commandLine, out string command, out string arguments)
        {
            command = string.Empty;
            arguments = string.Empty;

            if (string.IsNullOrWhiteSpace(commandLine)) return false;

            commandLine = commandLine.Trim();

            if (commandLine[0] == '"')
            {
                var closingQuote = commandLine.IndexOf('"', 1);

                if (closingQuote == -1) return false;

                command = commandLine.Substring(1, closingQuote - 1);
                arguments = commandLine.Substring(closingQuote + 1).Trim();

                return true;
            }

            var spaceIndex = commandLine.IndexOf(' ');

            if (spaceIndex >= 0)
            {
                command = commandLine.Substring(0, spaceIndex);
                arguments = commandLine.Substring(spaceIndex + 1).Trim();

                return true;
            }

            command = commandLine;
            arguments = string.Empty;

            return true;
        }

        private static Process OpenFile(string filePath)
        {
            if (File.Exists(filePath) == false && Directory.Exists(filePath) == false)
            {
                Debug.LogError($"File or directory not found: {filePath}");
                return null;
            }

            try
            {
                return Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to open file: {e.Message}");

                return null;
            }
        }
    }
}