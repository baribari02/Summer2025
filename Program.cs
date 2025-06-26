using System.Diagnostics;
using System.Numerics;
using System.Threading.Channels;

namespace bazaDate
{
   
    internal class Program
    { 
         static string firstName () 
        {
            Console.WriteLine("Introduceti prenumele angajatului: ");
            string fName = Console.ReadLine();
            return fName;
            
            
        }
        static string familyName()
        {
            Console.WriteLine("Introduceti numele angajatului: ");
            string lastName = Console.ReadLine();
            return lastName;


        }
        static string middleName()
        {
            Console.WriteLine("Exista  un al doilea prenume?(y/n): ");
            string mName=null;
            string test = Console.ReadLine();
            if ( test  == "n" )
            {
                mName = "-";
            }
            if ( test == "y" )
            {
                Console.WriteLine("Introduceti cel de al doilea prenume al angajatului: ");
                mName = Console.ReadLine();
            }
            return mName;

        }
        static uint contractHoursPerWeek()
        {
            Console.WriteLine("Indroduceti numarul de  ore lucrate pe saptamana: ");
            string i = Console.ReadLine();
            uint hours = uint.Parse(i);
            return hours;

        }

        static bool currentlyEmployed()
        {
            Console.WriteLine("Mai este angajat?y/n");
            string i = Console.ReadLine();
            bool status = false;
            if (i == "y")
            {
                status = true;
            }
            if (i == "n")
            {
                status = false;
            }
            return status;
        }
        static double wagePerYear()
        {
            Console.WriteLine("Salariul anual este:");
            string x = Console.ReadLine();
            double wage = double.Parse(x);
            return wage;
        }
        static uint weeksWorked()
        {
            Console.WriteLine("Numarul de saptamani lucrate este:");
            string y = Console.ReadLine();
            uint weeks = uint.Parse(y);
            return weeks;
        }
        static uint ageEmployed()
        {
            bool angajat = currentlyEmployed();
            uint age = 0;
            if (angajat==true)
            {
                Console.WriteLine("Introduceti varsta angajatului:");
                string y = Console.ReadLine();
                age = uint.Parse(y);
            }
             
            return age;
        }
        static void Main(string[] args)
        {
            string z="y";
            do
            {
                
                string prenume = firstName();
                string numeMijlociu = middleName();
                string nume = familyName();
                uint ore = contractHoursPerWeek();
                bool angajat = currentlyEmployed();
                double salariu = wagePerYear();
                uint saptamaniLucrate = weeksWorked();
                uint ani = 0;
                if (angajat == true)
                {
                    Console.WriteLine("Introduceti varsta angajatului:");
                    string y = Console.ReadLine();
                    ani = uint.Parse(y);
                }

               
                Console.WriteLine("Introduceti vechimea angajatului: ");
                string v=Console.ReadLine();
                double vechime=double.Parse(v);
                Console.WriteLine("Numele angajatului este: " + " " + prenume + " " + numeMijlociu + " " + nume);
                Console.WriteLine($"Salariul pe ora este: {salariu / (saptamaniLucrate * ore):C2}");
                Console.WriteLine($"Procentul de munca din varsat este: {(vechime/ani):P2}");
                Console.WriteLine("Doriti sa mai introduceti datele altui angajat?(y,n)");
                z=Console.ReadLine();

            } while (z == "y");
            

        }
    }
}
