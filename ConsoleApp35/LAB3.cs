using System;
using System.Diagnostics;
namespace Labaratory_3
{
    public class Program
    {
        public static void Main()
        {
          Variant4_1.Main_1();
          Console.WriteLine("---------------------");
          Variant4_2.Main_2();
          Console.WriteLine("---------------------");
          Variant4_2_2.Main_3();
          Console.WriteLine("---------------------");
          Variant4_3.Main_4();
          Console.WriteLine("---------------------");
          Programm.Main_5();
        }
        public class Variant4_1
        {
            public static void Main_1()
            {

                Console.Write("Enter elements of array: ");
                string[] input = Console.ReadLine().Split(' ');
                Console.Write("Enter the first index: ");
                int k = int.Parse(Console.ReadLine());
                Console.Write("Enter a second index: ");
                int t = int.Parse(Console.ReadLine());
                int[] array = AnnounceArray(input);
                DeleteElements(ref array, k, t);
                PrintArray(array);


            }

            public static int[] AnnounceArray(string[] Input)
            {
                int[] Arr = new int[Input.Length];
                for (int i = 0; i < Arr.Length; i++)
                {
                    Arr[i] = int.Parse(Input[i]);
                }

                return Arr;
            }
            public static void PrintArray(int[] arr)
            {
                foreach (var element in arr)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            public static int[] DeleteElements(ref int[] array, int k, int t)  // t = number of elements 
            {                                                         // k = started from the k-th element
                                                                      // size new array (if we have lenght of array which equals 10, we minus number of elements 
                int newSize = array.Length - t; // 10-3 = 7;

                int[] newArray = new int[newSize]; // The new array will equal 7

                for (int i = 0; i < k; i++)
                {
                    newArray[i] = array[i]; // This (for) uses for thing like make new array without space 
                }

                for (int i = k + t; i < array.Length; i++)
                {
                    newArray[i - t] = array[i]; // if newArray[4-3] = array[1] // 
                }

                array = newArray;
                return newArray;
            }
        }
        public class Variant4_2
        {
            static int GetSumOfDigits(int num)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += (num % 10);
                    num /= 10;
                }
                return sum;
            }

            static int CountOfMultiplies(int n, int i)
            {
                int sumOfDigits = GetSumOfDigits(i);
                return n / sumOfDigits;
            }


            static void PrintJagedArray(int[][] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"№{i}: ");
                    if (arr[i] == null)
                    {
                        i++;
                        Console.Write($"\n№{i}: ");
                    }
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write(arr[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }

            static void FillJaggedArray(int[][] jagArr)
            {
                int n = jagArr.Length;
                for (int i = 1; i < n; i++)
                {
                    jagArr[i] = new int[CountOfMultiplies(n, i)];
                    int sumOfDigits = GetSumOfDigits(i);
                    for (int j = sumOfDigits, idx = 0; j <= n; j += sumOfDigits)
                        jagArr[i][idx++] = j;
                }
            }
            public static void Main_2()
            {
                var currentProcess = Process.GetCurrentProcess();
                Console.WriteLine("Введіть n");
                int n = int.Parse(Console.ReadLine());
                int[][] jagArr = new int[n][];
                FillJaggedArray(jagArr);
                Console.WriteLine("Memory that used for program: {0} MB", currentProcess.PrivateMemorySize64 / 1024 / 1024);
                PrintJagedArray(jagArr);
            }

        }
        internal class Variant4_2_2
        {
            static int GetSumOfDigits(int num)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }

