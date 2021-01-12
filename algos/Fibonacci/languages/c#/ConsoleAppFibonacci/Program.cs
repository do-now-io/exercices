using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indicate max length :");

            var length = int.Parse(Console.ReadLine());
            var sequence = CalculFibonacciSequence(0, 1, length);

            Console.WriteLine(string.Join("\t", sequence));
        }

        private static List<int> CalculFibonacciSequence(int number1, int number2, int length){
           var sequence = new List<int>{number1};

           if(length > 0)
               sequence.AddRange(CalculFibonacciSequence(number2, number1+number2, length-1));
           
            return sequence;
        }
    }
}
