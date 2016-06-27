using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phase03_1
{
    public partial class welcome : System.Web.UI.Page
    {
        public object txt_LName { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string fName = Request.QueryString["txt_FName"];
            lbl_FName.Text = fName;
            string dName = (string)Session["dName"];
            lbl_dName.Text = dName;
            Session.Contents.Remove("dName");



            string uid = Request.QueryString["ID"];
            Session["uid"] = uid;

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateAccount.aspx");
        }
    }
}