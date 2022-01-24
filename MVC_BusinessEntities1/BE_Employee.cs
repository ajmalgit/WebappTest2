using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessEntities
{
    public class BE_Employee
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public int Salary
        {
            get;
            set;
        }
        public int DeptId
        {
            get;
            set;
        }
    }
}
