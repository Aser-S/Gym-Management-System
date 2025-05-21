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
    public partial class ManageSuppliers : Form
    {
        public ManageSuppliers()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

        }


        int editID = 0;
        private void ViewAll(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Supplier", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;


            // Ensure the parameter type matches the StaffID column in the database
            // If StaffID is an integer, convert ID: cmd.Parameters[0].SqlDbType = SqlDbType.Int; cmd.Parameters[0].Value = int.Parse(ID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tb_SupplierInfo = new DataTable();

            tb_SupplierInfo.Columns.Add("SupplierID");
            tb_SupplierInfo.Columns.Add("SupplierPhone");
            tb_SupplierInfo.Columns.Add("Name");


            DataRow row;
            while (reader.Read())
            {
                row = tb_SupplierInfo.NewRow();
                row["SupplierID"] = reader["SupplierID"];
                row["SupplierPhone"] = reader["SupplierPhone"];
                row["Name"] = reader["Name"];
                tb_SupplierInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_All.DataSource = tb_SupplierInfo;
        }


        private void AddNewMember(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            try
            {
                // Get the next MemberID by adding 1 to the current maximum
                string maxIdCmd = "SELECT COALESCE(MAX(SupplierID), 0) + 1 FROM Supplier";
                SqlCommand maxCmd = new SqlCommand(maxIdCmd, con);
                int nextId = (int)maxCmd.ExecuteScalar();

                // Insert the new member into Member table
                string cmdString = @"INSERT INTO Supplier (SupplierID, SupplierPhone, Name)
                             VALUES (@SupplierID, @SupplierPhone, @Name)";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.CommandType = CommandType.Text;

                // Add parameters for Member
                cmd.Parameters.Add(new SqlParameter("@SupplierID", nextId));
                cmd.Parameters.Add(new SqlParameter("@SupplierPhone", PhoneTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@Name", NameTxt.Text));

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Member added successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }



        private void ChangeAttribute(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Please search for a member first to select a valid MemberID.");
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

                switch (choice)
                {
                    case "name":
                        columnToUpdate = "Name";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "phone":
                        columnToUpdate = "SupplierPhone";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    
                    default:
                        MessageBox.Show("Please enter a valid attribute to update.");
                        return;
                }

                // Construct the query with the chosen column
                string fullChangeQuery = $"UPDATE Supplier SET {columnToUpdate} = @update WHERE SupplierID = @ID";

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
                            MessageBox.Show("No member found with the specified MemberID, or the input is invalid.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attribute: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }


        private void DeleteSupplier(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                if (!int.TryParse(IDTxt.Text, out editID))
                {
                    MessageBox.Show("Please enter a valid integer for the ID.");
                    return;
                }
                int.TryParse(IDTxt.Text, out editID);
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the supplier with ID {editID}? This action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

       

                // Step 2: Delete dependent records first to avoid foreign key violations
             

                // Step 3: Delete the member from the Member table
                int rowsAffected = 0;
                using (SqlCommand deleteCmd = new SqlCommand(@"DELETE FROM Supplier WHERE SupplierID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", editID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }


                // Step 5: Provide feedback to the user
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Supplier deleted successfully.");
                    editID = 0; // Reset class-level editID
                }
                else
                {
                    MessageBox.Show("No Supplier found with the specified MemberID.");
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


        private void label1_Click(object sender, EventArgs e)
        {

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

        private void ManageSuppliers_Load(object sender, EventArgs e)
        {

        }
        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void UpdateTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
