using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.OOP
{
    public class BaseTest<T>
    {
        public T returnT(T x)
        {
            Console.WriteLine("generic");
            return (T)Convert.ChangeType(5, typeof(T));
        }
        public int returnT(int c)
        {
            Console.WriteLine("non-generic");
            return 5;
        }
    }
    public class client
    {
        public void Process()
        {
            
            BaseTest<int> tt = new BaseTest<int>();
            tt.returnT(5);
        }
        
    }
   
}
