namespace ElectricalSystemSimulatorv3_GUI
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAddDevice = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonConnectDevices = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(455, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(546, 490);
            this.textBox1.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(12, 12);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(437, 63);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "UPDATE NETWORKS";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Location = new System.Drawing.Point(12, 166);
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Size = new System.Drawing.Size(135, 38);
            this.buttonAddDevice.TabIndex = 2;
            this.buttonAddDevice.Text = "Add Device";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(153, 218);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 5;
            // 
            // buttonConnectDevices
            // 
            this.buttonConnectDevices.Location = new System.Drawing.Point(12, 210);
            this.buttonConnectDevices.Name = "buttonConnectDevices";
            this.buttonConnectDevices.Size = new System.Drawing.Size(135, 38);
            this.buttonConnectDevices.TabIndex = 4;
            this.buttonConnectDevices.Text = "Connect Devices";
            this.buttonConnectDevices.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(259, 218);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 514);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonConnectDevices);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAddDevice;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button buttonConnectDevices;
        private System.Windows.Forms.TextBox textBox4;
    }
}

