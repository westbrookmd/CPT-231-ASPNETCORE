using OrderOptionsMaintenance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderOptionsMaintenance
{
    public partial class frmOptionsMaint : Form
    {
        OrderOption currentOrder = null;
        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {
            // get the first orderoption
            currentOrder = OrderOptionDB.GetOrderOptions();
            // place the values into each textbox
            txtSalesTax.Text = currentOrder.SalesTaxRate.ToString();
            txtShipFirstBook.Text = currentOrder.FirstBookShipCharge.ToString();
            txtShipAddlBook.Text = currentOrder.AdditionalBookShipCharge.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // temporarily store the old options
                OrderOption oldOptions = currentOrder;
                if (IsValidData())
                {
                    // cannot implicitly or explicitly convert a string to a decimal
                    // I used tryparses even though the data has already been validated
                    if (Decimal.TryParse(txtSalesTax.Text, out decimal salesTaxRate))
                    {
                        currentOrder.SalesTaxRate = salesTaxRate;
                    }
                    if (Decimal.TryParse(txtShipFirstBook.Text, out decimal shipFirstBook))
                    {
                        currentOrder.FirstBookShipCharge = shipFirstBook;
                    }
                    if (Decimal.TryParse(txtShipAddlBook.Text, out decimal shipAddlBook))
                    {
                        currentOrder.AdditionalBookShipCharge = shipAddlBook;
                    }
                    // update the database and notify the user of success or failure
                    if (OrderOptionDB.UpdateOrderOption(oldOptions, currentOrder))
                    {
                        MessageBox.Show("Database Saved!", "Database Saved");
                    }
                    else
                    {
                        MessageBox.Show("The database is either currently being accessed or " +
                            "no rows were updated.", "Concurrency Error");
                    }

                }
            }
            // catch sql exceptions and create custom error handling logic if needed
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Sql Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

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
