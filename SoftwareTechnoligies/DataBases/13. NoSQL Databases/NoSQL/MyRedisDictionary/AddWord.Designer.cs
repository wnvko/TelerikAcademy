namespace MyRedisDictionary
{
    partial class AddWord
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbMeaning = new System.Windows.Forms.TextBox();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Word:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Meaning:";
            // 
            // tbMeaning
            // 
            this.tbMeaning.Location = new System.Drawing.Point(76, 28);
            this.tbMeaning.Multiline = true;
            this.tbMeaning.Name = "tbMeaning";
            this.tbMeaning.Size = new System.Drawing.Size(196, 100);
            this.tbMeaning.TabIndex = 3;
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(76, 2);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(196, 20);
            this.tbWord.TabIndex = 1;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(15, 134);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(257, 23);
            this.btnAddWord.TabIndex = 4;
            this.btnAddWord.Text = "Add Word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // AddWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 170);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.tbMeaning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddWord";
            this.Text = "Add Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMeaning;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Button btnAddWord;
    }
}