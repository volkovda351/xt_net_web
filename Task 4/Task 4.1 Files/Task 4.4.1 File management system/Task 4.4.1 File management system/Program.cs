﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._4._1_File_management_system
{
	class Program
	{
		static void Main(string[] args)
		{
			GitRequest.Init();

			while (true)
			{
				Console.WriteLine("Choose the mode:");
				Console.WriteLine("1. Listening");
				Console.WriteLine("2. Reset to date");
				Console.WriteLine("3. Exit");

				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						GitRequest.AddCommit();
						Watcher.FileChanged += GitRequest.AddCommit;
						Watcher.Run();
						break;
					case "2":
						Console.WriteLine("Enter a date in the format dd/MM/yyyy HH:mm:ss");
						Console.WriteLine(GitRequest.ResetToDate(Console.ReadLine()));
						break;
					case "3":
						return;
					default:
						break;
				}
			}
		}
	}
}
