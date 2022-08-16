using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReFeelCourtesy.Logging
{
    public class Logging : iLoggin
    {
        public void Log(string message, string type)
        {
           if(type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red; 
                Console.WriteLine("Erorr - " + message);
            }
            else
            {
                if(type == "warning")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Erorr - " + message);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(message);
                }                
            }
        }
    }
}
