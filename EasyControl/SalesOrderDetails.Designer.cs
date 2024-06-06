namespace EasyControl
{
    partial class SalesOrderDetails
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
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_contact = new System.Windows.Forms.Label();
            this.lbl_position = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(57, 19);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(12, 37);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(57, 19);
            this.lbl_email.TabIndex = 1;
            this.lbl_email.Text = "Email:";
            // 
            // lbl_contact
            // 
            this.lbl_contact.AutoSize = true;
            this.lbl_contact.Location = new System.Drawing.Point(12, 65);
            this.lbl_contact.Name = "lbl_contact";
            this.lbl_contact.Size = new System.Drawing.Size(70, 19);
            this.lbl_contact.TabIndex = 2;
            this.lbl_contact.Text = "Contact:";
            // 
            // lbl_position
            // 
            this.lbl_position.AutoSize = true;
            this.lbl_position.Location = new System.Drawing.Point(12, 93);
            this.lbl_position.Name = "lbl_position";
            this.lbl_position.Size = new System.Drawing.Size(73, 19);
            this.lbl_position.TabIndex = 3;
            this.lbl_position.Text = "Position:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1085, 539);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "Available",
            "Cancelled",
            "Completed",
            "Picking up",
            "Processing",
            "Ready"});
            this.comboBox1.Location = new System.Drawing.Point(70, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1073, 477);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SalesOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 675);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_position);
            this.Controls.Add(this.lbl_contact);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("PMingLiU", 14F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SalesOrderDetails";
            this.Text = "Sales Order Details";
            this.Load += new System.EventHandler(this.SalesOrderDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_contact;
        private System.Windows.Forms.Label lbl_position;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}