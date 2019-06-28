using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTaskManager
{
    
    class AsyncTask
    {
        private static int counter = 1;

        public int Id { get; } = counter++;

        public event EventHandler<object> Complete;

        private readonly Func<object> taskBody;

        public AsyncTask(Func<object> taskBody)
        {
            this.taskBody = taskBody;
        }

        public void Run()//object
        {
            object result = taskBody();

            Complete?.Invoke(this, result);

            //return result;
        }
    }
}
