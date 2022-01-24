using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTest2
{
    public class EmpModel
    {
      
        public int id { get; set; }      
        public string employeeName { get; set; }     
        public string mobile { get; set; }      
        public string address { get; set; }

    }
}