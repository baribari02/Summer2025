using System;

namespace TemaStructures
{
    enum Status { FullTime, PartTime, Intern, Student }

    struct Employee
    {
        public string Prenume;
        public string? NumeM;
        public string Nume;
        public uint ContractHoursPerWeek;
        public Status EmploymentStatus;
        public bool isEmp;
        public double WagePerYear;
        public DateTime DateOfHire;
        public DateTime? DateOfBirth;
        public DateTime? DateOfLeave;

        public string GetFullName()
        {
            return $"{Nume} {Prenume} {(string.IsNullOrWhiteSpace(NumeM) ? "" : NumeM + " ")}";
        }

        public double GetPaymentPerHour()
        {
            return ContractHoursPerWeek > 0 ? WagePerYear / (ContractHoursPerWeek * 52) : 0;
        }

        public void AfisareDate()
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Nume complet: {GetFullName()}");
            Console.WriteLine($"Status: {EmploymentStatus}");
            Console.WriteLine($"Ore pe saptamana: {ContractHoursPerWeek}");
            Console.WriteLine($"Salariu anual: {WagePerYear:C}");
            Console.WriteLine($"Pe ora: {GetPaymentPerHour():C}");
            Console.WriteLine($"Este angajat: {isEmp}");
            Console.WriteLine($"Data angajarii: {DateOfHire.ToShortDateString()}");

            if (isEmp && DateOfBirth.HasValue)
                Console.WriteLine($"Data nasterii: {DateOfBirth.Value.ToShortDateString()}");
            else if (!isEmp && DateOfLeave.HasValue)
                Console.WriteLine($"Data plecarii: {DateOfLeave.Value.ToShortDateString()}");

            Console.WriteLine("---------------\n");
        }

        public void IncreaseWage(double crestere)
        {
            WagePerYear += crestere;
        }

        public void IncreaseWageByPercentage(double procent)
        {
            WagePerYear += WagePerYear * (procent / 100);
        }

        public void ShowInformation()
        {
            AfisareDate();
        }

        // Metodă statică pentru citirea unui angajat de la consolă
        public static Employee Citire()
        {
            Employee e = new Employee();

            Console.Write("Nume: ");
            e.Nume = Console.ReadLine();

            Console.Write("Prenume: ");
            e.Prenume = Console.ReadLine();

            Console.Write("Nume mijlociu(gol daca nu exista): ");
            string m = Console.ReadLine();
            e.NumeM = string.IsNullOrWhiteSpace(m) ? null : m;

           

            Console.Write("Ore pe saptamana: ");
            e.ContractHoursPerWeek = uint.Parse(Console.ReadLine());

            Console.Write("Status (FullTime, PartTime, Intern, Student): ");
            e.EmploymentStatus = Enum.Parse<Status>(Console.ReadLine(), true);

            Console.Write("In prezent angajat? (y/n): ");
            e.isEmp = Console.ReadLine().ToLower() == "y";

            Console.Write("Salariu pe an: ");
            e.WagePerYear = double.Parse(Console.ReadLine());

            Console.Write("Data angajarii (yyyy-mm-dd): ");
            e.DateOfHire = DateTime.Parse(Console.ReadLine());

            if (e.isEmp)
            {
                Console.Write("Data nasterii (yyyy-mm-dd): ");
                e.DateOfBirth = DateTime.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Data plecarii (yyyy-mm-dd): ");
                e.DateOfLeave = DateTime.Parse(Console.ReadLine());
            }

            return e;
        }

        // Metoda Main inclusă în struct
        public static void Main()
        {
            Employee[] employees = new Employee[100];
            int count = 0;
            string option;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Adaugă angajat");
                Console.WriteLine("2. Afiseaza toti angajatii");
                Console.WriteLine("3. Majoreaza salariul");
                Console.WriteLine("4. Iesire");
                Console.Write("Alege optiunea: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        employees[count++] = Citire();
                        break;

                    case "2":
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Angajatul #{i}:");
                            employees[i].ShowInformation();
                        }
                        if (count == 0) Console.WriteLine("Nu exista angajati!");
                        break;

                    case "3":
                        if (count == 0)
                        {
                            Console.WriteLine("Nu exista angajati!");
                            break;
                        }
                        Console.Write("Indexul angajatului pentru majora salariului: ");
                        int index = int.Parse(Console.ReadLine());
                        if (index >= 0 && index < count)
                        {
                            Console.Write("Majorează cu valoare sau procent? (v/p): ");
                            string mode = Console.ReadLine();

                            if (mode == "v")
                            {
                                Console.Write("Valoarea de adăugat: ");
                                double value = double.Parse(Console.ReadLine());
                                employees[index].IncreaseWage(value);
                            }
                            else if (mode == "p")
                            {
                                Console.Write("Procentul de creștere: ");
                                double percent = double.Parse(Console.ReadLine());
                                employees[index].IncreaseWageByPercentage(percent);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Index invalid.");
                        }
                        break;
                     default:
                        Console.WriteLine("Optiune invalida!");
                        break;

                }
                

            } while (option != "4");
        }
    }
}