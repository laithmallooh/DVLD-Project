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

        public static int AddNewUser( int PersonID, string UserName, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (UserID, PersonID, FullName, Password, IsActive )
             VALUES (@UserID, @PersonID, @FullName , @Password , @IsActive);
             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                connection.Close();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    return insertedID;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine("Error in AddNewUser: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                return -1;
            }
        }



        public static bool UpdateUser(int UserID, int PersonID, string FullName, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People  
                     SET 
                         PersonID = @PersonID,
                         FullName = @FullName, 
                         UserName = @UserName,
                         Password = @Password,
                         IsActive = @IsActive
                      
                     WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdatePerson: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
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
                transaction = connection.BeginTransaction();

                // Delete from TestAppointments table first
                string deleteTestAppointmentsQuery = @"
            DELETE FROM TestAppointments 
            WHERE LocalDrivingLicenseApplicationID IN (
                SELECT ApplicationID FROM LocalDrivingLicenseApplications 
                WHERE ApplicationID IN (
                    SELECT ApplicationID FROM Applications 
                    WHERE ApplicantPersonID = @PersonID
                )
            )";
                SqlCommand deleteTestAppointmentsCommand = new SqlCommand(deleteTestAppointmentsQuery, connection, transaction);
                deleteTestAppointmentsCommand.Parameters.AddWithValue("@UserID", UserID);
                deleteTestAppointmentsCommand.ExecuteNonQuery();

                // Delete from LocalDrivingLicenseApplications table next
                string deleteLocalDrivingLicenseApplicationsQuery = @"
            DELETE FROM LocalDrivingLicenseApplications 
            WHERE ApplicationID IN (
                SELECT ApplicationID FROM Applications 
                WHERE ApplicantPersonID = @PersonID
            )";
                SqlCommand deleteLocalDrivingLicenseApplicationsCommand = new SqlCommand(deleteLocalDrivingLicenseApplicationsQuery, connection, transaction);
                deleteLocalDrivingLicenseApplicationsCommand.Parameters.AddWithValue("@UserID", UserID);
                deleteLocalDrivingLicenseApplicationsCommand.ExecuteNonQuery();

                // Delete from Licenses table next
                string deleteLicensesQuery = @"
            DELETE FROM Licenses 
            WHERE ApplicationID IN (
                SELECT ApplicationID FROM Applications 
                WHERE ApplicantPersonID = @PersonID
            )";
                SqlCommand deleteLicensesCommand = new SqlCommand(deleteLicensesQuery, connection, transaction);
                deleteLicensesCommand.Parameters.AddWithValue("@UserID", UserID);
                deleteLicensesCommand.ExecuteNonQuery();

                // Delete from Applications table next
                string deleteApplicationsQuery = @"
            DELETE FROM Applications 
            WHERE ApplicantPersonID = @PersonID";
                SqlCommand deleteApplicationsCommand = new SqlCommand(deleteApplicationsQuery, connection, transaction);
                deleteApplicationsCommand.Parameters.AddWithValue("@UserID", UserID);
                deleteApplicationsCommand.ExecuteNonQuery();

                // Finally, delete from People table
                string deletePeopleQuery = @"
            DELETE FROM People 
            WHERE PersonID = @PersonID";
                SqlCommand deletePeopleCommand = new SqlCommand(deletePeopleQuery, connection, transaction);
                deletePeopleCommand.Parameters.AddWithValue("@UserID", UserID);
                rowsAffected = deletePeopleCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }



        public static bool GetUserInfoByID(int UserID, string PersonID,  ref string FullName, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    // Assigning the values with proper type casting
                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = reader["PersonID"].ToString();
                    FullName = reader["FullName"].ToString();
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
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
