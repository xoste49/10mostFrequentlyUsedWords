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
         this.tbTopList = new System.Windows.Forms.TextBox();
         this.listBox1 = new System.Windows.Forms.ListBox();
         this.nMinLength = new System.Windows.Forms.NumericUpDown();
         this.lMinLength = new System.Windows.Forms.Label();
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
         // tbTopList
         // 
         this.tbTopList.Location = new System.Drawing.Point(12, 57);
         this.tbTopList.Multiline = true;
         this.tbTopList.Name = "tbTopList";
         this.tbTopList.ReadOnly = true;
         this.tbTopList.Size = new System.Drawing.Size(378, 188);
         this.tbTopList.TabIndex = 1;
         // 
         // listBox1
         // 
         this.listBox1.FormattingEnabled = true;
         this.listBox1.Location = new System.Drawing.Point(397, 57);
         this.listBox1.Name = "listBox1";
         this.listBox1.Size = new System.Drawing.Size(290, 186);
         this.listBox1.TabIndex = 2;
         // 
         // nMinLength
         // 
         this.nMinLength.Location = new System.Drawing.Point(339, 12);
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
         this.lMinLength.Location = new System.Drawing.Point(189, 14);
         this.lMinLength.Name = "lMinLength";
         this.lMinLength.Size = new System.Drawing.Size(144, 13);
         this.lMinLength.TabIndex = 4;
         this.lMinLength.Text = "Минимальная длина слова";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(704, 260);
         this.Controls.Add(this.lMinLength);
         this.Controls.Add(this.nMinLength);
         this.Controls.Add(this.listBox1);
         this.Controls.Add(this.tbTopList);
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
      private System.Windows.Forms.TextBox tbTopList;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.NumericUpDown nMinLength;
      private System.Windows.Forms.Label lMinLength;
   }
}

