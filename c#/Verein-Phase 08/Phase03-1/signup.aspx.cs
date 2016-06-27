using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1
{
    public partial class signup : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton1_Click(object sender, EventArgs e)
        {

            if (txt_Psw.Text.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Please enter the the value in the Password field')", true);
            }
            else if ((txt_Psw.Text == (txt_Psw1.Text)) && (!txt_Psw.Text.Equals("")))
            {

                //string Message = "Personal data copied to database";
                string fName = Request.QueryString["txt_FName"];
                string LName = Request.QueryString["txt_LName"];
                string UName = Request.QueryString["txt_UName"];
                string Psw = Request.QueryString["txt_Psw"];
                string Addr = Request.QueryString["txt_Addr"];
                string Email = Request.QueryString["txt_Email"];
                string Phone = Request.QueryString["txt_Phone"];
                string Card = Request.QueryString["txt_Card"];

                string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
                // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                //create a command
                SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[CUSTOMER]([firstName],[lastName],[username],[password],[address],[email],[phoneNumber],[cardNumber])" +
                    "VALUES('" + fName + "', '" + LName + "', '" + UName + "', '" + Psw + "', '" + Addr + "', '" + Email + "', '" + Phone + "', '" + Card + "') SELECT SCOPE_IDENTITY();");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                //create a reader
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string id = reader[0].ToString();
                conn.Close();

                lbl_id.Text = id;
                Session["id"] = lbl_id.Text;
                Server.Transfer("welcome.aspx", true);

                lbl_dbg.Text = "Clicked function";
            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Please enter the equal value in the both Password fields')", true);
            }
        }
    }
}