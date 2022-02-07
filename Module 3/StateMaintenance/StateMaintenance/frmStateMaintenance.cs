/* 
* Marshall Westbrook
* CPT-231-S14
* U1-M3 Assignment
* Spring 2022
* A project that demonstrates how to use the DataGridView control
* 
* Extra Credit:
*   1) Paging
*   2) Exit confirmation
*   3) Fixed bug with clicking modify/delete column headers that 
*      results in an out of bounds of array exception that exists
*      in the book's code
*      
* Future considerations:
*   1) Consider rate limiting the db calls both within the client 
*      and from the db.
*   2) Consider caching a certain amount of pages to reduce the
*      db calls. Offer a "refresh" button on data that is already
*      cached.
*   3) Provide a search function that returns the top 10 results.
*      This could reduce the db calls and allow for more efficient
*      usage of the db.
*/

using System;
using System.Data;
using System.Drawing;
using System.Linq;
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

        // paging values
        int selectedPage = 1;
        int pageSize = 10;
        // programmatically set within the UpdateGUI method
        int maxPage;

        // private constants for the index values of the Modify and Delete button columns
        private const int modifyButtonColumnIndex = 2;
        private const int deleteButtonColumnIndex = 3;

        private void frmStateMaintenance_Load(object sender, EventArgs e)
        {
            DisplayStates();
        }

        private void DisplayStates()
        {
            // This method is called every time a change is made - assume data is in the columns
            // clear all current columns
            dgvStates.Columns.Clear();
            dgvStates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // sets the amount of states to skip before taking pageSize
            int statesToSkip = pageSize * (selectedPage - 1);

            // get states
            var states = context.States
                .OrderBy(c => c.StateName)
                .Select(c => new { c.StateCode, c.StateName })
                .Skip(statesToSkip)
                .Take(pageSize)
                .ToList();

            // bind the grid
            dgvStates.DataSource = states;

            // format grid
            dgvStates.ColumnHeadersDefaultCellStyle.BackColor = Color.Gold;
            dgvStates.EnableHeadersVisualStyles = false;
            dgvStates.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            // State Code Column
            dgvStates.Columns[0].HeaderText = "Code";

            // Modify Button Column
            DataGridViewButtonColumn modifyButtonColumn = new DataGridViewButtonColumn();
            modifyButtonColumn.HeaderText = "Modify";
            modifyButtonColumn.UseColumnTextForButtonValue = true;
            modifyButtonColumn.Text = "Modify";
            

            // Delete Button Column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.Text = "Delete";
            

            // Insert Button Columns
            dgvStates.Columns.Insert(modifyButtonColumnIndex, modifyButtonColumn);
            dgvStates.Columns.Insert(deleteButtonColumnIndex, deleteButtonColumn);

            dgvStates.Columns[2].Width = 50;
            dgvStates.Columns[3].Width = 50;
            // Update the page controls
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            /*consolidates all of the UI update logic into a single method.
            in the future, consider separating each set of logic into separate methods
            if different functionality is added */

            // consider only doing this once and then after adding/removing states
            maxPage = (context.States.Count() / pageSize);

            // Page Number Up/Down
            pageNumberUpDown.Maximum = maxPage;
            pageNumberUpDown.Value = selectedPage;

            // Previous Button
            if(selectedPage == 1)
            {
                btnPreviousPage.Enabled = false;
            }
            else
            {
                btnPreviousPage.Enabled = true;
            }

            // Next Button
            if (selectedPage == maxPage)
            {
                btnNextPage.Enabled = false;
            }
            else
            {
                btnNextPage.Enabled = true;
            }
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
            // confirmation dialog to prevent accidental exits
            DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit Prompt", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }   
        }

        private void dgvStates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // make sure we're clicking on the modify/delete column and we aren't clicking the header row
            if ((e.ColumnIndex == modifyButtonColumnIndex || e.ColumnIndex == deleteButtonColumnIndex) && e.RowIndex > -1)
            {
                // get the statecode
                string stateCode = dgvStates.Rows[e.RowIndex].Cells[0].Value.ToString();

                // set the selected state to our current state from the db
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

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if(selectedPage > 1)
            {
                selectedPage -= 1;
            }
            DisplayStates();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            // make sure the max page is set already
            if(maxPage != 0)
            {
                // if we're not at the max page, go to the next one
                if(selectedPage < maxPage)
                {
                    selectedPage += 1;
                }
                
            }
            // view the next page
            DisplayStates();
        }

        private void btnGoPage_Click(object sender, EventArgs e)
        {
            try
            {
                // attempt to validate the number entered and set the selectedPage as this
                selectedPage = int.Parse(pageNumberUpDown.Value.ToString());
                // view the next page
                DisplayStates();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid page number.", "Bad Page Number");
            }
        }
    }
}
