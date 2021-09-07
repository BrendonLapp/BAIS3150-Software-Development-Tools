using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using BAIS3150ConsoleNetCore31.TechnicalServices;
using BAIS3150ConsoleNetCore31.Domain;

namespace BAIS3150ConsoleNetCore31
{
    public class ADOPractice
    {
        public static void AddProgram()
        {
            ProgramParameters parameters = new ProgramParameters();
            Program.GetAGoodEntry(parameters);

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand addProgram = new SqlCommand();
            addProgram.Connection = sqlConnection;
            addProgram.CommandType = CommandType.StoredProcedure;
            addProgram.CommandText = "AddProgram";

            SqlParameter ProgramCode = new SqlParameter
            {
                ParameterName = "ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = parameters.ProgramCode
            };
            addProgram.Parameters.Add(ProgramCode);

            SqlParameter description = new SqlParameter
            {
                ParameterName = "Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = parameters.Description
            };
            addProgram.Parameters.Add(description);

            addProgram.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public static void GetProgram()
        {
            ProgramParameters parameters = new ProgramParameters();
            parameters.ProgramCode = Program.GetProgramCode();

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sql.Open();

            SqlCommand GetProgram = new SqlCommand();
            GetProgram.Connection = sql;
            GetProgram.CommandType = CommandType.StoredProcedure;
            GetProgram.CommandText = "GetProgram";

            SqlParameter ProgramCode = new SqlParameter
            {
                ParameterName = "ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = parameters.ProgramCode
            };
            GetProgram.Parameters.Add(ProgramCode);

            Console.WriteLine(GetProgram.ExecuteScalar().ToString());

            sql.Close();
        }

        public static void AddStudent()
        {
            Student student = new Student();
            //student.ProgramCode = Student.SetProgramCode();
            student.FirstName = Student.SetFirstName();
            student.LastName = Student.SetLastName();


            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand AddStudent = new SqlCommand();
            AddStudent.CommandType = CommandType.StoredProcedure;
            AddStudent.Connection = sqlConnection;
            AddStudent.CommandText = "AddStudent";

            //SqlParameter ProgramCode = new SqlParameter
            //{
            //    ParameterName = "ProgramCode",
            //    Direction = ParameterDirection.Input,
            //    SqlDbType = SqlDbType.VarChar,
            //    SqlValue = student.ProgramCode
            //};
            //AddStudent.Parameters.Add(ProgramCode);

            SqlParameter FirstName = new SqlParameter
            {
                ParameterName = "FirstName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = student.FirstName
            };
            AddStudent.Parameters.Add(FirstName);

            SqlParameter LastName = new SqlParameter
            {
                ParameterName = "LastName",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = student.LastName
            };
            AddStudent.Parameters.Add(LastName);

            AddStudent.ExecuteNonQuery();

            sqlConnection.Close();
        }

        //public static void UpdateStudent()
        //{
        //    Student student = new Student();
        //    student.StudentID = Student.SetStudentID();
        //    //student.ProgramCode = Student.SetProgramCode();
        //    student.FirstName = Student.SetFirstName();
        //    student.LastName = Student.SetLastName();

        //    SqlConnection sqlConnection = new SqlConnection();
        //    sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
        //    sqlConnection.Open();

        //    SqlCommand UpdateStudent = new SqlCommand();
        //    UpdateStudent.CommandText = "UpdateStudent";
        //    UpdateStudent.CommandType = CommandType.StoredProcedure;
        //    UpdateStudent.Connection = sqlConnection;

        //    SqlParameter StudentID = new SqlParameter
        //    {
        //        ParameterName = "StudentID",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.VarChar,
        //        SqlValue = student.StudentID
        //    };
        //    UpdateStudent.Parameters.Add(StudentID);

        //    //SqlParameter ProgramCode = new SqlParameter
        //    //{
        //    //    ParameterName = "ProgramCode",
        //    //    Direction = ParameterDirection.Input,
        //    //    SqlDbType = SqlDbType.VarChar,
        //    //    SqlValue = student.ProgramCode
        //    //};
        //    //UpdateStudent.Parameters.Add(ProgramCode);

        //    SqlParameter FirstName = new SqlParameter
        //    {
        //        ParameterName = "FirstName",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.VarChar,
        //        SqlValue = student.FirstName
        //    };
        //    UpdateStudent.Parameters.Add(FirstName);

        //    SqlParameter LastName = new SqlParameter
        //    {
        //        ParameterName = "LastName",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.VarChar,
        //        SqlValue = student.LastName
        //    };
        //    UpdateStudent.Parameters.Add(LastName);

        //    UpdateStudent.ExecuteNonQuery();

        //    sqlConnection.Close();
        //}

        public static void DeleteStudent()
        {
            int StudentID;
            Console.Write("Enter the student ID: ");
            StudentID = int.Parse(Console.ReadLine());

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sql.Open();

            SqlCommand DeleteStudent = new SqlCommand();
            DeleteStudent.CommandText = "DeleteStudent";
            DeleteStudent.CommandType = CommandType.StoredProcedure;
            DeleteStudent.Connection = sql;

            SqlParameter StudentId = new SqlParameter
            {
                ParameterName = "StudentID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                SqlValue = StudentID
            };
            DeleteStudent.Parameters.Add(StudentId);

            DeleteStudent.ExecuteNonQuery();

            sql.Close();
        }

        public static void GetStudent()
        {
            int studentID;
            Console.Write("StudentID: ");
            studentID = int.Parse(Console.ReadLine());

            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sql.Open();

            SqlCommand GetStudent = new SqlCommand();
            GetStudent.Connection = sql;
            GetStudent.CommandText = "GetStudent";
            GetStudent.CommandType = CommandType.StoredProcedure;

            SqlParameter studentIDParameter = new SqlParameter
            {
                ParameterName = "StudentID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                SqlValue = studentID
            };
            GetStudent.Parameters.Add(studentIDParameter);

            Console.WriteLine(GetStudent.ExecuteScalar().ToString());

            sql.Close();
        }

        public static void GetStudentsByProgram()
        {
            string ProgramCode;
            Console.WriteLine("Program Code: ");
            ProgramCode = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand GetStudentsByprogram = new SqlCommand
            {
                CommandText = "GetStudentsByProgram",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            SqlParameter programCodeParameter = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = ProgramCode
            };
            GetStudentsByprogram.Parameters.Add(programCodeParameter);

            SqlDataReader dataReader;

            dataReader = GetStudentsByprogram.ExecuteReader();

            if (dataReader.HasRows)
            {
                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    Console.WriteLine(dataReader.GetName(index));
                }
                while (dataReader.Read())
                {
                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                        Console.WriteLine(dataReader[index].ToString());
                    }
                }
            }

            dataReader.Close();
            sqlConnection.Close();
        }
    }
}
