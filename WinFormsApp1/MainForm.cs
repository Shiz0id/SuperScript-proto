using SuperScript;
using System;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        // Declare exeFullPath as a class-level variable to store the full path of the EXE
        private string exeFullPath = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        // Event handler for the button click to open the file dialog
        private void button1_Click(object sender, EventArgs e)
        {
            OpenExeFileDialog();
        }

        // Method to open file dialog and select an EXE file
        private void OpenExeFileDialog()
        {
            try
            {
                // Create and configure the OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*",  // Filter to show .exe files
                    Title = "Select an EXE File"  // Dialog title
                };

                // Show the dialog and check if the user selected a file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file's name (filename only) in the TextBox
                    ExeName.Text = Path.GetFileName(openFileDialog.FileName);  // Extract the file name

                    // Store the full file path in the class-level variable
                    exeFullPath = openFileDialog.FileName;  // Store full path in the variable
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExeName_TextChanged(object sender, EventArgs e)
        {
            // Handle the TextChanged event for the TextBox
        }

        private void ScriptWin_TextChanged(object sender, EventArgs e)
        {
            // Handle the TextChanged event for the TextBox
        }
        private void btnRunProcess_Click(object sender, EventArgs e)
        {
            string exePath = ExeName.Text.Trim();  // Textbox where user selects EXE
            string arguments = txtArguments.Text.Trim(); // Textbox for command-line args

            if (string.IsNullOrWhiteSpace(exePath))
            {
                MessageBox.Show("Please select an executable file.");
                return;
            }

            bool success = ProcessRunner.R(exeFullPath, arguments);

            MessageBox.Show(success ? "Process started successfully!" : "Failed to start process.");
        }
        private void btnShowExePath_Click(object sender, EventArgs e)
        {
            // Assuming exeFullPath already has data
            MessageBox.Show(exeFullPath, "Executable Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCheckProcess_Click(object sender, EventArgs e)
        {
            string processName = txtProcessName.Text.Trim();

            // Check if the text box is empty
            if (string.IsNullOrWhiteSpace(processName))
            {
                MessageBox.Show("Please enter a process name.");
                return; // Stop execution if empty
            }

            bool isRunning = Detection.IsProcessRunning(processName);

            // Show the correct message based on process detection
            MessageBox.Show(isRunning ? "OK! Process is running." : "Process not found.");
        }
        }
    }

