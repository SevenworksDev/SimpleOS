using System;
using Sys = Cosmos.System;

namespace SimpleOS
{
    public class Kernel : Sys.Kernel
    {
        private string _cmd;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("SimpleOS - Type 'help' for a list of commands.");
            _cmd = "";
        }

        protected override void Run()
        {
            Console.Write($"{_cmd}> ");
            var input = Console.ReadLine();
            string[] cmd = input.Split(' ');
            switch (cmd[0])
            {
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;
                case "reboot":
                    Sys.Power.Reboot();
                    break;
                case "help":
                    Console.WriteLine("shutdown - turn off the computer");
                    Console.WriteLine("reboot   - reboots the computer");
                    Console.WriteLine("help     - shows this help menu");
                    break;
                default:
                    Console.WriteLine($"\"{cmd[0]}\" is not a command");
                    break;
            }
            Console.WriteLine();
        }
    }
}