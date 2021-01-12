using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppLuhnAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            InitApp();
        }

        private static void InitApp(){
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Welcome to DoNow's credit card verification system !");
            Console.WriteLine("To start you need to choose the method of obtaining your sequence to check");
            Console.WriteLine("1 - Automatic sequence generation");
            Console.WriteLine("2 - Manual sequence generation");
            Console.WriteLine("q - Quit");

             ApplyChoice(Console.ReadLine());
        }
        private static void ApplyChoice(string choice){
            switch(choice){
                case "1": GenerateAutomaticSequence();
                break;
                case "2" : GenerateManualSequence();
                break;
                case "q" : CloseApp();
                break;
                default: InitApp();
                break;
            }
        }
        private static void GenerateManualSequence() {
            Console.WriteLine("Fill in your sequence and separate each number with a comma :");
            var sequence = new List<int>();
            var strSequenceArray = Console.ReadLine().Trim().Split(",");
            foreach(var strValue in strSequenceArray){
                if(int.TryParse(strValue, out var x) && x < 10) 
                    sequence.Add(x);
                else
                {
                    Console.WriteLine("Error while inserting");
                    GenerateManualSequence();
                } 
            } 
            CalculateDoubles(sequence);
        }

        private static int GenerateAutomaticSequence(){
            Console.WriteLine("Please indicate the range of digits to add to the sequence :");

            Random rnd = new Random();
            var sequence = new List<int>();
            var range = int.TryParse(Console.ReadLine(), out int r) ? r : GenerateAutomaticSequence();

            for (int i = 0; i < range; i++) 
                sequence.Add(rnd.Next(1, 9));

            CalculateDoubles(sequence);

            return range;
        }


        private static void CalculateDoubles(List<int>sequence){
            Console.WriteLine(string.Join("\t", sequence));

            sequence.RemoveAt(sequence.Count - 1);
            
            for(var i=sequence.Count-1; i >= 0; i = i-2) {
                var number = sequence[i] * 2;
                sequence[i] = number >= 10 ? GetSplitSum(number) : number; 
            }
            
            Console.WriteLine(string.Join("\t", sequence));

            ApplyResult(sequence);
        }

        private static void ApplyResult( List<int>sequence){
            var sequenceSum = sequence.Sum();
            var mod10 = sequenceSum % 10 ;
            Console.WriteLine(sequenceSum +" % 10 = "+mod10);
            Console.WriteLine( "The sequence is " + (mod10 == 0 ? "valid" : "invalid"));
            InitApp();
        }
        private static int GetSplitSum(int value){

            var valuesIntArray = new List<int>();
            value.ToString().Select(x=> int.Parse(x.ToString())).ToList().ForEach(delegate(int val){
                valuesIntArray.Add(val);
            });
            return valuesIntArray.Sum();
        }
        private static void CloseApp(){
            Console.WriteLine("GoodBye !");
            System.Environment.Exit(0);  
        }
    }
}
