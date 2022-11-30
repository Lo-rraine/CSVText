using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CSVText
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = new List<string>();
            var lastName = new List<string>();
            var address = new List<string>();

            string path = @"C:\Users\lorrainem\Documents\Data.csv";
            string namesPath = @"C:\Users\lorrainem\Documents\NamesData.txt";
            string addressPath = @"C:\Users\lorrainem\Documents\AdressData.txt";

            //Read the Data.csv file
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var rowColumn = reader.ReadLine().Split(',');
                    firstName.Add(rowColumn[0]);
                    lastName.Add(rowColumn[1]);
                    address.Add(rowColumn[2]);
                }
                          

                //count of last name appearance
                var lastNamesQuery = from c in lastName
                                     group c by c into g
                                     where g.Count() > 1
                                     orderby g.Key
                                     select new { Item = g.Key, ItemCount = g.Count() };
                Console.WriteLine("First Name:");
                Console.WriteLine();


                using (StreamWriter sw = new StreamWriter(namesPath, append: true))
                {
                    sw.WriteLine("Last Name: ");
                }

                foreach (var i in lastNamesQuery)
                {
                    Console.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));

                    using (StreamWriter sw = new StreamWriter(namesPath, append: true))
                    {
                        sw.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));
                    }

                }
                Console.WriteLine();
                Console.WriteLine();



                //count of First name appearance
                var firstNamesQuery = from c in firstName
                                      group c by c into g
                                      where g.Count() > 0
                                      orderby g.Key
                                      select new { Item = g.Key, ItemCount = g.Count() };
                //orderby(g => g.Count()};

                Console.WriteLine("Last Name");
                Console.WriteLine();

                using (StreamWriter sw = new StreamWriter(namesPath, append: true))
                {
                    sw.WriteLine(" ");
                    sw.WriteLine("First Name: ");
                }

                foreach (var i in firstNamesQuery)
                {
                    Console.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));

                    using (StreamWriter sw = new StreamWriter(namesPath, append: true))
                    {
                        sw.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));
                    }

                }
                Console.WriteLine();
                Console.WriteLine();

                //address
                address.Sort();

                var ordered = address.Select(s => new { Str = s, Split = s.Split(' ') }).OrderBy(x => (x.Split[1])).Select(x => x.Str).ToList();

                Console.WriteLine("Address:");
                Console.WriteLine();

             
                using (StreamWriter sw = new StreamWriter(addressPath, append: true))
                {
                    sw.WriteLine("Address: ");
                }

                foreach (var i in ordered)
                {
                    Console.WriteLine(i.ToString());
                    using (StreamWriter sw1 = new StreamWriter(addressPath, append: true))
                    {
                        sw1.WriteLine(string.Format(i.ToString()));
                    }
                }

                //address.Sort();
                Console.ReadLine();
                Console.WriteLine("Files gerenarated!");
                Console.ReadLine();
            }

        }
    }
}