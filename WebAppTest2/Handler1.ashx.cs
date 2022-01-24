using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebAppTest2.repository;

namespace WebAppTest2
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string callback = context.Request.QueryString["callback"];
            int customerId = 0;
            string custid = context.Request.QueryString["customerId"];
            int.TryParse(context.Request.QueryString["customerId"], out customerId);
            string json = "";
            if (custid != "")
            {
                json = this.GetCustomersJSON(int.Parse(custid));
            }
            else
            {
                json = this.GetCustomersJSON(customerId);
            }

          
            if (!string.IsNullOrEmpty(callback))
            {
                json = string.Format("{0}({1});", callback, json);
            }

            context.Response.ContentType = "text/json";
            context.Response.Write(json);
         //   context.Response.ContentType = "text/plain";
          //  context.Response.Write("Hello World");
        }


        private string GetCustomersJSON(int customerId)
        {

            EmpRepository empRepo = new EmpRepository();

            if (customerId!=0)
            {
                return (new JavaScriptSerializer().Serialize(empRepo.GetAllEmployeesSearch(customerId)));
            }

            return (new JavaScriptSerializer().Serialize(empRepo.GetAllEmployees()));

          //  empRepo.GetAllEmployees();


            //using (CustomerEntities entities = new CustomerEntities())
            //{
            //    var customers = from p in entities.Customers
            //                    where p.CustomerId == customerId || customerId == 0
            //                    select p;
            //    return (new JavaScriptSerializer().Serialize(customers.ToList()));
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}