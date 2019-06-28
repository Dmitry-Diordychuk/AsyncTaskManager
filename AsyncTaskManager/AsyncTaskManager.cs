using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTaskManager
{
    class AsyncTaskManager
    {
        public int ThreadNum { get; set; }

        public ConcurrentQueue<AsyncTask> queue = new ConcurrentQueue<AsyncTask>();

        //private static AutoResetEvent evnt = new AutoResetEvent(true);

        public AsyncTaskManager(int concurrencyLevel)
        {
            ThreadNum = concurrencyLevel;
        }

        public void EnqueTask(AsyncTask task)
        {
            queue.Enqueue(task);
        }

        public bool Start()
        {
            for(int i = 0; i < ThreadNum; i++)
            {
                AsyncTask task;
                if(queue.TryDequeue(out task))
                {
                }
                else
                {
                    return false;
                }

                Thread thread = new Thread(new ThreadStart(task.Run));
                thread.Start();
            }
            return true;
        }
        // Потоки берут задачу из очереди и выполнют их
        
        


        
    }
}
