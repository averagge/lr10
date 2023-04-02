using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
