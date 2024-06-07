namespace LegendMotor.WinForm;

partial class DealerForm
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
        this.lbl_dealer = new System.Windows.Forms.Label();
        this.txt_dealer = new System.Windows.Forms.TextBox();
        this.btn_search = new System.Windows.Forms.Button();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.SuspendLayout();
        // 
        // lbl_dealer
        // 
        this.lbl_dealer.AutoSize = true;
        this.lbl_dealer.Location = new System.Drawing.Point(14, 12);
        this.lbl_dealer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        this.lbl_dealer.Name = "lbl_dealer";
        this.lbl_dealer.Size = new System.Drawing.Size(67, 19);
        this.lbl_dealer.TabIndex = 0;
        this.lbl_dealer.Text = "Dealer: ";
        // 
        // txt_dealer
        // 
        this.txt_dealer.Location = new System.Drawing.Point(89, 9);
        this.txt_dealer.Name = "txt_dealer";
        this.txt_dealer.Size = new System.Drawing.Size(494, 30);
        this.txt_dealer.TabIndex = 1;
        // 
        // btn_search
        // 
        this.btn_search.Location = new System.Drawing.Point(589, 9);
        this.btn_search.Name = "btn_search";
        this.btn_search.Size = new System.Drawing.Size(91, 30);
        this.btn_search.TabIndex = 2;
        this.btn_search.Text = "Search";
        this.btn_search.UseVisualStyleBackColor = true;
        this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
        // 
        // dataGridView1
        // 
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.AllowUserToDeleteRows = false;
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new System.Drawing.Point(12, 45);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.ReadOnly = true;
        this.dataGridView1.RowTemplate.Height = 24;
        this.dataGridView1.Size = new System.Drawing.Size(765, 318);
        this.dataGridView1.TabIndex = 3;
        this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(658, 369);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(119, 30);
        this.button1.TabIndex = 4;
        this.button1.Text = "Add Dealer";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(686, 9);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(91, 30);
        this.button2.TabIndex = 5;
        this.button2.Text = "Reset";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // Dealer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(789, 411);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.btn_search);
        this.Controls.Add(this.txt_dealer);
        this.Controls.Add(this.lbl_dealer);
        this.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(5);
        this.Name = "Dealer";
        this.Text = "Dealer";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DealerForm_FormClosing);
        this.Load += new System.EventHandler(this.Dealer_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lbl_dealer;
    private System.Windows.Forms.TextBox txt_dealer;
    private System.Windows.Forms.Button btn_search;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
}