using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Laboration6.Model.DAL
{
    public class BookingDAL : DALBase
    {
        public IEnumerable<Booking> GetBookings()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var bookings = new List<Booking>(100);
                    var command = new SqlCommand("appSchema.usp_VisaMöbelbokningar", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var BookingIDIndex = reader.GetOrdinal("BokningsID");
                        var StudentIDIndex = reader.GetOrdinal("StudentID");
                        var NameIndex = reader.GetOrdinal("Namn");
                        var PieceOfFurnitureIDIndex = reader.GetOrdinal("MöbelID");
                        var DescriptionIndex = reader.GetOrdinal("Beskrivning");
                        var QuantityIndex = reader.GetOrdinal("Antal");
                        var PriceIndex = reader.GetOrdinal("Pris");

                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                BookingID = reader.GetInt32(BookingIDIndex),
                                StudentID = reader.GetInt32(StudentIDIndex),
                                Name = reader.GetString(NameIndex),
                                PieceOfFurnitureID = reader.GetInt32(PieceOfFurnitureIDIndex),
                                Description = reader.GetString(DescriptionIndex),
                                Quantity = reader.GetInt32(QuantityIndex),
                                Price = reader.GetDecimal(PriceIndex)
                            });
                        }
                    }
                    
                    bookings.TrimExcess();
                    return bookings;
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod då möbelbokningar skulle visas.");
                }
            }
        }

        public IEnumerable<Booking> GetBookingsByID(int studentID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var bookings = new List<Booking>(100);
                    SqlCommand command = new SqlCommand("appSchema.usp_VisaMöbelBokning", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var BookingIDIndex = reader.GetOrdinal("MöbelbokningsID");
                        var StudentIDIndex = reader.GetOrdinal("StudentID");
                        var NameIndex = reader.GetOrdinal("Namn");
                        var PieceOfFurnitureIDIndex = reader.GetOrdinal("MöbelID");
                        var DescriptionIndex = reader.GetOrdinal("Beskrivning");
                        var QuantityIndex = reader.GetOrdinal("Antal");
                        var PriceIndex = reader.GetOrdinal("Pris");

                            while (reader.Read())
                            {
                                bookings.Add(new Booking
                                {
                                    BookingID = reader.GetInt32(BookingIDIndex),
                                    StudentID = reader.GetInt32(StudentIDIndex),
                                    Name = reader.GetString(NameIndex),
                                    PieceOfFurnitureID = reader.GetInt32(PieceOfFurnitureIDIndex),
                                    Description = reader.GetString(DescriptionIndex),
                                    Quantity = reader.GetInt16(QuantityIndex),
                                    Price = reader.GetDecimal(PriceIndex)
                                });
                            }

                            bookings.TrimExcess();
                            return bookings;
                    }
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }


        public void InsertBooking(Booking booking)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_NyMöbelBokning", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@StudentID", SqlDbType.Int, 4).Value = booking.StudentID;
                    command.Parameters.Add("@MöbelID", SqlDbType.Int, 4).Value = booking.PieceOfFurnitureID;
                    command.Parameters.Add("@Antal", SqlDbType.SmallInt, 4).Value = booking.Quantity;
                    
                    command.Parameters.Add("@MöbelbokningsID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    booking.BookingID = (int)command.Parameters["@MöbelbokningsID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public void DeleteBooking(int bookingID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_TaBortMöbelbokning", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@MöbelbokningsID", SqlDbType.Int, 4).Value = bookingID;
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