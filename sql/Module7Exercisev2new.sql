/*
PROG 140          Module 7 Assignment   #8
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

-- Tasks:  

/*
1.  
10 pts 
Write a simple trigger that only prints a message stating that a row in the customers table has been updated and that fires only 
upon the execution of an update statement on the customers table.

Include a statement that will fire your trigger and also a statement to drop your trigger. 

*/
-- write your SQL statements here: 

USE Northwind
GO
CREATE TRIGGER [trgCustomerUpdated]
ON [dbo].[Customers]
FOR UPDATE 
AS 
/* Comments */
PRINT 'A row in the Customers table has been updated'

Begin Tran
Update [dbo].[Customers]
Set ContactTitle = 'Fred'
Where CustomerID = 'DUMON';
Commit tran

Select * from [dbo].[Customers]
Where CustomerID = 'DUMON';
GO
drop trigger [trgCustomerUpdated]

/*
2. 
10 pts
Create a trigger that will run instead of the Update statement on the Suppliers table.  It will 
fire when an Update statement is executed against the Suppliers table and will an error message saying:   
"Updating information in this table is not allowed"

Include a statement that will fire your trigger and also a statement to drop your trigger. 
(Hints:  There is such a thing as an "instead of trigger". See the demo file for an example! You can use RaisError for the error message.)

*/
-- write your SQL statements here: 

USE Northwind
GO
CREATE TRIGGER [trgSupplierUpdate]
on [dbo].[Suppliers]
Instead of UPDATE 
AS 
/* Comments */
SET NOCOUNT ON
RAISERROR ('Updating information in this table is no allowed',1,1)
SET NOCOUNT OFF

GO
Begin Tran
SET NOCOUNT ON
update [dbo].[Suppliers]
Set City = 'Detroit'
Where SupplierID = '8'
Commit tran

Select * from [dbo].[Suppliers]
Where SupplierID = '8'
GO
drop trigger [trgSupplierUpdate]


/*
3.  
15 pts
Northwind management is concerned that someone is updating and deleting products without following proper 
procedures. You are asked to provide a log of all future UPDATES and DELETES performed on the products table. Unfortunately
the products table does not store this information. You decide to create a log table and a trigger that will load this log table with the productid,
the date and the user of the deleted or updated product.

********************************************
Note: Here's how to find the user!!  There is an example in the demo file in the TRIGGER trgCheckSalaryCap however it is in the part I did not present on the video since 
I had to end the video and thought that 4 videos would be too much for everyone.  Its actually pretty easy.  There is a user function that retrieves the current user. 
It's called "user". The user can be obtained like this:

Declare @User varchar(20)
Select @User = System_User

********************************************

Include a statement that will fire your trigger and also a statement to drop your trigger. 

*/
-- write your SQL statements here: 

Declare @User varchar(20)
Select @User = System_User
print @User

Create Table ProdLog
(Time Datetime not null,
EventType NVARCHAR(20) not null,
ProductID int,
CurrentUser NVARCHAR(30))

go
CREATE TRIGGER trgLogUpdate
on Products
After Update, Delete
AS

Begin
declare @EventType NVARCHAR(20)
IF EXISTS(Select * From inserted)
Set @EventType = 'Update'
else
Set @EventType = 'Delete'
insert INTO ProdLog
Select GETDATE(), @EventType, ProductID, SYSTEM_USER
From deleted
End

Begin Tran
Update Products
Set ProductName = 'Chai Tea'
Where ProductID = 1
 
--select * from ProdLog
select * from Products
Where ProductID = 1

commit Tran
rollback Tran

Insert into Products (ProductName, Discontinued)
Values ('Test Product', 0)

Delete from Products where ProductName = 'Test Product'

GO
drop trigger trgLogUpdate


/*
4. 
15 pts
In our demo file Cursors.sql there is a stored procedure called "Rebuild_All_Indexes" near the end of that file. Use
this stored procedure as a model to create a stored procedure called "uspListAllUserTables" that will print
the names of all tables in the sys.Objects table that are user tables (ie., type = 'U').  (Hint: you will not need to 
return a table object - just using the print statement within the sproc will print out the tables)

Include a statement to execute your stored procedure and be sure to test it to ensure it works.
*/
-- write your SQL statements here: 


go
Create PROCEDURE uspListAllUserTables
AS
  DECLARE csrTableNames cursor
  FOR
    SELECT name FROM sys.Objects WHERE type = 'U'
    OPEN csrTableNames
    -- Create a variable to capture the table names
    DECLARE @name SYSNAME
    -- Load a name into the variable
    FETCH next FROM csrTableNames INTO @name
    WHILE @@fetch_status = 0
      BEGIN
			Begin
			print @name
			End
      FETCH next FROM csrTableNames INTO @name
      END
  CLOSE csrTableNames
  DEALLOCATE csrTableNames
  GO

-- call uspListAllUserTables to print the names of all user tables
Exec uspListAllUserTables 


