using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class Context
    {
        public IStrategy ContextStrategy;
        public static int[] array;
        public Context(IStrategy Strategy)
        {
            this.ContextStrategy = Strategy;
        }
        public Context() { }
        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm(array);
        }
    }

}
