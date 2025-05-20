namespace StudentInfo
{
    partial class Form_InfoHandler
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
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_IDNO = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(19, 15);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(44, 16);
            this.label_ID.TabIndex = 0;
            this.label_ID.Text = "ID No.";
            // 
            // textBox_IDNO
            // 
            this.textBox_IDNO.Location = new System.Drawing.Point(12, 34);
            this.textBox_IDNO.Name = "textBox_IDNO";
            this.textBox_IDNO.Size = new System.Drawing.Size(57, 22);
            this.textBox_IDNO.TabIndex = 1;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(75, 34);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(347, 22);
            this.textBox_Name.TabIndex = 2;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(82, 15);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(44, 16);
            this.label_Name.TabIndex = 2;
            this.label_Name.Text = "Name";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(428, 34);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(252, 22);
            this.textBox_Email.TabIndex = 3;
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(435, 15);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(41, 16);
            this.label_Email.TabIndex = 4;
            this.label_Email.Text = "Email";
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(686, 34);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(360, 22);
            this.textBox_Address.TabIndex = 4;
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(693, 15);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(58, 16);
            this.label_Address.TabIndex = 6;
            this.label_Address.Text = "Address";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 615);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(254, 46);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(532, 615);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(254, 46);
            this.button_Search.TabIndex = 7;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(272, 615);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(254, 46);
            this.button_Remove.TabIndex = 6;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(792, 615);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(254, 46);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 62);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1034, 547);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // Form_InfoHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label_Address);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.textBox_IDNO);
            this.Controls.Add(this.label_ID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_InfoHandler";
            this.ShowIcon = false;
            this.Text = "Student Info Handler";
            this.Load += new System.EventHandler(this.Form_InfoHandler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.TextBox textBox_IDNO;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

