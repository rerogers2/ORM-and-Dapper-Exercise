using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
    }
}

// This creates a blueprint for a collection of departments (regardless of department type)
