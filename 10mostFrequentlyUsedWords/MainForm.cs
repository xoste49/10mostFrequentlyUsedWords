using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
         if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastPath))
            folderBrowserDialog.SelectedPath = Properties.Settings.Default.LastPath;
         // Считываем последнее значение длины слова
         nMinLength.Value = Properties.Settings.Default.MinLength;
         // Регулярное выражение минимальной длины слова
         regex = new Regex(@"^.{" + (int)nMinLength.Value + ",}$");
      }

      // Словарь (слово => кол-во)
      private static ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
      // Колличество выводимых слов
      private static int countPrint = 10;
      // Регулярное выражение минимальной длины слова
      private static Regex regex;
      // Поток для чтения файлов
      Thread ReadFilesThread = new Thread(new ParameterizedThreadStart(ReadFiles));
      // Поток для сортировки
      Thread SortDictionaryThread;
      // Время работы
      Stopwatch stopWatch = new Stopwatch();

      // 52.10 секунд в одном потоке
      // 34.29 секунд с отдельным потоком чтения файлов
      // 32 секунды с отдельным потоком чтения файлов и сортировки
      // Кнопка выбора папки
      private void bOpenDirectory_Click(object sender, EventArgs e)
      {
         SortDictionaryThread = new Thread(SortDictionary);
         // Открываем диалог выбора папки
         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            stopWatch.Start();
            // Записываем путь к папке в настройки
            Properties.Settings.Default.LastPath = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            if (IsCheckEmptyFolder(folderBrowserDialog.SelectedPath)) return;
            if (IsCheckTxtFiles(folderBrowserDialog.SelectedPath)) return;

            ReadFilesThread.Start(folderBrowserDialog.SelectedPath);
            SortDictionaryThread.Start();

         }
      }

      // Чтение файлов
      private static void ReadFiles(object x)
      {
         string path = (string) x;
         string[] files = Directory.GetFiles(path, "*.txt");
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
                     if (string.IsNullOrWhiteSpace(s)) continue;
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
      }

      // Сортировка словаря
      private void SortDictionary()
      {
         // Флаг остановки потока чтения файлов
         bool IsStop = false;
         while (!IsStop)
         {
            Thread.Sleep(300);
            if (!ReadFilesThread.IsAlive) IsStop = true;
            Invoke(new MethodInvoker(() => { tbWords.Text = ""; }));
            Invoke(new MethodInvoker(() => { lbWords.Items.Clear(); }));
            ConcurrentDictionary<string, int> sortDictionary = new ConcurrentDictionary<string, int>(dict); // Копируем из-за проблем с доступностью
            var sortDict = sortDictionary.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var item in sortDict)
            {
               Invoke(new MethodInvoker(() => { tbWords.Text += item.Key + " " + item.Value + Environment.NewLine; }));
               Invoke(new MethodInvoker(() => { lbWords.Items.Add(item.Key + " " + item.Value); }));
               if (lbWords.Items.Count == countPrint) break;
            }
         }

         endWork();
      }

      // Проверка пустой папки
      private bool IsCheckEmptyFolder(string path)
      {
         if (Directory.GetFiles(path).Length == 0)
         {
            MessageBox.Show("Папка пуста!");
            return true;
         }

         return false;
      }

      // Проверка на присутствие txt файлов
      private bool IsCheckTxtFiles(string path)
      {
         if (Directory.GetFiles(path, "*.txt").Length == 0)
         {
            MessageBox.Show("txt файлы отсутствуют!");
            return true;
         }

         return false;
      }

      private void nMinLength_ValueChanged(object sender, EventArgs e)
      {
         // Записываем изменения длины слова в настройки
         Properties.Settings.Default.MinLength = (int)nMinLength.Value;
         Properties.Settings.Default.Save();
         // Регулярное выражение минимальной длины слова
         regex = new Regex(@"^.{" + (int)nMinLength.Value + ",}$");
      }

      // Метод вызова окончания работы потоков
      private void endWork()
      {
         TimeSpan ts = stopWatch.Elapsed;
         string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

         stopWatch.Stop();
         Invoke(new MethodInvoker(() => { MessageBox.Show("Готово! RunTime " + elapsedTime); }));
      }
   }
}
