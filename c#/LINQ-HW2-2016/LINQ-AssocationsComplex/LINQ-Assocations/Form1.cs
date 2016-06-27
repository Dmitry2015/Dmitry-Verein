using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_Assocations
{
    public partial class Form1 : Form
    {
        //Get dataContext
        Prod_Cat_DataClassDataContext myProductsData = new Prod_Cat_DataClassDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Style dataGridView
            dataGridViewBirds.AlternatingRowsDefaultCellStyle.BackColor = Color.PeachPuff;
            dataGridViewBirds.RowsDefaultCellStyle.BackColor = Color.PowderBlue;
            dataGridViewBirds.AutoResizeColumns();

            //Style form
            this.BackColor = Color.AntiqueWhite;
        }

        private void refreshDataGridView()
        {
            // Using the LINQtoSQL association, for every count event get the name of the Bird
            // starting in BirdCounts table and looking thru back to Bird table

            var products = from ProductsCountItem in myProductsData.Products
                           where ProductsCountItem.UnitPrice > 40
                           orderby ProductsCountItem.Category.CategoryID ascending
                        select new
                        {
                            ProductsCountItem.Category.CategoryName,
                            ProductsCountItem.Category.Description,
                            ProductsCountItem.ProductName,
                            ProductsCountItem.UnitPrice,
                            ProductsCountItem.ProductID
                        };

            //Bind to gridView
            dataGridViewBirds.DataSource = products;
        }


        private void buttonGetBirds_Click(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void buttonUpdateCount_Click(object sender, EventArgs e)
        {
            decimal counted;  //Variable to hold textBox input
            if (decimal.TryParse(textBoxNewCount.Text, out counted))
            {
         //   Get selected row (can click anywhere in the row)
            var selected = dataGridViewBirds.CurrentRow;
            int ProductID = (int)selected.Cells["ProductID"].Value;

                //Get row from dataContext
                var selectedProductCount =
                    (from products in myProductsData.Products
                     where products.ProductID == ProductID
                     select products).Single();

                selectedProductCount.UnitPrice = counted;   //Edit dataContext
                myProductsData.SubmitChanges();            //Submit Changes
                refreshDataGridView();                 //Refresh the display

            }
            else
            {
                MessageBox.Show("Please enter a decimal number.");
            }
            textBoxNewCount.Text = "";  //Clear textBox in either case

        }

        private void textBoxNewCount_TextChanged(object sender, EventArgs e)
        {

        }

        //private void buttonDelete_Click(object sender, EventArgs e)
        //{
        //    //Retrieve selected row and id
        //    var selectedRow = dataGridViewBirds.CurrentRow;
        //    int selectedID = (int)selectedRow.Cells["CountID"].Value;

        //    //Retrieve row to delete from dataContext
        //    var rowToDelete =
        //        (from bird in myProductsData.Products
        //         where bird.CountID == selectedID
        //         select bird).Single();

        //    //Mark for deletion
        //    myProductsData.Products.DeleteOnSubmit(rowToDelete);

        //    //Try to submit changes
        //    try
        //    {
        //        myProductsData.SubmitChanges();  // LINQ to SQL does all the work for us
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error deleting item: " + ex.Message);
        //    }

        //    //refresh gridView
        //    refreshDataGridView();
        //}
    }
}
