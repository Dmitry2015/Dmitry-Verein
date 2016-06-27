using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstEntFrame
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        public string city { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            PayablesEntities myPayables = new PayablesEntities();

            var highInvoices =
            from eachInvoice in myPayables.Invoices  // entity collection
            from amount in eachInvoice.InvoiceLineItems

            where eachInvoice.InvoiceTotal < 1000 && eachInvoice.InvoiceTotal > 500
            orderby eachInvoice.InvoiceNumber descending
            select new
            {
                eachInvoice.InvoiceNumber,
                eachInvoice.InvoiceTotal,
                eachInvoice.InvoiceDate,
                eachInvoice.Vendor.City,
                Amount = amount.Amount,
                amount.Description
            };

            dataGridView1.DataSource = highInvoices.ToList();

        }
    }
}
