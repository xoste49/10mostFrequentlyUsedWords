﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10mostFrequentlyUsedWords
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void bOpenDirectory_Click(object sender, EventArgs e)
      {
         // Открываем диалог выбора папки
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
            string s;
            foreach (string fileName in files)
               s = fileName;
         }
      }
   }
}
