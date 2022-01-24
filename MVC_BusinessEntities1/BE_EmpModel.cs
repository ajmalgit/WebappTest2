using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessEntities1
{
    public class BE_EmpModel
    {


        public int id { get; set; }
        public string employeeName { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }


        public List<BE_EmpSalary> lstEmpsal {get;set;}

        //   public BE_EmpSalary empSal { get; set; }

        public BE_EmpModel()
        {
            lstEmpsal = new List<BE_EmpSalary>();
        }


    }
    

    public class BE_EmpSalary
    {
        public int id { get; set; }

        public int EmpCode { get; set; }
        public int EmpSal { get; set; }
        public int EmpSalMonth { get; set; }
     



    }
}
