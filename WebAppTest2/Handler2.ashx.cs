using MVC_BusinessEntities1;
using MVC_DataAccessLayer2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebAppTest2.repository;

namespace WebAppTest2
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string custid = context.Request.QueryString["Id"];
            string name = context.Request.QueryString["Name"];
            string type = context.Request.QueryString["type"];

            string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();



            //  EmpModel objUsr = Deserialize<EmpModel>(strJson);

            BE_EmpModel objUsr = Deserialize<BE_EmpModel>(strJson);

            //  string callback = context.Request.QueryString["callback"];
            int customerId = 0;
            custid = "0";

          //  string custid = context.Request.QueryString["customerId"];
            int.TryParse(context.Request.QueryString["customerId"], out customerId);
            string json = "";
            if (type == "add")
            {
                json = this.GetCustomersJSON(int.Parse(custid),type, objUsr);
            }
           else if (type == "update")
            {
                json = this.GetCustomersJSON(int.Parse(custid), type, objUsr);
            }
            else
            {
                json = this.GetCustomersJSON(customerId,type, objUsr);
            }


            //if (!string.IsNullOrEmpty(callback))
            //{
            //    json = string.Format("{0}({1});", callback, json);
            //}

            context.Response.ContentType = "text/json";
            context.Response.Write(json);
            //   context.Response.ContentType = "text/plain";
            //  context.Response.Write("Hello World");
        }

        // we create a userinfo class to hold the JSON value
    


        // Converts the specified JSON string to an object of type T
        public T Deserialize<T>(string context)
        {
            string jsonData = context;

            //cast to specified objectType
            var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
            return obj;
        }

        private string GetCustomersJSON(int customerId,string type , BE_EmpModel obj)
            // private string GetCustomersJSON(int customerId, string type, EmpModel obj)
        {
           

            DL_EmpRepository empRepo = new DL_EmpRepository();

          //  EmpRepository empRepo = new EmpRepository();

            if (type == "add")
            {
                empRepo.AddEmployee(obj);
               // return (new JavaScriptSerializer().Serialize(empRepo.GetAllEmployees()));


            }
            else if (type == "update")
            {
                empRepo.UpdateEmployee(obj);
            }
            else if (type == "delete")
            {
                empRepo.DeleteEmployee(obj.id);
            }

            else if (customerId != 0)
            {
               // return (new JavaScriptSerializer().Serialize(empRepo.GetAllEmployeesSearch(customerId)));
            }
            else
            {
              
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