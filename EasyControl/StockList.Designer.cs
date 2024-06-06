namespace EasyControl
{
    partial class StockList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockList));
            this.cbx_category = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_spareName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_category
            // 
            this.cbx_category.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.cbx_category.FormattingEnabled = true;
            this.cbx_category.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "D"});
            this.cbx_category.Location = new System.Drawing.Point(784, 30);
            this.cbx_category.Margin = new System.Windows.Forms.Padding(5);
            this.cbx_category.Name = "cbx_category";
            this.cbx_category.Size = new System.Drawing.Size(62, 27);
            this.cbx_category.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.button1.Location = new System.Drawing.Point(856, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 27);
            this.button1.TabIndex = 23;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.label1.Location = new System.Drawing.Point(694, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Category:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 67);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(967, 555);
            this.dataGridView1.TabIndex = 20;
            // 
            // lbl_spareName
            // 
            this.lbl_spareName.AutoSize = true;
            this.lbl_spareName.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.lbl_spareName.Location = new System.Drawing.Point(14, 33);
            this.lbl_spareName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_spareName.Name = "lbl_spareName";
            this.lbl_spareName.Size = new System.Drawing.Size(103, 19);
            this.lbl_spareName.TabIndex = 25;
            this.lbl_spareName.Text = "Spare Name:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(995, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton2.Text = "Refresh";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(561, 30);
            this.textBox1.TabIndex = 26;
            // 
            // StockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 636);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbx_category);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_spareName);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "StockList";
            this.Text = "StockList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockList_FormClosing);
            this.Load += new System.EventHandler(this.StockList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_category;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_spareName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox textBox1;
    }
}