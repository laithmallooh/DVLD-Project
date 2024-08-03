using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsUsersData
    {


        public static bool NationalNumberExists(string nationalNumber)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM People WHERE NationalNo = @NationalNo";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalNo", nationalNumber);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    isFound = count > 0;
                }
                catch (Exception ex)
                {
                    // Handle exceptions such as logging the error message
                    Console.WriteLine(ex.Message);
                }
            }

            return isFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string query = "SELECT \r\n    u.UserID,\r\n    u.PersonID,\r\n    u.UserName,\r\n    p.FirstName + ' ' + p.SecondName + ' ' + p.ThirdName + ' ' + p.LastName AS FullName,\r\n    u.IsActive\r\nFROM \r\n    users u\r\nJOIN \r\n    people p ON u.PersonID = p.PersonID;\r\n";
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return dt;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                     VALUES (@PersonID, @UserName, @Password, @IsActive);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                MessageBox.Show("Connection opened successfully.");
                object result = command.ExecuteScalar();
                MessageBox.Show("Command executed successfully. Result: " + result);

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    return insertedID;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve inserted ID.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in AddNewUser: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message);
                }
                return -1;
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Connection closed.");
            }
        }



        public static bool UpdateUser(int UserID, int PersonID, string FullName, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users  
                     SET 
                         PersonID = @PersonID,
                         UserName = @UserName,
                         Password = @Password,
                         IsActive = @IsActive
                     WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                MessageBox.Show("Connection opened successfully.");
                rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Command executed successfully. Rows affected: " + rowsAffected);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in UpdateUser: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Connection closed.");
            }

            return (rowsAffected > 0);
        }






        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                MessageBox.Show("Connection opened successfully.");
                transaction = connection.BeginTransaction();

                string deleteQuery = @"
            DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                deleteCommand.Parameters.AddWithValue("@UserID", UserID);
                rowsAffected = deleteCommand.ExecuteNonQuery();
                MessageBox.Show("Command executed successfully. Rows affected: " + rowsAffected);

                transaction.Commit();
                MessageBox.Show("Transaction committed.");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Transaction rolled back.");
                MessageBox.Show("Error in DeleteUser: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message);
                }
                return false;
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Connection closed.");
            }

            return (rowsAffected > 0);
        }



        public static bool GetUserInfoByID(int UserID, ref string FullName, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                MessageBox.Show("Connection opened successfully.");
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    MessageBox.Show("User found: " + UserName);
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GetUserInfoByID: " + ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message);
                }
                isFound = false;
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Connection closed.");
            }

            return isFound;
        }



        public bool ValidateUser(string username, string password)
        {
            string connectionString = clsDataAccessSettings.ConnectionString;
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // If count is 1, the user exists and the credentials are correct
                        return count == 1;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        throw new Exception("Error validating user", ex);
                    }
                }
            }
        }






    }
}
