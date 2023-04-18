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

        public Shell(Form1 form1)
        {
            this.form1 = form1;
        }
        public int[] Algorithm(int[] mas)
        {

            IOFile.FillContent();
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
/*            int j, step;
            int tmp;*/
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
                        IOFile.InputInfoAboutComparison(temp, mas[j-gap]);
                        ComparativeAnalyses.Comparison++;
                        if (mas[j - gap] > temp)
                        {
                            IOFile.InputInfoAboutTransposition(mas[j], mas[j - gap]);
                            ComparativeAnalyses.NumberOfPermutations++;
                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[j], mas[j - gap]);
                            mas[j] = mas[j - gap];
                            j -= gap;
                            mas[j] = temp;


                        }
                        else
                            j -= gap;
                    }
/*                    mas[j] = temp;
*/                }
                gap /= 2;
            }
            
            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
            form1.Print(ComparativeAnalyses.Comparison, ComparativeAnalyses.NumberOfPermutations, elapsedTime);

/*            form1.label1.Text = Convert.ToString(ComparativeAnalyses.Comparison);
            form1.label2.Text = Convert.ToString(ComparativeAnalyses.NumberOfPermutations);
            form1.label3.Text = elapsedTime;*/
            return mas;


        }
    }
}
