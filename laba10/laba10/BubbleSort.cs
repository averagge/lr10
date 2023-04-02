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
        public static Form1 form1;

        public int[] Algorithm(int[] mas)
        {
            /*            if (flag)
                        {*/

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
            form1.label1.Text = Convert.ToString(ComparativeAnalyses.Comparison);
            form1.label2.Text = Convert.ToString(ComparativeAnalyses.NumberOfPermutations);
            form1.label3.Text = elapsedTime;
            return mas;
            /*}*/
        }
    }

}
