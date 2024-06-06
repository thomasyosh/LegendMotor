namespace EasyControl
{
    partial class SearchSpareForm
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_category = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(14, 9);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(62, 19);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(84, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 30);
            this.textBox1.TabIndex = 1;
            // 
            // lbl_category
            // 
            this.lbl_category.AutoSize = true;
            this.lbl_category.Location = new System.Drawing.Point(397, 9);
            this.lbl_category.Name = "lbl_category";
            this.lbl_category.Size = new System.Drawing.Size(85, 19);
            this.lbl_category.TabIndex = 2;
            this.lbl_category.Text = "Category: ";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "A",
            "B",
            "C",
            "D"});
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D"});
            this.comboBox1.Location = new System.Drawing.Point(488, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(46, 27);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(540, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1190, 529);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1162, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 19);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cart";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchSpareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 592);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_category);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SearchSpareForm";
            this.Text = "Search Spare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchSpareForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchSpareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_category;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button2;
    }
}