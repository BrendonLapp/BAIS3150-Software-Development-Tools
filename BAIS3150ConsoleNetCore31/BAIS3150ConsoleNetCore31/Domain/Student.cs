using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150ConsoleNetCore31.Domain
{
    public class Student
    {
        public string StudentID { get; set; }
        public string ProgramCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static int SetStudentID()
        {
            int studentID;
            Console.Write("StudentID: ");
            studentID = int.Parse(Console.ReadLine());

            return studentID;
        }

        public static string SetProgramCode()
        {
            string programCode = "";
            Console.Write("Program Code: ");
            programCode = Console.ReadLine();

            return programCode;
        }

        public static string SetFirstName()
        {
            string firstName = "";
            Console.Write("First Name: ");
            firstName = Console.ReadLine();

            return firstName;
        }

        public static string SetLastName()
        {
            string lastName = "";
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();

            return lastName;
        }
    }
}
