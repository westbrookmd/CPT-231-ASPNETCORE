namespace StateMaintenance
{
    partial class frmStateMaintenance
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvStates = new System.Windows.Forms.DataGridView();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pageNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnGoPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(19, 302);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 25);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(387, 302);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 25);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvStates
            // 
            this.dgvStates.AllowUserToAddRows = false;
            this.dgvStates.AllowUserToDeleteRows = false;
            this.dgvStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStates.Location = new System.Drawing.Point(19, 12);
            this.dgvStates.Name = "dgvStates";
            this.dgvStates.ReadOnly = true;
            this.dgvStates.RowTemplate.Height = 25;
            this.dgvStates.Size = new System.Drawing.Size(433, 273);
            this.dgvStates.TabIndex = 5;
            this.dgvStates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStates_CellClick);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(StateMaintenance.Models.Customer);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(91, 302);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(67, 25);
            this.btnPreviousPage.TabIndex = 6;
            this.btnPreviousPage.Text = "Previous";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(164, 302);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(58, 25);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.Text = "Next";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pageNumberUpDown
            // 
            this.pageNumberUpDown.Location = new System.Drawing.Point(267, 302);
            this.pageNumberUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.Name = "pageNumberUpDown";
            this.pageNumberUpDown.Size = new System.Drawing.Size(48, 23);
            this.pageNumberUpDown.TabIndex = 8;
            this.pageNumberUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.ValueChanged += new System.EventHandler(this.btnGoPage_Click);
            // 
            // btnGoPage
            // 
            this.btnGoPage.Location = new System.Drawing.Point(321, 302);
            this.btnGoPage.Name = "btnGoPage";
            this.btnGoPage.Size = new System.Drawing.Size(61, 24);
            this.btnGoPage.TabIndex = 9;
            this.btnGoPage.Text = "Go";
            this.btnGoPage.UseVisualStyleBackColor = true;
            this.btnGoPage.Click += new System.EventHandler(this.btnGoPage_Click);
            // 
            // frmStateMaintenance
            // 
            this.AcceptButton = this.btnGoPage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(497, 339);
            this.Controls.Add(this.btnGoPage);
            this.Controls.Add(this.pageNumberUpDown);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.dgvStates);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmStateMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State Maintenance";
            this.Load += new System.EventHandler(this.frmStateMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvStates;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.NumericUpDown pageNumberUpDown;
        private System.Windows.Forms.Button btnGoPage;
    }
}

