using System.Drawing;

namespace ToodedAB
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Lisa = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Kutsuta_Kategooria = new System.Windows.Forms.Button();
            this.Toode = new System.Windows.Forms.ComboBox();
            this.Kogus = new System.Windows.Forms.ComboBox();
            this.Hind = new System.Windows.Forms.ComboBox();
            this.Kat = new System.Windows.Forms.ComboBox();
            this.Otsi_Pilt = new System.Windows.Forms.Button();
            this.Toode_pb = new System.Windows.Forms.PictureBox();
            this.Lisa_kategooria = new System.Windows.Forms.Button();
            this.Kustuta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toode_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 275);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(936, 223);
            this.dgv.TabIndex = 0;
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            // 
            // Lisa
            // 
            this.Lisa.Location = new System.Drawing.Point(127, 243);
            this.Lisa.Name = "Lisa";
            this.Lisa.Size = new System.Drawing.Size(75, 26);
            this.Lisa.TabIndex = 1;
            this.Lisa.Text = "Lisa";
            this.Lisa.UseVisualStyleBackColor = true;
            this.Lisa.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Uuenda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Kutsuta_Kategooria
            // 
            this.Kutsuta_Kategooria.Location = new System.Drawing.Point(297, 200);
            this.Kutsuta_Kategooria.Name = "Kutsuta_Kategooria";
            this.Kutsuta_Kategooria.Size = new System.Drawing.Size(115, 26);
            this.Kutsuta_Kategooria.TabIndex = 3;
            this.Kutsuta_Kategooria.Text = "Kutsuta kategooria";
            this.Kutsuta_Kategooria.UseVisualStyleBackColor = true;
            this.Kutsuta_Kategooria.Click += new System.EventHandler(this.button3_Click);
            // 
            // Toode
            // 
            this.Toode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Toode.FormattingEnabled = true;
            this.Toode.ItemHeight = 20;
            this.Toode.Location = new System.Drawing.Point(171, 24);
            this.Toode.Name = "Toode";
            this.Toode.Size = new System.Drawing.Size(120, 28);
            this.Toode.TabIndex = 4;
            // 
            // Kogus
            // 
            this.Kogus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Kogus.FormattingEnabled = true;
            this.Kogus.Location = new System.Drawing.Point(171, 82);
            this.Kogus.Name = "Kogus";
            this.Kogus.Size = new System.Drawing.Size(120, 28);
            this.Kogus.TabIndex = 5;
            // 
            // Hind
            // 
            this.Hind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Hind.FormattingEnabled = true;
            this.Hind.Location = new System.Drawing.Point(171, 140);
            this.Hind.Name = "Hind";
            this.Hind.Size = new System.Drawing.Size(120, 28);
            this.Hind.TabIndex = 6;
            // 
            // Kat
            // 
            this.Kat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Kat.FormattingEnabled = true;
            this.Kat.Location = new System.Drawing.Point(171, 198);
            this.Kat.Name = "Kat";
            this.Kat.Size = new System.Drawing.Size(120, 28);
            this.Kat.TabIndex = 7;
            // 
            // Otsi_Pilt
            // 
            this.Otsi_Pilt.Location = new System.Drawing.Point(541, 212);
            this.Otsi_Pilt.Name = "Otsi_Pilt";
            this.Otsi_Pilt.Size = new System.Drawing.Size(75, 26);
            this.Otsi_Pilt.TabIndex = 8;
            this.Otsi_Pilt.Text = "Otsi Pilt";
            this.Otsi_Pilt.UseVisualStyleBackColor = true;
            this.Otsi_Pilt.Click += new System.EventHandler(this.Otsi_Pilt_Click);
            // 
            // Toode_pb
            // 
            this.Toode_pb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Toode_pb.Location = new System.Drawing.Point(575, 24);
            this.Toode_pb.Name = "Toode_pb";
            this.Toode_pb.Size = new System.Drawing.Size(304, 182);
            this.Toode_pb.TabIndex = 9;
            this.Toode_pb.TabStop = false;
            // 
            // Lisa_kategooria
            // 
            this.Lisa_kategooria.Location = new System.Drawing.Point(26, 243);
            this.Lisa_kategooria.Name = "Lisa_kategooria";
            this.Lisa_kategooria.Size = new System.Drawing.Size(95, 26);
            this.Lisa_kategooria.TabIndex = 0;
            this.Lisa_kategooria.Text = "Lisa kategooria";
            this.Lisa_kategooria.UseVisualStyleBackColor = true;
            this.Lisa_kategooria.Click += new System.EventHandler(this.Lisa_kategooria_Click);
            // 
            // Kustuta
            // 
            this.Kustuta.Location = new System.Drawing.Point(289, 243);
            this.Kustuta.Name = "Kustuta";
            this.Kustuta.Size = new System.Drawing.Size(82, 26);
            this.Kustuta.TabIndex = 10;
            this.Kustuta.Text = "Kustuta";
            this.Kustuta.UseVisualStyleBackColor = true;
            this.Kustuta.Click += new System.EventHandler(this.Kustuta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Toode nimetu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kogus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(21, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hind";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(21, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Kategooria";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(960, 510);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Kustuta);
            this.Controls.Add(this.Lisa_kategooria);
            this.Controls.Add(this.Toode_pb);
            this.Controls.Add(this.Otsi_Pilt);
            this.Controls.Add(this.Kat);
            this.Controls.Add(this.Hind);
            this.Controls.Add(this.Kogus);
            this.Controls.Add(this.Toode);
            this.Controls.Add(this.Kutsuta_Kategooria);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Lisa);
            this.Controls.Add(this.dgv);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toode_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button Lisa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Kutsuta_Kategooria;
        private System.Windows.Forms.ComboBox Toode;
        private System.Windows.Forms.ComboBox Kogus;
        private System.Windows.Forms.ComboBox Hind;
        private System.Windows.Forms.ComboBox Kat;
        private System.Windows.Forms.Button Otsi_Pilt;
        private System.Windows.Forms.PictureBox Toode_pb;
        private System.Windows.Forms.Button Lisa_kategooria;
        private System.Windows.Forms.Button Kustuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

