/******************************************************************************
* Bellevue Class: PROG 113
*           Term: Spring 2014
*     Instructor: Robert Main
*
* Solution/Project Name: VereinProject6
*             File Name: VereinProject6.cpp
*
* This file defines the entry point method, main(), for a C++ Console
* application. When the executable file is selected for execution, the OS
* will transfer execution to the first line of code in method main(). Other
* methods called from main() may be defined here as well.
*
* Programmer: Dmitry Verein
* Assigned Project: 6
*
* Revision     Date                        Release Comment
* --------  ----------  ------------------------------------------------------
*   1.0     05/16/2015  Initial Release
*
* File Methods
* ------------
*     Name                             Description
* ------------  --------------------------------------------------------------
* main					Program entry point method
* printReverse			Recursive method to display a C-Style string in reverse order
* printReversePointer	Recursive method to display a string in reverse order using
*						pointer arithmetics
*
* Classes Utilized
* ----------------
* None
*
* Program Inputs
* --------------
*     Data Type                             Description
* ----------------  ----------------------------------------------------------
* Console Keyboard  User's phrase to display in reverse
*
* Program Outputs
* ---------------
*    Data Type                             Description
* ---------------  -----------------------------------------------------------
* Console Monitor  User's phrase displayed in reverse order
*
******************************************************************************
*/
// External Definition files
// The first inclusion file MUST always be declared and MUST be first in the list
#include "stdafx.h"  // Defines IDE required external definition files
#include <iostream>  // Defines objects and classes used for stream I/O

// Namespaces utilized in this program
using namespace std;	// Announces to the compiler that members of the namespace
// "std" are utilized in this program

// Method Prototype Declaration
void printReverse(char * str, char * reverstring);
void printReversePointer(char* s);

/******************************************************************************
* Method: main()
*
* Method Description
* ------------------
* The program asks the user to enter a string (the maximum length of this string is 80).
* Then the programm call a recursive function printReverse that accepts the string as
* its argument and prints the string in reverse order. Then the programm call a
* recursive function printReversePointer, using pointer arithmetics that accepts the
* string as its argument and prints the string in reverse order.
* This project based on a driver program StringReverser.cpp.
*
*
* Method Arguments
* ----------------
*   Type        Name                        Description
* --------  -------------  ---------------------------------------------------
* None
*
* Return Value
* ------------
*   Type                              Description
* --------  ------------------------------------------------------------------
* int       Program execution status: 0 - No errors
*
* Invoked Methods
* ---------------
*      Name                            Description
* --------------  ------------------------------------------------------------
*
******************************************************************************
*/
int main()
{
	// Constant "const" Vlaue Declarations
	const int NO_ERRORS = 0;

	// Constant "const" Value Declaration
	const int MAX_LENGTH = 80;

	// Uninitialized Array Declaration
	char str[MAX_LENGTH + 1];
	char reverstring[MAX_LENGTH];

	cout << "Enter a string (the maximum length of string is 80): ";
	cin.getline(str, MAX_LENGTH);

	// Print the head of the result
	cout << "The reversed string is :\n";
	// Start the recursion at the first character in the array
	printReverse(str, reverstring);
	cout << "\nThe reversed string (using pointer arithmetics) is :\n";
	// Start the recursion (using pointer arithmetics) at the first character in the array
	printReversePointer(str);

	// This prevents the Console Window from closing during debug mode using
	// the Visual Studio IDE.
	// Note: Generally, you should not remove this code
	cin.ignore(cin.rdbuf()->in_avail());
	cout << "\nPress only the 'Enter' key to exit program: ";
	cin.get();

	return NO_ERRORS;

}	// End method: main()

/******************************************************************************
* Method: printReverse(char * str, char * reverstring)
*
* Method Description
* ------------------
* This method prints the accepted string in reverse order.
* The maximum length of string is 80.
*
*
* Method Arguments
* ----------------
*   Type        Name                        Description
* --------  -------------  ---------------------------------------------------
* char *	str				Initial string
* char *	reverstring		Reverse string
*
* Return Value
* ------------
*   Type                              Description
* --------  ------------------------------------------------------------------
* void
*
* Invoked Methods
* ---------------
*      Name                            Description
* --------------  ------------------------------------------------------------
*
******************************************************************************
*/
void printReverse(char * str, char * reverstring) {
	int n = strlen(str);
	for (int i = 0; i < n; i++) {
		reverstring[i] = str[n - i - 1];
		cout << reverstring[i];
	}
	reverstring[n] = str[n];
}


/******************************************************************************
* Method: printReversePointer(char* s)
*
* Method Description
* ------------------
* This method prints the accepted string in reverse order (using pointer arithmetics).
* The maximum length of string is 80.
*
*
* Method Arguments
* ----------------
*   Type        Name                        Description
* --------  -------------  ---------------------------------------------------
* char *	s				string
*
* Return Value
* ------------
*   Type                              Description
* --------  ------------------------------------------------------------------
* void
*
* Invoked Methods
* ---------------
*      Name                            Description
* --------------  ------------------------------------------------------------
*
******************************************************************************
*/
void printReversePointer(char* s)
{
	if (*s)
		printReversePointer(s + 1);
	else
		return;
	cout << *s;
}	// End method: printReversePointer(char* s)
