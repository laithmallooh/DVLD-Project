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

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
             string ThirdName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int Gendor, string ImagePath, int NationalityCountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, Email , Phone, Address , DateOfBirth ,Gendor , ImagePath , NationalityCountryID )
             VALUES (@NationalNo, @FirstName, @SecondName , @ThirdName , @LastName, @Email , @Phone, @Address,@DateOfBirth, @Gendor,@ImagePath , @NationalityCountryID);
             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor); // Check the spelling of Gendor here
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

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
                Console.WriteLine("Error in AddNewPerson: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                return -1;
            }
        }



        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
              string ThirdName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int Gendor, string ImagePath, int NationalityCountryID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE People  
                     SET 
                         NationalNo = @NationalNo,
                         FirstName = @FirstName, 
                         SecondName = @SecondName,
                         ThirdName = @ThirdName,
                         LastName = @LastName, 
                         Email = @Email, 
                         Phone = @Phone, 
                         Address = @Address, 
                         DateOfBirth = @DateOfBirth,
                         Gendor = @Gendor,
                         NationalityCountryID = @NationalityCountryID,
                         ImagePath = @ImagePath
                     WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

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





        public static bool DeletePerson(int PersonID)
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
                deleteTestAppointmentsCommand.Parameters.AddWithValue("@PersonID", PersonID);
                deleteTestAppointmentsCommand.ExecuteNonQuery();

                // Delete from LocalDrivingLicenseApplications table next
                string deleteLocalDrivingLicenseApplicationsQuery = @"
            DELETE FROM LocalDrivingLicenseApplications 
            WHERE ApplicationID IN (
                SELECT ApplicationID FROM Applications 
                WHERE ApplicantPersonID = @PersonID
            )";
                SqlCommand deleteLocalDrivingLicenseApplicationsCommand = new SqlCommand(deleteLocalDrivingLicenseApplicationsQuery, connection, transaction);
                deleteLocalDrivingLicenseApplicationsCommand.Parameters.AddWithValue("@PersonID", PersonID);
                deleteLocalDrivingLicenseApplicationsCommand.ExecuteNonQuery();

                // Delete from Licenses table next
                string deleteLicensesQuery = @"
            DELETE FROM Licenses 
            WHERE ApplicationID IN (
                SELECT ApplicationID FROM Applications 
                WHERE ApplicantPersonID = @PersonID
            )";
                SqlCommand deleteLicensesCommand = new SqlCommand(deleteLicensesQuery, connection, transaction);
                deleteLicensesCommand.Parameters.AddWithValue("@PersonID", PersonID);
                deleteLicensesCommand.ExecuteNonQuery();

                // Delete from Applications table next
                string deleteApplicationsQuery = @"
            DELETE FROM Applications 
            WHERE ApplicantPersonID = @PersonID";
                SqlCommand deleteApplicationsCommand = new SqlCommand(deleteApplicationsQuery, connection, transaction);
                deleteApplicationsCommand.Parameters.AddWithValue("@PersonID", PersonID);
                deleteApplicationsCommand.ExecuteNonQuery();

                // Finally, delete from People table
                string deletePeopleQuery = @"
            DELETE FROM People 
            WHERE PersonID = @PersonID";
                SqlCommand deletePeopleCommand = new SqlCommand(deletePeopleQuery, connection, transaction);
                deletePeopleCommand.Parameters.AddWithValue("@PersonID", PersonID);
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



        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth, ref int Gendor, ref string ImagePath, ref int NationalityCountryID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = reader["NationalNo"]?.ToString();
                    FirstName = reader["FirstName"]?.ToString();
                    SecondName = reader["SecondName"]?.ToString();
                    ThirdName = reader["ThirdName"]?.ToString();
                    LastName = reader["LastName"]?.ToString();
                    Email = reader["Email"]?.ToString();
                    Phone = reader["Phone"]?.ToString();
                    Address = reader["Address"]?.ToString();
                    DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.MinValue;
                    Gendor = reader["Gendor"] != DBNull.Value ? Convert.ToInt32(reader["Gendor"]) : 0;
                    ImagePath = reader["ImagePath"]?.ToString();
                    NationalityCountryID = reader["NationalityCountryID"] != DBNull.Value ? Convert.ToInt32(reader["NationalityCountryID"]) : -1;
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
