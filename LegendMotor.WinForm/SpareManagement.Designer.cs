namespace LegendMotor.WinForm
{
    partial class SpareManagement
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            comboBox1 = new ComboBox();
            lbl_category = new Label();
            textBox1 = new TextBox();
            lbl_name = new Label();
            linkLabel1 = new LinkLabel();
            button2 = new Button();
            linkLabel2 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(1004, 529);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(540, 9);
            button1.Name = "button1";
            button1.Size = new Size(157, 30);
            button1.TabIndex = 11;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] { "A", "B", "C", "D" });
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "", "A", "B", "C", "D" });
            comboBox1.Location = new Point(488, 9);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(46, 27);
            comboBox1.TabIndex = 10;
            // 
            // lbl_category
            // 
            lbl_category.AutoSize = true;
            lbl_category.Location = new Point(397, 15);
            lbl_category.Name = "lbl_category";
            lbl_category.Size = new Size(85, 19);
            lbl_category.TabIndex = 9;
            lbl_category.Text = "Category: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 9);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(307, 30);
            textBox1.TabIndex = 8;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new Point(14, 15);
            lbl_name.Margin = new Padding(5, 0, 5, 0);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(62, 19);
            lbl_name.TabIndex = 7;
            lbl_name.Text = "Name: ";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(1116, 15);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(86, 19);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Add Spare";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button2
            // 
            button2.Location = new Point(703, 9);
            button2.Name = "button2";
            button2.Size = new Size(157, 30);
            button2.TabIndex = 14;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(885, 12);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(83, 19);
            linkLabel2.TabIndex = 15;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Add spare";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // SpareManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 592);
            Controls.Add(linkLabel2);
            Controls.Add(button2);
            Controls.Add(linkLabel1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(lbl_category);
            Controls.Add(textBox1);
            Controls.Add(lbl_name);
            Font = new Font("新細明體", 14F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5);
            Name = "SpareManagement";
            Text = "Spare Management";
            Load += SpareManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button2;
        private LinkLabel linkLabel2;
    }
}