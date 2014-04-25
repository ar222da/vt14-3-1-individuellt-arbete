using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Laboration6.Model.DAL
{
    public class ContactDAL : DALBase
    {
        
        
        public IEnumerable<Contact> GetContacts()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(100);
                    var command = new SqlCommand("Person.uspGetContacts", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var contactIDIndex = reader.GetOrdinal("ContactID");
                        var FirstNameIndex = reader.GetOrdinal("FirstName");
                        var LastNameIndex = reader.GetOrdinal("LastName");
                        var EmailAddressIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                ContactID = reader.GetInt32(contactIDIndex),
                                FirstName = reader.GetString(FirstNameIndex),
                                LastName = reader.GetString(LastNameIndex),
                                EmailAddress = reader.GetString(EmailAddressIndex)
                            });
                        }
                    }
                    contacts.TrimExcess();
                    return contacts;
                }
                
                catch
                {
                    throw new ApplicationException("An error occured while getting customers from the database.");
                }   
            }
        }

        public Contact GetContactById(int contactID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Person.uspGetContact", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ContactID", contactID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int contactIDIndex = reader.GetOrdinal("ContactID");
                            int FirstNameIndex = reader.GetOrdinal("FirstName");
                            int LastNameIndex = reader.GetOrdinal("LastName");
                            int EmailAddressIndex = reader.GetOrdinal("EmailAddress");
                            
                            return new Contact
                            {
                                ContactID = reader.GetInt32(contactIDIndex),
                                FirstName = reader.GetString(FirstNameIndex),
                                LastName = reader.GetString(LastNameIndex),
                                EmailAddress = reader.GetString(EmailAddressIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }


        public void InsertContact(Contact contact)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Person.uspAddContact", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    
                    command.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    connection.Open();
                    command.ExecuteNonQuery();
                    contact.ContactID = (int)command.Parameters["@ContactID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Person.uspUpdateContact", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactID;
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    command.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    
                    connection.Open();

                    command.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        public void DeleteContact(int contactID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("Person.uspRemoveContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactID;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }





    }
}
            
        