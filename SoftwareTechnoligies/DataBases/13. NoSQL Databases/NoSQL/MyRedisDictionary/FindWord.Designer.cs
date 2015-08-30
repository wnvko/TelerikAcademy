namespace MyRedisDictionary
{
    partial class FindWord
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
            this.tbWordToFind = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnFindWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Word to Find:";
            // 
            // tbWordToFind
            // 
            this.tbWordToFind.Location = new System.Drawing.Point(117, 12);
            this.tbWordToFind.Name = "tbWordToFind";
            this.tbWordToFind.Size = new System.Drawing.Size(155, 20);
            this.tbWordToFind.TabIndex = 1;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(15, 38);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(257, 182);
            this.tbResult.TabIndex = 2;
            // 
            // btnFindWord
            // 
            this.btnFindWord.Location = new System.Drawing.Point(12, 226);
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.Size = new System.Drawing.Size(260, 23);
            this.btnFindWord.TabIndex = 3;
            this.btnFindWord.Text = "Find Word";
            this.btnFindWord.UseVisualStyleBackColor = true;
            this.btnFindWord.Click += new System.EventHandler(this.BtnFindWord_Click);
            // 
            // FindWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnFindWord);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbWordToFind);
            this.Controls.Add(this.label1);
            this.Name = "FindWord";
            this.Text = "Find Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWordToFind;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnFindWord;
    }
}