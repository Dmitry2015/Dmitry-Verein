using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLib;

namespace DataAdapterSolution
{
    public partial class RelatedTablesForm : Form
    {
        private DataSet ordersDataSet;

        public RelatedTablesForm()
        {
            InitializeComponent();
        }

        private void RelatedTablesForm_Load(object sender, EventArgs e)
        {
            // use middle tier data access routines
            ordersDataSet = NorthwindDataAccess.GetOrders2();

            // use data binding with the text boxes
        //    orderIDTextBox.DataBindings.Add("Text", ordersDataSet, "Orders.OrderID");
        //    orderDateTextBox.DataBindings.Add("Text", ordersDataSet, "Orders.OrderDate", true);

            //use data binding with the datagrid view
            orderLinesdataGridView.DataSource = ordersDataSet;
            orderLinesdataGridView.DataMember = "Customers.UsefulRelation";


            //use data binding with the datagrid view
            dataGridViewOrderID.DataSource = ordersDataSet;
            dataGridViewOrderID.DataMember = "Customers";

        }


        private void moveNextButton_Click(object sender, EventArgs e)
        {
            //make use of the form binding context 
            this.BindingContext[ordersDataSet, "Customers"].Position += 1;
        }

        private void moveFirstButton_Click(object sender, EventArgs e)
        {
            //make use of the form binding context 
            this.BindingContext[ordersDataSet, "Customers"].Position = 0;
        }
        private void movePreviousButton_Click(object sender, EventArgs e)
        {
            //make use of the form binding context 
            this.BindingContext[ordersDataSet, "Customers"].Position -= 1;
        }

        private void moveLastButton_Click(object sender, EventArgs e)
        {
            //make use of the form binding context 
            this.BindingContext[ordersDataSet, "Customers"].Position = this.BindingContext[ordersDataSet, "Customers"].Count - 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
