using BAIS3150ConsoleNetCore31.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BAIS3150ConsoleNetCore31.TechnicalServices
{
    public class Students
    {
        public bool AddStudent(Student acceptedStudent, string programCode)
        {
            bool success = false;

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand AddStudent = new SqlCommand();
            AddStudent.CommandType = CommandType.StoredProcedure;
            AddStudent.Connection = sqlConnection;
            AddStudent.CommandText = "AddStudent";

            SqlParameter ProgramCode = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = programCode
            };
            AddStudent.Parameters.Add(ProgramCode);

            SqlParameter FirstName = new SqlParameter
            {
                ParameterName = "FirstName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = acceptedStudent.FirstName
            };
            AddStudent.Parameters.Add(FirstName);

            SqlParameter LastName = new SqlParameter
            {
                ParameterName = "LastName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = acceptedStudent.LastName
            };
            AddStudent.Parameters.Add(LastName);

            SqlParameter Email = new SqlParameter
            {
                ParameterName = "Email",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = acceptedStudent.Email
            };
            AddStudent.Parameters.Add(Email);

            SqlParameter programCodeParameter = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = programCode
            };
            AddStudent.Parameters.Add(programCodeParameter);

            AddStudent.ExecuteNonQuery();

            sqlConnection.Close();

            success = true;

            return success;
        }

        public Student GetStudent(string StudentID)
        {
            Student EnrolledStudent = new Student();

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            BAIS3150Connection.Open();

            SqlCommand GetStudentCommand = new SqlCommand
            {
                CommandText = "GetStudent",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150Connection
            };

            SqlParameter StudentIDParameter = new SqlParameter
            {
                ParameterName = "StudentID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = StudentID
            };
            GetStudentCommand.Parameters.Add(StudentIDParameter);

            SqlDataReader DataReader;

            DataReader = GetStudentCommand.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    for (int index = 0; index < DataReader.FieldCount; index++)
                    {
                        EnrolledStudent.StudentID = DataReader["StudentID"].ToString();
                        EnrolledStudent.ProgramCode = DataReader["ProgramCode"].ToString();
                        EnrolledStudent.FirstName = DataReader["FirstName"].ToString();
                        EnrolledStudent.LastName = DataReader["LastName"].ToString();
                        EnrolledStudent.Email = DataReader["Email"].ToString();
                    }
                }
            }

            DataReader.Close();
            BAIS3150Connection.Close();

            return EnrolledStudent;
        }

        public bool UpdateStudent(Student EnrolledStudent)
        {
            bool Success;

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            BAIS3150Connection.Open();

            SqlCommand UpdateStudentCommand = new SqlCommand
            {
                CommandText = "UpdateStudent",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150Connection
            };

            SqlParameter StudentIDParameter = new SqlParameter
            {
                ParameterName = "StudentID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = EnrolledStudent.StudentID
            };
            UpdateStudentCommand.Parameters.Add(StudentIDParameter);

            SqlParameter ProgramCodeParameter = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = EnrolledStudent.ProgramCode
            };
            UpdateStudentCommand.Parameters.Add(ProgramCodeParameter);

            SqlParameter FirstNameParameter = new SqlParameter
            {
                ParameterName = "FirstName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = EnrolledStudent.FirstName
            };
            UpdateStudentCommand.Parameters.Add(FirstNameParameter);

            SqlParameter LastNameParameter = new SqlParameter
            {
                ParameterName = "LastName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = EnrolledStudent.LastName
            };
            UpdateStudentCommand.Parameters.Add(LastNameParameter);

            SqlParameter EmailParameter = new SqlParameter
            {
                ParameterName = "Email",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = EnrolledStudent.Email
            };
            UpdateStudentCommand.Parameters.Add(EmailParameter);

            UpdateStudentCommand.ExecuteNonQuery();

            Success = true;

            return Success;
        }

        public bool DeleteStudent(string StudentID)
        {
            bool Success;

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            BAIS3150Connection.Open();

            SqlCommand DeleteStudentCommand = new SqlCommand
            {
                CommandText = "DeleteStudent",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150Connection
            };

            SqlParameter StudentIDParameter = new SqlParameter
            {
                ParameterName = "StudentID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = StudentID
            };
            DeleteStudentCommand.Parameters.Add(StudentIDParameter);

            DeleteStudentCommand.ExecuteNonQuery();

            Success = true;

            return Success;
        }

        public List<Student> GetStudents(string ProgramCode)
        {
            List<Student> StudentsInProgram = new List<Student>();

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            BAIS3150Connection.Open();

            SqlCommand GetStudentsCommand = new SqlCommand
            {
                CommandText = "GetStudentsByProgram",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150Connection
            };

            SqlParameter ProgramCodeParameter = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = ProgramCode
            };
            GetStudentsCommand.Parameters.Add(ProgramCodeParameter);

            SqlDataReader DataReader;

            DataReader = GetStudentsCommand.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Student FoundStudent = new Student();
                    for (int index = 0; index < DataReader.FieldCount; index++)
                    {
                        FoundStudent.StudentID = DataReader["StudentID"].ToString();
                        FoundStudent.ProgramCode = DataReader["ProgramCode"].ToString();
                        FoundStudent.FirstName = DataReader["FirstName"].ToString();
                        FoundStudent.LastName = DataReader["LastName"].ToString();
                        FoundStudent.Email = DataReader["Email"].ToString();
                    }
                    StudentsInProgram.Add(FoundStudent);
                }
            }

            DataReader.Close();
            BAIS3150Connection.Close();

            return StudentsInProgram;
        }
    }
}
