using System;
using System.Threading;

namespace TrafficIntersection
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(2, 2);

        static object lockObject = new object(); 

        static int currentGreenLightIndex = 0; 

        static void Main(string[] args)
        {
            Thread trafficLight1Thread = new Thread(new ThreadStart(TrafficLight1));
            Thread trafficLight2Thread = new Thread(new ThreadStart(TrafficLight2));
            Thread trafficLight3Thread = new Thread(new ThreadStart(TrafficLight3));
            Thread trafficLight4Thread = new Thread(new ThreadStart(TrafficLight4));

            trafficLight1Thread.Start();
            trafficLight2Thread.Start();
            trafficLight3Thread.Start();
            trafficLight4Thread.Start();

            Console.ReadKey();
        }

        static void TrafficLight1()
        {
            while (true)
            {
                lock (lockObject) 
                {
                    if (currentGreenLightIndex == 0) 
                    {
                        Console.WriteLine("Світлофор 1: Зелений");
                        semaphore.WaitOne(); 
                        Thread.Sleep(5000); 
                        semaphore.Release(); 
                    }
                    else
                    {
                        Console.WriteLine("Світлофор 1: Червоний");
                    }
                }

                Thread.Sleep(1000); 
            }
        }

        static void TrafficLight2()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentGreenLightIndex == 1)
                    {
                        Console.WriteLine("Світлофор 2: Зелений");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                    {
                        Console.WriteLine("Світлофор 2: Червоний");
                    }
                }
                Thread.Sleep(1000);
            }
        }

        static void TrafficLight3()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentGreenLightIndex == 2)
                    {
                        Console.WriteLine("Світлофор 3: Зелений");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                    {
                        Console.WriteLine("Світлофор 3: Червоний");
                    }
                }

                Thread.Sleep(1000);
            }
        }

        static void TrafficLight4()
        {
            while (true)
            {
                lock (lockObject)
                {
                    if (currentGreenLightIndex == 3)
                    {
                        Console.WriteLine("Світлофор 4: Зелений");
                        semaphore.WaitOne();
                        Thread.Sleep(5000);
                        semaphore.Release();
                    }
                    else
                    {
                        Console.WriteLine("Світлофор 4: Червоний");
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
