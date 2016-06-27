/******************************************************************************
 * Bellevue Class: PROG 113
 *           Term: Speing 2015
 *     Instructor: Robert Main
 *
 * Solution/Project Name: VereinProject7
 *             File Name: VereinProject7.cpp    
 *
 * This file defines the entry point method, main(), for a C++ Console
 * application. When the executable file is selected for execution, the OS
 * will transfer execution to the first line of code in method main(). Other
 * methods called from main() may be defined here as well.
 *
 * Programmer: Dmitry Verein
 *
 * Assigned Project Number: 7
 *
 *
 * Revision     Date                        Release Comment
 * --------  ----------  ------------------------------------------------------
 *   1.0     05/24/2015  Initial Release
 *
 *
 * Program Inputs
 * --------------
 *  Device                              Description
 * --------  ------------------------------------------------------------------
 * Keyboard  User's number
 *
 *
 * Program Outputs
 * ---------------
 *  Device                            Description
 * --------  ------------------------------------------------------------------
 * Monitor		The  sequence  of  odd  numbers  squared,  starting  from  the  
 *				largest	odd number (<= n)  to the smallest odd number (1), then 
 *				displaying  the even numbers squared, starting with the smallest 
 *				even number (2)  to  the largest even number (<= n).
 *
 *
 * File Methods
 * ------------
 *     Name                             Description
 * ------------  --------------------------------------------------------------
 * main          Program entry point method
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

/******************************************************************************
* Method: main()
* 
* Method Description
* ------------------
*
*
* Specific Instructions:
* The method main() that displays a sequence of squared
* numbers from one to a specified maximum number, n. The program asks the user to enter the number, n.
* The format of the presentation will be to display first, the sequence of odd numbers  
* squared, starting  from  the  largest  odd number (<= n)  to the smallest odd number (1), 
* then displaying the even numbers squared, starting with the smallest even number (2)  
* to  the largest even number (<= n). The squared values displayed will have as separators, 
* the 2-characters ", ".
* For example, for n = 8, the displayed sequence will be:
* 49, 25, 9, 1, 4, 16, 36, 64
* For n = 9, the displayed sequence will be:
* 81, 49, 25, 9, 1, 4, 16, 36, 64
* This implementation does not use a loop construct, arrays, or any other STL Container
* object. It consist of only recursive calls to itself and display statement(s). In addition,
* this presentation does not have the ending separator characters: ", ".
*
* Pre-Conditions
* --------------
* ** None **
*
* Method Arguments
* ----------------
* ** None **
*
* Return Value
* ------------
*   Type                              Description
* --------  -------------------------------------------------------------------
* int       Program execution status: 0 - No errors
*
*
* Invoked Methods
* ---------------
*     Name                             Description
* ------------  --------------------------------------------------------------
*
*******************************************************************************
*/

// Function prototypes
void odd(int);			// Function prototype
void even(int, int);	// Function prototype

 int main()          
{
	 // Constant "const" Vlaue Declarations
	 const int NO_ERRORS = 0;

	 // Define variable
	 int x;
	 // The program asks a user to enter a number
	 cout << "Input the int number n:\n";
	 // Reading the user number
	 cin >> x;
	 // Call odd function to display odd numbers 
	 odd(x);
	 // Call even function to display even numbers 	 
	 even(1, x);

	// This prevents the Console Window from closing during debug mode using
	// the Visual Studio IDE.
	// Note: Generally, you should not remove this code
	cin.ignore(cin.rdbuf()->in_avail());
	cout << "\nPress only the 'Enter' key to exit program: ";
	cin.get();

	return NO_ERRORS;
}

 //******************************************************
 // Function odd. Accepts an int argument in n.		    *
 // This function displays the sequence of odd numbers  *
 // squared, starting  from  the  largest  odd number   *
 // (<= n)  to the smallest odd number(1)               *    
 //														*
 //******************************************************
 
 void odd(int n)
 {
	 if (n > 1 && n % 2 == 0)				//check condition
	 {
		 cout << (n - 1)*(n - 1) << ", ";	//print the odd number
		 odd(n - 2);						//decrease value
	 }
	 else if (n >= 1 && n % 2 != 0)			//check condition
	 {
		 cout << n*n << ", ";				//print the odd number
		 odd(n - 2);
	 }
 }


 //******************************************************
 // Function even. Accepts an int arguments in start	* 
 // and end. This function displays the				    *
 // sequence of even numbers squared, starting from		*
 // the  smallest  even number(2) to  the largest		*
 // even number(<= n).									*    
 //														*
 //******************************************************
 
 void even(int start, int end) {
	 if (start % 2 != 0) {					//check condition
		 even((start + 1), end);			//increase value
	 }
	 else if (start < end-1) {				//check condition
		 cout << start*start << ", ";		//print the even number
		 even((start + 2), end);			//increase value
	 }
	 else if (start == end || start == end-1) {	//check condition
		 cout << start*start << "\n ";			//print the even number without ", " at the end
	 }
 }
