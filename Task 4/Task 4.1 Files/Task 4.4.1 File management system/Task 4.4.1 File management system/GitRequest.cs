using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._4._1_File_management_system
{
    public static class GitRequest
    {
        public static void Init()
        {
            CommandLine.Execute("git init");
        }
        public static void AddCommit()
        {
            CommandLine.Execute("git add -A *.txt");
            string time = DateTime.Now.Ticks.ToString();
            CommandLine.Execute($"git commit -m {time}");
        }
        public static string ResetToDate(string date)
        {
            try
            {
                if (date.Length == 0)
                    return "Failure. Date is empty.";

                if (DateTime.Now.Ticks - DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks < 0)
                {
                    return "Failure. А сегодня в завтрашний день не все могут смотреть. " +
                           "Вернее, смотреть могут не только лишь все. " +
                           "Мало, кто может это делать. (Виталий Кличко)";
                }

                string time = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks.ToString();

                string gitLogs = CommandLine.Execute("git log --oneline");

                string[] rowsOfCommits = gitLogs.Split('\n');

                foreach (var item in rowsOfCommits)
                {
                    if (item.Length > 0)
                    {
                        Commit commit = new Commit(item);
                        long.TryParse(commit.Message, out long timeCommit);
                        long.TryParse(time, out long timeRequest);

                        if (timeCommit <= timeRequest)
                        {
                            CommandLine.Execute($"git reset --hard {commit.Hash}");
                            return "Success";
                        }
                    }
                }

                return "Failure. Нельзя вернуться в прошлое и изменить свой старт, " +
                       "но можно стартовать сейчас и изменить свой финиш. (Рой Джонс младший)";
            }
            catch (FormatException exception)
            {
                return $"Failure. {exception.Message}";
            }
        }
    }
}
