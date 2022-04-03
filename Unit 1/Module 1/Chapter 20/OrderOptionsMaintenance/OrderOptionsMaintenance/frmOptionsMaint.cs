/* 
* Marshall Westbrook
* CPT-231-S14
* M1-1 Assignment
* Spring 2022
* A project that demonstrates how to use Entity Framework Core.
*/


using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderOptionsMaintenance.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        // declaring our database context and the model we'll be using
        MMABooksContext context = new MMABooksContext();
        OrderOptions orderOptions = new OrderOptions();
        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {
            // loading the first OrderOptions model from our database
            orderOptions = context.OrderOptions.First();
            // setting each textbox's value to the values from the db
            txtSalesTax.Text = orderOptions.SalesTaxRate.ToString();
            txtShipFirstBook.Text = orderOptions.FirstBookShipCharge.ToString();
            txtShipAddlBook.Text = orderOptions.AdditionalBookShipCharge.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // checks each part of our model to validate the data in the textboxes
            if (IsValidData())
            {
                try
                {
                    // store the values from the textboxes into our model (they must be explicitly cast)
                    orderOptions.SalesTaxRate = decimal.Parse(txtSalesTax.Text);
                    orderOptions.FirstBookShipCharge = decimal.Parse(txtShipFirstBook.Text);
                    orderOptions.AdditionalBookShipCharge = decimal.Parse(txtShipAddlBook.Text);
                    // update the model, and if it updates properly we'll save the changes
                    context.OrderOptions.Update(orderOptions);
                    context.SaveChanges();
                    // alert the user that the db has been updated
                    MessageBox.Show("The database has been updated.", "Database Saved");
                }
                // CH20 Figure 20-12
                catch (DbUpdateException ex)
                {
                    string errorMessage = "";
                    // parse the exceptions from within the DbUpdateException
                    var sqlException = (SqlException)ex.InnerException;
                    // loop through them and list them in an easier format to read
                    foreach (SqlError error in sqlException.Errors)
                    {
                        errorMessage += "ERROR CODE: " + error.Number + " " +
                            error.Message + "\n";
                    }
                    // output to an alert box
                    MessageBox.Show(errorMessage);
                }
                catch (Exception ex)
                {
                    // catch everything else and display it here.
                    MessageBox.Show(ex.Message, "Unhandled Exception: " + ex.GetType().ToString());
                }
            }
        }
        /*
         * summary: validates each textbox's data to make sure it
         *          is able to be placed into the database
         */
        private bool IsValidData()
        {
            return Validator.IsPresent(txtSalesTax) &&
                   Validator.IsDecimal(txtSalesTax) &&
                   Validator.IsPresent(txtShipFirstBook) &&
                   Validator.IsDecimal(txtShipFirstBook) &&
                   Validator.IsPresent(txtShipAddlBook) &&
                   Validator.IsDecimal(txtShipAddlBook);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
