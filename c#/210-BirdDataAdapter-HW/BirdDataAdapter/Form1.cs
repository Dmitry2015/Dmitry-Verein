using ClassLibraryDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdDataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            XMLDataSet = new BirdsDataSet();  // add this line

        }

        private DataSet sqlBirdsDataSet;

        private const string path = @"C:\databases\RemoteBirdClub.xml";

        BirdsDataSet XMLDataSet;


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                BirdData.SaveBirdInfo(sqlBirdsDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            //    MessageBox.Show(ex.Message);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            try
            {
                sqlBirdsDataSet = BirdData.GetBirdInfo();

                // notice I did not have to create headings on the dataGridView
                // it picks them up from the DataTable fields
                DataGridViewBirds.DataSource = sqlBirdsDataSet;
                DataGridViewBirds.DataMember = "BirdCount";
                DataGridViewBirds.AutoResizeColumns();

                // dataGridViewProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;  // colors
                DataGridViewBirds.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AntiqueWhite;  // colors

                DataGridViewBirds.AutoResizeColumns();  // sizing
                DataGridViewBirds.Columns["CountID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridViewBirds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonReadXML_Click(object sender, EventArgs e)
        {
            XMLDataSet.ReadXml(path);
            DataGridViewXML.DataSource = XMLDataSet.BirdCount;

        }

        private void buttonImportData_Click(object sender, EventArgs e)
        {

            DataRow newDataRow;
            
            foreach (BirdsDataSet.BirdCountRow thisRow in XMLDataSet.BirdCount)
                {

                newDataRow = sqlBirdsDataSet.Tables["BirdCount"].NewRow();

                newDataRow["RegionID"] = thisRow.RegionID;
                newDataRow["BirderID"] = thisRow.BirderID;
                newDataRow["BirdID"] = thisRow.BirdID;
                newDataRow["CountDate"] = thisRow.CountDate;
                newDataRow["Counted"] = thisRow.Counted;

                sqlBirdsDataSet.Tables["BirdCount"].Rows.Add(newDataRow);

            }


        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {

            try
            {
                int pointer = this.BindingContext[sqlBirdsDataSet, "BirdCount"].Position;
                sqlBirdsDataSet.Tables["BirdCount"].Rows[pointer].Delete();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
