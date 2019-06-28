using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTaskManager
{
    class Program
    {

        static void Main(string[] args)
        {
            var taskManager = new AsyncTaskManager(4);
            foreach (var task in CreateTasks())
            {
                taskManager.EnqueTask(task);
                task.Complete += HandleTaskComplete;
            }
            taskManager.Start();
            Console.ReadLine();
        }

        private static void HandleTaskComplete(object task, object result)
        {
            Console.WriteLine("Task {0} completed with result: {1}",
                (task as AsyncTask).Id,
                result
            );
        }

        private static IEnumerable<AsyncTask> CreateTasks()
        {
            yield return new AsyncTask(() =>
            {
                Thread.Sleep(2000);
                return "result 1";
            });

            yield return new AsyncTask(() =>
            {
                Thread.Sleep(7000);
                return "result 2";
            });

            yield return new AsyncTask(() =>
            {
                Thread.Sleep(4000);
                return "result 3";
            });
        }
    }
    
}
