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

        public void PrintSuccessMassage()
        {
            Console.WriteLine("\nSuccess, press any key to continue...");
            Console.Read();
        }

        public void PrintExitMassage()
        {
            Console.WriteLine("\n Session Ended");
        }
        public void PrintErrorMassage() 
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
            ConsoleKeyInfo keyInfo;
            ConsoleAction action;
            do
            {
                var sw = new Stopwatch();
                Console.Clear();
                action.PrintMenu();
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        fc.CreateTxt();
                        action.PrintSuccessMassage();
                        break;

                    case ConsoleKey.D2:
                        fc.CreateXml();
                        action.PrintSuccessMassage();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D3:
                        fc.CreateJson();
                        action.PrintSuccessMassage();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.D0:
                        action.PrintExitMassage();
                        break;
                        
                    default:
                        action.PrintErrorMassage();
                        break;

                }

            } while (keyInfo.Key != ConsoleKey.D0);
           
        }
    }
}
