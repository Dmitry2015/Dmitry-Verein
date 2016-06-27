using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class OurHashTable
    {
        // hash TABLE is size pSize, stores data in aarray that goes from 0 to pSize-1

         // this new array of linked lists is what you will use instead of the string[] above
        LinkedList<LLnode>[] betterHashTable; // new hash table storage is an array of Linked lists

        public static int _size { get; private set; }

        public OurHashTable(int pSize)
        {
            betterHashTable = new LinkedList<LLnode>[pSize]; // create an array of LLs
        }

        public bool AddItem(int key, string value)
        {
            int hashedKey;  // the "human readable" key gets hashed it into this value using the division method below
            hashedKey = HashDiv(key);

            LLnode newNode = new LLnode(key, value);
            Console.Write("next random key " + key + "  its hashedKey is " + hashedKey);  // as we walk thru our loop, show what we are doing
            if (betterHashTable[hashedKey] == null)  // null value means this slot is empty, so we can write our data (now a string) here.
            {
                betterHashTable[hashedKey] = new LinkedList<LLnode>();
            }
            betterHashTable[hashedKey].AddFirst(newNode);
            Console.WriteLine();
            return true;
        }

    public string GetItem(int key)  // notice has fast a look up is!
    {
        if (betterHashTable[HashDiv(key)] == null)
        {
            return "";
        }
        else
        {
                for (int i = 0; i < betterHashTable[HashDiv(key)].Count; i++)
                {
                    if (betterHashTable[HashDiv(key)].ElementAt(i).key == key)
                    {
                        return betterHashTable[HashDiv(key)].ElementAt(i).value;
                    }
                }
                return "";
            }
    }

    internal void PrintState()  // this is sort of a diagnostic aid, wouldn't normally have this
    {
        Console.WriteLine();
        Console.WriteLine("This is what is in the hash table.");
        Console.WriteLine();
        for (int j = 0; j < _size; j++)
        {
            Console.WriteLine("Hash Key {0, 2} = ", j);

            if (betterHashTable[j] == null)
            {
                Console.WriteLine("EMPTY");
            }
            else
            {

                for (int i = 0; i < betterHashTable[j].Count; j++)
                {
                Console.Write("{(0), (1)}", betterHashTable[j].ElementAt(j).key, betterHashTable[j].ElementAt(j).value);
                }
                Console.WriteLine("");
            }
        }
    }

    // this is our key hashing algorithm, (using multiply) we could repalce this with other ones to try them out
    static public int HashDiv(int key)
    {
        int tableSize = _size;
        double Multiplier = .6180339887;  // must be > 0 but less than 1
                                          // Knuth suggests .6180339887 Multiplier 
        double dblKey = key; // convert the int key into a double precision floating point
        double percent = Multiplier * dblKey;
        percent = percent - (int)percent; // get the fractional part
        return (int)(Math.Floor(percent * tableSize)); // round down to make sure you have a number that is within the table size
    }

    public class LLnode
    {

        public int key { get; set; }
        public string value { get; set; }

        public LLnode()
        {
        }

        public LLnode(int newKey, string newValue)
        {
            key = newKey;
            value = newValue;
        }
    }
}
}
