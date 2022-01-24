using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_BusinessEntities;
using MVC_BusinessEntities1;

namespace MVC_DataAccessLayer2
{
   public class DL_EmpRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {

            
            string constr = ConfigurationManager.ConnectionStrings["MydeskConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details
        public bool AddEmployee(BE_EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@employeeName", obj.employeeName);
            com.Parameters.AddWithValue("@mobile", obj.mobile);
            com.Parameters.AddWithValue("@Address", obj.address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        public BE_EmpModel AddEmployee2(BE_EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@employeeName", obj.employeeName);
            com.Parameters.AddWithValue("@mobile", obj.mobile);
            com.Parameters.AddWithValue("@Address", obj.address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return obj;

            }
            else
            {
                obj.address = "";
                obj.mobile = "";
                obj.employeeName = "";
                return obj;
            }


        }
        //search
        public List<BE_EmpModel> GetAllEmployeesSearch(int id)
        {
            connection();
            List<BE_EmpModel> EmpList = new List<BE_EmpModel>();
            SqlCommand com = new SqlCommand("GetEmpSearch", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            EmpList = (from DataRow dr in dt.Rows

                       select new BE_EmpModel()
                       {
                           id = Convert.ToInt32(dr["Id"]),
                           employeeName = Convert.ToString(dr["employeeName"]),
                           mobile = Convert.ToString(dr["mobile"]),
                           address = Convert.ToString(dr["address"])
                       }).ToList();


            return EmpList;


        }
        //To view employee details with generic list 
        public List<BE_EmpModel> GetAllEmployees()
        {
            connection();
            List<BE_EmpModel> EmpList = new List<BE_EmpModel>();
            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            EmpList = (from DataRow dr in dt.Rows

                       select new BE_EmpModel()
                       {
                           id = Convert.ToInt32(dr["Id"]),
                           employeeName = Convert.ToString(dr["employeeName"]),
                           mobile = Convert.ToString(dr["mobile"]),
                           address = Convert.ToString(dr["address"])
                       }).ToList();


            return EmpList;


        }
        //To Update Employee details
        public bool UpdateEmployee(BE_EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.id);
            com.Parameters.AddWithValue("@Name", obj.employeeName);
            com.Parameters.AddWithValue("@mobile", obj.mobile);
            com.Parameters.AddWithValue("@Address", obj.address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To delete Employee details

        //display salary


        public List<BE_EmpModel> GetEmployeeSal(int id)
        {
            connection();
            List<BE_EmpModel> EmpList = new List<BE_EmpModel>();

            //List<BE_EmpSalary> EmpSalList = new List<BE_EmpSalary>();
            //BE_EmpModel empModel = new BE_EmpModel();
            //BE_EmpSalary empSal = new BE_EmpSalary();
            //empModel.lstEmpsal.Add(empSal);

            SqlCommand com = new SqlCommand("GetEmpSal", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            //EmpList = (from DataRow dr in dt.Rows
            //           select new BE_EmpModel()
            //           {
            //               id = Convert.ToInt32(dr["Id"]),
            //               employeeName = Convert.ToString(dr["employeeName"]),
            //               mobile = Convert.ToString(dr["mobile"]),
            //               address = Convert.ToString(dr["address"])
            //               }

            //           ).ToList();

           

            foreach (DataRow dr in dt.Rows )
            {
                BE_EmpModel empModel1 = new BE_EmpModel();
              

                empModel1.id = Convert.ToInt32(dr["Id"]);
                empModel1.employeeName = Convert.ToString(dr["employeeName"]);
                //  empModel1.lstEmpsal = new List<BE_EmpSalary>();

                BE_EmpSalary empSal1 = new BE_EmpSalary();

                empSal1.EmpSal = Convert.ToInt32(dr["salary"]);
                empSal1.EmpSalMonth = Convert.ToInt32(dr["month"]);
                //   empModel1.mobile = Convert.ToString(dr["mobile"]);
                // empModel1.address = Convert.ToString(dr["address"]);

                try
                {
                    empModel1.lstEmpsal.Add(empSal1);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    
                    
                }
              

                EmpList.Add(empModel1);



           
            }


            return EmpList;


        }

        public bool DeleteEmployee(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}
