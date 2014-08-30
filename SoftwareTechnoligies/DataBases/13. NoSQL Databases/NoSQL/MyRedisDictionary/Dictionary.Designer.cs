namespace MyRedisDictionary
{
    partial class Dictionary
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
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnFindWord = new System.Windows.Forms.Button();
            this.btnListAllWords = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(12, 12);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(260, 23);
            this.btnAddWord.TabIndex = 0;
            this.btnAddWord.Text = "Add New Word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnFindWord
            // 
            this.btnFindWord.Location = new System.Drawing.Point(12, 41);
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.Size = new System.Drawing.Size(260, 23);
            this.btnFindWord.TabIndex = 1;
            this.btnFindWord.Text = "Find Word";
            this.btnFindWord.UseVisualStyleBackColor = true;
            this.btnFindWord.Click += new System.EventHandler(this.btnFindWord_Click);
            // 
            // btnListAllWords
            // 
            this.btnListAllWords.Location = new System.Drawing.Point(12, 70);
            this.btnListAllWords.Name = "btnListAllWords";
            this.btnListAllWords.Size = new System.Drawing.Size(260, 23);
            this.btnListAllWords.TabIndex = 2;
            this.btnListAllWords.Text = "List All Words";
            this.btnListAllWords.UseVisualStyleBackColor = true;
            this.btnListAllWords.Click += new System.EventHandler(this.btnListAllWords_Click);
            // 
            // Dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 107);
            this.Controls.Add(this.btnListAllWords);
            this.Controls.Add(this.btnFindWord);
            this.Controls.Add(this.btnAddWord);
            this.Name = "Dictionary";
            this.Text = "Dictionary";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnFindWord;
        private System.Windows.Forms.Button btnListAllWords;
    }
}

