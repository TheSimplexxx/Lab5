using System;
using System.Threading;

namespace QuickSortMultithreading
{
    class QuickSortMultithreading
    {
        private object lockObject = new object();

        public void Run()
        {
            int[] arr = new int[] { 5, 2, 6, 1, 3, 9, 4, 8, 7 };

            Console.WriteLine("Вхідний масив: " + string.Join(", ", arr));

            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Відсортований масив: " + string.Join(", ", arr));

            Console.ReadKey();
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                Thread leftThread = new Thread(() => QuickSort(arr, left, pivot - 1));
                Thread rightThread = new Thread(() => QuickSort(arr, pivot + 1, right));

                leftThread.Start();
                rightThread.Start();

                leftThread.Join();
                rightThread.Join();
            }
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private void Swap(int[] arr, int i, int j)
        {
            lock (lockObject)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QuickSortMultithreading quickSort = new QuickSortMultithreading();
            quickSort.Run();
        }
    }
}