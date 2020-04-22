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
            //välkomnar användaren
            Console.WriteLine("\n Du har öppnat Loves Kalkylator.");
            Thread.Sleep(1250);

            //loopar programmet så det inte slutar förränn användaren stänger ned det
            bool programRunning = true;
            while (programRunning)
            {
                Console.Clear();
                Console.WriteLine("\n Vad vill du räkna ut?");
                //presenterar 4 räknealternativ som användaren kan välja mellan
                Console.WriteLine(@"
    1:[+]   2:[-]
    3:[/]   4:[*]
");

                //ser till så användaren skriver en korrekt input
                bool successfulInput = false;

                //skapar inputInt och ger den en value för att undvika error vid tryparse
                int inputInt = 0;
                while (!successfulInput)
                {
                    Console.WriteLine("\n Svara gärna mellan alternativen 1, 2, 3 eller 4.");
                    string input = Console.ReadLine();

                    //om den inte lyckas konvertera till int så blir det error
                    if (!int.TryParse(input, out inputInt))
                    {
                        Console.WriteLine("\n Endast siffor, tack.");
                    }
                    //om den lyckas så kommer den kolla följande
                    else
                    {
                        //kollar så att det är siffror mellan 1-4
                        if (inputInt > 4 || inputInt < 1)
                        {
                            Console.WriteLine("Endast siffror mellan 1-4, tack.");
                        }
                        else
                        {
                            //avslutar loopen såvida allt är korrekt
                            successfulInput = true;
                        }
                    }
                }

                if (inputInt == 1)
                {

                    //boolar successfulAmount för att se så att användaren matar in ett giltigt antal tal som ska beräknas
                    bool successfulAmount = false;

                    //skapar amountInt och ger värdet 0 för att undvika error i tryparse
                    int amountInt = 0;

                    //loopar så att ifall användaren skriver fel så får den en till chans tills det blir rätt
                    while (successfulAmount == false)
                    {
                        Console.WriteLine("\n Hur många tal vill du addera?");
                        string input = Console.ReadLine();

                        //kollar så att det går att kovertera, om inte får användaren försöka igen
                        if (!int.TryParse(input, out amountInt))
                        {
                            Console.WriteLine("\n Endast siffor, tack.");
                        }
                        //om det lyckas görs följande
                        else
                        {
                            //ser till så att användaren skriver in att det ska vara minst ett tal, ser dock inte varför man skulle vilja addera endast ett tal med inget...
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

                    /*skapar en array med antalat platser som använderas har bestämt. Arrayen skapar jag för att det är det mest effektiva sättet att spara flera värden
                     samt så gör detta att jag kan ha ett antal tal som användaren bestämmer istället för att ha typ int1 int2 int3 int4 osv.*/
                    int[] amount = new int[amountInt];
                    Console.WriteLine("Vänligen skriv ut talen");

                    //Här så tar programmet input av de tal som användaren vill räkna ut 
                    for (int i = 0; i < amount.Length; i++)
                    {
                        //int num är här att i konsolen säga till användaren vilket tal den kommer skriva, syns nedan under while-loopen
                        int num = i + 1;

                        //loopar för att användaren ska skriva in korrekta inputs, och frågas igen om användaren skriver fel. 
                        bool success = false;

                        //skapar int element, där element är det tal som kommer ta angiven talposition i arrayen som användaren anger nedan. 
                        //element får även ett värde för att undvika error i tryparse
                        int element = 0;
                        while (success == false)
                        {
                            //den skriver ut vilken talposition det är man fyller i
                            Console.WriteLine("\n" + num + ":");
                            string input = Console.ReadLine();

                            //om den inte lyckas convertera input till ett tal-element så blir det fel
                            if (!int.TryParse(input, out element))
                            {
                                Console.WriteLine("Endast siffor, tack.");
                            }
                            else
                            { 
                                success = true;
                                //(styckes indelare endast:)
                                Console.WriteLine();
                            }
                        }

                        //lägger in elementet i arrayen för [i]-positionen
                        amount[i] = element;
                    }
                   
                    //hämtar en array som med parameterar sedan returnerar ett värde
                    int sum = SummarizePlus(amount);

                    //skriver ut summan och går tillbaka till starten
                    Console.WriteLine("Summan: " + sum);
                }

                else if (inputInt == 2)
                {
                    //loopar så att användaren skriver in en korrekt input
                    bool successfulAmount = false;

                    //skapar amountInt och ger ett värde för att undvika error i tryparse
                    int amountInt = 0;
                    while (!successfulAmount)
                    {
                        //ber om input för antalet tal, där första kommer vara ett startvärde
                        Console.WriteLine("\n Hur många tal vill du subtrahera? (OBS: första inmatningsvärdet är ditt startvärde!)");
                        string input = Console.ReadLine();

                        //kollar så att det går att det går att konvertera 
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
                    //skapar en array med lika många talpositioner som användaren angett
                    int[] amount = new int[amountInt];
                    Console.WriteLine("Vänligen skriv ut talen.");

                    //skapar en for-loop där användaren nu kommer att fylla i talen per talposition
                    for (int i = 0; i < amount.Length; i++)
                    {
                        //int num för att vägleda vilken talposition det är användaren fyller i, detta displayas i programmet när det körs
                        int num = i + 1;

                        //loopar så att inmatningarna blir korrekta
                        bool success = false;

                        //skapar int element som är de konverterade talen, dessa får till en början värde 0 för att undvika error i tryparse
                        int element = 0;
                        while (!success)
                        {

                            //displayar vilket tal man fyller i 
                            Console.WriteLine("\n" + num + ":");
                            string input = Console.ReadLine();

                            //försöker konvertera, om error får man försöka igen
                            if (!int.TryParse(input, out element))
                            {
                                Console.WriteLine("Endast siffor, tack.");
                            }
                            else
                            { 
                                success = true;
                                Console.WriteLine();
                            }
                        }

                        //fyller i det konverterade värdet element till amount arrayen i den position som for-loopen sitter i 
                        amount[i] = element;
                    }

                    //hämtar summan för det man räknat ut
                    int sum = SummarizeSub(amount);

                    //skriver ut summan
                    Console.WriteLine("Summan: " + sum);
                }

                else if (inputInt == 3)
                {

                }

                else if (inputInt == 4)
                {

                }

                Console.ReadLine();

            }
        }

        static int SummarizePlus(int[] amount)
        {
            //börjar med att skapa sum så att det kan adderas värden till Inten
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
            //för att första talet som användaren skriver in ska vara ett starttal så sätter jag först att sum = amount[0]
            int sum = amount[0];

            //här så börjar första uträkningen på i=1 istället för i=0, detta är för att unvika så att programmet inte subtraherar starttalet med sig själv 
            for (int i = 1; i < amount.Length; i++)
            {
                sum = sum - amount[i];
            }

            //returnerar sum
            return sum;
        }

    }
}


