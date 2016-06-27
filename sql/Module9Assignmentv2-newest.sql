/*
PROG 140          Module 9 Assignment   #10		Back to Basics: MORE SQL PRACTICE!
POINTS 50              DUE DATE :  Consult module
							
Develop a SQL statement for each task listed.  This exercise uses the Northwind database.

Please type your SQL statement under each task below.  Ensure your statement works by testing it prior to turning it in
When writing answers for your select statements please keep in mind that there is more than one way to write a query. 
Please do your best to write a query that not only returns the information the questions asks for but to the best of your ability, 
in the best way possible to suit their needs. For example, consider the best way to sort, to name columns, etc. 
These are things you must think about on the job!
 
Turn In:

For this exercise you will submit one  WORD documents (instead of a .sql file) in which you have copied and pasted 
your entire work from your .sql file including all assignment questions and your SQL queries. 
The  document should contain your name at the top, assignment title, the date and any difficulties encountered. 


Submit your file to the instructor using the Canvas Assignment tool. 
*/


Use Northwind


/* 5 pts
1. Create a stored procedure that produces a list of all Suppliers in a 
      specified Region.  The procedure should accept 1 input parameter: Region. 
      The supplier list produced by the procedure should list, for each supplier:
      SupplierID, CompanyName, Region, and Country.  The list should be ordered 
      by CompanyName.  The procedure should also provide an OUTPUT parameter that
      returns the number of suppliers in the specified Region. 
	  (Reminder: we covered OUTPUT parameters in Module 5, Stored Procedure Basics, 
	  so if necessary, please review our Module 5 demo file: StoredProcedureBasics.sql)
      Note:  No error handling or commenting is required this time - just basic functionality.   */

	  go
	  create proc usp_ListSuppliersInRegion
	  @region Nvarchar(15),
	  @countInRegion INT OUTPUT
	  AS
	  Select SupplierID, CompanyName, Region, Country
	  From Suppliers
	  Where Region = @region
	  Order by CompanyName;

      Set @countInRegion =
	  (Select COUNT(*)
	  From Suppliers
	  Where Region = @region)
	

/* 2 pts
2.  Execute the above stored procedure for the Québec region. Make sure to display
        the value of the output parameter. You must set up a variable to hold the OUTPUT parameter, execute 
		the procedure and then use a Print statement to display the value of the OUTPUT parameter to the 
		Message window. */
        
        Go
		Declare @CountInRegion INT
		Exec usp_ListSuppliersInRegion 'Québec', @CountInRegion OUTPUT
		Print @CountinRegion
		go


/* 5 pts
3.  First: write an insert statement to insert yourself into the Employees table with a hiredate of today's date.
     Second: Write a Select statement that will retrieve all the Employees who were hired after '1/1/1993' 
		that have not ever sold anything (that means they do not have an order in the orders table).
		Hint:  please review left joins as necessary.  

*/

Insert into EMployees (LastName, FirstName, HireDate)
Values ('Verein', 'Dmitry', GETDATE());

Select e.*
From Employees e
Left join Orders o
On e.EmployeeID = o.EmployeeID
WHere o.EmployeeID IS NULL AND HireDate > '1/1/1993';


/* 2 pts
4. Create a new permanent table called SuppliersTest that has the same schema (same columns, same 
      datatypes) as the Suppliers table.  Populate the new table with a copy of the rows from the existing 
      Suppliers table. When you are finished the data in the SuppliersTest table should be the same as the data 
      in the Suppliers table.  You must accomplish this task using only one single SQL statement. The
	  Create table statement canNOT be used. 

	  Include a statement to drop your table.
*/

Select *
Into SuppliersTest
From Suppliers

Drop Table SuppliersTest

/* 5 pts
5. List all orders for the month of December 1997 that do NOT contain a line item for 
      product 59, "Raclette Courdavault". List the Order ID, Order Date, Customer ID 
      and Customer Name for each order.  (Note: Your answer will have 45 rows, assuming you have made
	  no significant, permanent changes to Northwind's Products, Customers and Orders tables.)
*/
select distinct o.orderID, OrderDate, c.customerID, c.CompanyName
from Orders o
join [Order Details] od
on o.orderID = od.orderID

join customers c
on c.customerID = o.customerID
where MONTH(OrderDate) = 12 AND YEAR(OrderDate) = 1997 AND ProductID <> 59;


/*  5 pts
6.   Your boss gives you an assignment: Find our best selling product.  You ask questions and determine that the boss would
			really like to see the top 5 best selling products and that by "best selling" he means those who have the most number of
			sales (ie., Orders), and not those that have sold the most quantity of products.
*/

Select top 5 o.ProductID, p.ProductName, COUNT(*) AS [Total Orders] 
From [Order Details] o 
JOIN Products p
on p.ProductID = o.ProductID
Group By o.ProductID, p.ProductName
Order by [Total Orders] DESC;
	 

