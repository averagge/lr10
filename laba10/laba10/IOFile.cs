using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class IOFile
    {
        public static string content;
        public static void FillContent()
        {
            foreach (var i in Context.array)
            {
                content += Convert.ToString(i) + ' ';
            }
            content += '\n';
        }
        public static string InputInfoAboutComparison(int first, int second)
        {
            content += "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Сравниваем " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
        public static string InputInfoAboutTransposition(int first, int second)
        {
            content += "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
            return "Перестановка " + Convert.ToString(first) + " и " + Convert.ToString(second) + '\n';
        }
    }
    

}
