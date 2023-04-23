using Microsoft.Extensions.Configuration;
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

            #region DEPARTMENTS
            //// creates a new instance of DapperDepartmentRepository that can SELECT or INSERT from/into departments
            //var departmentRepo = new DapperDepartmentRepository(conn);

            //// insert a new department into the database
            //departmentRepo.InsertDepartment("Games");

            //// creates a new collection of departments by SELECTing them from the database.departments
            //var departments = departmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion DEPARTMENTS

            #region PRODUCTS
            var productsRepo = new DapperProductRepository(conn);

            //productsRepo.CreateProduct("Buddy", 123.45, 8);

            // creates a product object then finds the object based on the product id
            //var productToUpdate = productsRepo.GetProduct(940);

            ////new product information
            //productToUpdate.OnSale = true;
            //productToUpdate.Price = 999.99;
            //productToUpdate.StockLevel = 543;

            //// updates the product that was found
            //productsRepo.UpdateProduct(productToUpdate);

            // Delete the product
            productsRepo.DeleteProduct(940);

            var products = productsRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID + "  " + product.Name + "  " + product.Price + "  " + product.CategoryID + "  " + product.OnSale + "  " + product.StockLevel);
            }
            #endregion
        }
    } 
}
