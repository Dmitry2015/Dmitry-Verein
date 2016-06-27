using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Student  // the other version of this program has Address as a struct
{
    // fields
    string _FirstName;
    string _LastName;
    Int64 _SID;
    int _Age;

    // properties
    public string FirstName
    {
        get { return _FirstName; }  // Getter
        set { _FirstName = value; } // Setter
    }
    public string LastName
    {
        get { return _LastName; }  // Getter
        set { _LastName = value; } // Setter
    }
    public Int64 SID
    {
        get { return _SID; }  // Getter
        set { _SID = value; } // Setter
    }
    public int Age
    {
        get { return _Age; }  // Getter
        set { _Age = value; } // Setter
    }

    //     constuctor WITH params
    public Student(string pfirstName, string plastName, Int64 pSID, int pAge)
    {
        _FirstName = pfirstName;
        _LastName = plastName;
        _SID = pSID;
        _Age = pAge;
    }

    public static bool ValidateSID(Int64 SID)
    {
        if ((SID > 950999999 || SID < 950000000))
        {
            Console.WriteLine("SID should be a 9 digit number that starts with 950");
            return false;
        }
        else
            return true;
    }

    public static bool ValidateAge(int Age)
    {
        if ((Age < 10 || Age > 150))
        {
            Console.WriteLine("Age should be between 10 and 150 ");
            return false;
        }
        else
            return true;
    }
}

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> StudentList = new List<Student>();  // we will see problems using a List< of structs>
            bool validSID;
            bool validAge;
            int howManyStudents = 3;
            Int64 SID;
            int Age;

            for (int k = 0; k < howManyStudents; k++)
            {
                Console.WriteLine("Next Student:");
                Console.WriteLine();
                Console.Write("Enter student First Name: ");
                string FirstName = Console.ReadLine();

                Console.WriteLine();
                Console.Write("Enter student Last Name: ");
                string LastName = Console.ReadLine();

                Console.WriteLine();

                SID = 0;
                validSID = false;
                while (validSID == false)
                {
                Console.Write("Enter student 9 digit SID: ");
                string tempSID = Console.ReadLine();

                try
                    {
                    SID = Convert.ToInt64(tempSID);
                    }
                    catch (Exception fe)
                    {
                     Console.WriteLine(fe.Message);
                    }
                    validSID = Student.ValidateSID(SID);
                    Console.WriteLine();
                }

                Age = 0;
                validAge = false;
                while (validAge == false)
                {
                    Console.Write("Enter student Age: ");
                    string tempAge = Console.ReadLine();
                    try
                    {
                        Age = Convert.ToInt16(tempAge);
                    }
                    catch (Exception fe)
                    {
                    Console.WriteLine(fe.Message);
                    }
                    validAge = Student.ValidateAge(Age);
                    Console.Write("");
                }
 
                Console.WriteLine();
                Student tempStudent = new Student(FirstName, LastName, SID, Age);
                StudentList.Add(tempStudent);  // add first to List
            }

            foreach (Student item in StudentList)
            {
                Console.Write(item.FirstName + " " + item.LastName + "'s SID is: " + item.SID + " and they are " + item.Age + " years old" + System.Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}


