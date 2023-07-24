
using System;
using System.Diagnostics;

namespace _24JulyAssignment
{
    class BubbleSort
    {
        static void Main()
        {
            int[] arr = GenerateRandomArray(10000);
            Console.WriteLine("Original array:");
            PrintArray(arr);

            BubbleSortAlgorithm(arr);
            Console.WriteLine("Sorted array:");
            PrintArray(arr);

            if (IsSorted(arr))
                Console.WriteLine("The array is sorted correctly.");
            else
                Console.WriteLine("The array is NOT sorted correctly.");

            // Performance analysis
            int[] sizes = { 100, 500, 5000, 10000 };
            foreach (int size in sizes)
            {
                int[] randomArray = GenerateRandomArray(size);
                long bubbleSortTime = MeasureSortingTime(BubbleSortAlgorithm, randomArray);

                Console.WriteLine($"Time taken to sort {size} elements using Bubble Sort: {bubbleSortTime} ms");
            }

            Console.ReadLine();
        }

        static void BubbleSortAlgorithm(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap the elements
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, the array is already sorted.
                if (!swapped)
                    break;
            }
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(1, 10000); // Generating random integers between 1 and 10000
            }
            return arr;
        }

        static bool IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static long MeasureSortingTime(Action<int[]> sortingAlgorithm, int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sortingAlgorithm(arr);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
