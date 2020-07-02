using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._3._2_Super_string
{
	public static class StringExtensions
	{
		public static Language GetLanguage(this string str)
		{
			if (str.All(a => (a >= 'а' && a <= 'я' || a >= 'А' && a <= 'Я' || a == 'ё' || a == 'Ё')))
				return Language.Russian;
			else if (str.All(a => (a >= 'A' && a <= 'Z' || a >= 'a' && a <= 'z')))
				return Language.English;
			else if (str.All(a => (a >= '0' && a <= '9')))
				return Language.Number;
			else
				return Language.Mixed;			
		}

		public enum Language
		{
			None,
			Russian,
			English,
			Number,
			Mixed
		}
	}
}
