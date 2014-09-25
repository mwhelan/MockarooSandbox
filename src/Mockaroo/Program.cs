using System;

namespace Mockaroo
{
    class Program
    {
        static void Main()
        {
            var items = new MockarooApiReader().GetData();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            //var generator = new MockarooFileGenerator();
            //generator.GenerateMockarooFiles();
        }

    }
}
