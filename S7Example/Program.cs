using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7Example
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var plc = new Plc(CpuType.S71500, "127.0.0.1", 0, 1))
            {
                plc.Open();

                ReadSingleVariables(plc);
                WriteSingleVariable(plc);
            }
        }

        private static void ReadSingleVariables(Plc plc)
        {
            Console.WriteLine("\n--- DB 2 ---\n");

            var db1Bool1 = plc.Read("DB2.DBX0.0");
            Console.WriteLine("DB2.DBX0.0: " + db1Bool1);

            var db1Bool2 = plc.Read("DB2.DBX0.1");
            Console.WriteLine("DB2.DBX0.1: " + db1Bool2);

        }

        private static void WriteSingleVariable(Plc plc)
        {
            Console.WriteLine("\n--- DB 2 ---\n");

            short db1WordVariable = 188;
            plc.Write("DB2.DBX0.0", true);

        }
        
    }
}
