using System;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;
using Process = System.Diagnostics.Process;

namespace Viewer.Runtime.Scripting
{
    static class ExternalProcess
    {
        private static Process active;

        public static event Action Started;

        public static event Action Stopped;

        public static string ScriptName { get; private set; }

        public static void Check()
        {
            if (active is not { HasExited: true }) return;

            active = null;

            Stopped?.Invoke();
        }

        public static void Edit(string filePath)
        {
            OpenFile(filePath);
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

            string workingDir = Path.GetDirectoryName(scriptPath);
            string escapedScriptPath = scriptPath.Replace("\"", "\\\"");

            Process process = new Process();

            process.StartInfo.WorkingDirectory = workingDir!;

            ScriptName = Path.GetFileName(scriptPath);

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = $@"""{escapedScriptPath}""";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = false;

#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            var command = $"python3 '{escapedScriptPath}'";
            process.StartInfo.FileName = "/usr/bin/osascript";
            process.StartInfo.Arguments = $"-e \"tell application \\\"Terminal\\\" to do script \\\"{command}\\\"\"";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;

#else
            ScriptName = "Unsupported platform for script execution";
            Debug.LogError("Unsupported platform for script execution.");
            return null;
#endif

            try
            {
                process.Start();

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

        private static Process OpenFile(string filePath)
        {
            if (File.Exists(filePath) == false && Directory.Exists(filePath) == false)
            {
                Debug.LogError($"File or directory not found: {filePath}");
                return null;
            }

            try
            {
                return Process.Start(new ProcessStartInfo()
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