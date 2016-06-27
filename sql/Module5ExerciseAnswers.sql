/*
PROG 140          Module 5 Assignment   #5
POINTS 50              DUE DATE :  Consult module
							

---------------------------------------------------------------------------------------------------------------------------------------------------------

Develop a SQL statement for each task listed.  This exercise uses the Northwind database.

Please type your SQL statement under each task below.  Ensure your statement works by testing it prior to turning it in
When writing answers for your select statements please keep in mind that there is more than one way to write a query. 
Please do your best to write a query that not only returns the information the questions asks for but to the best of your ability, in the best way possible to suit their needs. For example, consider the best way to sort, to name columns, etc. 
These are things you must think about on the job!
 
Turn In:

You will NOT turn in this assignment. Instead, please:
1) FIRST study all the module materials including the required readings in our textbook and watching all videos. 
2) Then study the questions in the Module5Exercise.sql file and carefully attempt to answer all of these on your own.
3) Then look at the answers file provided below to see examples of how these could be answered keeping in mind 
	 that there is often more than one way to get the same answer so if your answer retrieved the exact 
	 same results then yours may or may not be better!
	 Use the Discussion area to compare answers with your colleagues in our course, ie., other students and your instructor!
4) Only after you have fully studied by doing all of the above then take the QUIZ for this module and you should do well! 



*/

-- Tasks:  

/*
1.  Write a stored procedure within the Northwind database that will do the following:
     1. Check for the existence of a table named "EmployeesCopy" 
	 2. if it is true that the table EmployeesCopy exists to drop it and
	 3. Create a table called EmployeesCopy using a Select Into statement (do NOT use a Create table statement)
	     that will create and load the new EmployeesCopy table with all Employees from Northwind's Employees table. 
     
	 Name this procedure uspEmployees copy.
	 Note: Be sure this and all stored procedures you write contain a  couple of lines of documentation that specify, 
	 as a minimum, yourself as the author, the date it is written and a short description of what the procedure does. 

	 Please test your procedure to ensure it works and include here a working execute statement that
	 will correct call this procedure.

	 Include in your answer a statement to drop your stored procedure as well. (Separate statement - NOT inside the 
	 stored procedure of course!)
	 
	 Hint: there is a very similar example to this in our demo file for this module. 
*/
-- write your SQL statements here: 
/*
	Author: SQL Student
	Description: This sp checks for EmployeesCopy table, and drops it if it exists.
	Then it creates a new EmployeesCopy table and inserts all of the 
	Employees tables data into it.
*/
CREATE PROCEDURE uspEmployeesCopy
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY

		IF OBJECT_ID('EmployeesCopy') IS NOT NULL-- If EmployeesCopy exists
			DROP TABLE EmployeesCopy;-- Drop Employees Copy

		-- Select all data from Employees, create a table called EmployeesCopy and fill it
		SELECT * INTO EmployeesCopy
		FROM Employees;

	END TRY

	BEGIN CATCH
		DECLARE @ErrMsg nvarchar(4000);
		SELECT @ErrMsg = ERROR_MESSAGE();
		Throw 50001, @ErrMsg, 1;
	END CATCH
	SET NOCOUNT OFF
END
-- end sproc uspEmployeesCopy 

EXEC uspEmployeesCopy;   -- this executes the procedure

-- clean up
IF OBJECT_ID('uspEmployeesCopy') IS NOT NULL
	DROP PROCEDURE uspEmployeesCopy;  
GO

/*
2.  Remember the Recycle table from Module 1 Assignment 1 (Question #3)?  You wrote code to create
	 this table and load it with data in that exercise.

	 In this exercise, write a stored procedure called uspRecycle that will:
	 1. first drop the Recycle table if it exists
	 2. create the Recycle table 
	 3. Load the recycle table with the same rows of data you loaded it with from Module 1 Assignment 1
	 4. Includes Try-Catch Error handling within the sproc itself using the Throw command (this is done in the template below)

	 You may use the template below to start.
	 Test your stored procedure works correctly by writing a simple exec statement and debugging as needed.
*/

Create Procedure uspRecycle
as
Begin
	Set nocount on 
	Begin Try
	     
			 --- write your code here as specified in the instructions 1-3 above ---

	End Try

	Begin Catch
	  DECLARE @ErrMsg nvarchar(4000);
	  SELECT @ErrMsg = ERROR_MESSAGE();
	  Throw 50001, @ErrMsg, 1;
	End Catch

-- checking to see if table exists and is loaded:
	If (Select count(*) from Recycle) >1 
		begin
			Print 'Recycle table created and loaded '; Print getdate()
		End
	set nocount off 
End
-- end sproc 
------------------------------------------------------------------------ end of template

