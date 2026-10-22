using System;
using Spectre.Console;
using System.IO;

namespace SchedulerCLSS
{
    static class Sclad
    {
        static string[] Name = new string[10];
        static string[] Time = new string[10];
        static string[] Kab = new string[10];
        public  static void Main(string[] args)
        {
            
            int DayOfWeek = GetDayOfWeek();

            string Kabs =
                File.ReadAllText(
                    $"/home/maksimka/RiderProjects/SchedulerCLSSNET11/SchedulerCLSSNET11/bin/Debug/net11.0/{DayOfWeek}Kab.txt");
            string Schedule =
                File.ReadAllText(
                    $"/home/maksimka/RiderProjects/SchedulerCLSSNET11/SchedulerCLSSNET11/bin/Debug/net11.0/{DayOfWeek}.txt");
            string Times = 
                File.ReadAllText(
                    "/home/maksimka/RiderProjects/SchedulerCLSSNET11/SchedulerCLSSNET11/bin/Debug/net11.0/Times.txt");
            if (args.Contains("-L"))
            {
                Console.WriteLine("Кабинеты - {0}",Kab);
                Console.WriteLine("Время - {0}",Times);
                Console.WriteLine("Расписание - {0}",Schedule);
            }
            Time = Times.Split(",");
            Name = Schedule.Split(",");
            Kab = Kabs.Split(",");
            
            var table = new Table();
            table.AddColumn(new TableColumn("Номер\nУрока"));
            table.AddColumn(new TableColumn("Название\nУрока"));
            table.AddColumn(new TableColumn("Время\nУрока"));
            table.AddColumn(new TableColumn("Кабинет"));
            byte number = 1;
            for (int i = 0;i < Name.Length ; i++)
            {
                if (args.Contains("-L")) {
                    Console.WriteLine(i);
                }
                if (!string.IsNullOrWhiteSpace(Name[i]) && !string.IsNullOrWhiteSpace(Time[i]))
                {
                    table.AddRow($"{number}",  $"{Name[i]}", $"{Time[i]}", $"{Kab[i]}");
                    number++;
                }

                
            }

            
            AnsiConsole.Write(table);
            
        }

        public static int GetDayOfWeek()
        {
            DateTime ClockInfoFromSystem = DateTime.Now;
            int DayOfWeekBI = (int)ClockInfoFromSystem.DayOfWeek;
            if (DayOfWeekBI == 0)
            {
                DayOfWeekBI = 7;
            }
            return DayOfWeekBI;
        }
    }
}