using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converters.Helpers
{
    public class QueueManager<T> where T : class
    {
        static QueueManager<T> _queueManager;
        private Queue<T> _queue;

        protected QueueManager()
        {
            _queue = new Queue<T>();
        }

        public static QueueManager<T> GetInstance
        {
            get
            {
                return _queueManager ?? (_queueManager = new QueueManager<T>());
            }
        }

        public void Enqueue(T data)
        {
            _queue.Enqueue(data);
        }


        public T Dequeue()
        {

            return _queue.Dequeue();
        }

        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }

    }
}
