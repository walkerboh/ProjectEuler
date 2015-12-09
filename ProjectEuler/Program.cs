﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ProjectEuler.Problems;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select the problem you would like to run by problem number.\n");
            Console.WriteLine("Available Problems:");
            string @namespace = "ProjectEuler.Problems";
            List<string> classes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace.Equals(@namespace) && t.IsClass).Select(t => t.Name).ToList();
            classes.ForEach(c => Console.WriteLine(c));

            string problemNumber = "Problem" + Console.ReadLine();

            if (!classes.Contains(problemNumber))
                Console.WriteLine("BAD PROBLEM NUMBER - Please try again.");
            else
            {
                BaseProblem problem = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("ProjectEuler.Problems." + problemNumber)) as BaseProblem;
                TimeSpan duration = problem.Run();
                Console.WriteLine("Duration (in seconds): " + duration.TotalSeconds);
            }

            Console.ReadKey();
        }
    }
}
