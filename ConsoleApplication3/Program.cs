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
            FakeList<int> testList1 = new FakeList<int>() { 1, 2, 3 };
            FakeList<int> testList2 = new FakeList<int>() { 4, 5, 6 };
            FakeList<int> testList3 = new FakeList<int>() { 7, 8};
            FakeList<int> testList4 = new FakeList<int>() { 10, 11, 12, 13 };

            Console.WriteLine(testList1.Zip(testList2, testList3, testList4));
            Console.ReadLine();
        }
    }
}
