using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Dnc.Structures
{
    public class IOQueue
        : IQueue
    {
        #region Private members.
        private readonly ConcurrentQueue<Work> _workItems = new ConcurrentQueue<Work>();
        private static readonly WaitCallback _waitCallback = s => ((IOQueue)s).DoWork();
        private static readonly object _workSync = new object();
        private bool mIsDoing; 
        #endregion

        public void Enqueue(Action<object> callback,object state)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            var workItem = new Work()
            {
                State = state,
                Callback = callback
            };
            _workItems.Enqueue(workItem);

            if (!mIsDoing)
            {
                lock (_workSync)
                {
                    if (!mIsDoing)
                    {
                        ThreadPool.UnsafeQueueUserWorkItem(_waitCallback, this);
                        mIsDoing = true;
                    }
                }
            }
        }

        public void DoWork()
        {
            while (true)
            {
                while (_workItems.TryDequeue(out var item))
                {
                    item.Callback(item.State);
                }
                if (_workItems.IsEmpty)
                {
                    lock (_workSync)
                    {
                        if (_workItems.IsEmpty)
                        {
                            mIsDoing = false;
                            return;
                        }
                    }
                }
            }
        }
    }
}
