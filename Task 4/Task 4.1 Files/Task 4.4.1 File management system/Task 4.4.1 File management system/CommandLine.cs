using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task_4._4._1_File_management_system
{
	public static class CommandLine
	{
		public static string Execute(string command)
		{
            ProcessStartInfo cmd = new ProcessStartInfo("cmd.exe", $"/C {command}");
            cmd.WorkingDirectory = Environment.CurrentDirectory;

            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.RedirectStandardOutput = true;
            cmd.UseShellExecute = false;

            Process process = Process.Start(cmd);
            StreamReader output = process.StandardOutput;
            string result = output.ReadToEnd();
            process.WaitForExit();
            process.Close();
            return result;
        }
	}
}
