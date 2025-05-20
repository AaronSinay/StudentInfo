using System;
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

namespace StudentInfo
{
    public partial class Form_InfoHandler : Form
    {
        public Form_InfoHandler()
        {
            InitializeComponent();
            InitDataGrid();
        }

        private void Form_InfoHandler_Load(object sender, EventArgs e)
        {
            button_Remove.Enabled = false;
        }

        private void InitDataGrid()
        {
            // Adding Columns
            dataGridView.Columns.Add("IDNo", "ID No.");
            dataGridView.Columns.Add("Name", "Name");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Address", "Address");

            // Fixing layout
            dataGridView.Columns["IDNo"].Width = 80;
            dataGridView.Columns["Name"].Width = 150;
            dataGridView.Columns["Email"].Width = 150;
            dataGridView.Columns["Address"].Width = 400;

            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowTemplate.Height = 30;
        }

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

        private void button_Add_Click(object sender, EventArgs e)
        {
            string idNo = textBox_IDNO.Text;
            string name = textBox_Name.Text;
            string email = textBox_Email.Text;
            string address = textBox_Address.Text;

            if (string.IsNullOrEmpty(idNo) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Exit if any field is empty
            }

            dataGridView.Rows.Add(idNo, name, email, address);
            ClearTextBox();
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row and remove it
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                }
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {

        }

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
