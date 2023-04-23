﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            // creates a new instance of DapperDepartmentRepository that can SELECT or INSERT from/into departments
            var departmentRepo = new DapperDepartmentRepository(conn);

            // insert a new department into the database
            departmentRepo.InsertDepartment("Games");

            // creates a new collection of departments by SELECTing them from the database.departments
            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    } 
}
