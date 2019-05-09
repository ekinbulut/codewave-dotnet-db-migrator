using System.Collections.Generic;

namespace Converters.Helpers
{
    public class QueueManager<T> where T : class
    {
        static QueueManager<T> _queueManager;
        private readonly Queue<T> _queue;

        protected QueueManager()
        {
            _queue = new Queue<T>();
        }

        public static QueueManager<T> GetInstance => _queueManager ?? (_queueManager = new QueueManager<T>());

        public void Enqueue(T data)
        {
            _queue.Enqueue(data);
        }


        public T Dequeue()
        {

            return _queue.Dequeue();
        }

        public int Count => _queue.Count;
    }
}
