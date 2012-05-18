namespace Visualization
{
    partial class Visualize
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
            this.button1 = new System.Windows.Forms.Button();
            this.URL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 1042);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1992, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Visualize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // URL
            // 
            this.URL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.URL.Location = new System.Drawing.Point(0, 1022);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(1992, 20);
            this.URL.TabIndex = 1;
            this.URL.Text = "http://localhost/Compute/Combine/xml";
            // 
            // Visualize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1992, 1065);
            this.Controls.Add(this.URL);
            this.Controls.Add(this.button1);
            this.Name = "Visualize";
            this.Text = "Visualize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox URL;
    }
}

