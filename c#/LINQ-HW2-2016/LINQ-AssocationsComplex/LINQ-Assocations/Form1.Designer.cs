namespace LINQ_Assocations
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
            this.buttonGetBirds = new System.Windows.Forms.Button();
            this.dataGridViewBirds = new System.Windows.Forms.DataGridView();
            this.buttonUpdateCount = new System.Windows.Forms.Button();
            this.textBoxNewCount = new System.Windows.Forms.TextBox();
            this.labelNewCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBirds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetBirds
            // 
            this.buttonGetBirds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonGetBirds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetBirds.Location = new System.Drawing.Point(155, 28);
            this.buttonGetBirds.Name = "buttonGetBirds";
            this.buttonGetBirds.Size = new System.Drawing.Size(257, 23);
            this.buttonGetBirds.TabIndex = 0;
            this.buttonGetBirds.Text = "Get Bird Data From SQL";
            this.buttonGetBirds.UseVisualStyleBackColor = false;
            this.buttonGetBirds.Click += new System.EventHandler(this.buttonGetBirds_Click);
            // 
            // dataGridViewBirds
            // 
            this.dataGridViewBirds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBirds.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewBirds.Name = "dataGridViewBirds";
            this.dataGridViewBirds.Size = new System.Drawing.Size(596, 326);
            this.dataGridViewBirds.TabIndex = 1;
            // 
            // buttonUpdateCount
            // 
            this.buttonUpdateCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonUpdateCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateCount.Location = new System.Drawing.Point(209, 456);
            this.buttonUpdateCount.Name = "buttonUpdateCount";
            this.buttonUpdateCount.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateCount.TabIndex = 2;
            this.buttonUpdateCount.Text = "Update SQL";
            this.buttonUpdateCount.UseVisualStyleBackColor = false;
            this.buttonUpdateCount.Click += new System.EventHandler(this.buttonUpdateCount_Click);
            // 
            // textBoxNewCount
            // 
            this.textBoxNewCount.Location = new System.Drawing.Point(199, 417);
            this.textBoxNewCount.Name = "textBoxNewCount";
            this.textBoxNewCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewCount.TabIndex = 4;
            this.textBoxNewCount.TextChanged += new System.EventHandler(this.textBoxNewCount_TextChanged);
            // 
            // labelNewCount
            // 
            this.labelNewCount.AutoSize = true;
            this.labelNewCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewCount.Location = new System.Drawing.Point(103, 461);
            this.labelNewCount.Name = "labelNewCount";
            this.labelNewCount.Size = new System.Drawing.Size(107, 13);
            this.labelNewCount.TabIndex = 5;
            this.labelNewCount.Text = "Update Counted: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Click in any row and then enter a new value for the counted here: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNewCount);
            this.Controls.Add(this.textBoxNewCount);
            this.Controls.Add(this.buttonUpdateCount);
            this.Controls.Add(this.dataGridViewBirds);
            this.Controls.Add(this.buttonGetBirds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBirds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetBirds;
        private System.Windows.Forms.DataGridView dataGridViewBirds;
        private System.Windows.Forms.Button buttonUpdateCount;
        private System.Windows.Forms.TextBox textBoxNewCount;
        private System.Windows.Forms.Label labelNewCount;
        private System.Windows.Forms.Label label1;
    }
}

