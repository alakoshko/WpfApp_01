using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp_01.DataManagement
{
    class SQLProcessing
    {
        private SqlConnection connection;

        public SQLProcessing()
        {
            const string connection_string =
                @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Документы\GitHub\WpfApp_01\DB\PersonalDB.mdf; Integrated Security = True; Connect Timeout = 30";

            //Не находит класс System.Configuration.ConfigurationManager - глюк, блин.
            //var str = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"];


            //using (connection = new SqlConnection(str.ConnectionString))
            using (connection = new SqlConnection(connection_string))
            {
                connection.Open();
            }
        }

        public List<Employee> GetEmployees(){
            var Emps = new List<Employee>();

            #region sql
            var sql_select = "SELECT * FROM Employes";

            using (connection)
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    while (reader.Read())
                    {
                        Emps.Add(new Employee {
                            ID = (Guid)reader["ID"],
                            Name = (string)reader["Name"],
                            Lastname = (string)reader["Lastname"],
                            Patronymic = (string)reader["Patronymic"],
                            Age = (int)reader["Age"],
                            DeptID = (Guid)reader["DeptID"],
                            PositionID = (Guid)reader["PositionID"],
                            Salary = (double)reader["Salary"],
                            Birthday = (string)reader["Birthday"]
                        });

                        //var id = (Guid)reader.GetValue(0);
                        //var name = reader.GetString(1);
                        //var birthday = (string)reader["Birthday"];
                        //var email_col_index = reader.GetOrdinal("Email");
                        //var email = reader.GetString(email_col_index);
                    }
                    //reader.Close();
                }
            }
            #endregion

            return Emps;
        }
    }
}
