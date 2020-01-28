namespace OptionMenuForm
{
    partial class SettingsForm
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
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.labelOpacityValue = new System.Windows.Forms.Label();
            this.labelRedColor = new System.Windows.Forms.Label();
            this.labelGreenColor = new System.Windows.Forms.Label();
            this.labelBlueColor = new System.Windows.Forms.Label();
            this.trackBarRedColor = new System.Windows.Forms.TrackBar();
            this.trackBarGreenColor = new System.Windows.Forms.TrackBar();
            this.trackBarBlueColor = new System.Windows.Forms.TrackBar();
            this.labelRedColorValue = new System.Windows.Forms.Label();
            this.labelGreenColorValue = new System.Windows.Forms.Label();
            this.labelBlueColorValue = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueColor)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(85, 49);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(374, 45);
            this.trackBarOpacity.TabIndex = 0;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelOpacity.ForeColor = System.Drawing.Color.Silver;
            this.labelOpacity.Location = new System.Drawing.Point(1, 49);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(74, 20);
            this.labelOpacity.TabIndex = 4;
            this.labelOpacity.Text = "Opacity:";
            // 
            // labelOpacityValue
            // 
            this.labelOpacityValue.AutoSize = true;
            this.labelOpacityValue.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelOpacityValue.Location = new System.Drawing.Point(238, 33);
            this.labelOpacityValue.Name = "labelOpacityValue";
            this.labelOpacityValue.Size = new System.Drawing.Size(40, 20);
            this.labelOpacityValue.TabIndex = 5;
            this.labelOpacityValue.Text = "100";
            // 
            // labelRedColor
            // 
            this.labelRedColor.AutoSize = true;
            this.labelRedColor.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRedColor.ForeColor = System.Drawing.Color.Red;
            this.labelRedColor.Location = new System.Drawing.Point(49, 100);
            this.labelRedColor.Name = "labelRedColor";
            this.labelRedColor.Size = new System.Drawing.Size(26, 20);
            this.labelRedColor.TabIndex = 6;
            this.labelRedColor.Text = "R:";
            // 
            // labelGreenColor
            // 
            this.labelGreenColor.AutoSize = true;
            this.labelGreenColor.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreenColor.ForeColor = System.Drawing.Color.Lime;
            this.labelGreenColor.Location = new System.Drawing.Point(49, 151);
            this.labelGreenColor.Name = "labelGreenColor";
            this.labelGreenColor.Size = new System.Drawing.Size(26, 20);
            this.labelGreenColor.TabIndex = 7;
            this.labelGreenColor.Text = "G:";
            // 
            // labelBlueColor
            // 
            this.labelBlueColor.AutoSize = true;
            this.labelBlueColor.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlueColor.ForeColor = System.Drawing.Color.Blue;
            this.labelBlueColor.Location = new System.Drawing.Point(50, 202);
            this.labelBlueColor.Name = "labelBlueColor";
            this.labelBlueColor.Size = new System.Drawing.Size(25, 20);
            this.labelBlueColor.TabIndex = 8;
            this.labelBlueColor.Text = "B:";
            // 
            // trackBarRedColor
            // 
            this.trackBarRedColor.Location = new System.Drawing.Point(85, 100);
            this.trackBarRedColor.Maximum = 255;
            this.trackBarRedColor.Name = "trackBarRedColor";
            this.trackBarRedColor.Size = new System.Drawing.Size(374, 45);
            this.trackBarRedColor.TabIndex = 9;
            this.trackBarRedColor.Scroll += new System.EventHandler(this.trackBarRedColor_Scroll);
            // 
            // trackBarGreenColor
            // 
            this.trackBarGreenColor.Location = new System.Drawing.Point(85, 151);
            this.trackBarGreenColor.Maximum = 255;
            this.trackBarGreenColor.Name = "trackBarGreenColor";
            this.trackBarGreenColor.Size = new System.Drawing.Size(374, 45);
            this.trackBarGreenColor.TabIndex = 10;
            this.trackBarGreenColor.Scroll += new System.EventHandler(this.trackBarGreenColor_Scroll);
            // 
            // trackBarBlueColor
            // 
            this.trackBarBlueColor.Location = new System.Drawing.Point(85, 202);
            this.trackBarBlueColor.Maximum = 255;
            this.trackBarBlueColor.Name = "trackBarBlueColor";
            this.trackBarBlueColor.Size = new System.Drawing.Size(374, 45);
            this.trackBarBlueColor.TabIndex = 11;
            this.trackBarBlueColor.Scroll += new System.EventHandler(this.trackBarBlueColor_Scroll);
            // 
            // labelRedColorValue
            // 
            this.labelRedColorValue.AutoSize = true;
            this.labelRedColorValue.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelRedColorValue.Location = new System.Drawing.Point(238, 84);
            this.labelRedColorValue.Name = "labelRedColorValue";
            this.labelRedColorValue.Size = new System.Drawing.Size(21, 20);
            this.labelRedColorValue.TabIndex = 12;
            this.labelRedColorValue.Text = "0";
            // 
            // labelGreenColorValue
            // 
            this.labelGreenColorValue.AutoSize = true;
            this.labelGreenColorValue.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelGreenColorValue.Location = new System.Drawing.Point(238, 132);
            this.labelGreenColorValue.Name = "labelGreenColorValue";
            this.labelGreenColorValue.Size = new System.Drawing.Size(21, 20);
            this.labelGreenColorValue.TabIndex = 13;
            this.labelGreenColorValue.Text = "0";
            // 
            // labelBlueColorValue
            // 
            this.labelBlueColorValue.AutoSize = true;
            this.labelBlueColorValue.Font = new System.Drawing.Font("MV Boli", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelBlueColorValue.Location = new System.Drawing.Point(238, 183);
            this.labelBlueColorValue.Name = "labelBlueColorValue";
            this.labelBlueColorValue.Size = new System.Drawing.Size(21, 20);
            this.labelBlueColorValue.TabIndex = 14;
            this.labelBlueColorValue.Text = "0";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(503, 33);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(503, 71);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(631, 248);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelBlueColorValue);
            this.Controls.Add(this.labelGreenColorValue);
            this.Controls.Add(this.labelRedColorValue);
            this.Controls.Add(this.trackBarBlueColor);
            this.Controls.Add(this.trackBarGreenColor);
            this.Controls.Add(this.trackBarRedColor);
            this.Controls.Add(this.labelBlueColor);
            this.Controls.Add(this.labelGreenColor);
            this.Controls.Add(this.labelRedColor);
            this.Controls.Add(this.labelOpacityValue);
            this.Controls.Add(this.labelOpacity);
            this.Controls.Add(this.trackBarOpacity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Opacity = 0.7D;
            this.Text = "OptionMenuForm";
            this.Load += new System.EventHandler(this.OptionMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGreenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Label labelOpacityValue;
        private System.Windows.Forms.Label labelRedColor;
        private System.Windows.Forms.Label labelGreenColor;
        private System.Windows.Forms.Label labelBlueColor;
        private System.Windows.Forms.TrackBar trackBarRedColor;
        private System.Windows.Forms.TrackBar trackBarGreenColor;
        private System.Windows.Forms.TrackBar trackBarBlueColor;
        private System.Windows.Forms.Label labelRedColorValue;
        private System.Windows.Forms.Label labelGreenColorValue;
        private System.Windows.Forms.Label labelBlueColorValue;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
    }
}

