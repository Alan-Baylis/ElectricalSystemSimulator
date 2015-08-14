namespace ElectricalSystemSimulatorv3_GUI
{
    partial class ElectricalSimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxCommandLine = new System.Windows.Forms.TextBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBoxScriptFile = new System.Windows.Forms.TextBox();
            this.buttonLoadScriptFile = new System.Windows.Forms.Button();
            this.buttonBrowseScriptFile = new System.Windows.Forms.Button();
            this.openScriptFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 12);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(437, 63);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "UPDATE NETWORKS";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxCommandLine
            // 
            this.textBoxCommandLine.Location = new System.Drawing.Point(12, 152);
            this.textBoxCommandLine.Name = "textBoxCommandLine";
            this.textBoxCommandLine.Size = new System.Drawing.Size(437, 22);
            this.textBoxCommandLine.TabIndex = 3;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(12, 180);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(437, 23);
            this.buttonExecute.TabIndex = 4;
            this.buttonExecute.Text = "Execute Command";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBoxScriptFile
            // 
            this.textBoxScriptFile.Location = new System.Drawing.Point(12, 266);
            this.textBoxScriptFile.Name = "textBoxScriptFile";
            this.textBoxScriptFile.Size = new System.Drawing.Size(301, 22);
            this.textBoxScriptFile.TabIndex = 5;
            // 
            // buttonLoadScriptFile
            // 
            this.buttonLoadScriptFile.Location = new System.Drawing.Point(12, 294);
            this.buttonLoadScriptFile.Name = "buttonLoadScriptFile";
            this.buttonLoadScriptFile.Size = new System.Drawing.Size(137, 32);
            this.buttonLoadScriptFile.TabIndex = 6;
            this.buttonLoadScriptFile.Text = "Load Script";
            this.buttonLoadScriptFile.UseVisualStyleBackColor = true;
            this.buttonLoadScriptFile.Click += new System.EventHandler(this.buttonLoadScriptFile_Click);
            // 
            // buttonBrowseScriptFile
            // 
            this.buttonBrowseScriptFile.Location = new System.Drawing.Point(319, 265);
            this.buttonBrowseScriptFile.Name = "buttonBrowseScriptFile";
            this.buttonBrowseScriptFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseScriptFile.TabIndex = 7;
            this.buttonBrowseScriptFile.Text = "Browse..";
            this.buttonBrowseScriptFile.UseVisualStyleBackColor = true;
            this.buttonBrowseScriptFile.Click += new System.EventHandler(this.buttonBrowseScriptFile_Click);
            // 
            // openScriptFileDialog
            // 
            this.openScriptFileDialog.FileName = "openScriptFileDialog";
            // 
            // textBoxConsoleOutput
            // 
            this.textBoxConsoleOutput.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConsoleOutput.Location = new System.Drawing.Point(455, 12);
            this.textBoxConsoleOutput.Name = "textBoxConsoleOutput";
            this.textBoxConsoleOutput.Size = new System.Drawing.Size(546, 490);
            this.textBoxConsoleOutput.TabIndex = 8;
            this.textBoxConsoleOutput.Text = "";
            // 
            // ElectricalSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 514);
            this.Controls.Add(this.textBoxConsoleOutput);
            this.Controls.Add(this.buttonBrowseScriptFile);
            this.Controls.Add(this.buttonLoadScriptFile);
            this.Controls.Add(this.textBoxScriptFile);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.textBoxCommandLine);
            this.Controls.Add(this.buttonUpdate);
            this.Name = "ElectricalSimulatorForm";
            this.Text = "Electrical System Simulator v3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxCommandLine;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.TextBox textBoxScriptFile;
        private System.Windows.Forms.Button buttonLoadScriptFile;
        private System.Windows.Forms.Button buttonBrowseScriptFile;
        private System.Windows.Forms.OpenFileDialog openScriptFileDialog;
        private System.Windows.Forms.RichTextBox textBoxConsoleOutput;
    }
}

