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
                string ErrorMessage = ValidateDate(date);

                if (ErrorMessage.Length != 0)
                    return ErrorMessage;

                string time = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks.ToString();

                Commit commit = FindCommit(time);

                if (commit != null)
                {
                    CommandLine.Execute($"git reset --hard {commit.Hash}");
                    return "Success";
                }
                else
                {
                    return "Failure. Нельзя вернуться в прошлое и изменить свой старт, " +
                           "но можно стартовать сейчас и изменить свой финиш. (Рой Джонс младший)";
                }
            }
            catch (FormatException exception)
            {
                return $"Failure. {exception.Message}";
            }
        }

        private static string ValidateDate(string date)
        {
            if (date.Length == 0)
                return "Failure. Date is empty.";

            if (DateTime.Now.Ticks - DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks < 0)
            {
                return "Failure. А сегодня в завтрашний день не все могут смотреть. " +
                       "Вернее, смотреть могут не только лишь все. " +
                       "Мало, кто может это делать. (Виталий Кличко)";
            }

            return "";
        }

        private static Commit FindCommit(string time)
        {
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
                        return commit;
                    }
                }
            }

            return null;
        }
    }
}
