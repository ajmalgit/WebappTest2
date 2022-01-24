using MVC_BusinessEntities1;
using MVC_DataAccessLayer2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebAppTest2
{
    /// <summary>
    /// Summary description for Handler3
    /// </summary>
    public class Handler3 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string json = "";
            json = this.GetStudentList();

            string type = context.Request.QueryString["type"];

            string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();

            BE_EmpModel objUsr = Deserialize<BE_EmpModel>(strJson);

            string custid = "0";
            int customerId = 0;
           

            if (type == "add")
            {
                json = this.GetCustomersJSON(int.Parse(custid), type, objUsr);
            }
            else if (type == "update")
            {
                json = this.GetCustomersJSON(int.Parse(custid), type, objUsr);
            }
            else if (type == "salary")
            {
                json = this.GetCustomersJSON(int.Parse(custid), type, objUsr);
            }
            else
            {
                json = this.GetCustomersJSON(customerId, type, objUsr);
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }


        private string GetCustomersJSON(int customerId, string type, BE_EmpModel obj)
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
            else if (type == "salary")
            {
                //empRepo.GetEmployeeSal(obj.id);
                return (new JavaScriptSerializer().Serialize(empRepo.GetEmployeeSal(obj.id)));
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



        }


        public T Deserialize<T>(string context)
        {
            string jsonData = context;

            //cast to specified objectType
            var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
            return obj;
        }







        public string GetStudentList()
        {

            DL_EmpRepository empRepo = new DL_EmpRepository();
          
              //  List<BE_EmpModel> studentList = empRepo.GetAllEmployees();

            //    var jsonSerializer = new JavaScriptSerializer();

            //  return Json(jsonSerializer.Serialize(studentList), JsonRequestBehavior.AllowGet);
            //  return jsonSerializer.Serialize(studentList);
            //  return jsonSerializer.Serialize((studentList, JsonRequestBehavior.AllowGet));
            return (new JavaScriptSerializer().Serialize(empRepo.GetAllEmployees()));

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