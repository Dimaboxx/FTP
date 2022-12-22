using FTP_client_lib;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace Device_Manager
{
    internal class Program
    {
        static Manager ftpManager ;
        
        static void Main(string[] args )
        {
            var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<Program>();
            logger.LogInformation("program started");
            if ( args.Where(arg => String.Equals(arg, @"\h")).Any() ){
                //ShowHelp();
                ShowUsage();
                return;
            }

              

            if ( args.Length < 1)
            {
                ftpManager = new Manager();
                Selector();
                return;
            }
            if (args.Where(arg => String.Equals(arg, @"\f")).Any())
            {
                var findex = Array.FindIndex(args, (arg) => arg.Equals(@"\f"));
                if (findex + 1 < args.Length)
                    ftpManager = new Manager(args[findex + 1]);
                else
                    Console.WriteLine(@"после ключа \g должно следовать имя группы");
            }
            if (args.Where(arg => String.Equals(arg, @"\g")).Any())
            {
                var gindex = Array.FindIndex(args, (arg) => arg.Equals(@"\g"));
                if (gindex + 1 < args.Length)
                    ftpManager.UploadGroup(args[gindex + 1]);
                else
                    Console.WriteLine(@"после ключа \g должно следовать имя группы");
            }
            else
                Selector();

        }
        static void ShowHelp()
        {
            #region TODO
                //написать справку

            #endregion
           Console.WriteLine("use: remotehost, [user], [password], remotePath, localPath, mode ");
        }

        static void ShowUsage()
        {
            Console.WriteLine("use: ");
            Console.WriteLine("1: Print current configuration");
            Console.WriteLine("2: Upload to device");
            Console.WriteLine("3: Add Group");
            Console.WriteLine("4: Add Devece");
            Console.WriteLine("5: Remove Device");
            Console.WriteLine("6: Remove Group");
            Console.WriteLine("7: Save");
            Console.WriteLine("8: SendGroup");
            Console.WriteLine("0: Quit");
        }


        static void Selector()
        {
            while (true) {
            Console.Clear();
            ShowUsage();
            string s = Console.ReadLine();
            uint selecttion = 0;
                uint.TryParse(s, out selecttion);
            switch (selecttion)
            {
                case 0:
                        Console.Clear();
                        return;

                case 1:
                    Print();                    
                    break;
                case 2:
                    string gn = Console.ReadLine();
                    ftpManager.UploadGroup(gn);
                    break;
                case 7:
                    ftpManager.Save();
                    break;
                case 8:
                        Console.WriteLine("Введите имя группы");
                    var sin = Console.ReadLine();
                    ftpManager.UploadGroup(sin);
                    break;
                default:
                    Console.WriteLine("unknown selection");
                    break;
            };
            }

        }
        /// <summary>
        /// Print current configuration to Console
        /// </summary>
        /// <exception "></exception>
        private static void Print()
        {
            //
            ftpManager.Print();
            Console.ReadLine();
        }
    }
}