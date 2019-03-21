using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Core.Helpers
{
    /// <summary>
    /// Used for parallel computation and starting some threads to process items.
    /// <see cref="Task"/>
    /// <see cref="Parallel"/>
    /// </summary>
    public class TaskManager
    {
        /// <summary>
        /// Pallel computation using tasks <see cref="Task"/>.
        /// </summary>
        /// <typeparam name="T">WorkItem</typeparam>
        /// <param name="workItems">list</param>
        /// <param name="batch">count per batch</param>
        /// <param name="act">Action for list</param>
        public static void QueueWorkItemUsingTasks<T>(IEnumerable<T> workItems,
            int batch,
            Action<IEnumerable<T>> act)
            where T : class, new()
        {
            if (workItems == null || workItems.Count() == 0)
                throw new ArgumentNullException("Work items not allowed null or empty.");

            var total = workItems.Count();
            var pageCount = (total + batch - 1) / batch;

            var tasks = new List<Task>();
            for (int i = 0; i < pageCount; i++)
            {
                var pageIndex = i + 1;

                var items = workItems.Skip((pageIndex - 1) * batch).Take(batch);
                tasks.Add(Task.Run(() =>
                {
                    act.Invoke(items);
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }


        /// <summary>
        /// Pallel computation using parallel <see cref="Parallel"/>.
        /// </summary>
        /// <typeparam name="T">WorkItem</typeparam>
        /// <param name="workItems">list</param>
        /// <param name="batch">count per batch</param>
        /// <param name="act">Action for list</param>
        public static void QueueWorkItemsUsingParallel<T>(IEnumerable<T> workItems,
            int batch,
            Action<IEnumerable<T>> act)
            where T : class, new()
        {
            if (workItems == null || workItems.Count() == 0)
                throw new ArgumentNullException("Work items not allowed null or empty.");

            var total = workItems.Count();
            var pageCount = (total + batch - 1) / batch;

            var actions = new List<Action>();
            for (int i = 0; i < pageCount; i++)
            {
                var pageIndex = i + 1;

                var items = workItems.Skip((pageIndex - 1) * batch).Take(batch);
                actions.Add(() =>
                {
                    act.Invoke(items);
                });
            }

            Parallel.Invoke(actions.ToArray());
        }
    }
}
