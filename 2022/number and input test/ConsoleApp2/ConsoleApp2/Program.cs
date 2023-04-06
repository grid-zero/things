	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Welcome to a Simple calculator\n Please enter all values with a zero infront of them");
			List<int> numbs = new List<int>();
			var sum = 0;

			while (Console.ReadKey().Key != ConsoleKey.E)
			{
				numbs.Add(int.Parse(Console.ReadLine()));
			}

			for (int i = 0; i < numbs.Count; i++)
			{
				sum += numbs[i];
			}

			Console.WriteLine(\n"The Sum Is: " + sum);

			//Console.WriteLine(result2);
		}
	}

