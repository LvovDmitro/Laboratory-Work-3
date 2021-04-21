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
            this.numericUpDownwidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpheight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownmine = new System.Windows.Forms.NumericUpDown();
            this.buttonok = new System.Windows.Forms.Button();
            this.buttoncancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpheight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownmine)).BeginInit();
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
            this.labelheight.Location = new System.Drawing.Point(14, 53);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(56, 20);
            this.labelheight.TabIndex = 1;
            this.labelheight.Text = "Height";
            // 
            // labeMine
            // 
            this.labeMine.AutoSize = true;
            this.labeMine.Location = new System.Drawing.Point(14, 95);
            this.labeMine.Name = "labeMine";
            this.labeMine.Size = new System.Drawing.Size(43, 20);
            this.labeMine.TabIndex = 2;
            this.labeMine.Text = "Mine";
            // 
            // numericUpDownwidth
            // 
            this.numericUpDownwidth.Location = new System.Drawing.Point(91, 9);
            this.numericUpDownwidth.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownwidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownwidth.Name = "numericUpDownwidth";
            this.numericUpDownwidth.Size = new System.Drawing.Size(135, 26);
            this.numericUpDownwidth.TabIndex = 1;
            this.numericUpDownwidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownwidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpheight
            // 
            this.numericUpheight.Location = new System.Drawing.Point(91, 51);
            this.numericUpheight.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpheight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpheight.Name = "numericUpheight";
            this.numericUpheight.Size = new System.Drawing.Size(135, 26);
            this.numericUpheight.TabIndex = 7;
            this.numericUpheight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpheight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownmine
            // 
            this.numericUpDownmine.Location = new System.Drawing.Point(91, 92);
            this.numericUpDownmine.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownmine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownmine.Name = "numericUpDownmine";
            this.numericUpDownmine.Size = new System.Drawing.Size(135, 26);
            this.numericUpDownmine.TabIndex = 9;
            this.numericUpDownmine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownmine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonok
            // 
            this.buttonok.Location = new System.Drawing.Point(17, 133);
            this.buttonok.Name = "buttonok";
            this.buttonok.Size = new System.Drawing.Size(84, 31);
            this.buttonok.TabIndex = 10;
            this.buttonok.Text = "OK";
            this.buttonok.UseVisualStyleBackColor = true;
            this.buttonok.Click += new System.EventHandler(this.buttonok_Click);
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(125, 133);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(84, 31);
            this.buttoncancel.TabIndex = 11;
            this.buttoncancel.Text = "Cancel";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(234, 176);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.buttonok);
            this.Controls.Add(this.numericUpDownmine);
            this.Controls.Add(this.numericUpheight);
            this.Controls.Add(this.numericUpDownwidth);
            this.Controls.Add(this.labeMine);
            this.Controls.Add(this.labelheight);
            this.Controls.Add(this.labelwidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpheight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownmine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelwidth;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.Label labeMine;
        private System.Windows.Forms.NumericUpDown numericUpDownwidth;
        private System.Windows.Forms.NumericUpDown numericUpheight;
        private System.Windows.Forms.NumericUpDown numericUpDownmine;
        private System.Windows.Forms.Button buttonok;
        private System.Windows.Forms.Button buttoncancel;
    }
}