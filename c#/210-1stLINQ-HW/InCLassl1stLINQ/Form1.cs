using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InCLassl1stLINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class StudentObject
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        // Create a data source by using a collection initializer. 
        static List<StudentObject> studentsDS = new List<StudentObject>
        {
           new StudentObject {First="Svetlana", Last="Omelche", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new StudentObject {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new StudentObject {First="Sven", Last="Morten", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new StudentObject {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new StudentObject {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new StudentObject {First="Fadi", Last="Fakhour", ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new StudentObject {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new StudentObject {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new StudentObject {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new StudentObject {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new StudentObject {First="Eugene", Last="Zabokrit", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new StudentObject {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };



        private void Form1_Load(object sender, EventArgs e)
        {
             var studentQuery =
             from studentFound in studentsDS                    
             orderby studentFound.Last ascending    // order by Last name
             select new { studentFound.First, studentFound.Last };            

            //// make a header for our textbox
            textBox1.Text = ("First Name\tLast Name\r\n");
            textBox1.Text += ("------------------------------------------------------\r\n");

            //// Execute the query. 
            foreach (var thing in studentQuery)
            {
                textBox1.Text += (thing.First + "\t\t" + thing.Last + "\r\n");
            }

            // now fill the 2nd textbox

            var testScoresQuery =
             from student in studentsDS
             orderby student.Last ascending  
             select new { student.First, student.Last, student.Scores };
            
            // should be able to use my header code here
            textBox2.Text = ("First Name\tLast Name \tScore Total  \r\n");
            textBox2.Text += ("-----------------------------------------------------------------------------------------\r\n");

            // write a foreach that Executes the query and displays the data. 
            foreach (var thing in testScoresQuery)  
            {
                textBox2.Text += (thing.First + "\t\t" + thing.Last + "\t\t" + thing.Scores.Sum() + "\r\n");
            }

        }
    }
}
