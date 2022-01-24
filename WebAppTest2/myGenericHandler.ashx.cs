//using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebAppTest2
{
    /// <summary>
    /// Summary description for myGenericHandler
    /// </summary>
    public class myGenericHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            foreach (string key in context.Request.Files)
            {
                HttpPostedFile postedFile = context.Request.Files[key];
                string folderPath = context.Server.MapPath("~/Uploads/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                postedFile.SaveAs(folderPath + postedFile.FileName);
            }
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";
            context.Response.Write("Success");
           // context.Response.ContentType = "text/plain";
            context.Response.Write("File Uploaded Successfully!");
        }

        public class userInfo
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string qualification { get; set; }
            public string age { get; set; }
        }


        // Converts the specified JSON string to an object of type T
        public T Deserialize<T>(string context)
        {
            string jsonData = context;

            //cast to specified objectType
            var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
            return obj;
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