            static int CountOfMultiplies(int n, int i)
            {
                return n / i;
            }
            static void PrintArray(int[][] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"#{i}: ");
                    if (arr[i] == null)
                    {
                        i++;
                        Console.Write($"\n#{i}: ");
                    }
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write(arr[i][j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            static int GetMaxSum(int n)
            {
                int count = 0;
                int tmp = n;
                while (tmp > 9)
                {
                    tmp /= 10;
                    count++;
                }
                int sum1 = GetSumOfDigits(n);
                int sum2 = GetSumOfDigits((int)(tmp * Math.Pow(10, count)) - 1);
                if (sum1 < sum2)
                    return sum2;
                else return sum1;
            }
            static void FillIndexSumJagArray(int[][] indexSumJagArr, int n)
            {
                int l = indexSumJagArr.Length - 1;
                for (int i = 1; i <= l; i++)
                {
                    indexSumJagArr[i] = new int[CountOfMultiplies(n, i)];
                    for (int j = 1, idx = 0; j <= n; j++)
                        if (j % i == 0)
                            indexSumJagArr[i][idx++] = j;
                }
            }
            public static void Main_3()
            {
                var currentProcess = Process.GetCurrentProcess();
                Console.WriteLine("Введіть n");
                int n = int.Parse(Console.ReadLine());
                int l = GetMaxSum(n);
                int[][] indexSumJagArr = new int[l + 1][];
                int[][] jagArr = new int[n][];
                FillIndexSumJagArray(indexSumJagArr, n);
                for (int i = 0; i < n; i++)
                {
                    int digitsSum = GetSumOfDigits(i);
                    jagArr[i] = indexSumJagArr[digitsSum];
                }
                Console.WriteLine("Використана пам'ять: {0} MB", currentProcess.PrivateMemorySize64 / 1024 / 1024);
                if (jagArr.Length < 120) PrintArray(jagArr);

            }
        }
        internal class Variant4_3
        {
            public static void Main_4()
            {
                Console.Write("Enter count of jag array: ");
                int[][] jagArr = PrintJagArray.Input();
                jagArr.Resize();
            }

        }
    }
    public static class PrintJagArray
    {
        public static void Print(this int[][] jagArr)
        {
            foreach (var subArray in jagArr)
            {
                foreach (var element in subArray)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
        public static int[][] Input()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagArr = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Enter count of elements for row from {i} to ... ");
                string[] input = Console.ReadLine().Split(' ');
                jagArr[i] = new int[input.Length];
                for (int j = 0; j < jagArr[i].Length; j++)
                {
                    jagArr[i][j] = int.Parse(input[j]);
                }
            }
            return jagArr;
        }

    }
    public static class DeleteRows
    {
        public static void Resize(this int[][] jagArr)
        {
            Console.Write("Enter the fisrt {k} position: ");
            int k1 = int.Parse(Console.ReadLine());
            Console.Write("Enter a second {k} position: ");
            int k2 = int.Parse(Console.ReadLine());
            int remove = Remove(k1, k2);
            int[][] newArr = new int[jagArr.Length - remove][];
            int newIndex = 0;
            for (int i = 1; i < jagArr.Length; i++)
            {
                if (i < k1 || i > k2)
                {
                    newArr[newIndex] = jagArr[i];
                    newIndex++;
                }
            }

            jagArr = newArr;
            jagArr.Print();
        }

        private static int Remove(int k1, int k2)
        {
            return k2 - k1 + 1;
        }
    }
    class Programm
    {
        static void PrintListOfLists(List<List<int>> listOfLists)
        {
            foreach (var list in listOfLists)
            {
                foreach (var num in list)
                    Console.Write(num + " ");
                Console.WriteLine();
            }
        }
        static void FillMatrixListManual(List<List<int>> list, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                string[] tmp = Console.ReadLine().Trim().Split();
                var tmpList = new List<int>();
                for (int j = 0; j < cols; j++)
                    tmpList.Add(int.Parse(tmp[j]));
                list.Add(tmpList);
            }
        }
        static void FillMatrixListRandomly(List<List<int>> list, int rows, int cols)
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                List<int> tmp = new List<int>();
                for (int j = 0; j < cols; j++)
                    tmp.Add(rand.Next(0, 10));
                list.Add(tmp);
            }
        }

        static void FillListOfListsRandomly(List<List<int>> q, List<int> z)
        {
            for (int i = 0; i < z.Count; i++)
            {
                Random rand = new Random();
                List<int> tmp = new List<int>();
                for (int j = 0; j < z[i]; j++)
                    tmp.Add(rand.Next(0, 10));
                q.Add(tmp);
            }
        }
        public static void Main_5()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Size of matrix: ");
            int[] size = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var p = new List<List<int>>();
            var z = new List<int>();
            int rows = size[0];
            int cols = size[1];
            Console.WriteLine("0 - manual, other - random");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0) FillMatrixListManual(p, rows, cols);
            else FillMatrixListRandomly(p, rows, cols);

            Console.WriteLine("Introduced matrix: ");
            PrintListOfLists(p);

            foreach (var list in p)
            {
                int zeroIdx = list.LastIndexOf(0);
                if (zeroIdx == -1) z.Add(list.Count);
                else z.Add(zeroIdx + 1);
            }
            Console.WriteLine("\nArray Z: ");
            foreach (var item in z) Console.Write(item + " ");

            Console.WriteLine("\nArray Q: ");
            var q = new List<List<int>>();

            FillListOfListsRandomly(q, z);

            foreach (var list in q)
                list.Sort((a, b) => b.CompareTo(a));

            PrintListOfLists(q);
        }
    }
}

