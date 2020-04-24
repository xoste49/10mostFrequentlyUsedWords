using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
         // Считываем последнее значение длины слова
         if (Properties.Settings.Default.MinLength != null) nMinLength.Value = Properties.Settings.Default.MinLength;
      }

      // Словарь (слово => кол-во)
      private ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
      // Колличество выводимых слов
      private int countPrint = 10;

      // Кнопка выбора папки
      private void bOpenDirectory_Click(object sender, EventArgs e)
      {
         // Регулярное выражение минимальной длины слова
         Regex regex = new Regex(@"^.{" + (int)nMinLength.Value + ",}$");
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
                        // Проверяем на пустую строку
                        if(string.IsNullOrWhiteSpace(s)) continue;
                        // Проверяем минимальную длину строки
                        if (!regex.IsMatch(s)) continue;
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

            // сортируем
            var sortdict = dict.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in sortdict)
            {
               tbTopList.Text += item.Key + " " + item.Value + Environment.NewLine;
               listBox1.Items.Add(item.Key + " " + item.Value);
               if(listBox1.Items.Count == countPrint) break;
            }

            MessageBox.Show("Готово!");
         }
      }

      private void nMinLength_ValueChanged(object sender, EventArgs e)
      {
         // Записываем изменения длины слова в настройки
         Properties.Settings.Default.MinLength = (int) nMinLength.Value;
         Properties.Settings.Default.Save();
      }
   }
}
