 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

namespace Phase03_1.oneClickBuy
{


    public static class StringExtension
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
    }


    public partial class buy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string pid = Request.QueryString["ID"];

            //Connecting to DB
            string connStr = "Server=DELL-PC\\SQLEXPRESS;Database=SampleDB;User Id=web_user; Password=12345;";
            // string connStr = "Server=A134-002\\MSSQLSERVER3;Database=SampleDB;User Id=web_user; Password=12345;";

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            //Attempting to select info in row
            SqlCommand cmd = new SqlCommand("SELECT [product],[description],[price],[currentAmount],[pid] FROM [dbo].[PRODUCTS] WHERE[pid] = '" + pid + "';");

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;

            //create a reader
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbl_PName.Text = reader["product"].ToString();
                lbl_Descr.Text = reader["description"].ToString();
                lbl_Price.Text = reader["price"].ToString();
            }

            conn.Close();

            lbl_PName1.Text = lbl_PName.Text;
            lbl_Price1.Text = lbl_Price.Text;

            // Get all the info for the ID
            string id = (string)Session["id"];
            int value = Int32.Parse(id);
            conn.Open();

            //Attempting to update info in row
            SqlCommand cmdd = new SqlCommand("SELECT [firstName],[lastName],[username],[address],[email],[phoneNumber],[cardNumber] FROM [dbo].[CUSTOMER] WHERE[id] = '" + value + "';");



            cmdd.CommandType = System.Data.CommandType.Text;
            cmdd.Connection = conn;

            //create a reader
            SqlDataReader readerd = cmdd.ExecuteReader();
            while (readerd.Read())
            {
                lbl_FName.Text = readerd["firstName"].ToString();
                lbl_LName.Text = readerd["lastName"].ToString();
                lbl_UName.Text = readerd["username"].ToString();
                lbl_Addr.Text = readerd["address"].ToString();
                lbl_Email.Text = readerd["email"].ToString();
                lbl_Phone.Text = readerd["phoneNumber"].ToString();
                lbl_Card.Text = readerd["cardNumber"].ToString();
            }
            conn.Close();

            lbl_Addr1.Text = lbl_Addr.Text;
            string Card1 = lbl_Card.Text.GetLast(4);



            try
            {
                // get data from the pag

                // string to = txtb_to.Text;
                string to = lbl_Email.Text;

                //string body = txtb_body.Text;
                string body = "Dear " + lbl_FName.Text +
                    ", Thank you for buying " + lbl_PName.Text + ". Your item will be shipped to: " + lbl_Addr.Text +
                    "  and your credit card ending last 4 digits: " + Card1 + "  will be charged $" + lbl_Price.Text +
                    "      Thank you for your business, " + "    Sincerelly, Your Prog117BC";


                // string subject = txtb_subject.Text;
                string subject = "Confirmation message regarding buying " + lbl_PName.Text;

                // create a MailMessage object
                MailMessage mail = new MailMessage();

                // your own gmail credentials
                string senderEmail = "Prog117bc@gmail.com"; // a valid gmail email
                string senderPasswd = "!qaz@wsx"; // a valid password for the email above

                // build the email
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(to.ToString());
                mail.Subject = subject;
                mail.Body = body;

                // set it to tru if you want HTML
                mail.IsBodyHtml = true;

                // in case you want to attach a file
                //mail.Attachments.Add(new Attachment("C:\\someFile.jpg"));

                // SMTP Client for gmail only. Other emails will have different SMTP Clients.
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); // port 587

                // set the credentials
                smtp.Credentials = new NetworkCredential(senderEmail, senderPasswd);
                smtp.EnableSsl = true;

                // send the email
                smtp.Send(mail);

                lbl_dbg.Text = "The confirmation message sent to email: " + lbl_Email.Text;

            }
            catch (Exception exp)
            {
                // this is for debug only. Delete this for production
                lbl_dbg.Text = exp.ToString();

           }


            }

    }
}