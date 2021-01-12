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
            Console.WriteLine("Bienvenue sur le système de vérification de carte bancaire de DoNow !");
            Console.WriteLine("Pour commencer il vous faut choisir la méthode d'obtention de votre séquence à vérifier");
            Console.WriteLine("1 - Test d'une séquence automatique");
            Console.WriteLine("2 - Test d'une séquence manuelle");
            Console.WriteLine("q - Quitter");

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
            Console.WriteLine("Renseignez votre séquence et séparez chaque chiffre par une virgule :");
            var sequence = new List<int>();
            var strSequenceArray = Console.ReadLine().Trim().Split(",");
            foreach(var strValue in strSequenceArray){
                if(int.TryParse(strValue, out var x) && x < 10) 
                    sequence.Add(x);
                else
                {
                    Console.WriteLine("Erreur lors de la saisie");
                    GenerateManualSequence();
                } 
            } 
            CalculateDoubles(sequence);
        }

        private static int GenerateAutomaticSequence(){
            Console.WriteLine("Veuillez indiquer le nombre de chiffre à ajouter à la séquence :");

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
            Console.WriteLine( "La séquence est " + (mod10 == 0 ? "valide" : "invalide"));
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
            Console.WriteLine("GoodBye");
            System.Environment.Exit(0);  
        }
    }
}
