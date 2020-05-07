using ApplicationLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Services
{
    public class MyConsoleLogger: ILog
    {
        public void Info(string str)
        {
            Console.WriteLine(str);
        }
    }

}
