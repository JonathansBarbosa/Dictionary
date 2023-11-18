using System;
using System.Collections.Generic;
using System.IO;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path)) //Abrir o caminho do arquivo
                {

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    while (!sr.EndOfStream) //Ler e separar o nome e votos 
                    {

                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int votes = int.Parse(votingRecord[1]);

                        if (dictionary.ContainsKey(candidate))
                        {
                            dictionary[candidate] += votes;
                        }
                        else
                        {
                            dictionary[candidate] = votes;
                        }
                    }

                    foreach (var item in dictionary) //Percorrer os itens armazenados
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

        }
    }
}