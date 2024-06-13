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
        label1 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        label2 = new Label();
        textBox3 = new TextBox();
        label3 = new Label();
        textBox4 = new TextBox();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        comboBox1 = new ComboBox();
        comboBox2 = new ComboBox();
        button2 = new Button();
        comboBox3 = new ComboBox();
        label7 = new Label();
        textBox5 = new TextBox();
        label8 = new Label();
        button1 = new Button();
        label9 = new Label();
        radioButton1 = new RadioButton();
        radioButton2 = new RadioButton();
        activeUserComboBox = new ComboBox();
        activeUserLabel = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 102);
        label1.Name = "label1";
        label1.Size = new Size(62, 19);
        label1.TabIndex = 0;
        label1.Text = "Name: ";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(127, 99);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(448, 30);
        textBox1.TabIndex = 1;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(127, 222);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(448, 30);
        textBox2.TabIndex = 3;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 225);
        label2.Name = "label2";
        label2.Size = new Size(64, 19);
        label2.TabIndex = 2;
        label2.Text = "Phone: ";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(127, 175);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(448, 30);
        textBox3.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 178);
        label3.Name = "label3";
        label3.Size = new Size(73, 19);
        label3.TabIndex = 4;
        label3.Text = "Address:";
        // 
        // textBox4
        // 
        textBox4.Location = new Point(127, 12);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(448, 30);
        textBox4.TabIndex = 7;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 15);
        label4.Name = "label4";
        label4.Size = new Size(62, 19);
        label4.TabIndex = 6;
        label4.Text = "Email: ";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 271);
        label5.Name = "label5";
        label5.Size = new Size(78, 19);
        label5.TabIndex = 8;
        label5.Text = "Position: ";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(12, 322);
        label6.Name = "label6";
        label6.Size = new Size(54, 19);
        label6.TabIndex = 9;
        label6.Text = "Area: ";
        // 
        // comboBox1
        // 
        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(127, 268);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(263, 27);
        comboBox1.TabIndex = 10;
        comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        // 
        // comboBox2
        // 
        comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new Point(127, 319);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(263, 27);
        comboBox2.TabIndex = 11;
        // 
        // button2
        // 
        button2.Location = new Point(312, 451);
        button2.Name = "button2";
        button2.Size = new Size(263, 43);
        button2.TabIndex = 13;
        button2.Text = "Submit";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // comboBox3
        // 
        comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox3.FormattingEnabled = true;
        comboBox3.Location = new Point(127, 365);
        comboBox3.Name = "comboBox3";
        comboBox3.Size = new Size(263, 27);
        comboBox3.TabIndex = 15;
        comboBox3.Visible = false;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(12, 368);
        label7.Name = "label7";
        label7.Size = new Size(109, 19);
        label7.TabIndex = 14;
        label7.Text = "Bin Location:";
        label7.Visible = false;
        // 
        // textBox5
        // 
        textBox5.Enabled = false;
        textBox5.Location = new Point(127, 54);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(312, 30);
        textBox5.TabIndex = 17;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 57);
        label8.Name = "label8";
        label8.Size = new Size(83, 19);
        label8.TabIndex = 16;
        label8.Text = "Password:";
        // 
        // button1
        // 
        button1.Font = new Font("新細明體", 12F);
        button1.Location = new Point(445, 54);
        button1.Name = "button1";
        button1.Size = new Size(130, 30);
        button1.TabIndex = 18;
        button1.Text = "Generate";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(12, 146);
        label9.Name = "label9";
        label9.Size = new Size(72, 19);
        label9.TabIndex = 19;
        label9.Text = "Gender: ";
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Location = new Point(127, 146);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(64, 23);
        radioButton1.TabIndex = 20;
        radioButton1.TabStop = true;
        radioButton1.Text = "Male";
        radioButton1.UseVisualStyleBackColor = true;
        radioButton1.CheckedChanged += radioButton1_CheckedChanged;
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(207, 146);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(80, 23);
        radioButton2.TabIndex = 21;
        radioButton2.TabStop = true;
        radioButton2.Text = "Female";
        radioButton2.UseVisualStyleBackColor = true;
        radioButton2.CheckedChanged += radioButton2_CheckedChanged;
        // 
        // activeUserComboBox
        // 
        activeUserComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        activeUserComboBox.FormattingEnabled = true;
        activeUserComboBox.Location = new Point(127, 408);
        activeUserComboBox.Name = "activeUserComboBox";
        activeUserComboBox.Size = new Size(263, 27);
        activeUserComboBox.TabIndex = 23;
        // 
        // activeUserLabel
        // 
        activeUserLabel.AutoSize = true;
        activeUserLabel.Location = new Point(12, 411);
        activeUserLabel.Name = "activeUserLabel";
        activeUserLabel.Size = new Size(101, 19);
        activeUserLabel.TabIndex = 22;
        activeUserLabel.Text = "Active User:";
        activeUserLabel.Click += label10_Click;
        // 
        // CreateStaffForm
        // 
        AutoScaleDimensions = new SizeF(10F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(587, 506);
        Controls.Add(activeUserComboBox);
        Controls.Add(activeUserLabel);
        Controls.Add(radioButton2);
        Controls.Add(radioButton1);
        Controls.Add(label9);
        Controls.Add(button1);
        Controls.Add(textBox5);
        Controls.Add(label8);
        Controls.Add(comboBox3);
        Controls.Add(label7);
        Controls.Add(button2);
        Controls.Add(comboBox2);
        Controls.Add(comboBox1);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(textBox4);
        Controls.Add(label4);
        Controls.Add(textBox3);
        Controls.Add(label3);
        Controls.Add(textBox2);
        Controls.Add(label2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Font = new Font("新細明體", 14F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(5);
        Name = "CreateStaffForm";
        Text = "Create Staff";
        Load += CreateStaffForm_Load;
        ResumeLayout(false);
        PerformLayout();
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
    private ComboBox activeUserComboBox;
    private Label activeUserLabel;
}