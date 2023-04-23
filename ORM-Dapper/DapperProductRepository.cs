using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM products");
        }
         
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID) ", new {name = name, price = price, categoryID = categoryID });
        }

        public Products GetProduct(int id)
        {
            return _connection.QuerySingle<Products>("SELECT * FROM products WHERE ProductID = @id", new {id = id});
        }

        public void UpdateProduct(Products product)
        {
            _connection.Execute("UPDATE products " +
                                " SET Name = @name, " +
                                " Price = @price, " +
                                " CategoryID = @categoryID," +
                                " OnSale = @onSale," +
                                " Stocklevel = @stock" +
                                " WHERE ProductID = @id;",
                                new {id = product.ProductID, name = product.Name, price = product.Price, categoryID = product.CategoryID,
                                    onSale = product.OnSale, stock = product.StockLevel});
        }

        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM sales WHERE ProductID = @id;", new {id = id});
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id = id });
            _connection.Execute("DELETE FROM products WHERE ProductID = @id;", new { id = id });
        }
    }
}
