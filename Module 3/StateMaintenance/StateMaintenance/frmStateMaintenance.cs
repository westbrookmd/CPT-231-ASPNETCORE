using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StateMaintenance.Models;

namespace StateMaintenance
{
    public partial class frmStateMaintenance : Form
    {
        public frmStateMaintenance()
        {
            InitializeComponent();
        }

        MMABooksContext context = new MMABooksContext();
        State selectedState = null;

        // private constants for the index values of the Modify and Delete button columns

        private const int modifyButtonColumnIndex = 2;
        private const int deleteButtonColumnIndex = 3;

        private void frmStateMaintenance_Load(object sender, EventArgs e)
        {
            DisplayStates();
        }

        private void DisplayStates()
        {
            dgvStates.Columns.Clear();
            // get states and bind grid
            var states = context.States
                .OrderBy(c => c.StateName)
                .Select(c => new { c.StateCode, c.StateName  })
                .ToList();
            dgvStates.DataSource = states;

            // format grid
            dgvStates.ColumnHeadersDefaultCellStyle.BackColor = Color.Gold;
            dgvStates.EnableHeadersVisualStyles = false;
            dgvStates.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            // State Code Column
            dgvStates.Columns[0].HeaderText = "Code";
            dgvStates.Columns[0].Width = 40;

            // State Name Column
            dgvStates.Columns[1].Width = 150;

            // Modify and Delete Button Columns
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.HeaderText = "Modify";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            modifyButtonColumn.Text = "Modify";

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.Text = "Delete";

            dgvStates.Columns.Insert(modifyButtonColumnIndex, modifyButtonColumn);
            dgvStates.Columns.Insert(deleteButtonColumnIndex, deleteButtonColumn);

        }

        private void ModifyState()
        {
            var modifyForm = new frmAddModify()
            {
                AddState = false,
                State = selectedState
            };
            DialogResult result = modifyForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    selectedState = modifyForm.State;
                    context.SaveChanges();
                    DisplayStates();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void DeleteState()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedState.StateName.Trim()}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.States.Remove(selectedState);
                    context.SaveChanges(true);
                    DisplayStates();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    HandleConcurrencyError(ex);
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new frmAddModify
            {
                AddState = true
            };
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            { 
                try
                {
                    selectedState = addForm.State;
                    context.States.Add(selectedState);
                    context.SaveChanges();
                    DisplayStates();
                }
                catch (DbUpdateException ex)
                {
                    HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    HandleGeneralError(ex);
                }
            }
        }

        private void HandleConcurrencyError(DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var entityState = context.Entry(selectedState).State;
            if (entityState == EntityState.Detached)
            {
                MessageBox.Show("Another user has deleted that state.",
                "Concurrency Error");
            }
            else
            {
                string message = "Another user has updated that state.\n" +
                "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
            }
            DisplayStates();
        }

        private void HandleDatabaseError(DbUpdateException ex)
        {
            string errorMessage = "";
            var sqlException = (SqlException)ex.InnerException;
            foreach (SqlError error in sqlException.Errors)
            {
                errorMessage += "ERROR CODE: " + error.Number + " " +
                error.Message + "\n";
            }
            MessageBox.Show(errorMessage);
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == modifyButtonColumnIndex || e.ColumnIndex == deleteButtonColumnIndex)
            {

                string stateCode = dgvStates.Rows[e.RowIndex].Cells[0].Value.ToString();
                //currentState.StateName = dgvStates.Rows[e.RowIndex].Cells[1].Value.ToString();
                // set the selected state to our current state
                selectedState = context.States.Find(stateCode);

                if (e.ColumnIndex == modifyButtonColumnIndex)
                {
                    ModifyState();
                }
                else if (e.ColumnIndex == deleteButtonColumnIndex)
                {
                    DeleteState();
                }
            }
        }
    }
}
