using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ConsoleApp_ADO
{
    class Program
    {
        static void Main(string[] args)
        {

            bool flag = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Choose any Option from the list below");
                Console.WriteLine("\t1.Insert Employee Details:");
                Console.WriteLine("\t2.Display Employee Details:");
                Console.WriteLine("\t3.Display All Employees:");
                Console.WriteLine("\t4.Delete Employee:");
                Console.WriteLine("\t5.Exit:");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Employee.InsertEmployee();
                        break;
                    case "2":
                        Employee.DisplayEmployee();
                        break;
                    case "3":
                        Employee.DisplayEmployees();
                        break;
                    case "4":
                        Employee.DeleteEmployee();
                        break;
                    case "5":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Insert Valid Entry");
                        break;
                }


            } while (flag);


        }
    }
}
