using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            // make up 20 possible strings to store in hash table, using an empty [0] location for convenience, so array has 21 spots
            // will use loc's 1 thru 20 in our code below
            string[] dataArray = new string[] {"empty by design", "President", "Vice President", "Speaker of the House", "President pro tempore of the Senate", 
                "Secretary of State", "Secretary of the Treasury", "Secretary of Defense", "Attorney General", 
                "Secretary of the Interior", "Secretary of Agriculture", "Secretary of Commerce", "Secretary of Labor", "Secretary of Health and Human Services",
            "Secretary of Housing and Urban Development", "Secretary of Transportation", "Secretary of Energy", "Secretary of Education",
            "Secretary of Veterans Affairs", "Secretary of Homeland Security", "Prog 260 Teacher"};

            // instantiate our hash table instance
            OurHashTable theHashTable = new OurHashTable(15); // hash TABLE is size 15
            
           
            
            // allowed key range is 1 to 20, since that's how many unique items we might store from our string dataArray

            // hash algo takes specified number of entries (12)  with keys from 0 thru 19 and hashes into one of our slots, 0 thru 15

            int howMany = 12;  // we will try and fit 12 entries into this table of size 15
         
            string value;  // the string value corresponding to the human readable key (the defintion stored at the key)
            int numcollisions = 0;
           
            Random myRandom = new Random();

            bool success = false; // did the insert into hash table succeed?
           
            
            // this part is just to replace a human entering data, just a simulation to test our hash table
            // first create specified number of  unique random numbers bewteen 1 and 20 (to point to some of our strings)
            int[] ourKeys = UniqueRandomArray(howMany, 1, 20); // simulating entering 12 entries from a list of a possible 20 strings

            // contiune by putting these key: value pairs into our hash table
            for (int loopPointer = 0; loopPointer < howMany; loopPointer++)  // insert each of "howMany" (12) entries into the hash table
            // storing the value for a particular key into the hashtable at the location specified by doing the hash algo on that key
            {
                value = dataArray[ourKeys[loopPointer]];  // get our string from out dataArray
                success = theHashTable.AddItem(ourKeys[loopPointer], value);
                if (!success)
                {
                     numcollisions++;  // count the collision occurance
                }
                
            }

            // ok, done storing data into the hash table, write out its contents
    //        theHashTable.PrintState();

           
            Console.WriteLine();
            Console.WriteLine("We lost {0} pieces of data", numcollisions);
            Console.WriteLine();

            // ok, lets try and retrieve the data
            Console.WriteLine();
            Console.WriteLine("now we will see what our hashtable returns based on the keys we used to enter data");
            Console.WriteLine("for every collision we had storing the data, we get erroneous data returned");
            Console.WriteLine("find the duplicate values returned.");
            Console.WriteLine();
            for (int i = 0; i < howMany; i++)
            {
                Console.WriteLine("if enter key of {0} we get back: {1}", ourKeys[i],  theHashTable.GetItem(ourKeys[i]) );
            }

            Console.ReadLine();
        }

 
        // this method is just part of replacing a human entering data with simualtion code
        // this method will build an array of random numbers, making sure no two are the same
        // you set the range of the randmon numbers, lower and upper.
        public static int[] UniqueRandomArray(int arraySize, int Min, int Max)
        {
            int[] UniqueArray = new int[arraySize];
            Random rnd = new Random();
            int Random;
            for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++) // walk thru the array and do something for each element
            {
                Random = rnd.Next(Min, Max+1); // have to add 1 to max because of goofy .NET implimentation of Random
                for (int j = arrayIndex; j >= 0; j--)  // walk from the current arrayPointer backwards down to the 0 element 
                {
                    if (UniqueArray[j] == Random)  // check if we have already used this random number in any of the already assigned spots
                    { 
                        Random = rnd.Next(Min, Max+1);  // if we have used it already, pick a new number, and start back at the current arrayPointer again
                        j = arrayIndex;   // reset the inner loop to start all over again
                    }
                }
                UniqueArray[arrayIndex] = Random; // if none of the slots have used this number, we are free to use it here.
            }
            return UniqueArray;
        }


    }
}
