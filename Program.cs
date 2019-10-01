using System;
using System.Data;
using System.Data.SqlClient;

namespace BAIS3150_CodeSampleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string connectionString = @"server=(LocalDB)\MSSQLLocalDB;" + "Initial Catalog=BAIS3150_CodeSampleSystem";

            FindStudentById(connectionString, "2");

            FindCourseByProgramCode(connectionString, "CNT");

/*            EnrollStudent(connectionString, "Taha", "Sheikh", "mtsheikh@gmail.com", "BAIST");
*//*
            CreateProgram(connectionString, "TIFF", "this is fun fun")*/;
        }

        

        public static void FindCourseByProgramCode(string connectionString, string programCode)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the command and set it's properties
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "FindProgram";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@ProgramCode";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = programCode;

                // Add the parameter to the Parameters Collection
                command.Parameters.Add(parameter);

                //Open the connection and execute the reader 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }

                reader.Close();
            }

        }

        // Todo Implement a way to restrict empty, null, or too long values
        public static void CreateProgram(string connectionString, string programCode, string description)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the command and set it's properties
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "CreateProgram";
                command.CommandType = CommandType.StoredProcedure;


                // Add the input parameters and set its properties
                SqlParameter parameter = new SqlParameter();

                // FirstName
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                // Add the parameter to the Parameters Collection
                command.Parameters.AddWithValue("@programCode", programCode);

                // LastName
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                // Add the parameter to the Parameters Collection
                command.Parameters.AddWithValue("@Description", description);

                // Open the conenction and Execute the Insertion
                connection.Open();
                int successCode = command.ExecuteNonQuery();
                string errMsg = successCode != 0 ? "Record Inserted successfully to the database" : "Error in Insertion";

                Console.WriteLine(errMsg);

                connection.Close();
            }
        }

        // This method will enroll a Student based on the given information
        public static void EnrollStudent(string connectionString, string firstName, string lastName, string email, string programCode)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {

                // Create the command and set it's properties
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "EnrollStudent";
                command.CommandType = CommandType.StoredProcedure;


                // Add the input parameters and set its properties
                SqlParameter parameter = new SqlParameter();

                    // FirstName
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    // Add the parameter to the Parameters Collection
                    command.Parameters.AddWithValue("@FirstName",firstName);


                    // LastNAme
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    // Add the parameter to the Parameters Collection
                    command.Parameters.AddWithValue("@LastName",lastName);

                    // Email
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    // Add the parameter to the Parameters Collection
                    command.Parameters.AddWithValue("@Email", email );

                    // ProgramCode
                    parameter.SqlDbType = SqlDbType.VarChar;
                    parameter.Direction = ParameterDirection.Input;
                    // Add the parameter to the Parameters Collection
                    command.Parameters.AddWithValue("@ProgramCode", programCode);

                // Open the conenction and Execute the Insertion
                connection.Open();
                int successCode = command.ExecuteNonQuery();
                string errMsg = successCode != 0 ? "Record Inserted successfully to the database" : "Error in Insertion";

                Console.WriteLine(errMsg);
               
                connection.Close();

            }
        }

        // This stored procedure will find a student based on the student ID given to it
        public static void FindStudentById(string connectionString, string studentID)
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the command and set it's properties
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "FindStudent";
                command.CommandType = CommandType.StoredProcedure;

                // Add the input parameter and set its properties
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@StudentID";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = studentID;

                // Add the parameter to the Parameters Collection
                command.Parameters.Add(parameter);

                //Open the connection and execute the reader 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found");
                }

                reader.Close();
            }

        }
    }
}
