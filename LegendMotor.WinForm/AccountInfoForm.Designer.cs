namespace LegendMotor.WinForm
{
    partial class AccountInfoForm
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
            passwordTextBox = new TextBox();
            password = new Label();
            emailTextBox = new TextBox();
            email = new Label();
            createdAtDateTimePicker = new DateTimePicker();
            createdAtDateTimePicker.Enabled = false;
            label1 = new Label();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Enabled = false;
            passwordTextBox.Font = new Font("新細明體", 15.75F);
            passwordTextBox.Location = new Point(152, 73);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(312, 33);
            passwordTextBox.TabIndex = 21;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // password
            // 
            password.AutoSize = true;
            password.Font = new Font("新細明體", 15.75F);
            password.Location = new Point(37, 76);
            password.Name = "password";
            password.Size = new Size(92, 21);
            password.TabIndex = 20;
            password.Text = "Password:";
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("新細明體", 15.75F);
            emailTextBox.Location = new Point(152, 24);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(312, 33);
            emailTextBox.TabIndex = 19;
            emailTextBox.TextChanged += emailTextBox_TextChanged;
            // 
            // email
            // 
            email.AutoSize = true;
            email.Font = new Font("新細明體", 15.75F);
            email.Location = new Point(37, 27);
            email.Name = "email";
            email.Size = new Size(66, 21);
            email.TabIndex = 18;
            email.Text = "Email: ";
            // 
            // createdAtDateTimePicker
            // 
            createdAtDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            createdAtDateTimePicker.Font = new Font("新細明體", 15.75F);
            createdAtDateTimePicker.Format = DateTimePickerFormat.Custom;
            createdAtDateTimePicker.Location = new Point(152, 125);
            createdAtDateTimePicker.Name = "createdAtDateTimePicker";
            createdAtDateTimePicker.Size = new Size(312, 33);
            createdAtDateTimePicker.TabIndex = 23;
            createdAtDateTimePicker.ValueChanged += createdAtDateTimePickerDateTimePicker_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("新細明體", 15.75F);
            label1.Location = new Point(37, 130);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 22;
            label1.Text = "Created At:";
            // 
            // AccountInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(createdAtDateTimePicker);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(password);
            Controls.Add(emailTextBox);
            Controls.Add(email);
            Name = "AccountInfoForm";
            Text = "AccountInfo";
            Load += AccountInfoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox passwordTextBox;
        private Label password;
        private TextBox emailTextBox;
        private Label email;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private DateTimePicker createdAtDateTimePicker;
        private Label label1;
    }
}