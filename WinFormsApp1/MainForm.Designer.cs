namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ExeBut = new Button();
            ExeName = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            ScriptWin = new TextBox();
            ScriptWinLabel = new Label();
            btnCheckProcess = new Button();
            txtProcessName = new TextBox();
            btnRunProcess = new Button();
            txtArguments = new TextBox();
            btnShowExePath = new Button();
            btnSaveScript = new Button();
            btnOpenScript = new Button();
            SuspendLayout();
            // 
            // ExeBut
            // 
            ExeBut.Location = new Point(188, 43);
            ExeBut.Name = "ExeBut";
            ExeBut.Size = new Size(151, 61);
            ExeBut.TabIndex = 0;
            ExeBut.Text = "Add EXE to Program...";
            ExeBut.UseVisualStyleBackColor = true;
            ExeBut.Click += button1_Click;
            // 
            // ExeName
            // 
            ExeName.Location = new Point(24, 63);
            ExeName.Name = "ExeName";
            ExeName.ReadOnly = true;
            ExeName.Size = new Size(158, 23);
            ExeName.TabIndex = 1;
            ExeName.TextChanged += ExeName_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(23, 97);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(23, 122);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(24, 147);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 4;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // ScriptWin
            // 
            ScriptWin.Location = new Point(24, 318);
            ScriptWin.Multiline = true;
            ScriptWin.Name = "ScriptWin";
            ScriptWin.Size = new Size(550, 382);
            ScriptWin.TabIndex = 5;
            ScriptWin.TextChanged += ScriptWin_TextChanged;
            // 
            // ScriptWinLabel
            // 
            ScriptWinLabel.AutoSize = true;
            ScriptWinLabel.Location = new Point(24, 300);
            ScriptWinLabel.Name = "ScriptWinLabel";
            ScriptWinLabel.Size = new Size(95, 15);
            ScriptWinLabel.TabIndex = 6;
            ScriptWinLabel.Text = "Enter Script Here";
            // 
            // btnCheckProcess
            // 
            btnCheckProcess.Location = new Point(910, 208);
            btnCheckProcess.Name = "btnCheckProcess";
            btnCheckProcess.Size = new Size(75, 23);
            btnCheckProcess.TabIndex = 7;
            btnCheckProcess.Text = "CheckProcess";
            btnCheckProcess.UseVisualStyleBackColor = true;
            btnCheckProcess.Click += btnCheckProcess_Click;
            // 
            // txtProcessName
            // 
            txtProcessName.Location = new Point(804, 208);
            txtProcessName.Name = "txtProcessName";
            txtProcessName.Size = new Size(100, 23);
            txtProcessName.TabIndex = 8;
            // 
            // btnRunProcess
            // 
            btnRunProcess.Location = new Point(834, 333);
            btnRunProcess.Name = "btnRunProcess";
            btnRunProcess.Size = new Size(75, 23);
            btnRunProcess.TabIndex = 9;
            btnRunProcess.Text = "start exe";
            btnRunProcess.UseVisualStyleBackColor = true;
            btnRunProcess.Click += btnRunProcess_Click;
            // 
            // txtArguments
            // 
            txtArguments.Location = new Point(695, 334);
            txtArguments.Name = "txtArguments";
            txtArguments.Size = new Size(100, 23);
            txtArguments.TabIndex = 10;
            // 
            // btnShowExePath
            // 
            btnShowExePath.Location = new Point(643, 40);
            btnShowExePath.Name = "btnShowExePath";
            btnShowExePath.Size = new Size(75, 23);
            btnShowExePath.TabIndex = 11;
            btnShowExePath.Text = "ShowPath";
            btnShowExePath.UseVisualStyleBackColor = true;
            btnShowExePath.Click += btnShowExePath_Click;
            // 
            // btnSaveScript
            // 
            btnSaveScript.Location = new Point(588, 323);
            btnSaveScript.Name = "btnSaveScript";
            btnSaveScript.Size = new Size(93, 23);
            btnSaveScript.TabIndex = 12;
            btnSaveScript.Text = "Save Script..";
            btnSaveScript.UseVisualStyleBackColor = true;
            btnSaveScript.Click += btnSaveScript_Click;
            // 
            // btnOpenScript
            // 
            btnOpenScript.Location = new Point(588, 352);
            btnOpenScript.Name = "btnOpenScript";
            btnOpenScript.Size = new Size(93, 23);
            btnOpenScript.TabIndex = 13;
            btnOpenScript.Text = "Open Script..";
            btnOpenScript.UseVisualStyleBackColor = true;
            btnOpenScript.Click += btnOpenScript_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 789);
            Controls.Add(btnOpenScript);
            Controls.Add(btnSaveScript);
            Controls.Add(btnShowExePath);
            Controls.Add(txtArguments);
            Controls.Add(btnRunProcess);
            Controls.Add(txtProcessName);
            Controls.Add(btnCheckProcess);
            Controls.Add(ScriptWinLabel);
            Controls.Add(ScriptWin);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(ExeName);
            Controls.Add(ExeBut);
            Name = "MainForm";
            Text = "SuperScript";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ExeBut;
        private TextBox ExeName;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private TextBox ScriptWin;
        private Label ScriptWinLabel;
        private Button btnCheckProcess;
        private TextBox txtProcessName;
        private Button btnRunProcess;
        private TextBox txtArguments;
        private Button btnShowExePath;
        private Button btnSaveScript;
        private Button btnOpenScript;
    }
}
