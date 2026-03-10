using System;

namespace ExempluClase
{
    class Program
    {
        static void Main()
        {
            // --- Pasul 1: Preluare date de la tastatură ---
            Console.WriteLine("=== Pasul 1: Creare figură manuală ===");
            Console.Write("Introduceți denumirea figurii: ");
            string nume = Console.ReadLine();

            Console.Write("Introduceți numărul de laturi: ");
            if (int.TryParse(Console.ReadLine(), out int nr))
            {
                FiguraGeometrica f = new FiguraGeometrica(nume, nr);

                int[] laturi = new int[nr];

                for (int i = 0; i < nr; i++)
                {
                    Console.Write($"Dimensiune latura {i + 1}: ");

                    if (int.TryParse(Console.ReadLine(), out int valoare))
                        laturi[i] = valoare;
                    else
                        laturi[i] = 0;
                }

                f.SetDimensiuniLaturi(laturi);

                Console.WriteLine("\nRezultat manual:");
                Console.WriteLine(f.Info());
            }
            else
            {
                Console.WriteLine("Număr de laturi invalid!");
            }

            Console.WriteLine("\n-------------------------------------------");

            // --- Pasul 2: Joc - Generare automată de figuri ---
            Console.WriteLine("=== Pasul 2: Joc - Generare automată de figuri ===");

            Random rand = new Random();

            // Generăm 5 figuri aleatorii
            for (int i = 0; i < 5; i++)
            {
                int nrLaturiAleator = rand.Next(0, 8); // între 0 și 7

                // Denumire vidă conform cerinței
                FiguraGeometrica figuraJoc = new FiguraGeometrica(string.Empty, nrLaturiAleator);

                Console.WriteLine($"Figura {i + 1} generată (Laturi: {nrLaturiAleator}) -> {figuraJoc.TipFigura}");
                Console.WriteLine($"Detalii complete: {figuraJoc.Info()}");
            }

            Console.WriteLine("\nApăsați orice tastă pentru a închide...");
            Console.ReadKey();
        }
    }
}