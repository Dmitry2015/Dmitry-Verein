using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1.productManagement
{
    public partial class showAllProducts : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //Connecting to DB
            string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
            // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //Attempting to select info in row
            SqlCommand cmd = new SqlCommand("SELECT [product],[description],[price],[currentAmount],[pid] FROM [dbo].[PRODUCTS];");

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            string temp = "";
            string pidTemp = "";

            //create a reader
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp += reader["product"].ToString();
                temp += " ";
                temp += reader["description"].ToString();
                temp += " ";
                temp += reader["price"].ToString();
                temp += " ";
                temp += reader["currentAmount"].ToString();
                temp += " ";
                pidTemp = reader["pid"].ToString();

                temp += "<a href = \"../oneClickBuy/buy.aspx/?ID=" + pidTemp + "\" >Buy</a>";

                temp += "<br/>";
            }

            conn.Close();

            lbl_test2.Text = temp;
        }








}
}