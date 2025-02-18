using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperScript
{
    public static class ProcessRunner
    {
        /// <summary>
        /// Run a process with the specified exe path and arguments.
        /// </summary>
        /// <param name="exeFullPath">Full path to the exe to run.</param>
        /// <param name="arguments">Command line arguments to pass to the exe.</param>
        /// <param name="waitForExit">Whether to wait for the process to exit (optional).</param>
        /// <param name="captureOutput">Whether to capture the output from the process (optional).</param>
        /// <param name="captureError">Whether to capture the error output from the process (optional).</param>
        /// <returns>True if process started successfully, false otherwise.</returns>
        public static bool R(
            string exeFullPath,
            string arguments,
            bool waitForExit = false,
            bool captureOutput = false,
            bool captureError = false)
        {
            try
            {
                // Ensure the executable file exists
                if (!File.Exists(exeFullPath))
                {
                    throw new FileNotFoundException($"The executable was not found: {exeFullPath}");
                }

                // Log for debugging purposes
                Console.WriteLine($"Executable Path: {exeFullPath}");

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = exeFullPath,  // Full path to the EXE
                    Arguments = arguments,   // Command-line arguments to pass
                    RedirectStandardOutput = captureOutput,   // Redirect output if specified
                    RedirectStandardError = captureError,     // Redirect error if specified
                    UseShellExecute = !captureOutput && !captureError,  // Use shell execute if we’re not capturing output
                    CreateNoWindow = true    // Don't show a window for the process
                };

                // Start the process
                Process? process = Process.Start(psi);

                if (process == null)
                    throw new Exception("Failed to start the process.");

                // Handle output redirection if specified
                if (captureOutput)
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        // Optionally process the output here, for example:
                        Console.WriteLine($"Output: {e.Data}");
                    };
                    process.BeginOutputReadLine();  // Begin reading the standard output stream
                }

                // Handle error redirection if specified
                if (captureError)
                {
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        // Optionally process the error output here, for example:
                        Console.WriteLine($"Error: {e.Data}");
                    };
                    process.BeginErrorReadLine();  // Begin reading the error output stream
                }

                // If waitForExit is true, wait for the process to complete
                if (waitForExit)
                    process.WaitForExit();

                return true;
            }
            catch (Exception ex)
            {
                string errorMsg = "Error starting process:\n" + ex.Message;
                Clipboard.SetText(errorMsg);  // Copies the error to clipboard
                MessageBox.Show(errorMsg + "\n\n(The error has been copied to clipboard.)");
                return false;
            }
        }

        /// <summary>
        /// Run a process as an administrator with the specified exe path and arguments.
        /// </summary>
        /// <param name="exeFullPath">Full path to the exe to run.</param>
        /// <param name="arguments">Command line arguments to pass to the exe.</param>
        /// <returns>True if process started successfully, false otherwise.</returns>
        public static bool RunProcessAsAdmin(string exeFullPath, string arguments)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = exeFullPath,
                    Arguments = arguments,
                    Verb = "runas",  // This triggers the UAC prompt for elevation
                    UseShellExecute = true
                };

                Process.Start(psi);
                return true;
            }
            catch (Exception ex)
            {
                string errorMsg = "Failed to start process as admin:\n" + ex.Message;
                Clipboard.SetText(errorMsg);  // Copies the error to clipboard
                MessageBox.Show(errorMsg + "\n\n(The error has been copied to clipboard.)");
                return false;
            }
        }
    }
}