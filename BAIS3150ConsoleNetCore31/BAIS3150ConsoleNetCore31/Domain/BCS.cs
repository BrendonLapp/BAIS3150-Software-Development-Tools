using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using BAIS3150ConsoleNetCore31.TechnicalServices;

namespace BAIS3150ConsoleNetCore31.Domain
{
    class BCS
    {
        public bool EnrollStudent(Student AcceptedStudent, string ProgramCode)
        {
            bool Confirmastion;

            Students StudentManager = new Students();

            Confirmastion = StudentManager.AddStudent(AcceptedStudent, ProgramCode);

            return Confirmastion;
        }

        public bool CreateProgram(string ProgramCode, string Description)
        {
            bool Confirmation;

            Programs ProgramsManager = new Programs();

            Confirmation = ProgramsManager.AddProgram(ProgramCode, Description);

            return Confirmation;
        }

        public Student FindStudent (string StudentID)
        {
            Student EnrolledStudent = new Student();

            Students StudentManager = new Students();

            EnrolledStudent = StudentManager.GetStudent(StudentID);

            return EnrolledStudent;
        }

        public bool ModifyStudent(Student EnrolledStudent)
        {
            bool Confirmation;

            Students StudentManger = new Students();

            Confirmation = StudentManger.UpdateStudent(EnrolledStudent);

            return Confirmation;
        }

        public bool RemoveStudent(string StudentID)
        {
            bool Confirmation;

            Students StudentManager = new Students();

            Confirmation = StudentManager.DeleteStudent(StudentID);

            return Confirmation;
        }

        public ProgramDomain FindProgram(string ProgramCode)
        {
            ProgramDomain FoundProgram = new ProgramDomain();

            Programs ProgramManger = new Programs();

            FoundProgram = ProgramManger.GetProgram(ProgramCode);

            return FoundProgram;
        }
    }
}
