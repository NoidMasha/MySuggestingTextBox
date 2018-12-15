namespace MySuggestingTextBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBox = new MySuggestingTextBox.BaseTextBox(this);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(13, 99);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(70, 20);
            this.txtBox.TabIndex = 1;
            this.txtBox.Text = "Text";
            //*********************************************************************
            this.txtBox.ListLocation = new System.Drawing.Point(13, 119);
            this.txtBox.ListItems = new object[] {
            "sin",
            "cos",
            "tan",
            "cot",
            "arcsin",
            "arccos",
            "sinh",
            "cosh",
            "tanh",
            "coth" };
            this.txtBox.ListSize = new System.Drawing.Size(70, (this.txtBox.ListItemsCount+1)*this.txtBox.ListItemHighth);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "nav",
            "man",
            "tar"});
            this.listBox1.Location = new System.Drawing.Point(399, 358);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 500);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private BaseTextBox txtBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}

