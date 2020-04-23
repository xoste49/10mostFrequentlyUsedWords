using System;
using System.Collections.Concurrent;
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
         // Считываем последний используемый путь
         if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastPath))
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.LastPath;
      }

      private ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();

      private void bOpenDirectory_Click(object sender, EventArgs e)
      {
         // Открываем диалог выбора папки
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            // Записываем путь к папке в настройки
            Properties.Settings.Default.LastPath = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
            foreach (string fileName in files)
            {
               // Считываем из файла
               try
               {
                  using (var sr = new StreamReader(fileName))
                  {
                     while (sr.Peek() >= 0)
                     {
                        var s = sr.ReadLine();
                        try
                        {
                           dict.TryUpdate(s, ++dict[s], dict[s]);
                        }
                        catch (System.Collections.Generic.KeyNotFoundException exception)
                        {
                           dict.TryAdd(s, 1);
                        }
                        catch (Exception exception)
                        {
                           MessageBox.Show(exception.Message);
                        }
                     }
                  }
               }
               catch (Exception exception)
               {
                  MessageBox.Show(exception.Message);
               }
            }

            MessageBox.Show("Готово");
         }


      }
   }
}
