namespace ToDoLL
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRating = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelDataOutput = new System.Windows.Forms.Label();
            this.buttonGetNext = new System.Windows.Forms.Button();
            this.textBoxWhat = new System.Windows.Forms.TextBox();
            this.textBoxWhy = new System.Windows.Forms.TextBox();
            this.labelWhat = new System.Windows.Forms.Label();
            this.labelWhy = new System.Windows.Forms.Label();
            this.labelWhatOutput = new System.Windows.Forms.Label();
            this.labelWhyOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter A Rating (1-5)";
            // 
            // textBoxRating
            // 
            this.textBoxRating.Location = new System.Drawing.Point(165, 65);
            this.textBoxRating.Name = "textBoxRating";
            this.textBoxRating.Size = new System.Drawing.Size(100, 20);
            this.textBoxRating.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(167, 177);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add To List";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelDataOutput
            // 
            this.labelDataOutput.AutoSize = true;
            this.labelDataOutput.Location = new System.Drawing.Point(154, 325);
            this.labelDataOutput.Name = "labelDataOutput";
            this.labelDataOutput.Size = new System.Drawing.Size(35, 13);
            this.labelDataOutput.TabIndex = 3;
            this.labelDataOutput.Text = "label2";
            this.labelDataOutput.Click += new System.EventHandler(this.labelDataOutput_Click);
            // 
            // buttonGetNext
            // 
            this.buttonGetNext.Location = new System.Drawing.Point(165, 247);
            this.buttonGetNext.Name = "buttonGetNext";
            this.buttonGetNext.Size = new System.Drawing.Size(96, 23);
            this.buttonGetNext.TabIndex = 4;
            this.buttonGetNext.Text = "Get Next Book";
            this.buttonGetNext.UseVisualStyleBackColor = true;
            this.buttonGetNext.Click += new System.EventHandler(this.buttonGetNext_Click);
            // 
            // textBoxWhat
            // 
            this.textBoxWhat.Location = new System.Drawing.Point(165, 103);
            this.textBoxWhat.Name = "textBoxWhat";
            this.textBoxWhat.Size = new System.Drawing.Size(100, 20);
            this.textBoxWhat.TabIndex = 5;
            // 
            // textBoxWhy
            // 
            this.textBoxWhy.Location = new System.Drawing.Point(165, 144);
            this.textBoxWhy.Name = "textBoxWhy";
            this.textBoxWhy.Size = new System.Drawing.Size(100, 20);
            this.textBoxWhy.TabIndex = 6;
            // 
            // labelWhat
            // 
            this.labelWhat.AutoSize = true;
            this.labelWhat.Location = new System.Drawing.Point(23, 106);
            this.labelWhat.Name = "labelWhat";
            this.labelWhat.Size = new System.Drawing.Size(65, 13);
            this.labelWhat.TabIndex = 7;
            this.labelWhat.Text = "Enter A Title";
            // 
            // labelWhy
            // 
            this.labelWhy.AutoSize = true;
            this.labelWhy.Location = new System.Drawing.Point(23, 147);
            this.labelWhy.Name = "labelWhy";
            this.labelWhy.Size = new System.Drawing.Size(82, 13);
            this.labelWhy.TabIndex = 8;
            this.labelWhy.Text = "Enter An Author";
            // 
            // labelWhatOutput
            // 
            this.labelWhatOutput.AutoSize = true;
            this.labelWhatOutput.Location = new System.Drawing.Point(154, 370);
            this.labelWhatOutput.Name = "labelWhatOutput";
            this.labelWhatOutput.Size = new System.Drawing.Size(35, 13);
            this.labelWhatOutput.TabIndex = 9;
            this.labelWhatOutput.Text = "label2";
            // 
            // labelWhyOutput
            // 
            this.labelWhyOutput.AutoSize = true;
            this.labelWhyOutput.Location = new System.Drawing.Point(154, 410);
            this.labelWhyOutput.Name = "labelWhyOutput";
            this.labelWhyOutput.Size = new System.Drawing.Size(35, 13);
            this.labelWhyOutput.TabIndex = 10;
            this.labelWhyOutput.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rating";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "1 is highest rating";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 517);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelWhyOutput);
            this.Controls.Add(this.labelWhatOutput);
            this.Controls.Add(this.labelWhy);
            this.Controls.Add(this.labelWhat);
            this.Controls.Add(this.textBoxWhy);
            this.Controls.Add(this.textBoxWhat);
            this.Controls.Add(this.buttonGetNext);
            this.Controls.Add(this.labelDataOutput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxRating);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRating;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelDataOutput;
        private System.Windows.Forms.Button buttonGetNext;
        private System.Windows.Forms.TextBox textBoxWhat;
        private System.Windows.Forms.TextBox textBoxWhy;
        private System.Windows.Forms.Label labelWhat;
        private System.Windows.Forms.Label labelWhy;
        private System.Windows.Forms.Label labelWhatOutput;
        private System.Windows.Forms.Label labelWhyOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}

