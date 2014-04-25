using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Laboration6.Model.DAL
{
    public class StudentDAL : DALBase
    {
        
        
        public IEnumerable<Student> GetStudents()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var students = new List<Student>(100);
                    var command = new SqlCommand("appSchema.usp_VisaStudenter", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var StudentIDIndex = reader.GetOrdinal("StudentID");
                        var NameIndex = reader.GetOrdinal("Namn");
                        var AddressIndex = reader.GetOrdinal("Adress");
                        var PostalCodeIndex = reader.GetOrdinal("Postnummer");
                        var PostalAddressIndex = reader.GetOrdinal("Ort");
                        var TelephoneIndex = reader.GetOrdinal("Telefon");
                        var CategoryIDIndex = reader.GetOrdinal("KategoriID");

                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = reader.GetInt32(StudentIDIndex),
                                Name = reader.GetString(NameIndex),
                                Address = reader.GetString(AddressIndex),
                                PostalCode = reader.GetString(PostalCodeIndex),
                                PostalAddress = reader.GetString(PostalAddressIndex),
                                Telephone = reader.GetString(TelephoneIndex),
                                CategoryID = reader.GetInt32(CategoryIDIndex)
                            });
                        }
                    }
                    students.TrimExcess();
                    return students;
                }
                
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }   
            }
        }

        public Student GetStudentById(int studentID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_VisaStudent", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var StudentIDIndex = reader.GetOrdinal("StudentID");
                            var NameIndex = reader.GetOrdinal("Namn");
                            var AddressIndex = reader.GetOrdinal("Adress");
                            var PostalCodeIndex = reader.GetOrdinal("Postnummer");
                            var PostalAddressIndex = reader.GetOrdinal("Ort");
                            var TelephoneIndex = reader.GetOrdinal("Telefon");
                            var CategoryIDIndex = reader.GetOrdinal("KategoriID");
  
                            
                            return new Student
                            {
                                StudentID = reader.GetInt32(StudentIDIndex),
                                Name = reader.GetString(NameIndex),
                                Address = reader.GetString(AddressIndex),
                                PostalCode = reader.GetString(PostalCodeIndex),
                                PostalAddress = reader.GetString(PostalAddressIndex),
                                Telephone = reader.GetString(TelephoneIndex),
                                CategoryID = reader.GetInt32(CategoryIDIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }


        public void InsertStudent(Student student)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_NyStudent", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Namn", SqlDbType.VarChar, 40).Value = student.Name;
                    command.Parameters.Add("@Adress", SqlDbType.VarChar, 30).Value = student.Address;
                    command.Parameters.Add("@Postnummer", SqlDbType.VarChar, 6).Value = student.PostalCode;
                    command.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = student.PostalAddress;
                    command.Parameters.Add("@Telefon", SqlDbType.VarChar, 20).Value = student.Telephone;
                    command.Parameters.Add("@KategoriID", SqlDbType.Int, 4).Value = 5;
                    
                    command.Parameters.Add("@StudentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    student.StudentID = (int)command.Parameters["@StudentID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_UppdateraStudent", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@StudentID", SqlDbType.Int, 4).Value = student.StudentID;
                    command.Parameters.Add("@Namn", SqlDbType.VarChar, 40).Value = student.Name;
                    command.Parameters.Add("@Adress", SqlDbType.VarChar, 30).Value = student.Address;
                    command.Parameters.Add("@Postnummer", SqlDbType.VarChar, 6).Value = student.PostalCode;
                    command.Parameters.Add("@Ort", SqlDbType.VarChar, 25).Value = student.PostalAddress;
                    command.Parameters.Add("@Telefon", SqlDbType.VarChar, 20).Value = student.Telephone;
                    command.Parameters.Add("@KategoriID", SqlDbType.Int).Value = student.CategoryID;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public void DeleteStudent(int studentID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_TabortStudent", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@StudentID", SqlDbType.Int, 4).Value = studentID;
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }





    }
}
            
        