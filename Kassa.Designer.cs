﻿namespace ToodedAB
{
    partial class Kassa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.osta_button = new System.Windows.Forms.Button();
            this.lisa_korvi_button = new System.Windows.Forms.Button();
            this.eemalda_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kassa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(75, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tooted";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(506, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 207);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // osta_button
            // 
            this.osta_button.Location = new System.Drawing.Point(15, 363);
            this.osta_button.Name = "osta_button";
            this.osta_button.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.osta_button.Size = new System.Drawing.Size(94, 33);
            this.osta_button.TabIndex = 4;
            this.osta_button.Text = "Osta";
            this.osta_button.UseVisualStyleBackColor = true;
            this.osta_button.Click += new System.EventHandler(this.osta_button_Click);
            // 
            // lisa_korvi_button
            // 
            this.lisa_korvi_button.Location = new System.Drawing.Point(15, 325);
            this.lisa_korvi_button.Name = "lisa_korvi_button";
            this.lisa_korvi_button.Size = new System.Drawing.Size(103, 32);
            this.lisa_korvi_button.TabIndex = 5;
            this.lisa_korvi_button.Text = "Lisa ostukorvi";
            this.lisa_korvi_button.UseVisualStyleBackColor = true;
            this.lisa_korvi_button.Click += new System.EventHandler(this.lisa_korvi_button_Click);
            // 
            // eemalda_button
            // 
            this.eemalda_button.Location = new System.Drawing.Point(138, 325);
            this.eemalda_button.Name = "eemalda_button";
            this.eemalda_button.Size = new System.Drawing.Size(110, 32);
            this.eemalda_button.TabIndex = 6;
            this.eemalda_button.Text = "Eemalda ostukorvist";
            this.eemalda_button.UseVisualStyleBackColor = true;
            this.eemalda_button.Click += new System.EventHandler(this.eemalda_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(300, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ostukorv";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(24, 105);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(455, 198);
            this.dgv.TabIndex = 7;
            // 
            // Kassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eemalda_button);
            this.Controls.Add(this.lisa_korvi_button);
            this.Controls.Add(this.osta_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Kassa";
            this.Text = "Kassa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button osta_button;
        private System.Windows.Forms.Button lisa_korvi_button;
        private System.Windows.Forms.Button eemalda_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv;
    }
}