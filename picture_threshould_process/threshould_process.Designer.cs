namespace picture_threshould_process
{
    partial class threshould_process
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
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.graycheck = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Threshould_image = new System.Windows.Forms.PictureBox();
            this.graph_picture = new System.Windows.Forms.PictureBox();
            this.picThres = new System.Windows.Forms.PictureBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Threshould_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 19);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Original_Barcode_result";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(570, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 52);
            this.button2.TabIndex = 6;
            this.button2.Text = "ImageLoad & Barcode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(721, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 52);
            this.button3.TabIndex = 7;
            this.button3.Text = "gray & Threshould";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Threshould_Barcode_result";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 19);
            this.textBox2.TabIndex = 8;
            // 
            // graycheck
            // 
            this.graycheck.AutoSize = true;
            this.graycheck.Location = new System.Drawing.Point(201, 9);
            this.graycheck.Name = "graycheck";
            this.graycheck.Size = new System.Drawing.Size(95, 12);
            this.graycheck.TabIndex = 14;
            this.graycheck.Text = "gray_image_check";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(352, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(136, 19);
            this.textBox3.TabIndex = 15;
            // 
            // Threshould_image
            // 
            this.Threshould_image.Location = new System.Drawing.Point(378, 354);
            this.Threshould_image.Name = "Threshould_image";
            this.Threshould_image.Size = new System.Drawing.Size(317, 199);
            this.Threshould_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Threshould_image.TabIndex = 13;
            this.Threshould_image.TabStop = false;
            // 
            // graph_picture
            // 
            this.graph_picture.Location = new System.Drawing.Point(29, 345);
            this.graph_picture.Name = "graph_picture";
            this.graph_picture.Size = new System.Drawing.Size(258, 194);
            this.graph_picture.TabIndex = 12;
            this.graph_picture.TabStop = false;
            // 
            // picThres
            // 
            this.picThres.Location = new System.Drawing.Point(400, 118);
            this.picThres.Name = "picThres";
            this.picThres.Size = new System.Drawing.Size(317, 199);
            this.picThres.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThres.TabIndex = 11;
            this.picThres.TabStop = false;
            // 
            // picBarcode
            // 
            this.picBarcode.Image = global::picture_threshould_process.Properties.Resources.fast_45cm_rota;
            this.picBarcode.Location = new System.Drawing.Point(29, 118);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(317, 199);
            this.picBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBarcode.TabIndex = 10;
            this.picBarcode.TabStop = false;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(509, 51);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(30, 27);
            this.btnOpenImage.TabIndex = 16;
            this.btnOpenImage.Text = "...";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "Message:";
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(77, 78);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 19);
            this.lblmsg.TabIndex = 18;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // threshould_process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 592);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.graycheck);
            this.Controls.Add(this.Threshould_image);
            this.Controls.Add(this.graph_picture);
            this.Controls.Add(this.picThres);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "threshould_process";
            this.Text = "Threshould";
            ((System.ComponentModel.ISupportInitialize)(this.Threshould_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.PictureBox picThres;
        private System.Windows.Forms.PictureBox graph_picture;
        private System.Windows.Forms.PictureBox Threshould_image;
        private System.Windows.Forms.Label graycheck;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

