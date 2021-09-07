using System;
using System.Collections.Generic;
using System.Text;

namespace BAIS3150ConsoleNetCore31.Domain
{
    public class ProgramDomain
    {
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public List<Student> EnrolledStudents { get; set; }
    }
}
