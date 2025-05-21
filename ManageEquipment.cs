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

namespace DatabaseProject
{
    public partial class ManageEquipment : Form
    {
        public ManageEquipment()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add SelectionChanged event for DGV_Search
            DGV_Search.SelectionChanged += DGV_Search_SelectionChanged;
        }

        private void FirstNameTxt_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for future functionality if needed
        }

        private void ViewAll(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Equipment", con);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                DataTable tb_OrderInfo = new DataTable();
                tb_OrderInfo.Columns.Add("EquipmentID", typeof(int));
                tb_OrderInfo.Columns.Add("EquipmentName");
                tb_OrderInfo.Columns.Add("Stock", typeof(int));
                tb_OrderInfo.Columns.Add("Cost", typeof(decimal));

                DataRow row;
                while (reader.Read())
                {
                    row = tb_OrderInfo.NewRow();
                    row["EquipmentID"] = reader["EquipmentID"] != DBNull.Value ? Convert.ToInt32(reader["EquipmentID"]) : 0;
                    row["EquipmentName"] = reader["EquipmentName"] != DBNull.Value ? reader["EquipmentName"].ToString() : "";
                    row["Stock"] = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0;
                    row["Cost"] = reader["Cost"] != DBNull.Value ? Convert.ToDecimal(reader["Cost"]) : 0m;
                    tb_OrderInfo.Rows.Add(row);
                }
                reader.Close();
                DGV_ViewAll.DataSource = tb_OrderInfo;

                if (tb_OrderInfo.Rows.Count == 0)
                {
                    MessageBox.Show("No equipment found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        private void NewEquipment(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Validate inputs
                if (string.IsNullOrWhiteSpace(CostTxt.Text) || !decimal.TryParse(CostTxt.Text, out decimal cost))
                {
                    MessageBox.Show("Please enter a valid cost (numeric value).");
                    return;
                }
                if (string.IsNullOrWhiteSpace(AddStockTxt.Text) || !int.TryParse(AddStockTxt.Text, out int stock))
                {
                    MessageBox.Show("Please enter a valid stock amount (numeric value).");
                    return;
                }
                if (string.IsNullOrWhiteSpace(NameTxt.Text))
                {
                    MessageBox.Show("Please enter an equipment name.");
                    return;
                }

                // Get the next EquipmentID
                string maxIdCmd = "SELECT COALESCE(MAX(EquipmentID), 0) + 1 FROM Equipment";
                using (SqlCommand maxCmd = new SqlCommand(maxIdCmd, con))
                {
                    int nextId = (int)maxCmd.ExecuteScalar();

                    // Insert the new equipment into Equipment table
                    string cmdString = @"INSERT INTO Equipment (EquipmentID, EquipmentName, Stock, Cost)
                                     VALUES (@EquipmentID, @EquipmentName, @Stock, @Cost)";
                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@EquipmentID", nextId);
                        cmd.Parameters.AddWithValue("@EquipmentName", NameTxt.Text);
                        cmd.Parameters.AddWithValue("@Stock", stock);
                        cmd.Parameters.AddWithValue("@Cost", cost);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Added new Equipment!");
                // Refresh the view
                ViewAll(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private int equipmentID = 0; // Tracks the selected EquipmentID

        private void SearchEquipmentByName(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                string equipmentName = SearchNameTxt.Text.Trim();
                if (string.IsNullOrWhiteSpace(equipmentName))
                {
                    MessageBox.Show("Please enter an equipment name to search.");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"SELECT * FROM Equipment 
                      WHERE EquipmentName LIKE '%' + @EquipmentName + '%'",
                    con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EquipmentName", equipmentName);
                reader = cmd.ExecuteReader();

                DataTable tb_EquipmentInfo = new DataTable();
                tb_EquipmentInfo.Columns.Add("EquipmentID", typeof(int));
                tb_EquipmentInfo.Columns.Add("EquipmentName");
                tb_EquipmentInfo.Columns.Add("Stock", typeof(int));
                tb_EquipmentInfo.Columns.Add("Cost", typeof(decimal));

                DataRow row;
                while (reader.Read())
                {
                    row = tb_EquipmentInfo.NewRow();
                    row["EquipmentID"] = reader["EquipmentID"] != DBNull.Value ? Convert.ToInt32(reader["EquipmentID"]) : 0;
                    row["EquipmentName"] = reader["EquipmentName"] != DBNull.Value ? reader["EquipmentName"].ToString() : "";
                    row["Stock"] = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0;
                    row["Cost"] = reader["Cost"] != DBNull.Value ? Convert.ToDecimal(reader["Cost"]) : 0m;
                    tb_EquipmentInfo.Rows.Add(row);
                }
                reader.Close();
                DGV_Search.DataSource = tb_EquipmentInfo;

                if (tb_EquipmentInfo.Rows.Count == 0)
                {
                    MessageBox.Show("No equipment found with the specified name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        private void DGV_Search_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Search.SelectedRows.Count > 0)
            {
                equipmentID = Convert.ToInt32(DGV_Search.SelectedRows[0].Cells["EquipmentID"].Value);
            }
            else
            {
                equipmentID = 0;
            }
        }














        private void ChangeAttribute(object sender, EventArgs e)
        {
            int editID = 0;
            try
            {
                if (!int.TryParse(IDTxt.Text, out editID))
                {
                    MessageBox.Show("Please enter a valid integer for the ID.");
                    return;
                }
                int.TryParse(IDTxt.Text, out editID);
                // Validate inputs first
                string choice = UpdateChoice.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    MessageBox.Show("Please select an attribute to update.");
                    return;
                }

                if (editID == 0)
                {
                    MessageBox.Show("Please enter a valid ID.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(IDTxt.Text))
                {
                    MessageBox.Show($"Please enter a value for {choice}.");
                    return;
                }

                // Determine the column to update and validate the input based on the column type
                string columnToUpdate;
                object updateValue;
                /*TotalCost
Amount
StaffID
SupplierID
EquipmentID*/
                switch (choice)
                {
                    case "name":
                        columnToUpdate = "EquipmentName";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "stock":
                        columnToUpdate = "Stock";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "cost":
                        columnToUpdate = "Cost";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;

                    default:
                        MessageBox.Show("Please enter a valid attribute to update.");
                        return;
                }

                // Construct the query with the chosen column
                string fullChangeQuery = $"UPDATE Equipment SET {columnToUpdate} = @update WHERE EquipmentID = @ID";

                // Initialize the connection and command after validation
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(fullChangeQuery, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", editID);
                        cmd.Parameters.AddWithValue("@update", updateValue);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Updated {choice} successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No equipment found with the specified equipmentID, or the input is invalid.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attribute: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }












        private void DeleteEquipment(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Validate that an equipment has been selected
                if (equipmentID == 0)
                {
                    MessageBox.Show("Please search for an equipment first and select a row.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the equipment with ID {equipmentID}? This action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Step 1: Delete dependent records first to avoid foreign key violations
                string[] deleteDependentQueries = new string[]
                {
                    "DELETE FROM EquipmentOrder WHERE EquipmentID = @ID;",
                    "DELETE FROM RepairRecord WHERE EquipmentID = @ID;"
                };

                foreach (var query in deleteDependentQueries)
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", equipmentID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Step 2: Delete the equipment from the Equipment table
                int rowsAffected = 0;
                using (SqlCommand deleteCmd = new SqlCommand(@"DELETE FROM Equipment WHERE EquipmentID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", equipmentID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }

                // Step 3: Provide feedback to the user
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Equipment deleted successfully.");
                    equipmentID = 0; // Reset class-level equipmentID
                    DGV_Search.DataSource = null; // Clear the DataGridView
                    ViewAll(sender, e); // Refresh the view
                }
                else
                {
                    MessageBox.Show("No equipment found with the specified EquipmentID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        private void ManageEquipment_Load(object sender, EventArgs e)
        {

        }
        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void Logout(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Login form2 = new Login();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void ExitApplication(object sender, EventArgs e)
        {
            // Show a confirmation dialog to ensure the user wants to exit
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the application
                Application.Exit();
            }
        }

    }
}