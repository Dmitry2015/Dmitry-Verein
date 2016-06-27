using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260FibonacciRec
{
    /* Leonardo Bonacci (c. 1170 – c. 1250) known also as Leonardo of Pisa, was an Italian mathematician,
     * considered to be the most talented Western mathematician of the Middle Ages.
     * He posed, and solved, a problem involving the growth of a population of rabbits based on idealized 
     * assumptions. The solution, generation by generation, was a sequence of numbers later known as 
     * Fibonacci numbers. The number sequence was known to Indian mathematicians as early as the 6th 
     * century, but Fibonacci's Liber Abaci contains the earliest known description of the sequence 
     * outside of India. In the Fibonacci sequence of numbers, each number is the sum of the previous two 
     * numbers. He began the sequence with 1, 1, 2, but modern mathematicians start with 0, 1, 1, 2, etc. 
     * */



    class Program  
        // Fibinacci can be defined to start at 0, or at 1, we will use the start at 0 def.
        // impliment Fibonacci using recursion
        // Fibonacci is defined here as
        //======================================================
        // Fibonacci(0) = 0
        // Fibonacci(1) = 1
        // Fibonacci(N) = Fibonacci(N – 1) + Fibonacci(N – 2)
        //=======================================================

        // so if you ask for the x terms in the Fib series, given this input, the output should be
    /*
     * 0:  (no output, you said you want no terms
     * 1:  0  (you want the first term, which is 0, which is not calculated, this is defined as such)
     * 2:  0 1  (you want 2 terms, again the 2nd one is not calculated, this is defined as such)
     * 3:  0  1  1  (now that you are past the first and second term, the 3rd and the rest are calculated)
     * 4:  0, 1, 1, 2
     * 5:  0, 1, 1, 2, 3  (you are writing out 5 terms)
     * 6:  0, 1, 1, 2, 3, 5
     * 7:  0, 1, 1, 2, 3, 5, 8
     * */
    // 0    1    3    3    4    5    6    7    8  ...  25     ...  40            (don't try 50)
        // code should output, starting at 0, up to the last number corresponding values
        // 0    1    1    2    3    5    8    13   21 ...  75025  ...  102334155

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive interger for how many elements of the series: ");
            Console.WriteLine(" 0 is bad, says you want none.");
            Console.WriteLine(" 1 says you want to see only the first element in the series");
            Console.WriteLine(" 8 says you  want 8 terms, which would be 0  1  1  2  3  5  8  13");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Here are the terms in the series:");
            Fibonacci myFibonacci = new Fibonacci();
            myFibonacci.Calculate(userInput);

            Console.ReadLine();
        }
    }

    public class Fibonacci
    {
        public void Calculate(int input) //use a public wrapper for set up, dealing with the low number cases
        {
            int howManyInTheSequence = input;

            if (howManyInTheSequence <= 0)
            {
                Console.WriteLine("should enter an interger of 1 or greater");
                return;
            }
            Console.WriteLine("0");  // all valid sequences start with 0

            if (howManyInTheSequence == 1)
            {
                return; // they only wanted the first one
            }

            Console.WriteLine("1"); // all valid sequences beyond of 2 or more have a 2 as the 2nd number in series
            if (howManyInTheSequence == 2)
            {
                return;
            }

            // if they want more than 2, we will now calculate the 3rd and more terms
            // make the call to our recursive routine telling it:
            // how many terms to compute (but starting with two less, since we already did the first two if we got here
            // the recursive routine needs the prior two values, which since we are calling in for the first time, 
            // must be 0 and 1
            CalcWork(howManyInTheSequence-2, 0, 1); 
            //have already writting the 0 and 1 out
            return;
        }

        private void CalcWork(int recurseCount, int nMinus2, int nMinus1)  // use a private method for the iterative work
        {
            //write your code here (and no where else)
         
            int value = recurseCount;
            int nMin2 = nMinus2;
            int nMin1 = nMinus1;
            int sum = 1;

            if (value == 0)  // this is the exit for the recursion, as we will count this down
            {
                return;
            }

            else if (value >= 1)
            {
                sum = nMin2 + nMin1;
                Console.WriteLine("{0} ", sum);
                value = value - 1;
                nMin2 = nMin1;
                nMin1 = sum;
                CalcWork(value, nMin2, nMin1);
            }

            // test if you are done?  if yes, leave, 
            //if not, decrement 1 and call ourself with new values
                    return;
        }
    }
}
