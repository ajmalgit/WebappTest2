using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppTest2.repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MydeskConnection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details
        public bool AddEmployee(EmpModel obj)
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
        public EmpModel AddEmployee2(EmpModel obj)
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
        public List<EmpModel> GetAllEmployeesSearch(int id)
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();
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

                       select new EmpModel()
                       {
                           id = Convert.ToInt32(dr["Id"]),
                           employeeName = Convert.ToString(dr["employeeName"]),
                           mobile = Convert.ToString(dr["mobile"]),
                           address = Convert.ToString(dr["address"])
                       }).ToList();


            return EmpList;


        }
        //To view employee details with generic list 
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();
            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind EmpModel generic list using LINQ 
            EmpList = (from DataRow dr in dt.Rows

                       select new EmpModel()
                       {
                           id = Convert.ToInt32(dr["Id"]),
                           employeeName = Convert.ToString(dr["employeeName"]),
                           mobile = Convert.ToString(dr["mobile"]),
                           address = Convert.ToString(dr["address"])
                       }).ToList();


            return EmpList;


        }
        //To Update Employee details
        public bool UpdateEmployee(EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.id);
            com.Parameters.AddWithValue("@Name", obj.employeeName);
            com.Parameters.AddWithValue("@mobile", 888888);
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