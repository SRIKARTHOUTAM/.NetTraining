using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADO
{
    class Employee
    {


        public static void DisplayEmployees()
        {


            //retrive data fom database

            //step 1 - open a connection to database

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=DESKTOP-CKBAAPJ;Initial Catalog=EmployeeDB;Integrated Security=True";
            connection.Open();


            //step 2 - run sql query
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from Employee";
            command.Connection = connection;


            //step 3 - read data from result
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2}", reader["Id"], reader["FirstName"], reader["LastName"]);
            }

            connection.Close();
            Console.ReadKey();
        }

        public static void DisplayEmployee()
        {


            //retrive data fom database

            //step 1 - open a connection to database

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=DESKTOP-CKBAAPJ;Initial Catalog=EmployeeDB;Integrated Security=True";
            connection.Open();


            Console.Write("Enter Employee Id:");
            string empId = Console.ReadLine();



            //step 2 - run sql query
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from Employee where Id = @id";
            command.Connection = connection;

            SqlParameter param1 = new SqlParameter("id", empId);
            command.Parameters.Add(param1);


            //step 3 - read data from result
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2}", reader["Id"], reader["FirstName"], reader["LastName"]);
            }

            connection.Close();
            Console.ReadKey();
        }

        public static void InsertEmployee()
        {
            //step 1 - connect to database using sql connection, open connection

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=DESKTOP-CKBAAPJ;Initial Catalog=EmployeeDB;Integrated Security=True";
            connection.Open();

            Console.Write("Enter First Name :");
            string fname = Console.ReadLine();

            Console.Write("Enter Last Name :");
            string lname = Console.ReadLine();

            Console.Write("Enter Salary :");
            decimal salary = decimal.Parse(Console.ReadLine());

            //step 2 - run sql query
            SqlCommand command = new SqlCommand();
            command.CommandText = "insert into Employee Values(@fname, @lname, @salary, getdate())";
            command.Connection = connection;

            SqlParameter param1 = new SqlParameter("fname", fname);
            SqlParameter param2 = new SqlParameter("lname", lname);
            SqlParameter param3 = new SqlParameter("salary", salary);

            command.Parameters.Add(param1);
            command.Parameters.Add(param2);
            command.Parameters.Add(param3);

            //step 3 - execute 
            int status = command.ExecuteNonQuery();


            Console.WriteLine("Row(s) effected: {0}", status);
            connection.Close();

            Console.ReadLine();

        }

        public static void DeleteEmployee()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=DESKTOP-CKBAAPJ;Initial Catalog=EmployeeDB;Integrated Security=True";
            connection.Open();

            Console.WriteLine("Enter the Employee ID to Delete:");
            string empId = Console.ReadLine();
            SqlCommand command = new SqlCommand();
            command.CommandText = "delete from Employee where Id = @id";
            command.Connection = connection;

            SqlParameter param1 = new SqlParameter("id", empId);
            command.Parameters.Add(param1);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2}", reader["Id"], reader["FirstName"], reader["LastName"]);
            }

            connection.Close();
            Console.ReadKey();
        }
    }
}
