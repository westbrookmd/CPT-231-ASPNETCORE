using OrderOptionsMaintenance.Models;
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
        OrderOption currentOrder = null;
        public frmOptionsMaint()
        {
            InitializeComponent();
        }

        private void frmOptionsMaint_Load(object sender, EventArgs e)
        {
            currentOrder = OrderOptionDB.GetOrderOptions();
            txtSalesTax.Text = currentOrder.SalesTaxRate.ToString();
            txtShipFirstBook.Text = currentOrder.FirstBookShipCharge.ToString();
            txtShipAddlBook.Text = currentOrder.AdditionalBookShipCharge.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OrderOption oldOptions = currentOrder;
            if (IsValidData())
            {
                if(Decimal.TryParse(txtSalesTax.Text, out decimal salesTaxRate))
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
                OrderOptionDB.UpdateOrderOption(oldOptions, currentOrder);
                
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
