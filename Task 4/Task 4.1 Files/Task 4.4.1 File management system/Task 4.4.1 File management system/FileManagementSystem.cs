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
    public static class FileManagementSystem
    {
        public static void AddCommit()
        {
            Git.Add();
            string currentTime = DateTime.Now.Ticks.ToString();
            Git.Commit(currentTime);
        }

        public static string Reset(string date)
        {
            try
            {
                ValidateDate(date);
                string time = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks.ToString();

                Commit commit = FindCommit(time);

                if (commit != null)
                {
                    Git.ResetHard(commit);
                    return "Success";
                }
                else
                {
                    return "Failure. Such commit doesn't exist";
                }
            }
            catch (Exception exception)
            {
                return $"Failure. {exception.Message}";
            }
        }

        private static void ValidateDate(string date)
        {
            if (date.Length == 0)
                throw new ArgumentNullException("Failure. Date is empty.");

            if (DateTime.Now.Ticks - DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.CurrentCulture).Ticks < 0)
                throw new ArgumentNullException("Failure. Such date doesn't exist");
        }

        private static Commit FindCommit(string time)
        {
            string gitLogs = Git.LogOneline();

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