-- YOUR ANSWER:
-- drop procedure uspRecycle
Create Procedure uspRecycle
as
Begin
Set nocount on 
Begin Try
	If object_id('Recycle') is not null
			Drop table Recycle

	CREATE TABLE Recycle
		(RecycleID INT NOT NULL IDENTITY(1,1)
			CONSTRAINT PK_Recycle PRIMARY KEY,
		RecycleType NCHAR(10) NOT NULL,
		RecycleDescription NVARCHAR(100) NULL)


	INSERT INTO Recycle
		(RecycleType, RecycleDescription)
	VALUES ('Compost', 'Product is compostable, instructions included in packaging')

	INSERT INTO Recycle
		(RecycleType, RecycleDescription)
	VALUES ('Return', 'Product is returnable to company for 100% reuse')

	INSERT INTO Recycle
		(RecycleType, RecycleDescription)
	VALUES ('Scrap', 'Product is returnable and will be reclaimed and reprocessed')

	INSERT INTO Recycle
		(RecycleType, RecycleDescription)
	VALUES ('None', 'Product is not recycleable')

End Try

Begin Catch
  DECLARE @ErrMsg nvarchar(4000);
  SELECT @ErrMsg = ERROR_MESSAGE();
  Throw 50001, @ErrMsg, 1;
End Catch

If (Select count(*) from Recycle) >1 
	begin
		Print 'Recycle table created and loaded '; Print getdate()
	End
set nocount off 
End
-- end sproc 


-- write your simple execute statement here:
Exec uspRecycle

/*
3. Write a try-catch block to execute your stored procedure, uspRecycle, above. (It should be similar to what 
	was in our demo file, StoredProcedureBasics.sql)  
	For your convenience I am pasting an example from our demo file of a try-catch block that calls a stored procedure below.  
	You should use code similar to this to call your uspRecycle stored procedure:
	
	Begin Try
		Exec spInsertOrderDetails 
	end Try
	Begin Catch
		Print 'Error Message ' + convert(varchar, error_message());
		if error_number() >= 50000  print 'This is a custom error message';
	End Catch
*/
-- write your sql code here:

BEGIN TRY
    EXEC dbo.uspRecycle;
END TRY

BEGIN CATCH
    PRINT 'Error Message: ' + convert(nvarchar(4000), error_message());
    IF error_number() >= 50000 PRINT 'This is a custom error message.';
END CATCH;

/*
4. Let's say you're on the job in the Northwind company and people in your team are using the following script to get a 
	history of orders for an individual customer:

	-------------------------------------- start script
	Declare @CustomerID nchar(5);
	Set @CustomerID = 'ALFKI'  -- change the customerid here to the customer you are interested in

	SELECT ProductName, Total=SUM(Quantity)
	FROM Products P, [Order Details] OD, Orders O, Customers C
	WHERE C.CustomerID = @CustomerID
	AND C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID AND OD.ProductID = P.ProductID
	GROUP BY ProductName
	Order by Total Desc;
	------------------------------------- end script

	You want to add value to your new team as recent graduate of SQL Programming at Bellevue College
	so you volunteer to rewrite this as a stored procedure that can be called with a parameter for the
	CustomerID.  Your stored procedure will be written containing all of these things:
	* good documentation in the form of comments
	* error handling 
	* an existence check so that if the value of the CustomerID does not exist in the Customers table the query
	   in the stored procedure will not execute

	Recommendation (this is optional and you do NOT have to show your work):  Write this step-by-step!
	First  step - get it working without a parameter and so that it returns all values
	Second step - add the parameter and make sure that works
	Third step - add the existence check using examples from our demo scripts
	Fourth step - add the error handling similar to what was done above and in our examples in the demos
	Fifth step - add in the documentation and pretty it up!
	Sixth step - Add in multiple execute statements to test this and ensure it works!

	Challenge:
	*   make the parameter have a default value
	*   if the value of the parameter is null, print out the order history for ALL
					customers!

*/
-- write your sql code here
/*
	Author: SQL Student
	Description: This sp checks for the Recycle table, and drops it if it exists.
	Then it creates a new Recycle table and inserts 4 rows of data.
*/
alter PROCEDURE uspCustomerOrderHistory	
	(@CustomerId NCHAR(5) = NULL) -- Default is null if no param is passed
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY
		
		IF @CustomerId IS NULL
			BEGIN
				-- This will print out order history for all customers
				SELECT P.ProductName, Total=SUM(Quantity)
				FROM Products P
				JOIN [Order Details] OD ON P.ProductID = OD.ProductID
				JOIN Orders O ON OD.OrderID = O.OrderID
				JOIN Customers C ON O.CustomerID = C.CustomerID
				GROUP BY P.ProductName
				ORDER BY Total DESC;
			END
		ELSE IF EXISTS(SELECT * FROM Customers WHERE CustomerID = @CustomerId)
			BEGIN
				-- This Select gets a history of orders for an individual customer
				SELECT P.ProductName, Total=SUM(Quantity)
				FROM Products P
				JOIN [Order Details] OD ON P.ProductID = OD.ProductID
				JOIN Orders O ON OD.OrderID = O.OrderID
				JOIN Customers C ON O.CustomerID = C.CustomerID
				WHERE C.CustomerID = @CustomerId
				GROUP BY P.ProductName
				ORDER BY Total DESC;
			END
		ELSE
			BEGIN
				PRINT 'The CustomerID ' + @CustomerID + ' is not present in the database...';
			END
	END TRY
	BEGIN CATCH
		DECLARE @ErrMsg nvarchar(4000);
		SELECT @ErrMsg = ERROR_MESSAGE();
		Throw 50001, @ErrMsg, 1;
	END CATCH
