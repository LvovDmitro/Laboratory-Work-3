namespace Лабораторная_работа__3
{
    partial class Highscores
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
            this.labeleasy = new System.Windows.Forms.Label();
            this.labelmedium = new System.Windows.Forms.Label();
            this.labelhard = new System.Windows.Forms.Label();
            this.buttonreset = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labeleasy
            // 
            this.labeleasy.AutoSize = true;
            this.labeleasy.Location = new System.Drawing.Point(14, 12);
            this.labeleasy.Name = "labeleasy";
            this.labeleasy.Size = new System.Drawing.Size(44, 20);
            this.labeleasy.TabIndex = 0;
            this.labeleasy.Text = "Easy";
            // 
            // labelmedium
            // 
            this.labelmedium.AutoSize = true;
            this.labelmedium.Location = new System.Drawing.Point(14, 56);
            this.labelmedium.Name = "labelmedium";
            this.labelmedium.Size = new System.Drawing.Size(65, 20);
            this.labelmedium.TabIndex = 1;
            this.labelmedium.Text = "Medium";
            // 
            // labelhard
            // 
            this.labelhard.AutoSize = true;
            this.labelhard.Location = new System.Drawing.Point(14, 99);
            this.labelhard.Name = "labelhard";
            this.labelhard.Size = new System.Drawing.Size(44, 20);
            this.labelhard.TabIndex = 2;
            this.labelhard.Text = "Hard";
            // 
            // buttonreset
            // 
            this.buttonreset.Location = new System.Drawing.Point(34, 139);
            this.buttonreset.Name = "buttonreset";
            this.buttonreset.Size = new System.Drawing.Size(84, 31);
            this.buttonreset.TabIndex = 3;
            this.buttonreset.Text = "Reset";
            this.buttonreset.UseVisualStyleBackColor = true;
            this.buttonreset.Click += new System.EventHandler(this.buttonreset_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(164, 139);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(84, 31);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // Highscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(278, 185);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonreset);
            this.Controls.Add(this.labelhard);
            this.Controls.Add(this.labelmedium);
            this.Controls.Add(this.labeleasy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Highscores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Highscores";
            this.Load += new System.EventHandler(this.Highscores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeleasy;
        private System.Windows.Forms.Label labelmedium;
        private System.Windows.Forms.Label labelhard;
        private System.Windows.Forms.Button buttonreset;
        private System.Windows.Forms.Button buttonOK;
    }
}