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
        private BubbleSort bubbleSort;
        private Shell shell;
/*        saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";*/
        public void Print(int comparison, int permut, string time)
        {
            label1.Text = Convert.ToString(comparison);
            label2.Text = Convert.ToString(permut);
            label3.Text = time;
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
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(bubbleSort);
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button1.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(shell);
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button1.Enabled = false;
                }
                IOFile.content = "";
            }
            else
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
