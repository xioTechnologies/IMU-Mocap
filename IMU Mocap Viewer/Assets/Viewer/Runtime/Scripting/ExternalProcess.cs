using System;
using System.IO;
using UnityEngine;
using Process = System.Diagnostics.Process;

namespace Viewer.Runtime.Scripting
{
    static class ExternalProcess
    {
        private static Process active;

        public static string Message { get; private set; }

        public static void Check()
        {
            if (active is not { HasExited: true }) return;

            Message = "";

            active = null;
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

                Dispose();
            }

            active = RunScript(script);
        }

        public static void Dispose()
        {
            Message = "";

            if (active == null || active.HasExited) return;

            try
            {
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
            }
        }

        private static Process RunScript(string scriptPath)
        {
            if (File.Exists(scriptPath) == false)
            {
                Message = "Script not found";

                Debug.LogError($"Script not found: {scriptPath}");

                return null;
            }

            string workingDir = Path.GetDirectoryName(scriptPath);
            string escapedScriptPath = scriptPath.Replace("\"", "\\\"");

            Process process = new Process();

            process.StartInfo.WorkingDirectory = workingDir!;

            Message = Path.GetFileName(scriptPath);

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = $@"""{escapedScriptPath}""";
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = false;

#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            process.StartInfo.FileName = "/usr/bin/open";
            process.StartInfo.Arguments = $"-a Terminal \"{escapedScriptPath}\"";
            process.StartInfo.UseShellExecute = false;

#elif UNITY_EDITOR_LINUX || UNITY_STANDALONE_LINUX
            process.StartInfo.FileName = "/usr/bin/x-terminal-emulator"; // or try gnome-terminal, konsole, etc.
            process.StartInfo.Arguments = $"-e \"python3 \\\"{escapedScriptPath}\\\"\"";
            process.StartInfo.UseShellExecute = false;

#else
            ActiveScript = "Unsupported platform for script execution";
            Debug.LogError("Unsupported platform for script execution.");
            return null;
#endif

            try
            {
                process.Start();

                return process;
            }
            catch (System.Exception e)
            {
                Message = $"Failed to run script: {e.Message}";

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
                return Process.Start(new System.Diagnostics.ProcessStartInfo()
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