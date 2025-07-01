using System.ComponentModel;

namespace calculator
{
    internal class Program
    {
        static uint n;
        static double memorie;
        static double rezultatCurent;
        static double calcSuma()
        {   
            Console.WriteLine("Introduceti numarul de termeni: ");
            n = uint.Parse(Console.ReadLine());
            double Add = 0;
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine($"Numarul {i}: ");
                        double nr = double.Parse(Console.ReadLine());
                        Add += nr;

                    }
           
                return Add;
         
        }

        static double calcDif()
        {
            
            Console.WriteLine("Introduceti numarul de termeni: ");
            n = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Numarul 1: ");
            double nr = double.Parse(Console.ReadLine());
            double Dif = nr;
            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine($"Numarul {i}: ");
                nr = double.Parse(Console.ReadLine());
                Dif -=nr;
            }
           
            return Dif;
        }
        static double calcInm()
        {

            Console.WriteLine("Introduceti numarul de termeni: ");
            n = uint.Parse(Console.ReadLine());
            double inm = 1;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Numarul {i}: ");
                double nr = double.Parse(Console.ReadLine());
                inm *= nr;
            }
            return inm;
        }
        static double calcDiv()
        {

            Console.WriteLine("Introduceti numarul de termeni: ");
            n = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Numarul 1: ");
            double nr = double.Parse(Console.ReadLine());
            double div = nr;
            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine($"Numarul {i}: ");
                nr = double.Parse(Console.ReadLine());
                div /= nr;
            }
            return div;
        }

        static void memorieFct()
        {
            Console.WriteLine("Alege: M+, M-,MC,MR,MS");
            string opt = Console.ReadLine();

            switch (opt)
            {
                case "MS":
                    memorie = rezultatCurent;
                    Console.WriteLine($"Rezultatul curent ({rezultatCurent}) a fost salvat in memorie.");
                    break;
                case "MR":
                    Console.WriteLine($"Valoarea memorata este: {memorie}");
                    break;
                case "MC":
                    memorie = 0;
                    Console.WriteLine("Memoria a fost stearsa.");
                    break;
                case "M+":
                    Console.WriteLine("Introdu un numar pe care vrei sa-l aduni la memorie:");
                    double numarPlus = double.Parse(Console.ReadLine());
                    memorie += numarPlus;
                    Console.WriteLine($"Memoria actualizata: {memorie} (adunat {numarPlus})");
                    break;
                case "M-":
                    Console.WriteLine("Introdu un numar pe care vrei sa-l scazi din memorie:");
                    double numarMinus = double.Parse(Console.ReadLine());
                    memorie -= numarMinus;
                    Console.WriteLine($"Memoria actualizata: {memorie} (scazut {numarMinus})");
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }

       

        static void Main(string[] args)
        {
            string optiune;
            string iesire = "y";
            do
            {
                Console.WriteLine("Introduceti operatia: (+, -, *, /, ^, radical, memory, exit)");
                optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "+":

                        double result = calcSuma();
                        rezultatCurent = result;
                        if (result is int)
                            Console.WriteLine("Rezultatul este: " + (int)result);
                        Console.WriteLine("Rezultatul este: "+ result);
                        break;

                    case "-":

                        double result1 = calcDif();
                        rezultatCurent = result1;
                        if (result1 is int)
                            Console.WriteLine("Rezultatul este: " + (int)result1);
                        Console.WriteLine("Rezultatul este: " + result1);
                        break;

                    case "*":

                        double result2 = calcInm();
                        rezultatCurent = result2;
                        if (result2 is int)
                            Console.WriteLine("Rezultatul este: " + (int)result2);
                        Console.WriteLine("Rezultatul este: " + result2);
                        break;

                    case "/":

                        double result3 = calcDiv();
                        rezultatCurent = result3;
                        if (result3 is int)
                            Console.WriteLine("Rezultatul este: " + (int)result3);
                        Console.WriteLine("Rezultatul este: " + result3);
                        break;

                    case "^":
                        Console.WriteLine("Introduceti numarul: ");
                        double nr1 = double.Parse(Console.ReadLine());
                        Console.WriteLine("Introduceti puterea:");
                        double nr2 = double.Parse(Console.ReadLine());
                        double result4 = Math.Pow(nr1, nr2);
                        rezultatCurent = result4;

                        if (result4 is int)
                            Console.WriteLine("Rezultatul este: " + (int)result4);
                        Console.WriteLine("Rezultatul este: " + result4);
                        break;

                    case "radical":
                    start:
                        Console.WriteLine("Introduceti numarul: ");
                        double nr = double.Parse(Console.ReadLine());
                        if (nr <= 0)
                        {
                            Console.WriteLine("Bad input");
                            goto start;
                        }

                        double result5 = Math.Sqrt(nr);
                        rezultatCurent = result5;
                        if (result5 is int)
                            Console.WriteLine("Rezultatul este: " + (int)result5);
                        Console.WriteLine("Rezultatul este: " + result5);
                        break;

                    case "memory":
                        memorieFct();
                        break;

                    case "exit":
                        iesire = "n";
                        continue;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
                Console.WriteLine("Doriti sa efectuati o alta operatie? (y/n)");
                iesire=Console.ReadLine();
            } while (iesire == "y");




        }
    }
}
