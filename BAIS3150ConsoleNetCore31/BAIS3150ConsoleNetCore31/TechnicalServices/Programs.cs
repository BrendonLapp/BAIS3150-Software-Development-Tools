using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using BAIS3150ConsoleNetCore31.Domain;
using System.Data;

namespace BAIS3150ConsoleNetCore31.TechnicalServices
{
    public class Programs
    {
        public bool AddProgram(string ProgramCode, string Description)
        {
            bool Success;

            SqlConnection BAIS3150Connection = new SqlConnection
            {
                ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;"
            };
            BAIS3150Connection.Open();

            SqlCommand AddProgramCommand = new SqlCommand()
            {
                CommandText = "AddProgram",
                CommandType = CommandType.StoredProcedure,
                Connection = BAIS3150Connection
            };

            SqlParameter ProgramCodeParmeter = new SqlParameter
            {
                ParameterName = "ProgramCode",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = ProgramCode
            };
            AddProgramCommand.Parameters.Add(ProgramCodeParmeter);

            SqlParameter DescriptionParameter = new SqlParameter
            {
                ParameterName = "Description",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = Description
            };
            AddProgramCommand.Parameters.Add(DescriptionParameter);





            try
            {
                AddProgramCommand.ExecuteNonQuery();
                Success = true;
            }
            catch
            {
                Success = false;
            }

            return Success;
        }

        public ProgramDomain GetProgram(string ProgramCode)
        {
            ProgramDomain FoundProgram = new ProgramDomain();

            SqlConnection BAIS3150Connection = new SqlConnection();
            BAIS3150Connection.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            BAIS3150Connection.Open();

            SqlCommand GetProgramCommand = new SqlCommand
            {
                CommandText = "GetProgram",
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
            GetProgramCommand.Parameters.Add(ProgramCodeParameter);

            SqlDataReader DataReader;

            DataReader = GetProgramCommand.ExecuteReader();

            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    for (int index = 0; index < DataReader.FieldCount; index++)
                    {
                        FoundProgram.ProgramCode = DataReader["ProgramCode"].ToString();
                        FoundProgram.Description = DataReader["Description"].ToString();
                    }
                }
            }

            DataReader.Close();
            BAIS3150Connection.Close();

            return FoundProgram;
        }
    }
}
