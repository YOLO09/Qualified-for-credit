using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anoyolo_Mlotha_Project1_PRG152
{
    class Program
    {
        enum Menu
        {
            CaptureDetails = 1,
            creditqualification,
            showqualificationstats,
            Exit
        }
        private static string[,] CustDetails()
        {
            bool end = true;

            while (end == true)
            {
                bool Continue = true;

                while (Continue == true)
                {
                    Console.WriteLine("How many customer's details would you like to add?");
                    int Custnos = int.Parse(Console.ReadLine());

                    string[,] Cust = new string[Custnos, 7];

                    for (int i = 0; i < Custnos; i++)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter the customer's name: ");
                        string name = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the customer's employment status: ");
                        string status = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the customer's years in current job (if any): ");
                        string yearsatjob = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the customer's years at current residence: ");
                        string yearsatres = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the customer's monthly salary: ");
                        string salary = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the amount of the customer's non-mortgage debt: ");
                        string debt = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine("Enter the customer's number of children: ");
                        string noofchild = Console.ReadLine();

                        Cust[i, 0] = name;
                        Cust[i, 1] = status;
                        Cust[i, 2] = yearsatjob;
                        Cust[i, 3] = yearsatres;
                        Cust[i, 4] = salary;
                        Cust[i, 5] = debt;
                        Cust[i, 6] = noofchild;
                    }
                }
                Console.WriteLine("Do you want to add more applicant's? press y to stop");
                string stopping = Console.ReadLine();

                if (stopping == "y")
                {
                    end = true;
                    Console.ReadLine();
                }
            }

            return CustDetails();
        }
        private static (string[,],int, int) Checking()//method for checking the qualifiers
        {
            string[,] Customers = CustDetails();
            string[] Qualifiers = new string[Customers.GetLength(0)];
            int Qualifyingcount = 0;
            int Nonqualifyingcount = 0;

            for (int i = 0; i < Customers.GetLength(0); i++)
            {
                for (int j = 0; j < Customers.GetLength(0); j++)
                {
                    if (int.Parse(Customers[i, 5]) >= int.Parse(Customers[i,4]) || int.Parse(Customers[i,6]) > 6)
                    {
                        if (Customers[i, 1] == "employed" && int.Parse(Customers[i, 2]) > 6)
                        {
                            Console.WriteLine(Customers[i, 1] + " qualifies for credit");
                            Qualifiers[i] = Customers[i, 0];
                            Qualifyingcount++;
                        }
                        else if (int.Parse(Customers[i,3]) <= 2)
                        {
                            Console.WriteLine(Customers[i, 1] + " qualifies for credit");
                            Qualifiers[i] = Customers[i, 0];
                            Qualifyingcount++;
                        }

                        else
                        {
                            Nonqualifyingcount++;
                        }
                    }
                    else
                    {
                        Nonqualifyingcount++;
                    }
                }
            }
            return Checking();
        }
        private static void Displayqualifiers()//method for displaying qualifiers
        {
            var (Customers, Qualifyingcount,nonqualifyingcount) = Checking();

            foreach (var item in Customers)
            {
                Console.WriteLine("");
            }
            Console.WriteLine("The amount of qualifiers is: " + Qualifyingcount);
            Console.WriteLine("The amount of non-qualifiers is: " + nonqualifyingcount);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            bool Continue = true;

            while (Continue == true)
            {
                Console.Clear();
                Console.WriteLine("1. Capture details");
                Console.WriteLine("2. Checking credit qualification");
                Console.WriteLine("3. Show qualification stats");
                Console.WriteLine("4. Exit the program");

                Console.WriteLine("  ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                Menu Main = (Menu)choice;

                switch (Main)
                {
                    case Menu.CaptureDetails:

                        CustDetails();
                        Console.ReadLine();
                        break;

                    case Menu.creditqualification:
                        Checking();
                        Console.ReadLine();
                        break;

                    case Menu.showqualificationstats:
                        Displayqualifiers();
                        break;

                    case Menu.Exit:
                        Continue = false;
                        Console.WriteLine("You are now exiting this application");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Please enter one of the options");
                        break;
                }
            }
        }
    }
}
