namespace LegendMotor.WinForm;

partial class CreateStaffForm
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
        this.label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.textBox3 = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.textBox4 = new System.Windows.Forms.TextBox();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.comboBox2 = new System.Windows.Forms.ComboBox();
        this.button2 = new System.Windows.Forms.Button();
        this.comboBox3 = new System.Windows.Forms.ComboBox();
        this.label7 = new System.Windows.Forms.Label();
        this.textBox5 = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.label9 = new System.Windows.Forms.Label();
        this.radioButton1 = new System.Windows.Forms.RadioButton();
        this.radioButton2 = new System.Windows.Forms.RadioButton();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 102);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(62, 19);
        this.label1.TabIndex = 0;
        this.label1.Text = "Name: ";
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(127, 99);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(448, 30);
        this.textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(127, 222);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(448, 30);
        this.textBox2.TabIndex = 3;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 225);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(64, 19);
        this.label2.TabIndex = 2;
        this.label2.Text = "Phone: ";
        // 
        // textBox3
        // 
        this.textBox3.Location = new System.Drawing.Point(127, 175);
        this.textBox3.Name = "textBox3";
        this.textBox3.Size = new System.Drawing.Size(448, 30);
        this.textBox3.TabIndex = 5;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 178);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(73, 19);
        this.label3.TabIndex = 4;
        this.label3.Text = "Address:";
        // 
        // textBox4
        // 
        this.textBox4.Location = new System.Drawing.Point(127, 12);
        this.textBox4.Name = "textBox4";
        this.textBox4.Size = new System.Drawing.Size(448, 30);
        this.textBox4.TabIndex = 7;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 15);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(62, 19);
        this.label4.TabIndex = 6;
        this.label4.Text = "Email: ";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(12, 271);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(78, 19);
        this.label5.TabIndex = 8;
        this.label5.Text = "Position: ";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(12, 322);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(54, 19);
        this.label6.TabIndex = 9;
        this.label6.Text = "Area: ";
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(127, 268);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(263, 27);
        this.comboBox1.TabIndex = 10;
        this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        // 
        // comboBox2
        // 
        this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox2.FormattingEnabled = true;
        this.comboBox2.Location = new System.Drawing.Point(127, 319);
        this.comboBox2.Name = "comboBox2";
        this.comboBox2.Size = new System.Drawing.Size(263, 27);
        this.comboBox2.TabIndex = 11;
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(312, 398);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(263, 43);
        this.button2.TabIndex = 13;
        this.button2.Text = "Submit";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // comboBox3
        // 
        this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox3.FormattingEnabled = true;
        this.comboBox3.Location = new System.Drawing.Point(127, 365);
        this.comboBox3.Name = "comboBox3";
        this.comboBox3.Size = new System.Drawing.Size(263, 27);
        this.comboBox3.TabIndex = 15;
        this.comboBox3.Visible = false;
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(12, 368);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(109, 19);
        this.label7.TabIndex = 14;
        this.label7.Text = "Bin Location:";
        this.label7.Visible = false;
        // 
        // textBox5
        // 
        this.textBox5.Enabled = false;
        this.textBox5.Location = new System.Drawing.Point(127, 54);
        this.textBox5.Name = "textBox5";
        this.textBox5.Size = new System.Drawing.Size(312, 30);
        this.textBox5.TabIndex = 17;
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(12, 57);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(83, 19);
        this.label8.TabIndex = 16;
        this.label8.Text = "Password:";
        // 
        // button1
        // 
        this.button1.Font = new System.Drawing.Font("PMingLiU", 12F);
        this.button1.Location = new System.Drawing.Point(445, 54);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(130, 30);
        this.button1.TabIndex = 18;
        this.button1.Text = "Generate";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(12, 146);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(72, 19);
        this.label9.TabIndex = 19;
        this.label9.Text = "Gender: ";
        // 
        // radioButton1
        // 
        this.radioButton1.AutoSize = true;
        this.radioButton1.Location = new System.Drawing.Point(127, 146);
        this.radioButton1.Name = "radioButton1";
        this.radioButton1.Size = new System.Drawing.Size(64, 23);
        this.radioButton1.TabIndex = 20;
        this.radioButton1.TabStop = true;
        this.radioButton1.Text = "Male";
        this.radioButton1.UseVisualStyleBackColor = true;
        this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
        // 
        // radioButton2
        // 
        this.radioButton2.AutoSize = true;
        this.radioButton2.Location = new System.Drawing.Point(207, 146);
        this.radioButton2.Name = "radioButton2";
        this.radioButton2.Size = new System.Drawing.Size(80, 23);
        this.radioButton2.TabIndex = 21;
        this.radioButton2.TabStop = true;
        this.radioButton2.Text = "Female";
        this.radioButton2.UseVisualStyleBackColor = true;
        this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
        // 
        // CreateStaffForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(587, 449);
        this.Controls.Add(this.radioButton2);
        this.Controls.Add(this.radioButton1);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox5);
        this.Controls.Add(this.label8);
        this.Controls.Add(this.comboBox3);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.comboBox2);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.textBox4);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.textBox3);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.textBox2);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label1);
        this.Font = new System.Drawing.Font("PMingLiU", 14F);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(5);
        this.Name = "CreateStaffForm";
        this.Text = "Create Staff";
        this.Load += new System.EventHandler(this.CreateStaffForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.ComboBox comboBox3;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.RadioButton radioButton1;
    private System.Windows.Forms.RadioButton radioButton2;
}