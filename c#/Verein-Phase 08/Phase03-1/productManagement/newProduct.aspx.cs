using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1.productManagement
{
    public partial class newProduct : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string Message = "Personal data copied to database";
            string Name = Request.QueryString["txt_Name"];
            string Descr = Request.QueryString["txt_Descr"];
            string Prise = Request.QueryString["txt_Prise"];
            string Amnt = Request.QueryString["txt_Amnt"];


            string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
            // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //create a command
            SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[PRODUCTS]([product],[description],[price],[currentAmount])" +
            "VALUES('" + Name + "', '" + Descr + "', '" + Prise + "', '" + Amnt + "');");

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //create a reader
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            conn.Close();
            Server.Transfer("showAllProducts.aspx", true);
        }


    }
}