using BAIS3150ConsoleNetCore31.Domain;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using BAIS3150ConsoleNetCore31.TechnicalServices;

namespace BAIS3150ConsoleNetCore31
{
    class Menu
    {
        public static void MainMenu(int option)
        {

        }
    }

    class ProgramParameters
    {
        public string ProgramCode { get; set; }
        public string Description { get; set; }
    }

    class Program
    {
        public static ProgramParameters GetAGoodEntry(ProgramParameters newParameters)
        {
            //ProgramParameters newParameters = new ProgramParameters();
            string ProgramCode = "";
            string Description = "";
            bool GoodEntry = false;

            while (GoodEntry != true)
            {
                Console.Write("Enter the Program code: ");
                ProgramCode = Console.ReadLine();

                Console.Write("Enter the description: ");
                Description = Console.ReadLine();

                GoodEntry = CheckForValues(ProgramCode, Description);
            }

            newParameters.ProgramCode = ProgramCode;
            newParameters.Description = Description;

            return newParameters;
        }

        public static string GetProgramCode()
        {
            string ProgramCode = "";
            Console.Write("Enter the program code: ");
            ProgramCode = Console.ReadLine();

            return ProgramCode;
        }

        public static void Main(string[] args)
        {
            //string userInput;
            //int optionChoice;

            //Console.WriteLine("1. Add Program");
            //Console.WriteLine("2. Get Program");
            //Console.WriteLine("3. Add Student");
            //Console.WriteLine("4. Update Student");
            //Console.WriteLine("5. Delete Student");
            //Console.WriteLine("6. Get Student");
            //Console.WriteLine("7. Get Student by program");
            //Console.Write("Pick an option: ");
            //userInput = Console.ReadLine();
            //optionChoice = int.Parse(userInput);

            //Menu.MainMenu(optionChoice);
            bool success;
            BCS BCSManager = new BCS();
            success = BCSManager.CreateProgram("REW", "Architecture");
            if (success == true)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public static void ExecuteNonQueryExample()
        {
            Console.WriteLine("ExecuteNonQueryExample");

            ProgramParameters newParameters = new ProgramParameters();
            GetAGoodEntry(newParameters);

            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand addProgram = new SqlCommand();
            addProgram.Connection = sqlConnection;
            addProgram.CommandType = CommandType.StoredProcedure;
            addProgram.CommandText = "AddProgram";

            SqlParameter programCodeParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newParameters.ProgramCode,
            };

            addProgram.Parameters.Add(programCodeParameter);

            SqlParameter descriptionParameter = new SqlParameter
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newParameters.Description,
            };

            addProgram.Parameters.Add(descriptionParameter);

            addProgram.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public static void GetProgramsDataReaderExample()
        {
            Console.WriteLine("Get Programs data reader exmaple");

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetPrograms"
            };

            SqlDataReader dataReader;

            dataReader = sqlCommand.ExecuteReader();

            if (dataReader.HasRows)
            {
                Console.WriteLine("Columns:");
                Console.WriteLine("----");

                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    Console.WriteLine(dataReader.GetName(index));
                }
                Console.WriteLine("Values:");
                Console.WriteLine("----");

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

        public static bool CheckForValues(string ProgramCode, string Description)
        {
            if (ProgramCode == "" || ProgramCode == null)
            {
                Console.WriteLine("You need to enter a program code.");
                return false;
            }
            else if (Description == "" || Description == null)
            {
                Console.WriteLine("You need to enter a description.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void ExecuteScalarExample()
        {
            Console.WriteLine("Execute Scalar Example");

            ProgramParameters newParameters = new ProgramParameters();
            GetAGoodEntry(newParameters);

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            sqlConnection.Open();

            SqlCommand sql = new SqlCommand
            {
                Connection = sqlConnection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };

            SqlParameter programCodeParameter = new SqlParameter
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = newParameters.ProgramCode
            };

            sql.Parameters.Add(programCodeParameter);

            Console.WriteLine(sql.ExecuteScalar().ToString());

            sqlConnection.Close();
        }
    }
}
