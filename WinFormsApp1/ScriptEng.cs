using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SuperScript;

namespace SuperScript
{

}
public partial class ScriptEngine
{
    [GeneratedRegex(@"WHEN FILE_DETECTED\(""(.+)""\)")]
    private static partial Regex FileDetectedRegex();

    [GeneratedRegex(@"DO RUN_PROCESS\(""(.+)"",\s*""(.+)""\)")]
    private static partial Regex RunProcessRegex();

    [GeneratedRegex(@"DO MOVE_FILE\(""(.+)"",\s*""(.+)""\)")]
    private static partial Regex MoveFileRegex();

    [GeneratedRegex(@"DO DELETE_FILE\(""(.+)""\)")]
    private static partial Regex DeleteFileRegex();

    private bool isRunning = true;

    public void RunScript(string script)
    {
        string[] lines = script.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        // Process each line of the script
        foreach (string line in lines)
        {
            if (line.StartsWith("WHEN FILE_DETECTED", StringComparison.OrdinalIgnoreCase))
            {
                Match match = FileDetectedRegex().Match(line);
                if (match.Success)
                {
                    string directory = Path.GetDirectoryName(match.Groups[1].Value);
                    string filter = Path.GetFileName(match.Groups[1].Value);
                    Task.Run(() => WatchForFiles(directory, filter));
                }
            }
            // Add more triggers here...
            else if (line.StartsWith("DO RUN_PROCESS", StringComparison.OrdinalIgnoreCase))
            {
                Match match = RunProcessRegex().Match(line);
                if (match.Success)
                {
                    string exeFullPath = match.Groups[1].Value;
                    string args = match.Groups[2].Value;
                    ProcessRunner.R(exeFullPath, args);
                }
            }
            // Add more commands here...
            else if (line.StartsWith("DO MOVE_FILE", StringComparison.OrdinalIgnoreCase))
            {
                Match match = MoveFileRegex().Match(line);
                if (match.Success)
                {
                    string source = match.Groups[1].Value;
                    string destination = match.Groups[2].Value;
                    FileMover.MoveFile(source, destination);
                }
            }
            else if (line.StartsWith("DO DELETE_FILE", StringComparison.OrdinalIgnoreCase))
            {
                Match match = DeleteFileRegex().Match(line);
                if (match.Success)
                {
                    string filePath = match.Groups[1].Value;
                    FileDeleter.DeleteFile(filePath);
                }
            }
        }
    }
    // Watch for files in the specified directory with the specified filter
    private void WatchForFiles(string directory, string filter)
    {
        FileSystemWatcher watcher = new FileSystemWatcher
        {
            Path = directory,
            Filter = filter,
            EnableRaisingEvents = true
        };

        watcher.Created += (s, e) =>
        {
            if (isRunning)
            {
                Console.WriteLine($"Detected: {e.FullPath}");
            }
        };
    }

    public void Stop()
    {
        isRunning = false;
    }
}
