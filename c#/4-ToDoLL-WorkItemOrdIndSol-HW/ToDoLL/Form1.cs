using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoLL
{
    public partial class Form1 : Form
    {
        Book ToDoLL;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoLL = new Book();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Book aBook = new Book();
            aBook.Rating = Convert.ToInt32(textBoxRating.Text);
            aBook.Title = textBoxWhat.Text;
            aBook.Author = textBoxWhy.Text;

        // This program will store either by the priority text box, using this method to Insert
        //      ToDoLL.InsertAt(newWorkItem, Convert.ToInt32(textBoxPrioity.Text)); // get the index value from the new textBoxPrioity
        //      ToDoLL.InsertAt(newWorkItem, Convert.ToInt32(textBoxValue.Text)); // get the index value from the new textBoxPrioity

        // or it will store them based on the value of the value text box.
        //    ToDoLL.InsertInOrder(newWorkItem);  // 
        ToDoLL.InsertInOrder(aBook);

            textBoxRating.Text = "";
            textBoxWhat.Text= "";
            textBoxWhy.Text = "";
        }

        private void buttonGetNext_Click(object sender, EventArgs e)
        {
            try
            {
                //    WorkItem currentWorkItem = new WorkItem();
                Book currentWorkItem = new Book();

                currentWorkItem = ToDoLL.RemoveFromFront();
                labelDataOutput.Text = currentWorkItem.Rating.ToString();
                labelWhatOutput.Text = currentWorkItem.Title;
                labelWhyOutput.Text = currentWorkItem.Author;
            }
            catch (Exception)
            {
                labelDataOutput.Text = "Nothing more to do.";
                labelWhatOutput.Text = "";
                labelWhyOutput.Text = "";
            }
          
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelDataOutput_Click(object sender, EventArgs e)
        {

        }
    }
}
