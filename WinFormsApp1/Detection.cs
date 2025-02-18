using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperScript
{

}
public class Detection
{
    // Function to detect a running process (e.g., Minecraft.exe)
    public static bool IsProcessRunning(string processName)
    {
        // Get a list of all running processes
        Process[] processes = Process.GetProcessesByName(processName);

        // If the length is greater than 0, that means the process is running
        return processes.Length > 0;
    }

    // Example of a function for detecting a specific file in a directory
    public static bool IsFileInDirectory(string directory, string fileName)
    {
        // Check if the file exists in the directory
        string filePath = System.IO.Path.Combine(directory, fileName);
        return System.IO.File.Exists(filePath);
    }
}