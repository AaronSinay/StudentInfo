﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data.OleDb;
using Microsoft.Win32.SafeHandles;

namespace StudentInfo
{
    public partial class Form_InfoHandler : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin\source\repos\StudentInfo.accdb";

        // Class-level variable to store the original ID
        private string originalIDNo = string.Empty;

        public Form_InfoHandler()
        {
            InitializeComponent();
            InitDataGrid();


            textBox_IDNO.TextChanged += TextBox_TextChanged;
            textBox_Name.TextChanged += TextBox_TextChanged;
            textBox_Email.TextChanged += TextBox_TextChanged;
            textBox_Address.TextChanged += TextBox_TextChanged;


            textBox_IDNO.KeyPress += TextBox_IDNO_KeyPress;
            textBox_Name.KeyPress += TextBox_Name_KeyPress;
        }



        // Startup executions
        private void Form_InfoHandler_Load(object sender, EventArgs e)
        {
            button_Remove.Enabled = false;
            button_Add.Enabled = false;
            button_Search.Enabled = false;
            button_Save.Enabled = false;
            EnsureDatabaseStructure();
        }



        // Prevents other symbols other than number to be inputted
        private void TextBox_IDNO_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        // Prevents Number and Other Symbols from being inputted should be obvious tho
        private void TextBox_Name_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        // Just checks if textBoxes are empty or nah
        private void TextBox_TextChanged(object sender, EventArgs e)
        {

            bool allTextBoxesFilled = !string.IsNullOrEmpty(textBox_IDNO.Text) &&
                                     !string.IsNullOrEmpty(textBox_Name.Text) &&
                                     !string.IsNullOrEmpty(textBox_Email.Text) &&
                                     !string.IsNullOrEmpty(textBox_Address.Text);

            button_Add.Enabled = allTextBoxesFilled;


            button_Search.Enabled = !string.IsNullOrEmpty(textBox_IDNO.Text);
        }



        // Just check if an item is selected should be obvious what this does
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                button_Remove.Enabled = true;
            }
            else
            {
                button_Remove.Enabled = false;
            }
        }



        // Just initializing the key component of GridView like column and it's layout
        private void InitDataGrid()
        {

            dataGridView.Columns.Add("IDNo", "ID No.");
            dataGridView.Columns.Add("Name", "Name");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Address", "Address");


            dataGridView.Columns["IDNo"].Width = 80;
            dataGridView.Columns["Name"].Width = 150;
            dataGridView.Columns["Email"].Width = 150;
            dataGridView.Columns["Address"].Width = 400;

            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.Height = 30;
        }



        // It make sure that Students Table exist in the Database if not then make one
        private void EnsureDatabaseStructure()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, "Students", "TABLE" });

                    if (schemaTable.Rows.Count == 0)
                    {
                        string createTableQuery = @"
                    CREATE TABLE Students (
                        IDNo TEXT(80),
                        Name TEXT(150),
                        Email TEXT(150),
                        Address TEXT(200)
                    )";

                        OleDbCommand cmd = new OleDbCommand(createTableQuery, conn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Database was empty. 'Students' table created successfully.");
                    }

                    // Always load data after structure is created/ensured :)
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ensuring database structure: " + ex.Message);
                }
            }
        }



        // This load the GridView with Database datas
        private void LoadData()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Students ORDER BY IDNo ASC";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Clear existing rows and columns
                    dataGridView.Rows.Clear();

                    // Add data from database to grid
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView.Rows.Add(
                            row["IDNo"].ToString(),
                            row["Name"].ToString(),
                            row["Email"].ToString(),
                            row["Address"].ToString()
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }



        // Should be Obvious
        private void button_Add_Click(object sender, EventArgs e)
        {
            string idNo = textBox_IDNO.Text;
            string name = textBox_Name.Text;
            string email = textBox_Email.Text;
            string address = textBox_Address.Text;

            // Checks if textboxes requirement are met
            if (string.IsNullOrEmpty(idNo) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add to database
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Students (IDNo, Name, Email, Address) VALUES (@IDNo, @Name, @Email, @Address)";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDNo", idNo);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.ExecuteNonQuery();

                    // Add to grid
                    dataGridView.Rows.Add(idNo, name, email, address);
                    ClearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding record: " + ex.Message);
                }
            }
        }

        // Yeah it removes not only from GridView also to Database
        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow row = dataGridView.SelectedRows[0];
                string idNo = row.Cells["IDNo"].Value.ToString();

                // Remove from database
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Students WHERE IDNo = @IDNo";
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@IDNo", idNo);
                        cmd.ExecuteNonQuery();

                        // Remove from grid
                        dataGridView.Rows.Remove(row);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing record: " + ex.Message);
                    }
                }
            }
        }



        // As the name suggest it searches(for ID)
        private void button_Search_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox_IDNO.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please enter an ID number to search", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Search in database
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Students WHERE IDNo = @IDNo";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDNo", searchTerm);

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        textBox_Name.Text = row["Name"].ToString();
                        textBox_Email.Text = row["Email"].ToString();
                        textBox_Address.Text = row["Address"].ToString();

                        // Store the original ID in the class-level variable
                        originalIDNo = row["IDNo"].ToString();

                        button_Save.Enabled = true;

                        MessageBox.Show("Student found", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        button_Save.Enabled = false;
                        MessageBox.Show("No student found with that ID number", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching record: " + ex.Message);
                }
            }
        }


        // Saves the updated student information
        private void button_Save_Click(object sender, EventArgs e)
        {
            // Make sure the student was found (i.e., originalIDNo is set)
            if (string.IsNullOrEmpty(originalIDNo))
            {
                MessageBox.Show("Please search for a student record first", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = textBox_Name.Text;
            string email = textBox_Email.Text;
            string address = textBox_Address.Text;

            // Ensure all fields except ID are filled in
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all fields", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Update only Name, Email, and Address. ID No should remain unchanged
                    string query = "UPDATE Students SET Name = @Name, Email = @Email, Address = @Address WHERE IDNo = @OriginalIDNo";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@OriginalIDNo", originalIDNo);  // Ensure we update using the original ID

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student information updated successfully");

                        // Optionally, refresh the data grid or reset form fields after saving
                        ClearTextBox();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update student information");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating database: " + ex.Message);
                }
            }
        }



        // Should be Clear what this does
        private void ClearTextBox()
        {
            textBox_IDNO.Clear();
            textBox_Name.Clear();
            textBox_Email.Clear();
            textBox_Address.Clear();
            textBox_IDNO.Focus();
        }
    }
}