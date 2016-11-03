﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
            var query = cars.OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Select(c => c)
                .First(c => c.Manufacturer == "BMW" && c.Year == 2016);
            Console.WriteLine($"{query.Name}:{query.Manufacturer}");

            //foreach (var item in query)
            //{
            //    Console.WriteLine($"{item.Name,-20} : {item.Combined}");
            //}
        }

        private static List<car> ProcessFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1) //pagination
                .Where(L => L.Length > 1)
                .Select(car.ParseFromCSV)
                .ToList();
        }
    }
}