/* 5 pts
7. Consider order # 10248. Write a script below that will:
	* write the select statement to list this order in the Orders table
	* write another separate select statement to list all line items for Order 10248 in the Order Details table. 
	* Write a statement to begin a transaction.  
	* Write statement(s) to delete order 10248 and all its line items.
	* Write two statements: one to commit the transaction (comment that one out) and one to rollback the transaction
   */

   go
   select *
   from orders
   where OrderID = 10248;

   select *
   from [Order Details]
   where OrderID = 10248;

   begin tran
   delete from  [Order Details]
      where OrderID = 10248;

	  delete from  Orders
      where OrderID = 10248;

	  rollback
	  go


/* 8 pts
 8. (You had to know this was coming :-) )
		
		Turn your script in the previous question (#7) into a stored procedure that will take any order number as its parameters and then
		delete and remove any and all associated line items.

		Include a print message that indicates the sproc has completed successfully.

		Include error handling (try-catch blocks) within the procedure to catch the error if the deletes do not succeed. 
		As always include proper commenting.

		Include a call to your sproc that will also use Try-Catch to handle any errors thrown
*/
GO
CREATE PROC usp_deleteOrderAndDetails
        @orderid INT

		AS

		SET NOCOUNT ON
		BEGIN TRY
		IF NOT EXISTS(SELECT * from Orders WHERE OrderID = @orderId)
		THROW 50001, 'order does not exist', 1;

		IF NOT EXISTS(SELECT * FROM [Order details] WHERE OrderID = @orderId)			
		THROW 50002, 'order details do not exist', 1;

		BEGIN TRAN
		DELETE FROM [Order details]
		WHERE OrderID = @orderId;

		DELETE FROM Orders
		WHERE OrderID = @orderId

 COMMIT
 PRINT 'usp_deleteOrderAndDetails executed successfully'
 END TRY
 BEGIN CATCH
 IF @@TRANCOUNT > 0
   ROLLBACK
DECLARE @ERRMsg nvarchar(4000);
SELECT @ERRMsg = ERROR_MESSAGE();
THROW 50001, @ErrMsg, 1;
END CATCH
--END SPROC
BEGIN TRY
      EXEC usp_deleteOrderAndDetails 10249;
END TRY

BEGIN CATCH
  PRINT 'Execuation failed'
  PRINT ERROR_MESSAGE();
  END CATCH

DROP PROC usp_deleteOrderAndDetails;


/* 3 pts
9.  Create a query that lists customer names together with the first date
			  that they placed an order.  Note:  You only need to include customers who
			  have actually placed orders.   Include CustomerID, CustomerName and first
			  order date as columns in your view. 
*/

select c.CustomerID, c.CompanyName, CONVERT(date,MIN(OrderDate)) AS [FIRST ORDER DATE]
from [Order Details] od
join orders o
on o.OrderID = od.OrderID
join customers c
on c.CustomerID = o.CustomerID
group by c.CustomerID, c.CompanyName


/* 3 pts
10.  a) Create a view from the query in question 9.  
        b) Write a simple Select statement that uses this view to retrieve customers placing orders prior to 2-15-1999.
*/


go
create view vw_CustomersAndFirstOrder
as

select c.CustomerID, c.CompanyName, CONVERT(date,MIN(OrderDate)) AS [FIRST ORDER DATE]
from [Order Details] od
join orders o
on o.OrderID = od.OrderID
join customers c
on c.CustomerID = o.CustomerID
group by c.CustomerID, c.CompanyName

go
select *
from vw_CustomersAndFirstOrder
Where [FIRST ORDER DATE] < '2-15-1999';

drop view  vw_CustomersAndFirstOrder;


/* 2 pts
11. Write a single query that creates a phone list of all Suppliers, Customers, and Employees with
		only two columns:  Name and Phone.  
*/

go

select companyname AS name, phone
from suppliers
union select companyname, phone from Customers
union select FirstName + ' ' + LastName, HomePhone from Employees


/* 5 pts
 12.  Write a Select statement that displays all Northwind products.  Use a Case to add an extra column to the output 
        that indicates categories of pricing using the following categorization:

		when UnitPrice < 50.00 then 'small ticket'
		when UnitPrice < 150.00 then 'medium ticket'
		when UnitPrice < 250.00 then 'large ticket'
		else 'big ticket'
*/

SELECT ProductName,
       CASE WHEN UnitPrice < 50.00 THEN 'small ticket'
            WHEN UnitPrice < 150.00 THEN 'medium ticket'
            WHEN UnitPrice < 250.00 THEN 'large ticket'
            ELSE 'big ticket' END AS Category
  FROM Products