SET NOCOUNT OFF
END	
-- end of sproc uspCustomerOrderHistory

-- the following two execute statements should each print out the total order history for the customer
-- since the input parameter will be null
EXEC uspCustomerOrderHistory null;
EXEC uspCustomerOrderHistory;  

-- the following should print out only the customer order history for the valid customer 'ALFKI'
EXEC uspCustomerOrderHistory 'ALFKI';  -- 12 rows

-- the following will print a message that the customer is not valid:
EXEC uspCustomerOrderHistory 'asldkf';

-- clean up
DROP PROCEDURE uspCustomerOrderHistory;
	

/*
5.  The following is a stored procedure that already exists in the	Northwind database:

		Create Procedure [dbo].[Employee Sales by Country] 
			@Beginning_Date DateTime
			, @Ending_Date DateTime 
			AS
			SELECT Employees.Country, Employees.LastName, Employees.FirstName, Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal AS SaleAmount
			FROM Employees INNER JOIN 
				(Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID) 
				ON Employees.EmployeeID = Orders.EmployeeID
			WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date

		First: describe what this stored procedure does as though you are explaining to a co-worker on  your team
		who has limited SQL experience.
		
		Second: Rewrite this stored procedure to use default values for the two input parameters. The default values 
		will be the January 1st, 2014 for the start date and December 31st 2014**

		Third:
		Make the default values generic to use the January 1st of the current year for the Beginning_Date parameter 
		and December 31st of the current year for the end date parameter, no matter what year it is.  Hint: you 
		will use SQL Server date functions!
*/
-- write your sql code here:


USE Northwind;

/*
	Author: SQL Student

	Description: This sp is a rewrite of the existing sproc: [dbo].[Employee Sales by Country] 
	It has been customized to include to parameters to allow for the entry of a begin and end date
	If no parameters are supplied it will default to the current year. 
*/
Create Procedure [dbo].[uspEmployeeSalesbyCountry] 
@Beginning_Date DateTime = null
, @Ending_Date DateTime = null
AS
begin
 IF @Beginning_Date IS NULL 
 SET @Beginning_Date = '1/1/' + CONVERT(varchar, DATEPART(yyyy, getdate()))
 IF @Ending_Date IS NULL 
 SET @Ending_Date = '12/31/' + CONVERT(varchar, DATEPART(yyyy, getdate()))

SELECT Employees.Country, Employees.LastName
, Employees.FirstName, Orders.ShippedDate, Orders.OrderID, "Order Subtotals".Subtotal AS SaleAmount
FROM Employees INNER JOIN 
(Orders INNER JOIN "Order Subtotals" ON Orders.OrderID = "Order Subtotals".OrderID) 
ON Employees.EmployeeID = Orders.EmployeeID
WHERE Orders.ShippedDate Between @Beginning_Date And @Ending_Date
end
-- end sproc

-- testing the procedure:
 EXEC [dbo].[Employee Sales by Country];
 EXEC [dbo].[Employee Sales by Country] '1990-01-01', '2013-12-31';




 --**  Notes for testing
--When you check the data you will know that there are no records that qualify, ie., none that have shipped this year. You can see this by executing:

Use Northwind
select min(ShippedDate), max(ShippedDate) from Orders

--Here are a couple of records I'm inserting in order to test your work as it comes in. I am sharing it with you so that you can also test it yourself prior to turning it in!!


Insert into orders values ('alfki', 5, getdate(), getdate(), getdate(), 1, 12, 'Sweeney', '100 Main', 'Seattle', 'WA', 98116, 'USA')

---- the above code created an order # 11078 in my database. It may not be the exact # in yours depending upon what you have modified in yours.

---- to find the exact number run the following code:

select @@identity  -- this will print the new order # that you just inserted!  

-- @@Identity is a global variable that returns the value of whatever is the most recently inserted identity value 

---- in the following line of code replace the value 11078 with the value just returned by the line of code above.  

insert into [order details] values (11078, 10, 15.00, 2, 0);


--**  Notes for testing
--When you check the data you will know that there are no records that qualify, ie., none that have shipped this year. You can see this by executing:

Use Northwind
select min(ShippedDate), max(ShippedDate) from Orders

--Here are a couple of records I'm inserting in order to test your work as it comes in. I am sharing it with you so that you can also test it yourself prior to turning it in!!


Insert into orders values ('alfki', 5, getdate(), getdate(), getdate(), 1, 12, 'Sweeney', '100 Main', 'Seattle', 'WA', 98116, 'USA')

---- the above code created an order # 11078 in my database. It may not be the exact # in yours depending upon what you have modified in yours.

---- to find the exact number run the following code:

select @@identity  -- this will print the new order # that you just inserted!  

-- @@Identity is a global variable that returns the value of whatever is the most recently inserted identity value 

---- in the following line of code replace the value 11078 with the value just returned by the line of code above.  

insert into [order details] values (11078, 10, 15.00, 2, 0);