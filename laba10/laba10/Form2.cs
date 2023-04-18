using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba10
{
    public partial class Form2 : Form
    {
        private BubbleSort bubbleSort;
        private Shell shell;
        private Context context;
        private int[] range;
        private int comp;
        private int perm;
        private string time;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form1)
        {
            InitializeComponent();
            bubbleSort = new BubbleSort(this);
            shell = new Shell(this);

        }
        public void Tab(int c, int p, string t)
        {
            comp = c;
            perm = p;
            time = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int min = 1000;
            int max = 0;
            int j = 0;
            for (int i = 10; i <= 30; i += 10)
            {
                GenerateRandomArray(i);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = i;
                this.context = new Context(bubbleSort);
                context.ExecuteAlgorithm();
                dataGridView1.Rows[j].Cells[1].Value= "С: " + comp + "П: " + perm + "В: " + time;
                if (comp < min)
                {
                    min = comp;
                    label1.Text = "Лучший результат показала сортировка методом обмена с объемом выборки " + i + " количеством сравнений " + min;
                }

                if (comp > max)
                {
                    max = comp;
                    label2.Text = "Худший результат показала сортировка методом обмена с объемом выборки " + i + " количеством сравнений " + max;

                }
                ContArr();
                this.context = new Context(shell);
                context.ExecuteAlgorithm();
                dataGridView1.Rows[j].Cells[2].Value = "С: " + comp + "П: " + perm + "В: " + time;
                if (comp < min)
                {
                    min = comp;
                    label1.Text = "Лучший результат показала сортировка методом Шелла с объемом выборки " + i + " количеством сравнений " + min;

                }

                if (comp > max)
                {
                    max = comp;
                    label2.Text = "Худший результат показала сортировка методом Шелла с объемом выборки " + i + " количеством сравнений " + max;

                }
                j++;

            }

        }
        private void GenerateRandomArray(int size)
        {
            Context.array = new int[size];
            range = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                Context.array[i] = rand.Next(100);
                range[i] = Context.array[i];

            }

        }
        private void ContArr()
        {
            for (int i = 0; i < range.Length; i++)
            {
                Context.array[i] = range[i];
            }

        }
    }
}
