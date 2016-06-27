using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public static class NorthwindDataAccess
    {
        //Note:  If your server is not named localhost, you will need to change the connection string
        // private const string connectString = @"Server = localhost;Database=Northwind;Integrated Security=SSPI";
        private const string connectString = @"Server = DELL-PC\SQLEXPRESS;Database=Prog210northwind;Integrated Security=SSPI";

        //private const string connectString = @"Server = lrumans-a255h\linda2005;Database=Northwind;Integrated Security=SSPI";

        // Generic error message for database issues
        private const string sqlErrorMessage = "Database operation failed.  Please contact your System Administrator";



        /// <summary>
        /// This method retrieves data from 2 tables in the Northwind
        /// database and returns a dataset holding the 2 tables with a DataRelation.
        /// </summary>
        /// <returns>The DataSet containing 2 tables that are related by a DataRelation
        /// </returns>
        /// 



        public static DataSet GetOrders2()
        {
            // data adapter
            SqlDataAdapter northwindAdapter;
            //data set
            DataSet ordersDataSet;
            //relation
            DataRelation ordersDataRelation;

            //instantiate the data adapter
            northwindAdapter = new SqlDataAdapter();
            //instantiate the select command object
            northwindAdapter.SelectCommand = new SqlCommand();
            //instantiate the connection object
            northwindAdapter.SelectCommand.Connection = new SqlConnection();
            try
            {
                // set the connection string in the connection object
                northwindAdapter.SelectCommand.Connection.ConnectionString = connectString;
                //set the command text
                northwindAdapter.SelectCommand.CommandText =
                    "Select * from Customers order by CustomerID";
                //instantiate the data set to be filled
                ordersDataSet = new DataSet("Orders DataSet");
                //contact the database
                //includes the connect and the sending of the SQL
                //and fill 1 table in the dataset
                northwindAdapter.Fill(ordersDataSet, "Customers");

                //now we wish to fill another table 
                //so we change the command text
                northwindAdapter.SelectCommand.CommandText =
                   "Select * from [Orders] order by OrderDate DESC";
                //now we contact the database again
                // and add another table to the dataset
                northwindAdapter.Fill(ordersDataSet, "Orders");

                //set up the relationship between the 2 tables
                ordersDataRelation = new DataRelation("UsefulRelation",
                    ordersDataSet.Tables["Customers"].Columns["CustomerID"],
                    ordersDataSet.Tables["Orders"].Columns["CustomerID"]);
                ordersDataSet.Relations.Add(ordersDataRelation); // add it to the property which is a List<DataRelation>

                // Creating in-memory ForeignKeyConstraint  <<<< but won't let you have this with same rela as the DataRelation above, as the above already creates this too.
                ForeignKeyConstraint custOrderFK = new ForeignKeyConstraint("custOrderFK",  // rela name, then parent, then child
                    ordersDataSet.Tables["Customers"].Columns["CustomerID"],
                    ordersDataSet.Tables["Orders"].Columns["CustomerID"]);
                custOrderFK.DeleteRule = Rule.None;  // now that we have a Constraint, how do we want to handle conflicts?
                // .None = take no action, so system will not delete an order that has associated line item in the Order Details table.
                //ordersDataSet.Tables["OrderDetails"].Constraints.Add(custOrderFK);  // like adding params, we need to add this to property that is a List<ForeignKeyConstraint>

                return ordersDataSet;
            }
            catch (SqlException sqlEx)
            {
                //here you might write details to an error log
                // that exists on a network server or in another database

                //note that we do not throw the original SQLException object
                //because the object contains information (server, database, etc.)
                //that we do not want to reveal
                throw new ApplicationException(sqlErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

    }
}
