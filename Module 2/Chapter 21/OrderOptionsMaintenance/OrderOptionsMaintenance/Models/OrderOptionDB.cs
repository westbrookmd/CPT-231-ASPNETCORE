/* 
* Marshall Westbrook
* CPT-231-S14
* M1-2 Assignment
* Spring 2022
* A project that demonstrates how to use ADO.NET
*/
using Microsoft.Data.SqlClient;
using System.Data;

namespace OrderOptionsMaintenance.Models
{
    public static class OrderOptionDB
    {
        // We aren't catching exceptions here at all - these will bubble up to calling methods
        public static OrderOption GetOrderOptions()
        {
            // create a default orderoption
            OrderOption orderOption = new OrderOption();
            // select statement that doesn't filter by rows
            string getOrderStatement =
                "SELECT SalesTaxRate, FirstBookShipCharge, AdditionalBookShipCharge " +
                "FROM OrderOptions";
            using SqlConnection connection = new SqlConnection(MMABooksDB.ConnectionString);
            using SqlCommand command = new SqlCommand(
                getOrderStatement, connection);
            // creating parameters to create proper mappings
            command.Parameters.AddWithValue("@SalesTax", orderOption.SalesTaxRate);
            command.Parameters.AddWithValue("@FirstBookShipCharge", orderOption.FirstBookShipCharge);
            command.Parameters.AddWithValue("@AdditionalBookShipCharge", orderOption.AdditionalBookShipCharge);

            connection.Open();
            // only returning a single result (doing this here instead of in a WHERE clause)
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
            // close the connection as a safe meassure.
            // I think this would automatically be closed due to being out of scope
            connection.Close();
            return orderOption;
        }

        public static bool UpdateOrderOption(OrderOption oldOptions, OrderOption newOptions)
        {
            // Not included a WHERE clause since there is only one entry
            string updateStatement =
                "UPDATE OrderOptions SET " +
                "SalesTaxRate = @NewSalesTaxRate, " +
                "FirstBookShipCharge = @NewFirstBookShipCharge, " +
                "AdditionalBookShipCharge = @NewAdditionalBookShipCharge " +
                "FROM OrderOptions ";
            using SqlConnection connection = new SqlConnection(MMABooksDB.ConnectionString);
            using SqlCommand command = new SqlCommand(
                updateStatement, connection);
            // creating the mappings to our OrderOption
            command.Parameters.AddWithValue("@NewSalesTaxRate", newOptions.SalesTaxRate);
            command.Parameters.AddWithValue("@NewFirstBookShipCharge", newOptions.FirstBookShipCharge);
            command.Parameters.AddWithValue("@NewAdditionalBookShipCharge", newOptions.AdditionalBookShipCharge);
            command.Parameters.AddWithValue("@OldSalesTaxRate", oldOptions.SalesTaxRate);
            command.Parameters.AddWithValue("@OldFirstBookShipCharge", oldOptions.FirstBookShipCharge);
            command.Parameters.AddWithValue("@OldAdditionalBookShipCharge", oldOptions.AdditionalBookShipCharge);
            connection.Open();

            // capture our result and return whether it was successful or not
            int rowsreturned = command.ExecuteNonQuery();
            connection.Close();
            return (rowsreturned > 0);
        }
    }
}