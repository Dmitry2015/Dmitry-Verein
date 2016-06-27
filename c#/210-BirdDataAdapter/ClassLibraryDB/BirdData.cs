using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDB
{
    public class BirdData
    {

        //  private const string connectString = @"Data Source=N252-004\MSSQLSERVER3;Initial Catalog = Birds;Integrated Security=SSPI";
        private const string connectString = @"Data Source=DELL-PC\SQLEXPRESS;Initial Catalog = Birds;Integrated Security=SSPI";
        private const string sqlErrorMessage = "Database operation failed.  Please contact your System Administrator.";

        /// <summary>
        /// Retrieve the product table information
        /// </summary>
        /// <returns>DataSet with Products Table</returns>
      //  public static DataSet GetProductInfo()
        public static DataSet GetBirdInfo()
        {
            SqlDataAdapter productsDataAdapter;   // takes rows returned from database and puts them into dataset
            DataSet internalDataSet;     // repository to hold data from  database

            //********************************************************************************

            try
            {
                //Instantiate the data adapter
                productsDataAdapter = new SqlDataAdapter();

                //Instantiate the dataset
                internalDataSet = new DataSet();

                //Configure the DataAdapter
                productsDataAdapter.SelectCommand = new SqlCommand();

                productsDataAdapter.SelectCommand.CommandText =
                "Select CountID,RegionID,BirderID,BirdID,CountDate,Counted from BirdCount order by CountID";

                productsDataAdapter.SelectCommand.Connection = new SqlConnection();
                productsDataAdapter.SelectCommand.Connection.ConnectionString = connectString;

                //Retrieve data from the database
                productsDataAdapter.Fill(internalDataSet, "BirdCount");

                //********************************************************************************
                ////now we wish to fill another table ,    //so we change the command text
                productsDataAdapter.SelectCommand.CommandText =
                "Select * from [Bird]"; // <<<<<<<<<<<<<<<<<<<<<<

                //now we contact the database again
                // and add another table to the dataset
                productsDataAdapter.Fill(internalDataSet, "Bird");

                //==========================================================
                // the Database will reject any changes that conflict with its
                // ref integ rules, but that is after-the-fact ...
                // if you replicate the rule here in the DataSet, then the
                // user will get told in the form when they make a mistake
                // this one prevents deleting a product that is currently
                // in an order

                ForeignKeyConstraint myFKeyConstraint;
                myFKeyConstraint = new ForeignKeyConstraint("Bird-BirdCount-FK",
                    internalDataSet.Tables["Bird"].Columns["BirdID"],
                    internalDataSet.Tables["BirdCount"].Columns["BirdID"]);
                myFKeyConstraint.DeleteRule = Rule.None;
                myFKeyConstraint.UpdateRule = Rule.None;

                myFKeyConstraint.AcceptRejectRule = AcceptRejectRule.Cascade;
                internalDataSet.Tables["BirdCount"].Constraints.Add(myFKeyConstraint);
                internalDataSet.EnforceConstraints = true;

                //********************************************************************************
                ////now we wish to fill another table ,    //so we change the command text
                productsDataAdapter.SelectCommand.CommandText =
                "Select * from [Region]"; // <<<<<<<<<<<<<<<<<<<<<<
                //now we contact the database again
                // and add another table to the dataset
                productsDataAdapter.Fill(internalDataSet, "Region");

                ForeignKeyConstraint myFKeyConstraint1;
                myFKeyConstraint1 = new ForeignKeyConstraint("Reg-BirdCount-FK",
                    internalDataSet.Tables["Region"].Columns["RegionID"],
                    internalDataSet.Tables["BirdCount"].Columns["RegionID"]);
                myFKeyConstraint1.DeleteRule = Rule.None;
                myFKeyConstraint1.UpdateRule = Rule.None;

                myFKeyConstraint1.AcceptRejectRule = AcceptRejectRule.Cascade;
                internalDataSet.Tables["BirdCount"].Constraints.Add(myFKeyConstraint1);
                internalDataSet.EnforceConstraints = true;
                

                //productsDataAdapter.SelectCommand.CommandText =
                //"Select * from [Birder]"; // <<<<<<<<<<<<<<<<<<<<<<
                //productsDataAdapter.Fill(internalDataSet, "Birder");

                //ForeignKeyConstraint myFKeyConstraint2;
                //myFKeyConstraint2 = new ForeignKeyConstraint("Birder-BirdCount-FK",
                //    internalDataSet.Tables["Birder"].Columns["BirderID"],
                //    internalDataSet.Tables["BirdCount"].Columns["BirderID"]);
                //myFKeyConstraint2.DeleteRule = Rule.None;
                //myFKeyConstraint2.UpdateRule = Rule.None;

                //myFKeyConstraint2.AcceptRejectRule = AcceptRejectRule.Cascade;
                //internalDataSet.Tables["BirdCount"].Constraints.Add(myFKeyConstraint2);
                //internalDataSet.EnforceConstraints = true;

                //************************************************************

                return internalDataSet;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlErrorMessage);
            }
            catch (Exception ex)
            {
                //send the exception to the presentation tier 
                throw ex;
            }


        }


        /// <summary>
        /// Update the database with changes from the DataSet
        /// </summary>
        // /// <param name="productsDataSet">DataSet containing Products Table</param>
        /// 
        /// <param name="birdDataSet">DataSet containing Products Table</param>
        /// 
        /// <returns>number of rows changed</returns>

        public static int SaveBirdInfo(DataSet birdDataSet)
        {
            int rowCount;
            SqlDataAdapter productDataAdapter;

            //Instantiate the data adapter
            productDataAdapter = new SqlDataAdapter();

            try
            {

                //Configure the DataAdapter

                //UPDATE Command  ----------------------------------------------------------------------------------------------------------

                productDataAdapter.UpdateCommand = new SqlCommand();

                //note that we do not need a new connection
                // we can use the same connection as that used by the InsertCommand 

                productDataAdapter.UpdateCommand.Connection = new SqlConnection();
                productDataAdapter.UpdateCommand.Connection.ConnectionString = connectString;

                // here is the prototype SQL for the Update Command
                productDataAdapter.UpdateCommand.CommandText =
                " UPDATE BirdCount " +
                " SET RegionID = @RegionID, " +
                " BirderID =@BirderID, " +
                " BirdID= @BirdID," +
                " CountDate=@CountDate, " +
                " Counted=@Counted " +
                 " WHERE CountID = @CountID";

        //Set up the parameters for the update command  (need to change from productDataAdapter.InsertCommand.Parameters
        // to productDataAdapter.UpdateCommand.Parameters

        productDataAdapter.UpdateCommand.Parameters.Add("@CountID", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@CountID"].SourceColumn = "CountID";

                productDataAdapter.UpdateCommand.Parameters.Add("@RegionID", System.Data.SqlDbType.NVarChar, 5);
                productDataAdapter.UpdateCommand.Parameters["@RegionID"].SourceColumn = "RegionID";

                productDataAdapter.UpdateCommand.Parameters.Add("@BirderID", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@BirderID"].SourceColumn = "BirderID";

                productDataAdapter.UpdateCommand.Parameters.Add("@BirdID", System.Data.SqlDbType.NVarChar, 10);
                productDataAdapter.UpdateCommand.Parameters["@BirdID"].SourceColumn = "BirdID";

                productDataAdapter.UpdateCommand.Parameters.Add("@CountDate", System.Data.SqlDbType.SmallDateTime);
                productDataAdapter.UpdateCommand.Parameters["@CountDate"].SourceColumn = "CountDate";

                productDataAdapter.UpdateCommand.Parameters.Add("@Counted", System.Data.SqlDbType.Int);
                productDataAdapter.UpdateCommand.Parameters["@Counted"].SourceColumn = "Counted";
                                             

                //GO

                // explicitly open connection

                productDataAdapter.UpdateCommand.Connection.Open();

                //Use the DataAdapter to update the database
                rowCount = productDataAdapter.Update(birdDataSet, "BirdCount");

                return rowCount;
            }

            //catch (SqlException sqlEx)
            //{
            //    throw new ApplicationException(sqlErrorMessage);
            //}

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                //close the connection
                productDataAdapter.UpdateCommand.Connection.Close();
            }
        }
    }
}
