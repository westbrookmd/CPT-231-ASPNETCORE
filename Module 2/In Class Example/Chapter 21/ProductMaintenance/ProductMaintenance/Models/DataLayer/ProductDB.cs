using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProductMaintenance.Models.DataLayer
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            Product product = null;
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(MMABooksDB.ConnectionString);
                string getProductStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity " +
                                         "FROM Products " +
                                         "WHERE ProductCode = @ProductCode";
            
                using SqlCommand getProductSqlCommand = new SqlCommand(getProductStatement, sqlConnection);
                getProductSqlCommand.Parameters.AddWithValue("@ProductCode", productCode);

                sqlConnection.Open();
                using SqlDataReader sqlDataReader = getProductSqlCommand.ExecuteReader(CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
                if (sqlDataReader.Read())
                {
                    product = new Product
                    {
                        ProductCode = sqlDataReader["ProductCode"].ToString(),
                        Description = sqlDataReader["Description"].ToString(),
                        UnitPrice = (decimal)sqlDataReader["UnitPrice"],
                        OnHandQuantity = (int)sqlDataReader["OnHandQuantity"]
                    };
                } 
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            return product;
        }

        public static void AddProduct(Product product)
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(MMABooksDB.ConnectionString);

                string addProductStatement = "INSERT Products (ProductCode, Description, UnitPrice, OnHandQuantity) " +
                                             "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";

                using SqlCommand addProductSqlCommand = new SqlCommand(addProductStatement, sqlConnection);

                addProductSqlCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                addProductSqlCommand.Parameters.AddWithValue("@Description", product.Description);
                addProductSqlCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                addProductSqlCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

                sqlConnection.Open();
                int number = addProductSqlCommand.ExecuteNonQuery();
                if (number < 1)
                {
                    MessageBox.Show("Nothing was added", "Add Product Error");
                }
                else
                {
                    MessageBox.Show("The product was added!", "Product added");
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            bool update = false;
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(MMABooksDB.ConnectionString);

                string updateProductStatement = "UPDATE Products SET ProductCode = @NewProductCode, " +
                                                "Description =  @NewDescription, UnitPrice = @NewUnitPrice, " +
                                                "OnHandQuantity = @NewOnHandQuantity " +
                                                "WHERE ProductCode = @OldProductCode";

                using SqlCommand updateProductSqlCommand = new SqlCommand(updateProductStatement, sqlConnection);

                updateProductSqlCommand.Parameters.AddWithValue("@NewProductCode", newProduct.ProductCode);
                updateProductSqlCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
                updateProductSqlCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
                updateProductSqlCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
                updateProductSqlCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);

                sqlConnection.Open();

                int number = updateProductSqlCommand.ExecuteNonQuery();
                update = number > 0;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            return false;        
        }

        public static bool DeleteProduct(Product product)
        {
            bool update = false;
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(MMABooksDB.ConnectionString);
                string deleteProductStatement = "DELETE FROM Products WHERE ProductCode = @ProductCode";

                using SqlCommand deleteProductSqlCommand = new SqlCommand(deleteProductStatement, sqlConnection);

                deleteProductSqlCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);

                sqlConnection.Open();

                int number = deleteProductSqlCommand.ExecuteNonQuery();
                update = number > 0;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            return update;        
        }
    }
}