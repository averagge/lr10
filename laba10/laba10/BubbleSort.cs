using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class BubbleSort : IStrategy
    {
        public int iterationCount = 0;
        public Form1 form1;
        public Form2 form2;


        public BubbleSort(Form1 form1)
        {
            this.form1 = form1;
        }
        public BubbleSort(Form2 form2)
        {
            this.form2 = form2;
        }

        public int[] Algorithm(int[] mas)
        {
            iterationCount = 0;
            ComparativeAnalyses.Comparison = 0;
            ComparativeAnalyses.NumberOfPermutations = 0;
            IOFile.FillContent();
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    this.iterationCount++;
                    IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                    IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                    ComparativeAnalyses.Comparison++;
                    if (mas[i] > mas[j])
                    {
                        IOFile.InputInfoAboutTransposition(mas[i], mas[j]);
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                        ComparativeAnalyses.NumberOfPermutations++;
                        IOFile.FillContent();
                        if(form1!=null)
                            form1.AddItemsListBox(mas[i], mas[j]);
                    }
                }
            }
            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
            if (form1 != null)
                form1.Print(ComparativeAnalyses.Comparison, ComparativeAnalyses.NumberOfPermutations, elapsedTime);
            if (form2 != null)
                form2.Tab(ComparativeAnalyses.Comparison, ComparativeAnalyses.NumberOfPermutations, elapsedTime);
            return mas;
        }
    }

}
