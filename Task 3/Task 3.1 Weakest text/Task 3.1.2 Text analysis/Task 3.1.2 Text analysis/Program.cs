using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._2_Text_analysis
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("1. Проанализировать текст");
				Console.WriteLine("2. Выход");

				int.TryParse(Console.ReadLine(), out int choice);

				switch (choice)
				{
					case 1:
						Console.WriteLine("Введите текст на анализ");
						OutputFormatChoosing(CalcResult(Console.ReadLine()));
						break;
					case 2:
						return;
					default:
						break;
				}
			}
		}
		static void OutputFormatChoosing(List<KeyValuePair<string, int>> result)
		{
			while (true)
			{
				Console.WriteLine("Выберите сортировку данных");
				Console.WriteLine("1. По словам");
				Console.WriteLine("2. По количеству в тексте");
				Console.WriteLine("3. Выход");

				int.TryParse(Console.ReadLine(), out int choice);

				switch (choice)
				{
					case 1:
						SortByWord(ref result);
						PrintResult(result);
						break;
					case 2:
						SortByCnt(ref result);
						PrintResult(result);
						break;
					case 3:
						return;
					default:
						break;
				}
			}
		}
		static List<KeyValuePair<string, int>> CalcResult(string str)
		{
			StringBuilder textBuilder = new StringBuilder();

			for (int i = 0; i < str.Length; i++)
			{
				if (char.IsLetter(str[i]))
					textBuilder.Append(char.ToLower(str[i]));
				else
					textBuilder.Append(" ");
			}

			string[] text = textBuilder.ToString().Split();

			SortedDictionary<string, int> dict = new SortedDictionary<string, int>();

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i].Length > 0)
				{
					if (!dict.ContainsKey(text[i]))
						dict.Add(text[i], 1);
					else
						dict[text[i]] += 1;
				}
			}

			return dict.ToList();
		}
		static void SortByWord(ref List<KeyValuePair<string, int>> result)
		{
			result.Sort(delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
			{
				if (pair1.Key.CompareTo(pair2.Key) < 0)
					return -1;
				else
					return 1;
			});
		}
		static void SortByCnt(ref List<KeyValuePair<string, int>> result)
		{
			result.Sort(delegate (KeyValuePair<string, int> pair1, KeyValuePair<string, int> pair2)
			{
				if (pair1.Value < pair2.Value)
					return -1;
				else
					return 1;
			});
		}
		static void PrintResult(List<KeyValuePair<string, int>> result)
		{
			foreach (var item in result)
				Console.WriteLine($"{item.Key} : {item.Value}");
		}
	}
}
