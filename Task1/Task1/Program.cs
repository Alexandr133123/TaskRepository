using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Task1.BusinessLogicLayer.FileCreator;

namespace Task1
{


    struct ConsoleAction
    {
        public void PrintMenu()
        {
            Console.WriteLine("1 - Create .txt Fille\n2 - Create .xml File\n3 - Create .json File\n0 - Execute Exit");
        }

        public void PrintSuccessMessage()
        {
            Console.WriteLine("\nSuccess, press any key to continue...");
            Console.Read();
        }

        public void PrintExitMessage()
        {
            Console.WriteLine("\n Session Ended");
        }
        public void PrintErrorMessage() 
        {
            Console.WriteLine("Error - Wrong Key\n Press any key...");
            Console.Read();
        }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            
            FileCreationHandler fc = new FileCreationHandler();
            var sw = new Stopwatch();
            ConsoleKeyInfo keyInfo;
            ConsoleAction action;
            do
            {
                Console.Clear();
                action.PrintMenu();
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        sw.Start();
                        fc.CreateTxt();
                        sw.Stop();
                        Console.WriteLine(sw.Elapsed);
                        action.PrintSuccessMessage();
                        break;

                    case ConsoleKey.D2:
                        fc.CreateXml();
                        action.PrintSuccessMessage();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        fc.CreateJson();
                        action.PrintSuccessMessage();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D0:
                        action.PrintExitMessage();
                        break;
                        
                    default:
                        action.PrintErrorMessage();
                        break;

                }

            } while (keyInfo.Key != ConsoleKey.D0);
           
        }
    }
}
