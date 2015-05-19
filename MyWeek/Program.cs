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
            var da = new DatabaseAccess();

            // DBにアクセスして、従業員番号60の人の名前を取得する。
            Console.WriteLine(da.GetEmployeeNameBy("60"));

            // DBにアクセスして、従業員番号70の人の名前を取得する。
            Console.WriteLine(da.GetEmployeeNameBy("70"));

            // DBにアクセスして、従業員番号80の人の名前を取得する。
            Console.WriteLine(da.GetEmployeeNameBy("80"));
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


    }

   
}
