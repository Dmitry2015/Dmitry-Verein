namespace BirdDataAdapter
{
    partial class Form1
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
            this.DataGridViewBirds = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonReadXML = new System.Windows.Forms.Button();
            this.buttonImportData = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.DataGridViewXML = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBirds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewXML)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewBirds
            // 
            this.DataGridViewBirds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewBirds.Location = new System.Drawing.Point(22, 296);
            this.DataGridViewBirds.Name = "DataGridViewBirds";
            this.DataGridViewBirds.Size = new System.Drawing.Size(693, 217);
            this.DataGridViewBirds.TabIndex = 0;
            this.DataGridViewBirds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBirds_CellContentClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(116, 550);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(122, 32);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(326, 550);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(122, 32);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonReadXML
            // 
            this.buttonReadXML.Location = new System.Drawing.Point(55, 249);
            this.buttonReadXML.Name = "buttonReadXML";
            this.buttonReadXML.Size = new System.Drawing.Size(139, 42);
            this.buttonReadXML.TabIndex = 4;
            this.buttonReadXML.Text = "ReadXML";
            this.buttonReadXML.UseVisualStyleBackColor = true;
            this.buttonReadXML.Click += new System.EventHandler(this.buttonReadXML_Click);
            // 
            // buttonImportData
            // 
            this.buttonImportData.Location = new System.Drawing.Point(505, 253);
            this.buttonImportData.Name = "buttonImportData";
            this.buttonImportData.Size = new System.Drawing.Size(159, 38);
            this.buttonImportData.TabIndex = 5;
            this.buttonImportData.Text = "ImportData";
            this.buttonImportData.UseVisualStyleBackColor = true;
            this.buttonImportData.Click += new System.EventHandler(this.buttonImportData_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(529, 547);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(147, 35);
            this.buttonDeleteRow.TabIndex = 6;
            this.buttonDeleteRow.Text = "DeleteRow";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // DataGridViewXML
            // 
            this.DataGridViewXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewXML.Location = new System.Drawing.Point(22, 21);
            this.DataGridViewXML.Name = "DataGridViewXML";
            this.DataGridViewXML.Size = new System.Drawing.Size(693, 211);
            this.DataGridViewXML.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 613);
            this.Controls.Add(this.DataGridViewXML);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonImportData);
            this.Controls.Add(this.buttonReadXML);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.DataGridViewBirds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBirds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewBirds;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonReadXML;
        private System.Windows.Forms.Button buttonImportData;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.DataGridView DataGridViewXML;
    }
}

