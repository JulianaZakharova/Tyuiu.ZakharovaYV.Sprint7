﻿
namespace Tyuiu.ZakharovaYV.Sprint7.V15
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelInfo_NVD = new System.Windows.Forms.Label();
            this.buttonOK_NVD = new System.Windows.Forms.Button();
            this.pictureBoxOne_NVD = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOne_NVD)).BeginInit();
            this.SuspendLayout();
            // 
            // labelInfo_NVD
            // 
            this.labelInfo_NVD.AutoSize = true;
            this.labelInfo_NVD.Location = new System.Drawing.Point(114, 9);
            this.labelInfo_NVD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo_NVD.Name = "labelInfo_NVD";
            this.labelInfo_NVD.Size = new System.Drawing.Size(284, 130);
            this.labelInfo_NVD.TabIndex = 9;
            this.labelInfo_NVD.Text = resources.GetString("labelInfo_NVD.Text");
            // 
            // buttonOK_NVD
            // 
            this.buttonOK_NVD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonOK_NVD.Location = new System.Drawing.Point(332, 165);
            this.buttonOK_NVD.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOK_NVD.Name = "buttonOK_NVD";
            this.buttonOK_NVD.Size = new System.Drawing.Size(66, 25);
            this.buttonOK_NVD.TabIndex = 8;
            this.buttonOK_NVD.Text = "Ок";
            this.buttonOK_NVD.UseVisualStyleBackColor = false;
            this.buttonOK_NVD.Click += new System.EventHandler(this.buttonOK_NVD_Click);
            // 
            // pictureBoxOne_NVD
            // 
            this.pictureBoxOne_NVD.Image = global::Tyuiu.ZakharovaYV.Sprint7.V15.Properties.Resources.Frame_15;
            this.pictureBoxOne_NVD.Location = new System.Drawing.Point(11, 11);
            this.pictureBoxOne_NVD.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxOne_NVD.Name = "pictureBoxOne_NVD";
            this.pictureBoxOne_NVD.Size = new System.Drawing.Size(89, 91);
            this.pictureBoxOne_NVD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOne_NVD.TabIndex = 7;
            this.pictureBoxOne_NVD.TabStop = false;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 201);
            this.Controls.Add(this.labelInfo_NVD);
            this.Controls.Add(this.buttonOK_NVD);
            this.Controls.Add(this.pictureBoxOne_NVD);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Об авторе ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOne_NVD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo_NVD;
        private System.Windows.Forms.Button buttonOK_NVD;
        private System.Windows.Forms.PictureBox pictureBoxOne_NVD;
    }
}