using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            var connect = "User Id=hr; password=hr;" + "Data Source=localhost:1521/orcl; Pooling=false;";

            using (var con = new OracleConnection())
            {
                con.ConnectionString = connect;
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "select first_name from employees where department_id = 60";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }

            Console.WriteLine("DONE!");

        }
    }

    class DatabaseAccess
    {

        public string GetEmployeesFirstNameByDepartmentIdIs60()
        {
            var connect = "User Id=hr; password=hr;" + "Data Source=localhost:1521/orcl; Pooling=false;";

            using (var con = new OracleConnection())
            {
                con.ConnectionString = connect;
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "select first_name from Employees where department_id = 60";

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return string.Empty;

        }

    }

   
}
