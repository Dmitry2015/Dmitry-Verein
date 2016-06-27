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
        }

        private DataSet birdDataSet;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                BirdData.SaveBirdInfo(birdDataSet);
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
                birdDataSet = BirdData.GetBirdInfo();

                // notice I did not have to create headings on the dataGridView
                // it picks them up from the DataTable fields
                DataGridViewBirds.DataSource = birdDataSet;
                DataGridViewBirds.DataMember = "BirdCount";
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
    }
}
