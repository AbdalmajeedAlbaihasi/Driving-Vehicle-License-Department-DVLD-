using DVLDShared.DTOs.People;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLDDataAccess
{      
    
    //SqlDataReader reader = command.ExecuteReader();
    //object result = sqlCommand.ExecuteScalar();
    //effect = sqlCommand.ExecuteNonQuery();



    ///1


    public sealed class clsPeopleDataAccess
    {

        public async Task<List<PersonListDto>> GetAllAsync()
        {
            List<PersonListDto> people = new List<PersonListDto>();

            using SqlConnection connection =
                new SqlConnection(clsServer_connection.Server);

            using SqlCommand command =
                new SqlCommand("SP_GetAllPeople", connection);

            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                PersonListDto person = new PersonListDto
                {
                    PersonId = Convert.ToInt32(reader["PersonID"]),

                    NationalNo =
                        Convert.ToString(reader["NationalNo"])
                        ?? string.Empty,

                    FullName =
                        Convert.ToString(reader["FullName"])
                        ?? string.Empty,

                    DateOfBirth =
                        Convert.ToDateTime(reader["DateOfBirth"]),

                    Gender =
                        Convert.ToString(reader["Gender"])
                        ?? string.Empty,

                    Address =
                        Convert.ToString(reader["Address"])
                        ?? string.Empty,

                    Phone =
                        Convert.ToString(reader["Phone"])
                        ?? string.Empty,

                    Email = reader["Email"] == DBNull.Value
                        ? null
                        : Convert.ToString(reader["Email"]),

                    CountryName =
                        Convert.ToString(reader["CountryName"])
                        ?? string.Empty,

                    ImagePath = reader["ImagePath"] == DBNull.Value
                        ? null
                        : Convert.ToString(reader["ImagePath"])
                };

                people.Add(person);
            }

            return people;
        }































        public static bool GetPeopleByID(int PersonID, ref string nationalNo, ref string firstName, ref string secondName,
                                     ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte Gendor,
                                     ref string Phone, ref int NationalityCountryID, ref string Email, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsServer_connection.Server);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    nationalNo = reader["NationalNo"].ToString();
                    firstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    thirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                    lastName = reader["LastName"].ToString();
                    Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                    ImagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString();
                    Address = reader["Address"].ToString();
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Phone = reader["Phone"].ToString();
                    NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);

                    reader.Close();
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        //2
        public static bool GetPeopleByNationalNo(string nationalNo, ref int PersonID, ref string firstName, ref string secondName,
                                     ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref int Gendor,
                                     ref string Phone, ref int NationalityCountryID, ref string Email, ref string Address, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsServer_connection.Server);
            string query = "SELECT * FROM People WHERE nationalNo = @nationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    firstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    thirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                    lastName = reader["LastName"].ToString();
                    Email = reader["Email"] != DBNull.Value ? "" : reader["Email"].ToString();
                    ImagePath = reader["ImagePath"] != DBNull.Value ? "" : reader["ImagePath"].ToString();
                    Address = reader["Address"].ToString();
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Phone = reader["Phone"].ToString();
                    NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);

                    reader.Close();
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




        //3
        public static int AddPeople(string NationalNo, string FirstName, string SecondName, string ThirdName
            , string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)

        {
            int PeopleID = -1;
            SqlConnection sqlConnection = new SqlConnection(clsServer_connection.Server);
            string query = @"INSERT INTO [dbo].[People]
           ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gendor]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
     VALUES
           (@NationalNo 
           ,@FirstName  
           ,@SecondName 
           ,@ThirdName  
           ,@LastName   
           ,@DateOfBirth
           ,@Gendor 
           ,@Address    
           ,@Phone     
           ,@Email      
           ,@NationalityCountryID 
           ,@ImagePath)

            select SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != null && ThirdName != "")
            {
                sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gendor", Gendor);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "" && Email != null)
            {
                sqlCommand.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PeopleID = ID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return PeopleID;
        }




        //4
        public static bool UpdatePeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName
            , string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int effect = 0;
            SqlConnection sqlConnection = new SqlConnection(clsServer_connection.Server);
            string query = @"UPDATE [dbo].[People]
                           SET
                               [NationalNo] = @NationalNo
                              ,[FirstName] = @FirstName
                              ,[SecondName] = @SecondName
                              ,[ThirdName] = @ThirdName
                              ,[LastName]  = @LastName
                              ,[DateOfBirth] =@DateOfBirth  
                              ,[Gendor] = @Gendor  
                              ,[Address] = @Address   
                              ,[Phone] = @Phone   
                              ,[Email] = @Email 
                              ,[NationalityCountryID] = @NationalityCountryID 
                              ,[ImagePath] = @ImagePath
                           WHERE PersonID = @PersonID; ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "" && ThirdName != null)
            {
                sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            }
            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gendor", Gendor);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "" && Email != null)
            {
                sqlCommand.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Email", System.DBNull.Value);
            }
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                sqlConnection.Open();
                effect = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { sqlConnection.Close(); }

            return (effect > 0);
        }



        //5
        



        //6
        public static bool DeletePeople(int PersonID)
        {
            int effect = 0;
            SqlConnection sqlConnection = new SqlConnection(clsServer_connection.Server);
            string query = "delete from people where PersonID = @PersonID;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                sqlConnection.Open();
                effect = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { sqlConnection.Close(); }
            return (effect > 0);
        }



        public DataTable FiendByIdPeople(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsServer_connection.Server);
            string query = "select * from people where PersonID = @PersonID;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { sqlConnection.Close(); }
            return dt;
        }



        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsServer_connection.Server);
            string query = "select * from Countries ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { sqlConnection.Close(); }
            return dt;
        }
    }
    //11
    //22


}
