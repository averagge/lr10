using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class Shell: IStrategy
    {
        public int iterationCount = 0;
        public Form1 form1;
        public Form2 form2;


        public Shell(Form1 form1)
        {
            this.form1 = form1;
        }
        public Shell(Form2 form2)
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
            int n = mas.Length;
            int gap = n / 2;
            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = mas[i];
                    int j = i;
                    while (j >= gap)
                    {
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[j - gap], temp);
                        ComparativeAnalyses.Comparison++;
                        if (mas[j - gap] > temp)
                        {
                            IOFile.InputInfoAboutTransposition(mas[j - gap], mas[j]);
/*                            ComparativeAnalyses.NumberOfPermutations++;
                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[j], mas[j - gap]);*/
                            mas[j] = mas[j - gap];
                            j -= gap;
                            mas[j] = temp;
                            ComparativeAnalyses.NumberOfPermutations++;
                            IOFile.FillContent();
                            if(form1!=null)
                                form1.AddItemsListBox(mas[j], mas[j + gap]);

                        }
                        else
                            j -= gap;
                    }
                }
                gap /= 2;
            }
            
            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
            if(form1!=null)
                form1.Print(ComparativeAnalyses.Comparison, ComparativeAnalyses.NumberOfPermutations, elapsedTime);
            if (form2 != null)
                form2.Tab(ComparativeAnalyses.Comparison, ComparativeAnalyses.NumberOfPermutations, elapsedTime);
            return mas;
        }
    }
}
