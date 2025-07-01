using System;
using System.Runtime.CompilerServices;

namespace HelloWorld2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            BYTE
            
            byte a;
            a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = byte.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (byte.TryParse(input, out byte number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(Byte.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(Byte.MaxValue);
            //----------------------------------------

            SBYTE
            //----------------------------------------
            sbyte a;
            a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (sbyte.TryParse(input, out sbyte number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(SByte.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(SByte.MaxValue);
            //----------------------------------------

            SHORT
            //----------------------------------------
            short a;
            a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = short.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (short.TryParse(input, out short number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(Int16.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(Int16.MaxValue);
            //----------------------------------------


            USHORT
            //----------------------------------------
            ushort a;
            a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = ushort.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (ushort.TryParse(input, out ushort number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(UInt16.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(UInt16.MaxValue);
            //----------------------------------------


            INT
            //----------------------------------------
            int a;
            a = 12;
            Console.WriteLine(a);
            Console.WriteLine("New value for a");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
                Console.Write(number);
            else
                Console.Write("Bad input");
            Console.WriteLine("Min value for a");
            Console.WriteLine(Int32.MinValue);
            Console.WriteLine("Max value for a");
            Console.WriteLine(Int32.MaxValue);
            //-----------------------------------------


            UINT
            //-----------------------------------------
                uint a;
            a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = uint.Parse(Console.ReadLine());
            Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (uint.TryParse(input, out uint number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(UInt32.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(UInt32.MaxValue);
        }
        //-----------------------------------------


        LONG
            //-----------------------------------------
            long a;
        a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = long.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (long.TryParse(input, out long number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(Int64.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(Int64.MaxValue);
            //-----------------------------------------
            
            
            ULONG
            //-----------------------------------------
            ulong a;
        a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = ulong.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (ulong.TryParse(input, out ulong number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(UInt64.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(UInt64.MaxValue);
            //-----------------------------------------
            
            
            FLOAT
            //-----------------------------------------
            float a;
        a = 12.2f;
            Console.WriteLine(a);
            Console.WriteLine("New value for a");
            a = float.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a");
            string input = Console.ReadLine();
            if (float.TryParse(input, out float number))
                Console.WriteLine(number);
            else
                Console.Write("Bad input");
            Console.WriteLine("Min value for a");
            Console.WriteLine(Single.MinValue);
            Console.WriteLine("Max value for a");
            Console.WriteLine(Single.MaxValue);
            //------------------------------------------
            
            DOUBLE
            //------------------------------------------
            double a;
        a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = double.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(Double.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(Double.MaxValue);
            //------------------------------------------
            
            
            //------------------------------------------
            decimal a;
        a = 127;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Min value for a: ");
            Console.WriteLine(Decimal.MinValue);
            Console.WriteLine("Max value for a: ");
            Console.WriteLine(Decimal.MaxValue);
            //------------------------------------------
            
            
            //------------------------------------------
            bool a;
        a = true;
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = bool.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (bool.TryParse(input, out bool number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("One value for a: ");
            Console.WriteLine("True");
            Console.WriteLine("The other value for a: ");
            Console.WriteLine("False");
            //------------------------------------------
            
            
            //------------------------------------------
            char a;
        a = 't';
            Console.WriteLine(a);
            Console.WriteLine("New value for a: ");
            a = char.Parse(Console.ReadLine());
        Console.WriteLine("Another value for a: ");
            string input = Console.ReadLine();
            if (char.TryParse(input, out char number))
                Console.WriteLine(number);
            else
                Console.WriteLine("Bad input");
            Console.WriteLine("Max value for a: ");
            Console.WriteLine((int) Char.MaxValue);
            Console.WriteLine("Min value for a: ");
            Console.WriteLine((int) Char.MinValue);
            //------------------------------------------
            */
        }
    }
}
