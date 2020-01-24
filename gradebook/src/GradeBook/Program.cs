using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Wes's Gradebook");
            book.GradeAdded += OnGradeAdded;
            // .. loop
            while (true)
            {
                Console.WriteLine("\nEnter a Grade [or 'Q' to Quit]");
                var input = Console.ReadLine();
                if (input == "Q" || input == "q") {
                    break;
                } 
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("------------");
                }
            }
            
            var stats = book.GetStatistics();

            Console.WriteLine($"\nThe lowest grade is {stats.Low:N2}.");
            Console.WriteLine($"The highest grade is {stats.High:N2}.");
            Console.WriteLine($"The average grade is {stats.Average:N2}.");
            Console.WriteLine($"The average letter grade is {stats.Letter}.");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }

}
