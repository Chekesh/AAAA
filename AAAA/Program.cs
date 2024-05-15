using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAAA
{
    internal class Program
    {
        public delegate bool Logik(int i, int largest);
        static void Main(string[] args)
        {
            int[] mass = { 14, 2, 103, 5552,0, -1, -10, 5 };

            Console.WriteLine("Ввыедите < или >");
            string logica = Console.ReadLine();

            
            if (logica == ">")
            {
                Sort(mass, (i, largest) => { return mass[i] < mass[largest] ? true : false; });
                Vivod(mass);

            }
            else if (logica == "<")
            {
                Sort(mass, (i, largest) => { return mass[i] > mass[largest] ? true : false; });
                Vivod(mass);
            }
            else
            {
                Console.WriteLine("не праильно введенны данные");
            }
            Console.Read();
        }

        public static void swap(int i, int y, int[] mass)
        {
            int save = mass[i];
            mass[i] = mass[y];
            mass[y] = save;
        }

        public static void Vivod(int[] mass)
        {
            foreach (int i in mass)
            {
                Console.WriteLine(i);
            }
        }

        public static void Sort(int[] mass, Logik logik)
        {
            int n = mass.Length;

            for (int i = n / 2 - 1; i >= 0; i--)  
                Heapify(mass, n, i, logik);

            for (int i = n - 1; i >= 0; i--)
            {
                swap(0, i, mass);

                Heapify(mass, i, 0, logik);
            }
        }

        static void Heapify(int[] mass, int bypass, int i, Logik logik)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < bypass)
            {
                if (logik(left, largest)) { largest = left; }
            }

            if (right < bypass) { 
                if (logik(right, largest)) {  largest = right; }
            }

            if (largest != i)
            {
                swap(i, largest, mass);
                Heapify(mass, bypass, largest, logik);
            }
        }
    }
}
