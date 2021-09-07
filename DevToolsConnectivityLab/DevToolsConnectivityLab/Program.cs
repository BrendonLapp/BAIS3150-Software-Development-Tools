using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace DevToolsConnectivityLab
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCustomersByCountry();
            Console.WriteLine();
            GetCategory();
            Console.WriteLine();
            GetProductsByCategory();
            Console.WriteLine();
        }

        static void GetCustomersByCountry()
        {
            string country = "Canada";

            SqlConnection northwind = new SqlConnection();
            northwind.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            northwind.Open();

            SqlCommand GetCustomersByCountry = new SqlCommand
            {
                CommandText = "BLapp1.GetCustomersByCountry",
                CommandType = CommandType.StoredProcedure,
                Connection = northwind
            };

            SqlParameter countryParameter = new SqlParameter
            {
                ParameterName = "Country",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
                SqlValue = country
            };

            GetCustomersByCountry.Parameters.Add(countryParameter);

            SqlDataReader dataReader;

            dataReader = GetCustomersByCountry.ExecuteReader();

            if (dataReader.HasRows)
            {
                Console.WriteLine("Customer Columns");
                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    Console.Write(dataReader.GetName(index) + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("----");
                Console.WriteLine("Customer Values");
                while (dataReader.Read())
                {
                    Console.WriteLine();
                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                        Console.Write(dataReader[index].ToString() + "; ");
                    }
                }
            }

            dataReader.Close();
            northwind.Close();
        }

        static void GetCategory()
        {
            Console.WriteLine();
            int categoryID = 2;

            SqlConnection northwind = new SqlConnection();
            northwind.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            northwind.Open();

            SqlCommand GetCategory = new SqlCommand
            {
                CommandText = "BLapp1.GetCategory",
                CommandType = CommandType.StoredProcedure,
                Connection = northwind
            };

            SqlParameter categoryIDParameter = new SqlParameter
            {
                ParameterName = "CategoryID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                SqlValue = categoryID
            };
            GetCategory.Parameters.Add(categoryIDParameter);

            SqlDataReader dataReader;

            dataReader = GetCategory.ExecuteReader();

            if (dataReader.HasRows)
            {
                Console.WriteLine("Category Columns");
                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    Console.Write(dataReader.GetName(index) + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("----");
                Console.WriteLine("Category Values");
                while (dataReader.Read())
                {
                    Console.WriteLine();
                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                        Console.Write(dataReader[index].ToString() + "; ");
                    }
                }
            }

            dataReader.Close();
            northwind.Close();
        }

        static void GetProductsByCategory()
        {
            Console.WriteLine();
            int categoryID = 2;

            SqlConnection northwind = new SqlConnection();
            northwind.ConnectionString = @"Persist Security Info=False;Database=Northwind;User ID=blapp1;Password=Password;server=dev1.baist.ca;";
            northwind.Open();

            SqlCommand GetProductsByCategory = new SqlCommand()
            {
                CommandText = "BLapp1.GetProductsByCategory",
                CommandType = CommandType.StoredProcedure,
                Connection = northwind
            };

            SqlParameter categoryIDParameter = new SqlParameter
            {
                ParameterName = "CategoryID",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
                SqlValue = categoryID
            };

            GetProductsByCategory.Parameters.Add(categoryIDParameter);

            SqlDataReader dataReader;

            dataReader = GetProductsByCategory.ExecuteReader();

            if (dataReader.HasRows)
            {
                Console.WriteLine("Product Columns");
                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    Console.Write(dataReader.GetName(index) + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("----");
                Console.WriteLine("Product Values");
                while (dataReader.Read())
                {
                    Console.WriteLine();
                    for (int index = 0; index < dataReader.FieldCount; index++)
                    {
                        Console.Write(dataReader[index].ToString() + "; ");
                    }
                }
            }

            dataReader.Close();
            northwind.Close();
        }
    }
}
