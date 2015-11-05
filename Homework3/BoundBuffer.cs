using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework3
{
    class BoundBuffer<T> {
        private const long MaxQueueSize = (Constants.UpperBound - Constants.LowerBound);
        private Queue<T> _queue = new Queue<T>();
        private List<long> List = new List<long>();
   

        public void Add (long item)
          {

             lock (List) {
                while (List.Count >= MaxQueueSize) {
                    Monitor.Wait(List);
                }
                List.Add(item);
                Monitor.Pulse(List);
            }
            //Monitor.Exit(_queue);
        }
        
   
      public List <long> GetList()
       {
         return List; 
       
       }
        public Queue<T> GetQueue()
       {
         return _queue; 
       
       }
        public void SetList(List<long> _List)
        {
         List =  _List; 
        }
     public void SetQueue(Queue<T> NewQueue){
         _queue = NewQueue;
     }

        public void Enqueue(T item) {
            //Monitor.Enter(_queue);
            lock (_queue) {
                while (_queue.Count >= MaxQueueSize) {
                    Monitor.Wait(_queue);
                }
                _queue.Enqueue(item);
                Monitor.Pulse(_queue);
            }
            //Monitor.Exit(_queue);
        }

        public T Dequeue() {
            try {
                Monitor.Enter(_queue);
                while (_queue.Count == 0) {
                    Monitor.Wait(_queue);
                }
                var item = _queue.Dequeue();
                Monitor.Pulse(_queue);
                return item;
            } finally {
                Monitor.Exit(_queue);
            }
        }
    }
}
 
    
