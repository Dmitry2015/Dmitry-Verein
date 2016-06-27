using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {

            if (txt_Uname.Text.Equals(""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Please enter the Username')", true);
            }
            else
            {

                string db_id = "";
                string db_UName = "";
                string db_Psw = "";
                string dName = Request.QueryString["txt_dName"];
                string UName = Request.QueryString["txt_UName"];
                string Psw = Request.QueryString["txt_Psw"];


                //Connecting to DB
                string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
                // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                //Attempting to update info in row
                SqlCommand cmd = new SqlCommand("SELECT[id],[firstname],[username],[password] FROM[dbo].[CUSTOMER] WHERE[username] = '" + UName + "' AND[password] = '" + Psw + "'; ");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;

                //create a reader
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    db_id = reader["id"].ToString();
                    dName = reader["firstname"].ToString();
                    db_UName = reader["username"].ToString();
                    db_Psw = reader["password"].ToString();
                }
                conn.Close();

                if (UName == db_UName && Psw == db_Psw)
                {
                    lbl_id.Text = db_id;
                    Session["id"] = lbl_id.Text;

                    lbl_dName.Text = dName;
                    Session["dName"] = lbl_dName.Text;

                    Server.Transfer("welcome.aspx", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Wrong UserName or/and password.')", true);
                }

            }
        }
    }
}