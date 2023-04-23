using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        // best practice for private field is _variable
        // sets my connection to private so that it can't be changed once instantiated
        // ctrl . on red squiggle to add "using" 
        private readonly IDbConnection _connection;

        // ctrl . on _connection, "create constructor" to make this constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        // method that gets all the departments
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments");
        }

        // method that inserts another department to the database
        public void InsertDepartment(string name)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name)", new {name = name});
        }
    }
}

// pass a connection into this class, makes the connection private,
// then queries the database and returns all the departments into a collection matching IDepartmentRepository
