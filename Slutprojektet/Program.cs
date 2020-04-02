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
            Console.WriteLine("\n Du har öppnat Loves Kalkylator.");
            bool programRunning = true;
            while (programRunning)
            {

                Console.WriteLine("\n Vad vill du räkna ut?");
                Console.WriteLine(@"
    1:[+]   2:[-]
    3:[/]   4:[*]
");
                //bool success = int.TryParse(input, out int converted);

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

                    int sum = SummarizePlus(amount);

                    Console.WriteLine(sum);

                    Console.WriteLine(amount[0] + " " + amount[3]);

                }

                else if (inputInt == 2)
                {

                }

                else if (inputInt == 3)
                {

                }

                else if (inputInt == 4)
                {

                }

                Console.WriteLine("success");
                Console.ReadLine();

            }
        }

        static int SummarizePlus(int[] amount)
        {
            int sum = 0;
            for (int i = 0; i < amount.Length; i++)
            {
                sum = sum + amount[i];
            }

            return sum;
        }

        /*static int Plus()
        {
            //(multiplicerar pris med antal och returnerar total pris
        }


        //parametrar skadar min hjärna, fattar *0**/
    }
}


