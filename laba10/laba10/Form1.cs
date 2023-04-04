﻿using System;
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
        private BubbleSort bubbleSort;
        private Shell shell;
        private IOFile iOFile;

        public void Print(int comparison, int permut, string time)
        {
            label1.Text = Convert.ToString(comparison);
            label2.Text = Convert.ToString(permut);
            label3.Text = time;
        }
        public void SaveData()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(path, IOFile.content);
        }
/*        public void LoadData()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = openFileDialog1.FileName;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr);
                sr.Close();
            }
        }*/
        private void Separator(StreamReader streamReader)
        {
            List<string> arrayList = new List<string>();
            char[] listChar = { };
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
                IOFile.content += Convert.ToString(j) + " ";
            }
            listBox1.Items.Add(IOFile.content);
            listBox1.Items.Add("");
        }
        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + ", ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + ", ";
                }
            }
            count++;
        }
        public Form1()
        {
            InitializeComponent();
            bubbleSort = new BubbleSort(this);
            shell = new Shell(this);
            iOFile = new IOFile(this);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            listBox1.Items.Clear();
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(bubbleSort);
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    SaveData();
/*                    button1.Enabled = false;
*/                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(shell);
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    SaveData();
/*                    button1.Enabled = false;
*/                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = openFileDialog1.FileName;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                Separator(sr);
                sr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int n = Convert.ToInt32(textBox1.Text);
            Context.array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < Context.array.Length; i++)
                Context.array[i] = rand.Next(1000);
            for (int i = 0; i < Context.array.Length; i++)
            {
                textBox2.Text += Convert.ToString(Context.array[i]);
                textBox2.Text += ", ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
    }
}
