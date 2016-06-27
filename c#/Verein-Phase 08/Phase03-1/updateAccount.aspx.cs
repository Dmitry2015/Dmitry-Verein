using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1
{
    public partial class updateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = (string)Session["id"];
            int value = Int32.Parse(id);

            //Connecting to DB
            string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
            // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //Attempting to update info in row
            SqlCommand cmd = new SqlCommand("SELECT [firstName],[lastName],[username],[password],[address],[email],[phoneNumber],[cardNumber] FROM [dbo].[CUSTOMER] WHERE[id] = '" + value + "';");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //create a reader
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txt_FName.Text = reader["firstName"].ToString();
                txt_LName.Text = reader["lastName"].ToString();
                txt_UName.Text = reader["username"].ToString();
                txt_Psw.Text = reader["password"].ToString();
                txt_Addr.Text = reader["address"].ToString();
                txt_Email.Text = reader["email"].ToString();
                txt_Phone.Text = reader["phoneNumber"].ToString();
                txt_Card.Text = reader["cardNumber"].ToString();
            }
            conn.Close();
            Session["idf"] = id;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                string idf = (string)Session["idf"];
                int val = Int32.Parse(idf);
                string fName = Request.QueryString["txt_FName"];
                string LName = Request.QueryString["txt_LName"];
                string UName = Request.QueryString["txt_UName"];
                string Psw = Request.QueryString["txt_Psw"];
                string Addr = Request.QueryString["txt_Addr"];
                string Email = Request.QueryString["txt_Email"];
                string Phone = Request.QueryString["txt_Phone"];
                string Card = Request.QueryString["txt_Card"];

            //Connecting to DB
            string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
                // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                //Attempting to update info in row
                SqlCommand cmd = new SqlCommand("UPDATE[dbo].[CUSTOMER] SET[firstName] = '" + fName + "',[lastName] = '" + LName + "',[username] = '" + UName +
                    "',[password] = '" + Psw + "',[address] = '" + Addr + "',[email] = '" + Email + "',[phoneNumber] = '" + Phone + "',[cardNumber] = '" + Card + "' WHERE[id] = '" + val + "';");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("updateAccount.aspx");
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("welcome.aspx", true);
        }
    }
}