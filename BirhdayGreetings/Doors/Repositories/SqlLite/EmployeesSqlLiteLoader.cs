using System.Collections.Generic;
using System.Data.SQLite;
using BirthdayGreetings.Domain.Model;

namespace BirthdayGreetings.Doors.Repositories.SqlLite
{
    public static class EmployeesSqlLiteLoader
    {
        public static List<Employee> Load(string filename)
        {
            using var connection = new SQLiteConnection($"URI=file:{filename}");
            connection.Open();
            using SQLiteCommand command = new SQLiteCommand
            {
                CommandText = "select * from employees",
                Connection = connection
            };
            using SQLiteDataReader reader = command.ExecuteReader();

            List<Employee> employees= new List<Employee>();
            while (reader.Read())
            {
                employees.Add(new Employee(
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(4),
                    reader.GetString(3)));
            }

            return employees;
        }
    }
}