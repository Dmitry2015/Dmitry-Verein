namespace VendorMaintenance
{
    partial class frmAddModifyVendor
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
            System.Windows.Forms.Label ZipCodeLabel;
            System.Windows.Forms.Label StateNameLabel;
            System.Windows.Forms.Label Address1Label;
            System.Windows.Forms.Label NameLabel;
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ZipCodeLabel = new System.Windows.Forms.Label();
            StateNameLabel = new System.Windows.Forms.Label();
            Address1Label = new System.Windows.Forms.Label();
            NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ZipCodeLabel
            // 
            ZipCodeLabel.AutoSize = true;
            ZipCodeLabel.Location = new System.Drawing.Point(308, 344);
            ZipCodeLabel.Name = "ZipCodeLabel";
            ZipCodeLabel.Size = new System.Drawing.Size(29, 13);
            ZipCodeLabel.TabIndex = 25;
            ZipCodeLabel.Text = "Age:";
            ZipCodeLabel.Click += new System.EventHandler(this.ZipCodeLabel_Click);
            // 
            // StateNameLabel
            // 
            StateNameLabel.AutoSize = true;
            StateNameLabel.Location = new System.Drawing.Point(472, 344);
            StateNameLabel.Name = "StateNameLabel";
            StateNameLabel.Size = new System.Drawing.Size(65, 13);
            StateNameLabel.TabIndex = 23;
            StateNameLabel.Text = "Department:";
            // 
            // Address1Label
            // 
            Address1Label.AutoSize = true;
            Address1Label.Location = new System.Drawing.Point(165, 344);
            Address1Label.Name = "Address1Label";
            Address1Label.Size = new System.Drawing.Size(61, 13);
            Address1Label.TabIndex = 17;
            Address1Label.Text = "Last Name:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new System.Drawing.Point(14, 344);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new System.Drawing.Size(60, 13);
            NameLabel.TabIndex = 16;
            NameLabel.Text = "First Name:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(283, 408);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 23);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.Location = new System.Drawing.Point(28, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(311, 369);
            this.txtAge.MaxLength = 20;
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(80, 20);
            this.txtAge.TabIndex = 26;
            this.txtAge.Tag = "Age";
            // 
            // cboDept
            // 
            this.cboDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(424, 369);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(150, 21);
            this.cboDept.TabIndex = 24;
            this.cboDept.Tag = "Department";
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboStates_SelectedIndexChanged);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(168, 369);
            this.txtLName.MaxLength = 50;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(119, 20);
            this.txtLName.TabIndex = 19;
            this.txtLName.Tag = "Last Name";
            this.txtLName.TextChanged += new System.EventHandler(this.txtLName_TextChanged);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(17, 369);
            this.txtFName.MaxLength = 50;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(119, 20);
            this.txtFName.TabIndex = 18;
            this.txtFName.Tag = "First Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(556, 318);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmAddModifyVendor
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnDelete;
            this.ClientSize = new System.Drawing.Size(586, 458);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(ZipCodeLabel);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(StateNameLabel);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(Address1Label);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(NameLabel);
            this.Controls.Add(this.txtFName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModifyVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Delete Employee";
            this.Load += new System.EventHandler(this.frmAddModifyVendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.ComboBox cboDept;
        internal System.Windows.Forms.TextBox txtLName;
        internal System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}