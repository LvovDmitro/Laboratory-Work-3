namespace Лабораторная_работа__3
{
    partial class Settings
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
            this.labelwidth = new System.Windows.Forms.Label();
            this.labelheight = new System.Windows.Forms.Label();
            this.labeMine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.BackColor = System.Drawing.SystemColors.Window;
            this.labelwidth.Location = new System.Drawing.Point(14, 12);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(50, 20);
            this.labelwidth.TabIndex = 0;
            this.labelwidth.Text = "Width";
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(15, 53);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(56, 20);
            this.labelheight.TabIndex = 1;
            this.labelheight.Text = "Height";
            // 
            // labeMine
            // 
            this.labeMine.AutoSize = true;
            this.labeMine.Location = new System.Drawing.Point(21, 94);
            this.labeMine.Name = "labeMine";
            this.labeMine.Size = new System.Drawing.Size(43, 20);
            this.labeMine.TabIndex = 2;
            this.labeMine.Text = "Mine";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(234, 176);
            this.Controls.Add(this.labeMine);
            this.Controls.Add(this.labelheight);
            this.Controls.Add(this.labelwidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.Label labeMine;
    }
}