/******************************************************************************
 * Bellevue Class: PROG 113
 *           Term: Spring 2014
 *     Instructor: Robert Main
 *
 * Solution/Project Name: PROG113_Project6
 *             File Name: StringReverser.cpp
 *
 * This file defines the entry point method, main(), for a C++ Console
 * application. When the executable file is selected for execution, the OS
 * will transfer execution to the first line of code in method main(). Other
 * methods called from main() may be defined here as well.
 *
 * Programmer: ** Your Name Here **
 * Assigned Project: 6
 *
 * Revision     Date                        Release Comment
 * --------  ----------  ------------------------------------------------------
 *   1.0     mm/dd/2014  Initial Release
 *
 * File Methods
 * ------------
 *     Name                             Description
 * ------------  --------------------------------------------------------------
 * main          Program entry point method
 * printReverse  Recursive method to display a C-Style string in reverse order
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
using namespace std; // Announces to the compiler that members of the namespace
                     // "std" are utilized in this program

// Method Prototype Declaration
void printReverse(char* s, int index);

/******************************************************************************
 * Method: main()
 * 
 * Method Description
 * ------------------
 * 
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
 * void
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
	// Constant "const" Value Declaration
	const int MAX_LENGTH = 80;

	// Uninitialized Array Declaration
	char str[MAX_LENGTH + 1];


	cout << "Enter a string: " ;
	cin.getline(str, MAX_LENGTH);

	cout << "The reversed string is :\n";
	// Start the recursion at the first character in the array
	printReverse(str, 0);


	// This prevents the Console Window from closing during debug mode
	// Note: Generally, you should not remove this code
	cin.ignore(cin.rdbuf()->in_avail());
	cout << "\nPress only the 'Enter' key to exit program: ";
	cin.get();

	return 0;

}	// End method: main()


/******************************************************************************
 * Method: printReverse(char*, int)
 * 
 * Method Description
 * ------------------
 * 
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
 * void
 *
 * Invoked Methods
 * ---------------
 *      Name                            Description
 * --------------  ------------------------------------------------------------
 *
 ******************************************************************************
 */
void printReverse(char* phrase, int index)
{

}	// End method: printReverse(char*, int)