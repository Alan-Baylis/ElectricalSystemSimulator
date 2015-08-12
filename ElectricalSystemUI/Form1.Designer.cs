namespace ElectricalSystemUI
{
    partial class Form1
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
            this.environmentTreeView = new System.Windows.Forms.TreeView();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // environmentTreeView
            // 
            this.environmentTreeView.Location = new System.Drawing.Point(1003, 12);
            this.environmentTreeView.Name = "environmentTreeView";
            this.environmentTreeView.Size = new System.Drawing.Size(337, 717);
            this.environmentTreeView.TabIndex = 0;
            // 
            // commandTextBox
            // 
            this.commandTextBox.Location = new System.Drawing.Point(595, 12);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(255, 22);
            this.commandTextBox.TabIndex = 1;
            this.commandTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.commandTextBox_KeyUp);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(595, 47);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(371, 683);
            this.consoleTextBox.TabIndex = 2;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(857, 12);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(109, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 718);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 742);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.environmentTreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView environmentTreeView;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

