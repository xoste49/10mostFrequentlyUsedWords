namespace _10mostFrequentlyUsedWords
{
   partial class MainForm
   {
      /// <summary>
      /// Обязательная переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
         this.bOpenDirectory = new System.Windows.Forms.Button();
         this.lbWords = new System.Windows.Forms.ListBox();
         this.nMinLength = new System.Windows.Forms.NumericUpDown();
         this.lMinLength = new System.Windows.Forms.Label();
         this.labelList = new System.Windows.Forms.Label();
         this.tbWords = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.nMinLength)).BeginInit();
         this.SuspendLayout();
         // 
         // folderBrowserDialog
         // 
         this.folderBrowserDialog.ShowNewFolderButton = false;
         // 
         // bOpenDirectory
         // 
         this.bOpenDirectory.Location = new System.Drawing.Point(12, 12);
         this.bOpenDirectory.Name = "bOpenDirectory";
         this.bOpenDirectory.Size = new System.Drawing.Size(97, 23);
         this.bOpenDirectory.TabIndex = 0;
         this.bOpenDirectory.Text = "Открыть папку";
         this.bOpenDirectory.UseVisualStyleBackColor = true;
         this.bOpenDirectory.Click += new System.EventHandler(this.bOpenDirectory_Click);
         // 
         // lbWords
         // 
         this.lbWords.FormattingEnabled = true;
         this.lbWords.Location = new System.Drawing.Point(12, 79);
         this.lbWords.Name = "lbWords";
         this.lbWords.Size = new System.Drawing.Size(204, 186);
         this.lbWords.TabIndex = 2;
         // 
         // nMinLength
         // 
         this.nMinLength.Location = new System.Drawing.Point(305, 15);
         this.nMinLength.Name = "nMinLength";
         this.nMinLength.Size = new System.Drawing.Size(120, 20);
         this.nMinLength.TabIndex = 3;
         this.nMinLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
         this.nMinLength.ValueChanged += new System.EventHandler(this.nMinLength_ValueChanged);
         // 
         // lMinLength
         // 
         this.lMinLength.AutoSize = true;
         this.lMinLength.Location = new System.Drawing.Point(155, 17);
         this.lMinLength.Name = "lMinLength";
         this.lMinLength.Size = new System.Drawing.Size(144, 13);
         this.lMinLength.TabIndex = 4;
         this.lMinLength.Text = "Минимальная длина слова";
         // 
         // labelList
         // 
         this.labelList.AutoSize = true;
         this.labelList.Location = new System.Drawing.Point(9, 63);
         this.labelList.Name = "labelList";
         this.labelList.Size = new System.Drawing.Size(190, 13);
         this.labelList.TabIndex = 5;
         this.labelList.Text = "10 самых часто используемых слов";
         // 
         // tbWords
         // 
         this.tbWords.Location = new System.Drawing.Point(222, 79);
         this.tbWords.Multiline = true;
         this.tbWords.Name = "tbWords";
         this.tbWords.ReadOnly = true;
         this.tbWords.Size = new System.Drawing.Size(204, 186);
         this.tbWords.TabIndex = 6;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(437, 278);
         this.Controls.Add(this.tbWords);
         this.Controls.Add(this.labelList);
         this.Controls.Add(this.lMinLength);
         this.Controls.Add(this.nMinLength);
         this.Controls.Add(this.lbWords);
         this.Controls.Add(this.bOpenDirectory);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "MainForm";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.nMinLength)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button bOpenDirectory;
      private System.Windows.Forms.ListBox lbWords;
      private System.Windows.Forms.NumericUpDown nMinLength;
      private System.Windows.Forms.Label lMinLength;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.TextBox tbWords;
    }
}

