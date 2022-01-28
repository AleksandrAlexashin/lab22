using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object,int[]> func= new Func<object, int[]>(GetArray);
            Task<int[]> task = new Task<int[]>(func,n);
            Action<Task<int[]>> action = new Action<Task<int[]>>(SumMaxArray);
            Task task1 = task.ContinueWith(action);
            task.Start();
            Console.ReadKey();

        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i=0;i<n;i++)
            {
                array[i] = random.Next(0, 20);
                Console.Write("{0} ",array[i]);

            }
            return array;
            
        }
        static void SumMaxArray(Task<int[]> task)
        {
            int[] array = task.Result;
            int sum = 0;
            for (int i=0; i<array.Count(); i++)
            {
                sum += array[i];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чисел массива равна {0}",sum);
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max) max = a;
            }
            Console.WriteLine("Максимальное число массива равно {0}", max);


        }
      


    }
}
