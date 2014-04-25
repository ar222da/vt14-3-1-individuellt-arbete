using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Laboration6.Model.DAL
{
    public class PieceOfFurnitureDAL : DALBase
    {
        public IEnumerable<PieceOfFurniture> GetFurniture()
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var furniture = new List<PieceOfFurniture>(100);
                    var command = new SqlCommand("appSchema.usp_VisaMöbler", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var PieceOfFurnitureIDIndex = reader.GetOrdinal("MöbelID");
                        var DescriptionIndex = reader.GetOrdinal("Beskrivning");
                        var PriceIndex = reader.GetOrdinal("Pris");
                        var BuyingPriceIndex = reader.GetOrdinal("Inköpspris");
                        var QuantityIndex = reader.GetOrdinal("Antal");
                        
                        while (reader.Read())
                        {
                            furniture.Add(new PieceOfFurniture
                            {
                                PieceOfFurnitureID = reader.GetInt32(PieceOfFurnitureIDIndex),
                                Description = reader.GetString(DescriptionIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                BuyingPrice = reader.GetDecimal(BuyingPriceIndex),
                                Quantity = reader.GetInt32(QuantityIndex)
                        
                            });
                        }
                    }
                    furniture.TrimExcess();
                    return furniture;
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public PieceOfFurniture GetPieceOfFurnitureById(int pieceoffurnitureID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_VisaMöbel", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MöbelID", pieceoffurnitureID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var PieceOfFurnitureIDIndex = reader.GetOrdinal("MöbelID");
                            var DescriptionIndex = reader.GetOrdinal("Beskrivning");
                            var PriceIndex = reader.GetOrdinal("Pris");
                            var BuyingPriceIndex = reader.GetOrdinal("Inköpspris");
                            var QuantityIndex = reader.GetOrdinal("Antal");


                            return new PieceOfFurniture
                            {
                                PieceOfFurnitureID = reader.GetInt32(PieceOfFurnitureIDIndex),
                                Description = reader.GetString(DescriptionIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                BuyingPrice = reader.GetDecimal(BuyingPriceIndex),
                                Quantity = reader.GetInt32(QuantityIndex)
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


        public void InsertPieceOfFurniture(PieceOfFurniture pieceoffurniture)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_NyMöbel", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 50).Value = pieceoffurniture.Description;
                    command.Parameters.Add("@Pris", SqlDbType.Decimal,6).Value = pieceoffurniture.Price;
                    command.Parameters.Add("@Inköpspris", SqlDbType.Decimal, 6).Value = pieceoffurniture.BuyingPrice;
                    command.Parameters.Add("@Antal", SqlDbType.Int, 4).Value = pieceoffurniture.Quantity;

                    command.Parameters.Add("@MöbelID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    pieceoffurniture.PieceOfFurnitureID = (int)command.Parameters["@MöbelID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public void UpdatePieceOfFurniture(PieceOfFurniture pieceoffurniture)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_UppdateraMöbel", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@MöbelID", SqlDbType.Int, 4).Value = pieceoffurniture.PieceOfFurnitureID;
                    command.Parameters.Add("@Beskrivning", SqlDbType.VarChar, 50).Value = pieceoffurniture.Description;
                    command.Parameters.Add("@Pris", SqlDbType.Decimal, 6).Value = pieceoffurniture.Price;
                    command.Parameters.Add("@Inköpspris", SqlDbType.Decimal, 6).Value = pieceoffurniture.BuyingPrice;
                    command.Parameters.Add("@Antal", SqlDbType.Int, 4).Value = pieceoffurniture.Quantity;

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod i dataåtkomstlagret.");
                }
            }
        }

        public void DeletePieceOfFurniture(int pieceoffurnitureID)
        {
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("appSchema.usp_TabortMöbel", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@MöbelID", SqlDbType.Int, 4).Value = pieceoffurnitureID;
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