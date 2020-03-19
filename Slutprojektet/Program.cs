using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vad heter jag?");

            string nameGuess = Console.ReadLine();

            Guess(nameGuess);

        }

        static void Guess(string solution)
        {
            if (solution == "love")
            {
                
            }
        }
    }
}

/*
 //
            Console.WriteLine("Vad heter jag? A: love B: axel");
            string answer = Console.ReadLine();

            string solution = Answer(solutionArray[0]);
            //

    static Array Answer()
        {
            string[] solutionArray = {"A", "B", "A", "C"};
        }
     
     */
