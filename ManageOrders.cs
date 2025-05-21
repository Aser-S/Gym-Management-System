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
    public partial class ManageOrders : Form
    {
        public ManageOrders()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

        }




        private void ViewAll(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM EquipmentOrder", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;

            
            // Ensure the parameter type matches the StaffID column in the database
            // If StaffID is an integer, convert ID: cmd.Parameters[0].SqlDbType = SqlDbType.Int; cmd.Parameters[0].Value = int.Parse(ID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tb_OrderInfo = new DataTable();

            tb_OrderInfo.Columns.Add("OrderID");
            tb_OrderInfo.Columns.Add("OrderDate");
            tb_OrderInfo.Columns.Add("TotalCost");
            tb_OrderInfo.Columns.Add("Amount");
            tb_OrderInfo.Columns.Add("StaffID");
            tb_OrderInfo.Columns.Add("SupplierID");
            tb_OrderInfo.Columns.Add("EquipmentID");


            DataRow row;
            while (reader.Read())
            {
                row = tb_OrderInfo.NewRow();
                row["OrderID"] = reader["OrderID"];
                row["OrderDate"] = reader["OrderDate"];
                row["TotalCost"] = reader["TotalCost"];
                row["Amount"] = reader["Amount"];
                row["StaffID"] = reader["StaffID"];
                row["SupplierID"] = reader["SupplierID"];
                row["EquipmentID"] = reader["EquipmentID"];

                tb_OrderInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_ViewAll.DataSource = tb_OrderInfo;
        }

        private void SortEquipmentOrders(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();
                string sortBy = SortByTxt.Text.Trim().ToLower();
                string orderByClause = "ORDER BY ";
                switch (sortBy)
                {
                    case "date":
                        orderByClause += "OrderDate";
                        break;
                    case "cost":
                        orderByClause += "TotalCost";
                        break;
                    case "equipment":
                        orderByClause += "EquipmentID";
                        break;
                    case "supplier":
                        orderByClause += "SupplierID";
                        break;
                    default:
                        MessageBox.Show("Please enter a valid sort option: 'Date', 'Cost', 'Equipment', or 'Supplier'.");
                        return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"SELECT * FROM EquipmentOrder " + orderByClause,
                    con);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTable tb_EquipmentOrderInfo = new DataTable();
                tb_EquipmentOrderInfo.Columns.Add("OrderDate");
                tb_EquipmentOrderInfo.Columns.Add("TotalCost", typeof(decimal));
                tb_EquipmentOrderInfo.Columns.Add("EquipmentID", typeof(int));
                tb_EquipmentOrderInfo.Columns.Add("SupplierID", typeof(int));
                tb_EquipmentOrderInfo.Columns.Add("StaffID", typeof(int));
                tb_EquipmentOrderInfo.Columns.Add("Amount");
                DataRow row;
                while (reader.Read())
                {
                    row = tb_EquipmentOrderInfo.NewRow();
                    row["OrderDate"] = reader["OrderDate"] != DBNull.Value ? reader["OrderDate"] : DBNull.Value;
                    row["TotalCost"] = reader["TotalCost"] != DBNull.Value ? Convert.ToDecimal(reader["TotalCost"]) : 0m; // Default to 0 for NULL
                    row["EquipmentID"] = reader["EquipmentID"] != DBNull.Value ? Convert.ToInt32(reader["EquipmentID"]) : 0; // Default to 0 for NULL
                    row["SupplierID"] = reader["SupplierID"] != DBNull.Value ? Convert.ToInt32(reader["SupplierID"]) : 0; // Default to 0 for NULL
                    row["StaffID"] = reader["StaffID"] != DBNull.Value ? Convert.ToInt32(reader["StaffID"]) : 0; // Default to 0 for NULL
                    row["Amount"] = reader["Amount"] != DBNull.Value ? reader["Amount"] : DBNull.Value;
                    tb_EquipmentOrderInfo.Rows.Add(row);
                }
                reader.Close();
                DGV_Sort.DataSource = tb_EquipmentOrderInfo;
                if (tb_EquipmentOrderInfo.Rows.Count == 0)
                {
                    MessageBox.Show("No equipment orders found.");
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
        private void MakeOrder(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Validate inputs
                if (string.IsNullOrWhiteSpace(AmountTxt.Text) || !int.TryParse(AmountTxt.Text, out int amount))
                {
                    MessageBox.Show("Please enter a valid amount (numeric value).");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ReceiverIDTxt.Text) || !int.TryParse(ReceiverIDTxt.Text, out int staffID))
                {
                    MessageBox.Show("Please enter a valid StaffID (numeric value).");
                    return;
                }
                if (string.IsNullOrWhiteSpace(SupplierName.Text))
                {
                    MessageBox.Show("Please enter a supplier name.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(NameTxt.Text))
                {
                    MessageBox.Show("Please enter an equipment name.");
                    return;
                }

                // Validate StaffID exists in Staff table
                using (SqlCommand checkStaffCmd = new SqlCommand("SELECT COUNT(*) FROM Staff WHERE StaffID = @StaffID", con))
                {
                    checkStaffCmd.Parameters.AddWithValue("@StaffID", staffID);
                    int count = (int)checkStaffCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show($"StaffID {staffID} does not exist in the Staff table.");
                        return;
                    }
                }

                // Get the next OrderID
                string maxIdCmd = "SELECT COALESCE(MAX(OrderID), 0) + 1 FROM EquipmentOrder";
                using (SqlCommand maxCmd = new SqlCommand(maxIdCmd, con))
                {
                    int nextId = (int)maxCmd.ExecuteScalar();

                    // Insert the new order into EquipmentOrder table
                    string cmdString = @"INSERT INTO EquipmentOrder (OrderID, OrderDate, TotalCost, Amount, StaffID, SupplierID, EquipmentID)
                             VALUES (@OrderID, GETDATE(), @TotalCost, @Amount, @StaffID, 
                                     (SELECT SupplierID FROM Supplier WHERE Name = @SupplierName), 
                                     (SELECT EquipmentID FROM Equipment WHERE EquipmentName = @EquipmentName))";
                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Calculate TotalCost dynamically
                        decimal totalCost = 0;
                        using (SqlCommand costCmd = new SqlCommand("SELECT Cost FROM Equipment WHERE EquipmentName = @EquipmentName", con))
                        {
                            costCmd.Parameters.AddWithValue("@EquipmentName", NameTxt.Text);
                            var costObj = costCmd.ExecuteScalar();
                            if (costObj != null && costObj != DBNull.Value)
                            {
                                totalCost = Convert.ToDecimal(costObj) * amount;
                            }
                            else
                            {
                                MessageBox.Show("Equipment not found or cost is unavailable.");
                                return;
                            }
                        }

                        // Add parameters
                        cmd.Parameters.AddWithValue("@OrderID", nextId);
                        cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@StaffID", staffID);
                        cmd.Parameters.AddWithValue("@SupplierName", SupplierName.Text);
                        cmd.Parameters.AddWithValue("@EquipmentName", NameTxt.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Order Done!");
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



















        int editID = 0;
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
                    case "totalcost":
                        columnToUpdate = "TotalCost";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "amount":
                        columnToUpdate = "Amount";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "staffid":
                        columnToUpdate = "StaffID";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "supplierid":
                        columnToUpdate = "SupplierID";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "equipmentid":
                        columnToUpdate = "EquipmentID";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;

                    default:
                        MessageBox.Show("Please enter a valid attribute to update.");
                        return;
                }

                // Construct the query with the chosen column
                string fullChangeQuery = $"UPDATE EquipmentOrder SET {columnToUpdate} = @update WHERE OrderID = @ID";

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
                            MessageBox.Show("No order found with the specified OrderID, or the input is invalid.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attribute: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }


        private void DeleteOrder(object sender, EventArgs e)
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
                    $"Are you sure you want to delete the order with ID {editID}? This action cannot be undone.",
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
                using (SqlCommand deleteCmd = new SqlCommand(@"DELETE FROM EquipmentOrder WHERE OrderID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", editID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }


                // Step 5: Provide feedback to the user
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Order deleted successfully.");
                    editID = 0; // Reset class-level editID
                }
                else
                {
                    MessageBox.Show("No Order found with the specified MemberID.");
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















        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ManageOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
