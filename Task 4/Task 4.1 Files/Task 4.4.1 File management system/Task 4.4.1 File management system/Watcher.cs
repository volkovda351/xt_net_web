using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace Task_4._4._1_File_management_system
{
    public static class Watcher
    {
        public static event Action FileChanged;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher(Environment.CurrentDirectory))
            {
                watcher.IncludeSubdirectories = true;
                watcher.NotifyFilter = (NotifyFilters)127;
                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press 'q' to quit the watcher");
                while (Console.ReadLine() != "q") { }
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            FileChanged?.Invoke();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            FileChanged?.Invoke();
        }
    }
}
