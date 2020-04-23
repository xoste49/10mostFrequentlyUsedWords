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
         this.tbTopList.Size = new System.Drawing.Size(378, 381);
         this.tbTopList.TabIndex = 1;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.tbTopList);
         this.Controls.Add(this.bOpenDirectory);
         this.Name = "MainForm";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button bOpenDirectory;
      private System.Windows.Forms.TextBox tbTopList;
   }
}

