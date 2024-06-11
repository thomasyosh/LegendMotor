namespace LegendMotor.WinForm
{
    partial class AddSpareForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            btn_upload = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 184);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 0;
            label1.Text = "Name: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(121, 181);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(500, 30);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 269);
            label2.Name = "label2";
            label2.Size = new Size(103, 19);
            label2.TabIndex = 2;
            label2.Text = "Description: ";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(121, 266);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(500, 96);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 505);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(609, 352);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 378);
            label3.Name = "label3";
            label3.Size = new Size(56, 19);
            label3.TabIndex = 5;
            label3.Text = "Price: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(121, 375);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(74, 30);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(121, 424);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(74, 30);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 427);
            label4.Name = "label4";
            label4.Size = new Size(72, 19);
            label4.TabIndex = 7;
            label4.Text = "Weight: ";
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 478);
            label5.Name = "label5";
            label5.Size = new Size(75, 19);
            label5.TabIndex = 10;
            label5.Text = "Supplier:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(435, 163);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // btn_upload
            // 
            btn_upload.Location = new Point(453, 133);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new Size(168, 42);
            btn_upload.TabIndex = 12;
            btn_upload.Text = "Upload";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += btn_upload_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 227);
            label6.Name = "label6";
            label6.Size = new Size(80, 19);
            label6.TabIndex = 13;
            label6.Text = "Category:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "A", "B", "C", "D" });
            comboBox1.Location = new Point(121, 224);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 27);
            comboBox1.TabIndex = 14;
            // 
            // button2
            // 
            button2.Location = new Point(121, 464);
            button2.Name = "button2";
            button2.Size = new Size(194, 33);
            button2.TabIndex = 15;
            button2.Text = "Add Suppler price";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(341, 464);
            button3.Name = "button3";
            button3.Size = new Size(106, 33);
            button3.TabIndex = 16;
            button3.Text = "Save record";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // AddSpareForm
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 749);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(label6);
            Controls.Add(btn_upload);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Font = new Font("新細明體", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "AddSpareForm";
            Text = "Add Spare";
            Load += AddSpareForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private Button button3;
    }
}