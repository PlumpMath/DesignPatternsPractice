using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.DP.SimpleFactory;
using ConsoleApplication1.LinQ;
using ConsoleApplication1.DataStructure.LinkedList;
using ConsoleApplication1.OOP;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryClient clnt = new FactoryClient();
            //clnt.Process();
            //Console.Read();

            //LinqClient clnt = new LinqClient();


            //DataStructure
            //NodeClient clnt = new NodeClient();
            //            clnt.Process();
            //OOP Test
            client clnt = new client();
            clnt.Process();
            Console.ReadLine();

        }
    }
}
