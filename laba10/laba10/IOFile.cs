using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public class IOFile
    {
        public static string content;
        private Form1 form1;
        public static void FillContent()
        {
            foreach (var i in Context.array)
            {
                content += Convert.ToString(i) + ' ';
            }
            content += '\n';
        }
        public static string InputInfoAboutComparison(int first, int second)
        {
            content += "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static string InputInfoAboutTransposition(int first, int second)
        {
            content += "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static void SaveData()
        {
            /*if (form1.saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = form1.saveFileDialog1.FileName;
            System.IO.File.WriteAllText(path, IOFile.content);*/
        }
        public static void LoadData()
        {
            /*if (form1.openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = form1.openFileDialog1.FileName;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr);
                sr.Close();
            }*/
        }
        private static void Separator(StreamReader streamReader)
        {
            int CurrentFilePosition = 0;
            int TempMultiplicationResult = 0;
            int LoadedArrayElement = 0;
            int TempDigitCapacity = 0;
            while (streamReader.Peek() != -1)
            {
                if (streamReader.Peek() == 32)
                {
                    char[] vs = new char[2 * CurrentFilePosition];
                    streamReader.Read(vs, CurrentFilePosition, 1);
                    CurrentFilePosition++;
                }
                else if (streamReader.Peek() >= 48 && streamReader.Peek() <= 57)
                {
                    do
                    {
                        if (streamReader.Peek() == -1)
                        {
                            break;
                        }
                        /*streamReader.Read(listChar, CurrentFilePosition, 1);
                        int.TryParse(Convert.ToString(listChar[CurrentFilePosition]), out TempMultiplicationResult);
                        TempMultiplicationResult *= Convert.ToInt32(Math.Pow(10.0, TempDigitCapacity));
                        LoadedArrayElement += TempMultiplicationResult;
                        CurrentFilePosition++;
                        TempDigitCapacity++;*/
                    }
                    while (streamReader.Peek() != 32);
                    string output = new string(Convert.ToString(LoadedArrayElement).ToCharArray().Reverse().ToArray());
                    int.TryParse(output, out LoadedArrayElement);
/*                    arrayList.Add(Convert.ToString(LoadedArrayElement));
*/                    TempDigitCapacity = 0;
                    TempMultiplicationResult = 0;
                    LoadedArrayElement = 0;
                }
                else
                {
                    MessageBox.Show("Некорректный формат загружаемого файла.");
                    break;
                }
            }
            /*Context.array = new int[arrayList.Count];
            for (int k = 0; k < arrayList.Count; k++)
            {
                int.TryParse(arrayList[k], out Context.array[k]);
            }
            foreach (int j in Context.array)
            {
                content += Convert.ToString(j) + " ";
            }
            form1.listBox1.Items.Add(content);
            form1.listBox1.Items.Add("");*/
        }

    }


}
