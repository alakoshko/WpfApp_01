using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp_01.DataManagement
{
    class SQLProcessing
    {
        private const string connection_string =
                @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Документы\GitHub\WpfApp_01\DB\PersonalDB.mdf; Integrated Security = True; Connect Timeout = 30";

        private SqlConnection connection;

        public SQLProcessing()
        {
            
            //Не находит класс System.Configuration.ConfigurationManager - глюк, блин.
            //var str = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"];


            //using (connection = new SqlConnection(str.ConnectionString))
            using (connection = new SqlConnection(connection_string))
            {
                connection.Open();
            }
        }

        
        public void GetEmployees(ObservableCollection<Employee> employees)
        {
            //var Emps = new List<Employee>();

            #region sql
            var sql_select = "SELECT * FROM dbo.Employes";

            using (connection = new SqlConnection(connection_string))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return;

                    while (reader.Read())
                    {
                        #region поля null
                        Guid deptdID;
                        var col_index = reader.GetOrdinal("DeptID");
                        if (!reader.IsDBNull(col_index))
                            deptdID = reader.GetGuid(col_index);
                        else deptdID = new Guid();

                        Guid positionID;
                        col_index = reader.GetOrdinal("PositionID");
                        if (!reader.IsDBNull(col_index))
                            positionID = reader.GetGuid(col_index);
                        else positionID = new Guid();

                        string birthday;
                        col_index = reader.GetOrdinal("Birthday");
                        if (!reader.IsDBNull(col_index))
                            birthday = reader.GetString(col_index);
                        else birthday = "";

                        double salary;
                        col_index = reader.GetOrdinal("Salary");
                        if (!reader.IsDBNull(col_index))
                            salary = (double)reader.GetValue(col_index);
                        //salary = reader.GetFloat(col_index);
                        else salary = 0;
                        #endregion

                        employees.Add(new Employee
                        {
                            ID = (Guid)reader["ID"],
                            Name = (string)reader["Name"],
                            Lastname = (string)reader["Lastname"],
                            Patronymic = (string)reader["Patronymic"],
                            Age = (int)reader["Age"],
                            DeptID = deptdID,
                            //Dept = ,
                            PositionID = positionID,
                            Salary = salary,
                            Birthday = birthday
                        });
                    }
                    //reader.Close();
                }
            }
            #endregion

            //return Emps;
        }

        public void GetDepartments(ObservableCollection<Department> dept)
        {
            #region sql
            var sql_select = "SELECT * FROM dbo.Departaments";

            using (connection = new SqlConnection(connection_string))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return;

                    while (reader.Read())
                    {
                        #region поля null
                        Guid companydID;
                        var col_index = reader.GetOrdinal("CompanyID");
                        if (!reader.IsDBNull(col_index))
                            companydID = reader.GetGuid(col_index);
                        else companydID = new Guid();
                        #endregion

                        dept.Add(new Department
                        {
                            ID = (Guid)reader["ID"],
                            DeptName = (string)reader["Name"],
                            CompanyID = companydID,
                        });
                    }
                    //reader.Close();
                }
            }
            #endregion

            //return Emps;
        }

        public void GetCompanies(ObservableCollection<Company> companies)
        {
            #region sql
            var sql_select = "SELECT * FROM dbo.Company";

            using (connection = new SqlConnection(connection_string))
            {
                connection.Open();

                var command = new SqlCommand(sql_select, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return;

                    while (reader.Read())
                    {
                        companies.Add(new Company
                        {
                            ID = (Guid)reader["ID"],
                            Name = (string)reader["Name"],
                        });
                    }
                    //reader.Close();
                }
            }
            #endregion

            //return Emps;
        }
    }
}
