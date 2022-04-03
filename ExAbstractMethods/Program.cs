using System;
using System.Collections.Generic;
using ExAbstractMethods.Entities;
using System.Globalization;

namespace ExAbstractMethods
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            Console.Write("Enter the number of TAX PAYERS: ");
            int numPayers = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numPayers; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");
                Console.Write("Individual or Company (i/c): ");
                char answer = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (answer == 'i')
                {
                    Console.Write("Health Expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberEmployees));
                }
            }
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAX PLAYED: ");
            foreach(TaxPayer taxpayer in list)
            {
                double tax = taxpayer.Tax();
                Console.WriteLine(taxpayer.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }
            Console.WriteLine();
            Console.Write("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
