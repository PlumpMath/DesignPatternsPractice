using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DP.SimpleFactory
{
    //Two benefits, Concrete implementation is separated out in other class, and client is becoming unaware of actual type, reduces impact of change in 
    //product class
    public class Factory
    {
        public IDairyProducts ProvideDairyProduct(string type)
        {
            IDairyProducts product;
            switch (type)
            { 
                case "1":
                    product = new Cheeze();
                    break;
                case "2":
                    product = new Paneer();
                    break;
                case "3":
                    product = new Curd();
                    break;
                default:
                    product = new Cheeze();
                    break;
            }
            return product;
        }
    }
    public interface IDairyProducts
    {

        
    }
    public class Cheeze : IDairyProducts
    {
        public Cheeze()
        {
            Console.WriteLine("Cheez");
        }
    
    }
    public class Paneer : IDairyProducts
    {
        public Paneer()
        {
            Console.WriteLine("Paneer");

        }
    }
    public class Curd : IDairyProducts
    {
        public Curd()
        {
            Console.WriteLine("Curd");
        }
    }

    public class FactoryClient
    {
        public void Process()
        { 
            Factory dairyProductFactory = new Factory();
            IDairyProducts products = dairyProductFactory.ProvideDairyProduct("1");
            products = dairyProductFactory.ProvideDairyProduct("2");
            products = dairyProductFactory.ProvideDairyProduct("3");
        }
    }

}
