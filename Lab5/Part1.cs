using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerExample
{
    class Program
    {
        static Queue<int> queue = new Queue<int>(); 
        static object lockObject = new object(); 

        static void Main(string[] args)
        {
            Thread producerThread = new Thread(new ThreadStart(Producer));
            Thread consumerThread = new Thread(new ThreadStart(Consumer));

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();

            Console.ReadKey();
        }

        static void Producer()
        {
            Random random = new Random();

            while (true)
            {
                int number = random.Next(1, 100); 

                lock (lockObject) 
                {
                    queue.Enqueue(number); 
                    Console.WriteLine($"Виробник: додано число {number} до черги");
                }

                Thread.Sleep(1000); 
            }
        }

        static void Consumer()
        {
            while (true)
            {
                int number;

                lock (lockObject) 
                {
                    if (queue.Count > 0) 
                    {
                        number = queue.Dequeue(); 
                        Console.WriteLine($"Споживач: взято число {number} з черги");
                    }
                }

                Thread.Sleep(1000); 
            }
        }
    }
}