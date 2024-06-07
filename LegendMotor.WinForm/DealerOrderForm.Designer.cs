namespace LegendMotor.WinForm;

partial class DealerOrderForm
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
        lbl_dealer = new Label();
        comboBox1 = new ComboBox();
        dataGridView1 = new DataGridView();
        btn_search = new Button();
        comboBox2 = new ComboBox();
        label1 = new Label();
        button1 = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // lbl_dealer
        // 
        lbl_dealer.AutoSize = true;
        lbl_dealer.Location = new Point(14, 15);
        lbl_dealer.Margin = new Padding(5, 0, 5, 0);
        lbl_dealer.Name = "lbl_dealer";
        lbl_dealer.Size = new Size(67, 19);
        lbl_dealer.TabIndex = 0;
        lbl_dealer.Text = "Dealer: ";
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(89, 12);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(534, 27);
        comboBox1.TabIndex = 1;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(12, 45);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowTemplate.Height = 24;
        dataGridView1.Size = new Size(1168, 238);
        dataGridView1.TabIndex = 2;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // btn_search
        // 
        btn_search.Location = new Point(1105, 11);
        btn_search.Name = "btn_search";
        btn_search.Size = new Size(75, 27);
        btn_search.TabIndex = 3;
        btn_search.Text = "Search";
        btn_search.UseVisualStyleBackColor = true;
        btn_search.Click += btn_search_Click;
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.ItemHeight = 19;
        comboBox2.Items.AddRange(new object[] { "", "Cancelled", "Completed", "Pending", "Processing", "Ready", "Rejected", "Shipping" });
        comboBox2.Location = new Point(722, 12);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(121, 27);
        comboBox2.TabIndex = 36;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(651, 15);
        label1.Margin = new Padding(5, 0, 5, 0);
        label1.Name = "label1";
        label1.Size = new Size(63, 19);
        label1.TabIndex = 37;
        label1.Text = "Status: ";
        // 
        // button1
        // 
        button1.Location = new Point(871, 9);
        button1.Name = "button1";
        button1.Size = new Size(91, 30);
        button1.TabIndex = 38;
        button1.Text = "Search";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // DealerOrderForm
        // 
        AutoScaleDimensions = new SizeF(10F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1028, 295);
        Controls.Add(button1);
        Controls.Add(label1);
        Controls.Add(comboBox2);
        Controls.Add(btn_search);
        Controls.Add(dataGridView1);
        Controls.Add(comboBox1);
        Controls.Add(lbl_dealer);
        Font = new Font("新細明體", 14F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        Name = "DealerOrderForm";
        Text = "Dealer Order";
        Load += DealerOrder_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lbl_dealer;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button btn_search;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Label label1;
    private Button button1;
}