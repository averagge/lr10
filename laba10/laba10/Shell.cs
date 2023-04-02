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
        public static Form1 form1;

        public int[] Algorithm(int[] mas)
        {

            IOFile.FillContent();
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            int j, step;
            int tmp;
            for (step = mas.Length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < mas.Length; i++)
                {
                    tmp = mas[i];
                    for (j = i; j >= step; j -= step)
                    {
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                        ComparativeAnalyses.Comparison++;
                        if (tmp < mas[j - step])
                        {
                            IOFile.InputInfoAboutTransposition(mas[i], mas[j]);
                            mas[j] = mas[j - step];
                            ComparativeAnalyses.NumberOfPermutations++;
                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[i], mas[j]);
                        }
                        else
                            break;
                    }
                    mas[j] = tmp;
                }
            }
            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
            form1.label1.Text = Convert.ToString(ComparativeAnalyses.Comparison);
            form1.label2.Text = Convert.ToString(ComparativeAnalyses.NumberOfPermutations);
            form1.label3.Text = elapsedTime;
            return mas;


        }
    }
}
