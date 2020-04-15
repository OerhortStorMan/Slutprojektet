using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Slutprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Du har öppnat Loves Kalkylator.");
            Thread.Sleep(1250);

            //loopar programmet
            bool programRunning = true;
            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine("\n Vad vill du räkna ut?");
                Console.WriteLine(@"
    1:[+]   2:[-]
    3:[/]   4:[*]
");

                //ser till så användaren skriver en korrekt input
                bool successfulInput = false;
                int inputInt = 0;
                while (successfulInput == false)
                {
                    Console.WriteLine("\n Svara gärna mellan alternativen 1, 2, 3 eller 4.");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out inputInt))
                    {
                        Console.WriteLine("\n Endast siffor, tack.");
                    }
                    else
                    {
                        //kollar så att det är siffror mellan 1-4
                        if (inputInt > 4 || inputInt < 1)
                        {
                            Console.WriteLine("Endast siffror mellan 1-4, tack.");
                        }
                        else
                        {
                            successfulInput = true;
                        }
                    }
                }

                if (inputInt == 1)
                {

                    //boolar successfulAmount för att se så att användaren matar in ett giltigt antal tal som ska beräknas
                    bool successfulAmount = false;
                    int amountInt = 0;
                    while (successfulAmount == false)
                    {
                        Console.WriteLine("\n Hur många tal vill du addera?");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out amountInt))
                        {
                            Console.WriteLine("\n Endast siffor, tack.");
                        }
                        else
                        {
                            if (amountInt < 1)
                            {
                                Console.WriteLine("Endast siffror över 1, tack.");
                            }
                            else
                            {
                                successfulAmount = true;
                            }
                        }
                    }

                    //skapar en array med antalat platser som använderas har bestämt
                    int[] amount = new int[amountInt];
                    Console.WriteLine("Vänligen skriv ut talen");

                    //Här så tar programmet input av de tal som användaren vill räkna ut
                    for (int i = 0; i != amountInt; i++)
                    {
                        int num = i + 1;

                        bool success = false;
                        int element = 0;
                        while (success == false)
                        {
                            Console.WriteLine("\n" + num + ":");
                            string input = Console.ReadLine();

                            //om den inte lyckas convertera input till ett tal-element så blir det fel
                            if (!int.TryParse(input, out element))
                            {
                                Console.WriteLine("\n Endast siffor, tack.");
                            }
                            else
                            {

                                success = true;
                                Console.WriteLine();

                            }
                        }

                        //lägger in elementet i arrayen
                        amount[i] = element;
                    }
                   
                    //hämtar en array som med parameterar returnerar sedan ett värde
                    int sum = SummarizePlus(amount);

                    Console.WriteLine("Summan: " + sum);

                }

                else if (inputInt == 2)
                {
                    bool successfulAmount = false;
                    int amountInt = 0;
                    while (successfulAmount == false)
                    {
                        //här så vill jag sätta att man matar in start värdet och sedan så är det = sum i SummarizeSub();
                        Console.WriteLine("\n Hur många tal vill du subtrahera? (notera att första inmatningsvärdet är ditt startvärde)");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out amountInt))
                        {
                            Console.WriteLine("\n Endast siffor, tack.");
                        }
                        else
                        {
                            if (amountInt < 1)
                            {
                                Console.WriteLine("\n Endast siffror över 1, tack.");
                            }
                            else
                            {
                                successfulAmount = true;
                            }
                        }
                    }

                    int[] amount = new int[amountInt];
                    Console.WriteLine("Vänligen skriv ut talen");

                    for (int i = 0; i != amountInt; i++)
                    {
                        int num = i + 1;

                        bool success = false;
                        int element = 0;
                        while (success == false)
                        {
                            Console.WriteLine("\n" + num + ":");
                            string input = Console.ReadLine();

                            if (!int.TryParse(input, out element))
                            {
                                Console.WriteLine("\n Endast siffor, tack.");
                            }
                            else
                            {

                                success = true;
                                Console.WriteLine();

                            }
                        }

                        amount[i] = element;
                    }

                    int sum = SummarizeSub(amount);

                    Console.WriteLine("Summan: " + sum);
                }

                else if (inputInt == 3)
                {

                }

                else if (inputInt == 4)
                {

                }

                Console.WriteLine("Success");
                Console.ReadLine();

            }
        }

        static int SummarizePlus(int[] amount)
        {
            //börjar med att ange sum
            int sum = 0;

            //för varje amount.Length så utför den ett arbete där den adderar ett tal från amount arrayen till sum
            for (int i = 0; i < amount.Length; i++)
            {
                
                sum = sum + amount[i];
            }

            //returnerar sum
            return sum;
        }

        static int SummarizeSub(int[] amount)
        {
            //för att första talet som användaren skriver in ska vara ett start tal (som ska vara positivt) så sätter jag först att sum = amount[0]
            int sum = amount[0];
            //här så börjar första uträkningen på i=1 istället för i=0, detta är för att unvika så att programmet inte subtraherar starttalet med sig själv 
            for (int i = 1; i < amount.Length; i++)
            {
                sum = sum - amount[i];
            }

            return sum;
        }

    }
}


