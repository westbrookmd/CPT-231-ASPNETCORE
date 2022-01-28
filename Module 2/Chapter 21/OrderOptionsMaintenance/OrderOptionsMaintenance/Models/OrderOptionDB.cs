using Microsoft.Data.SqlClient;
using System.Data;

namespace OrderOptionsMaintenance.Models
{
    public static class OrderOptionDB
    {
        public static OrderOption GetOrderOptions()
        {
            OrderOption orderOption = null;
            string getOrderStatement =
                "SELECT SalesTax, FirstBookShipCharge, AdditionalBookShipCharge" +
                "FROM OrderOptionDB";
            using SqlConnection connection = new SqlConnection(MMABooksDB.ConnectionString);
            using SqlCommand command = new SqlCommand(
                getOrderStatement, connection);
            command.Parameters.Add(getOrderStatement);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleResult & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                orderOption = new OrderOption
                {
                    SalesTaxRate = (decimal)reader["SalesTaxRate"],
                    FirstBookShipCharge = (decimal)reader["FirstBookShipCharge"],
                    AdditionalBookShipCharge = (decimal)reader["AdditionalBookShipCharge"]
                };
            }
            return orderOption;
        }

        public static bool UpdateOrderOption(OrderOption oldOptions, OrderOption newOptions)
        {
            string updateStatement =
                "UPDATE OrderOption SET" +
                "SalesTaxRate = @NewSalesTaxRate," +
                "FirstBookShipCharge = @NewFirstBookShipCharge," +
                "AdditionalBookShipCharge = @NewAdditionalBookShipCharge" +
                "WHERE SalesTaxRate = @OldSalesTaxRate," +
                "AND FirstBookShipCharge = @OldFirstBookShipCharge," +
                "AND AdditionalBookShipCharge = @OldAdditionalBookShipCharge";
            using SqlConnection connection = new SqlConnection(MMABooksDB.ConnectionString);
            using SqlCommand command = new SqlCommand(
                updateStatement, connection);
            command.Parameters.AddWithValue("@NewSalesTaxRate", newOptions.SalesTaxRate);
            command.Parameters.AddWithValue("@NewFirstBookShipCharge", newOptions.FirstBookShipCharge);
            command.Parameters.AddWithValue("@NewAdditionalBookShipCharge", newOptions.AdditionalBookShipCharge);
            command.Parameters.AddWithValue("@OldSalesTaxRate", oldOptions.SalesTaxRate);
            command.Parameters.AddWithValue("@OldFirstBookShipCharge", oldOptions.FirstBookShipCharge);
            command.Parameters.AddWithValue("@OldAdditionalBookShipCharge", oldOptions.AdditionalBookShipCharge);
            connection.Open();

            int rowsreturned = command.ExecuteNonQuery();
            return (rowsreturned > 0);
        }
    }
}