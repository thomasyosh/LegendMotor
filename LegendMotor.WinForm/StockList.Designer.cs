namespace LegendMotor.WinForm;

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
        cbx_category = new ComboBox();
        button1 = new Button();
        label1 = new Label();
        dataGridView1 = new DataGridView();
        lbl_spareName = new Label();
        toolStrip1 = new ToolStrip();
        toolStripButton2 = new ToolStripButton();
        textBox1 = new TextBox();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        toolStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // cbx_category
        // 
        cbx_category.Font = new Font("新細明體", 14F);
        cbx_category.FormattingEnabled = true;
        cbx_category.Items.AddRange(new object[] { "", "A", "B", "C", "D" });
        cbx_category.Location = new Point(784, 30);
        cbx_category.Margin = new Padding(5);
        cbx_category.Name = "cbx_category";
        cbx_category.Size = new Size(62, 27);
        cbx_category.TabIndex = 22;
        // 
        // button1
        // 
        button1.Font = new Font("新細明體", 14F);
        button1.Location = new Point(856, 30);
        button1.Margin = new Padding(5);
        button1.Name = "button1";
        button1.Size = new Size(125, 27);
        button1.TabIndex = 23;
        button1.Text = "Search";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("新細明體", 14F);
        label1.Location = new Point(694, 33);
        label1.Margin = new Padding(5, 0, 5, 0);
        label1.Name = "label1";
        label1.Size = new Size(80, 19);
        label1.TabIndex = 24;
        label1.Text = "Category:";
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(14, 67);
        dataGridView1.Margin = new Padding(5);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowTemplate.Height = 24;
        dataGridView1.Size = new Size(967, 555);
        dataGridView1.TabIndex = 20;
        // 
        // lbl_spareName
        // 
        lbl_spareName.AutoSize = true;
        lbl_spareName.Font = new Font("新細明體", 14F);
        lbl_spareName.Location = new Point(14, 33);
        lbl_spareName.Margin = new Padding(5, 0, 5, 0);
        lbl_spareName.Name = "lbl_spareName";
        lbl_spareName.Size = new Size(103, 19);
        lbl_spareName.TabIndex = 25;
        lbl_spareName.Text = "Spare Name:";
        // 
        // toolStrip1
        // 
        toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton2 });
        toolStrip1.Location = new Point(0, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Padding = new Padding(0, 0, 2, 0);
        toolStrip1.Size = new Size(995, 25);
        toolStrip1.TabIndex = 21;
        toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButton2
        // 
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
        toolStripButton2.ImageTransparentColor = Color.Magenta;
        toolStripButton2.Name = "toolStripButton2";
        toolStripButton2.Size = new Size(53, 22);
        toolStripButton2.Text = "Refresh";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(125, 27);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(561, 30);
        textBox1.TabIndex = 26;
        // 
        // StockList
        // 
        AutoScaleDimensions = new SizeF(10F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(995, 636);
        Controls.Add(textBox1);
        Controls.Add(cbx_category);
        Controls.Add(button1);
        Controls.Add(label1);
        Controls.Add(dataGridView1);
        Controls.Add(lbl_spareName);
        Controls.Add(toolStrip1);
        Font = new Font("新細明體", 14F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        Name = "StockList";
        Text = "StockList";
        Load += StockList_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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