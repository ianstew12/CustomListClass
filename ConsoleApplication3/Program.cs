using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeList<string> testList = new FakeList<string>() { "a","b","c"};

            testList.Remove("a");
            testList.Add("d");
            Console.WriteLine(testList);
            Console.ReadLine();
        }
    }
}
