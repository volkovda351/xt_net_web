using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._4._1_File_management_system
{
	public static class Git
	{
		public static void Init()
		{
			CommandLine.Execute("git init");
		}

		public static void Add()
		{
			CommandLine.Execute("git add -A *.txt");
		}

		public static void Commit(string time)
		{
			CommandLine.Execute($"git commit -m {time}");
		}

		public static void ResetHard(Commit commit)
		{
			CommandLine.Execute($"git reset --hard {commit.Hash}");
		}

		public static string LogOneline()
		{
			return CommandLine.Execute("git log --oneline");
		}
	}
}
