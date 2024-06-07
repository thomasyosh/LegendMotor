namespace LegendMotor.WinForm;

partial class AdminMenu
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        this.btn_addStaff = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        this.toolStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // toolStrip1
        // 
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.toolStripButton1});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(293, 25);
        this.toolStrip1.TabIndex = 7;
        this.toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButton1
        // 
        this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
        this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton1.Name = "toolStripButton1";
        this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
        this.toolStripButton1.Text = "Logout";
        this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
        // 
        // btn_addStaff
        // 
        this.btn_addStaff.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.btn_addStaff.Location = new System.Drawing.Point(12, 28);
        this.btn_addStaff.Name = "btn_addStaff";
        this.btn_addStaff.Size = new System.Drawing.Size(269, 40);
        this.btn_addStaff.TabIndex = 8;
        this.btn_addStaff.Text = "Add Staff";
        this.btn_addStaff.UseVisualStyleBackColor = true;
        this.btn_addStaff.Click += new System.EventHandler(this.btn_searchSpare_Click);
        // 
        // button1
        // 
        this.button1.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.button1.Location = new System.Drawing.Point(12, 74);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(269, 40);
        this.button1.TabIndex = 9;
        this.button1.Text = "Update Staff";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // AdminMenu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(293, 124);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.btn_addStaff);
        this.Controls.Add(this.toolStrip1);
        this.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(5);
        this.Name = "AdminMenu";
        this.Text = "AdminForm";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMenu_FormClosed_1);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton1;
    private System.Windows.Forms.Button btn_addStaff;
    private System.Windows.Forms.Button button1;
}