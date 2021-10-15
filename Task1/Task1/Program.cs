using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Task1.DBLayer.DbCall;
using System.Diagnostics;
using Task1.BusinessLogicLayer.FileCreator;
using Task1.DBLayer.Model;

namespace Task1
{

    class Program
    {
       
        static void Main(string[] args)
        {

           
            FileCreator fc = new FileCreator();

            ConsoleKeyInfo keyInfo;

            Console.WriteLine("1 - Create .txt Fille\n2 - Create .xml File\n3 - Create .json File");

            keyInfo = Console.ReadKey();

            Console.WriteLine();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                   
                    fc.CreateTxt();
                   
                 break;

                case ConsoleKey.D2:
                  
                    fc.CreateXml();
                    
                break;
                case ConsoleKey.D3:
                   
                    fc.CreateJson();
                
                break;

                default:

                    Console.WriteLine("Wrong key");

                break;
            }
           
            
            
            
        }
    }
}
