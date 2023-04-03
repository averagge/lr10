using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public partial class Form1 : Form
    {
        private Context context;
        public int count;

        public static void LoadData()
        {
            if (form1.openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = form1.openFileDialog1.FileName;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr);
                sr.Close();
            }
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
                        streamReader.Read(listChar, CurrentFilePosition, 1);
                        int.TryParse(Convert.ToString(listChar[CurrentFilePosition]), out TempMultiplicationResult);
                        TempMultiplicationResult *= Convert.ToInt32(Math.Pow(10.0, TempDigitCapacity));
                        LoadedArrayElement += TempMultiplicationResult;
                        CurrentFilePosition++;
                        TempDigitCapacity++;
                    }
                    while (streamReader.Peek() != 32);
                    string output = new string(Convert.ToString(LoadedArrayElement).ToCharArray().Reverse().ToArray());
                    int.TryParse(output, out LoadedArrayElement);
                    arrayList.Add(Convert.ToString(LoadedArrayElement));
                    TempDigitCapacity = 0;
                    TempMultiplicationResult = 0;
                    LoadedArrayElement = 0;
                }
                else
                {
                    MessageBox.Show("Некорректный формат загружаемого файла.");
                    break;
                }
            }
            Context.array = new int[arrayList.Count];
            for (int k = 0; k < arrayList.Count; k++)
            {
                int.TryParse(arrayList[k], out Context.array[k]);
            }
            foreach (int j in Context.array)
            {
                content += Convert.ToString(j) + " ";
            }
            form1.listBox1.Items.Add(content);
            form1.listBox1.Items.Add("");
        }


        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(new BubbleSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
/*                    IOFile.SaveData();
*/                    button1.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    /*this.context = new Context(new ShellSort());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    buttonSort.Enabled = false;*/
                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }

        }

    }
}
