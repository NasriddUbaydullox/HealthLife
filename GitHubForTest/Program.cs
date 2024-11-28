
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Expense_tracker
{
    internal class Program
    {
        public static string path = @"D:\temp\Expense_tracker.txt";

        static void Main(string[] args)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    var sb = """
        | Expense        | Amount  | Date    |
        ======================================
        """;

                    sw.WriteLine(sb);
                }
            }
            bool check = true;
            while (check)
            {
                string Expense;
                Console.Write("Expense name: ");
                Expense = Console.ReadLine();
                Console.Write("\nAmount: ");
                int Amount = int.Parse(Console.ReadLine());
                Console.Write("\nDate (HH:mm): ");
                string Time = Console.ReadLine();
                if (!isValidTime(Time))
                {
                    while (!isValidTime(Time))
                    {
                        Console.WriteLine("vaqt hato kiritildi , Iltimos boshidan kiriting:");
                        Console.Write("Date (HH:mm): ");
                        Time = Console.ReadLine();
                    }
                }
                if (isValidTime(Time))
                {
                    Console.WriteLine("\nHit enter to add expense...");
                    string input = Console.ReadLine();
                    Console.Clear();
                    Write(Expense, Amount, Time);
                    if (input == "Stop" || input == "stop" || input == "STOP" || input == "sToP")
                    {
                        Console.WriteLine("E raxmat");
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
            }
        }

        static void Write(string expense, int amount, string time)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"| {expense,-14} | {amount,6} | {time,8} |");
            sb.Append("======================================");
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine(sb.ToString());
            }
        }
        static bool isValidTime(string input)
        {
            string pattern = @"^([01]?[0-9]|2[0-3]):([0-5]?[0-9])$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
