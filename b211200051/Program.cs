using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b211200051
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            KafaTopu kafaTopu = new KafaTopu(20, 60);
            kafaTopu.Run();
            Console.ReadKey();
        }
    }
}
