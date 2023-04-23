using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    }
}

// this helps us create an object of type Department that takes on the qualities of having a DepartmentID and a Name
