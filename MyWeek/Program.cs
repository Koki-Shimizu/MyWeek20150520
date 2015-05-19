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
            new DataWriter().WriteAll();
        }

    }

    class DataWriter
    {
        public void WriteAll()
        {
            var da = new DatabaseAccess();

            var idArray = new string[] { "60", "70", "80" };
            
            foreach (var id in idArray)
            {
                Write(da.GetEmployeeNameBy(id));
            }

            foreach (var id in idArray)
            {
                Write(da.GetEmployeeAddressBy(id));
            }
        }

        public void Write(string name)
        {
            Console.WriteLine(name);
        }
    }


    class DatabaseAccess
    {

        public string GetEmployeeNameBy(string employeeId)
        {
            var connect = "User Id=hr; password=hr;" + "Data Source=localhost:1521/orcl; Pooling=false;";

            using (var con = new OracleConnection())
            {
                con.ConnectionString = connect;
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "select name from Employees where employees_id = " + employeeId;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return string.Empty;
        }



        internal string GetEmployeeAddressBy(string id)
        {
            var connect = "User Id=hr; password=hr;" + "Data Source=localhost:1521/orcl; Pooling=false;";

            using (var con = new OracleConnection())
            {
                con.ConnectionString = connect;
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandText = "select address from Employees where employees_id = " + id;

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
