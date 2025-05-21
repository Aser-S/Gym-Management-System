using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseProject
{
    public partial class ManageStaff : Form
    {
        int staffID = 0;

        public ManageStaff()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;


            // Second database operation: Retrieve MembershipType data
            using (SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con2.Open();

                    using (SqlCommand cmd2 = new SqlCommand(@"SELECT RepairRecordID, EquipmentID, RepairDate, Description, NumberOfRepairs FROM RepairRecord", con2)) // Adjusted column names
                    {
                        cmd2.CommandType = CommandType.Text;

                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            DataTable tb_MemberInfo = new DataTable();
                            tb_MemberInfo.Columns.Add("Repair Record ID");
                            tb_MemberInfo.Columns.Add("Equipment ID");
                            tb_MemberInfo.Columns.Add("Repair Date");
                            tb_MemberInfo.Columns.Add("Description");
                            tb_MemberInfo.Columns.Add("Number Of Repairs");

                            DataRow row;
                            while (reader2.Read())
                            {
                                row = tb_MemberInfo.NewRow();
                                row["Repair Record ID"] = reader2["RepairRecordID"];
                                row["Equipment ID"] = reader2["EquipmentID"];
                                row["Repair Date"] = reader2["RepairDate"];
                                row["Description"] = reader2["Description"];
                                row["Number Of Repairs"] = reader2["NumberOfRepairs"];
                                tb_MemberInfo.Rows.Add(row);
                            }

                            DGV_RepairRecord.DataSource = tb_MemberInfo;

                            if (tb_MemberInfo.Rows.Count == 0)
                            {
                                MessageBox.Show("No Repairs found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving Repairs: {ex.Message}");
                }
            }
        }

        private void AddNewRepair(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con.Open();

                    // Parse EquipmentID and RepairDate
                    if (!int.TryParse(RepairedEquipmentTxt.Text, out int equipmentId))
                    {
                        MessageBox.Show("Invalid Equipment ID.");
                        return;
                    }
                    if (!DateTime.TryParse(RepairDateTxt.Text, out DateTime repairDate))
                    {
                        MessageBox.Show("Invalid Repair Date.");
                        return;
                    }

                    // 1) Get next RepairRecordID
                    const string nextIdSql = @"
                SELECT COALESCE(MAX(RepairRecordID), 0) + 1 
                  FROM RepairRecord";
                    int nextId;
                    using (SqlCommand cmdId = new SqlCommand(nextIdSql, con))
                    {
                        nextId = (int)cmdId.ExecuteScalar();
                    }

                    // 2) Get current max NumberOfRepairs for this equipment
                    const string maxRepairsSql = @"
                SELECT COALESCE(MAX(NumberOfRepairs), 0) 
                  FROM RepairRecord 
                 WHERE EquipmentID = @EquipmentID";
                    int currentMax;
                    using (SqlCommand cmdMax = new SqlCommand(maxRepairsSql, con))
                    {
                        cmdMax.Parameters.AddWithValue("@EquipmentID", equipmentId);
                        currentMax = (int)cmdMax.ExecuteScalar();
                    }
                    int newRepairsCount = currentMax + 1;

                    // 3) Insert new repair record
                    const string insertSql = @"
                INSERT INTO RepairRecord 
                    (RepairRecordID, EquipmentID, StaffID, RepairDate, NumberOfRepairs, Description)
                VALUES 
                    (@RepairRecordID, @EquipmentID, @StaffID, @RepairDate, @NumberOfRepairs, @Description)";
                    using (SqlCommand cmdIns = new SqlCommand(insertSql, con))
                    {
                        cmdIns.Parameters.AddWithValue("@RepairRecordID", nextId);
                        cmdIns.Parameters.AddWithValue("@EquipmentID", equipmentId);
                        cmdIns.Parameters.AddWithValue("@RepairDate", repairDate);
                        cmdIns.Parameters.AddWithValue("@StaffID", 4);
                        cmdIns.Parameters.AddWithValue("@NumberOfRepairs", newRepairsCount);
                        cmdIns.Parameters.AddWithValue("@Description", DescTxt.Text);
                        cmdIns.ExecuteNonQuery();
                    }

                    MessageBox.Show("Repair added successfully. New repair count: " + newRepairsCount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ViewAllStaff(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Staff", con);
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                DataTable tb_StaffInfo = new DataTable();
                tb_StaffInfo.Columns.Add("StaffID", typeof(int));
                tb_StaffInfo.Columns.Add("FirstName");
                tb_StaffInfo.Columns.Add("LastName");
                tb_StaffInfo.Columns.Add("Role");
                tb_StaffInfo.Columns.Add("Salary");
                tb_StaffInfo.Columns.Add("WorkingHours");
                tb_StaffInfo.Columns.Add("Phone");
                tb_StaffInfo.Columns.Add("Email");
                tb_StaffInfo.Columns.Add("SSN");
                tb_StaffInfo.Columns.Add("StaffSupervisorID");
                tb_StaffInfo.Columns.Add("Password");
                DataRow row;
                while (reader.Read())
                {
                    row = tb_StaffInfo.NewRow();
                    row["StaffID"] = Convert.ToInt32(reader["StaffID"]);
                    row["FirstName"] = reader["FirstName"];
                    row["LastName"] = reader["LastName"];
                    row["Role"] = reader["Role"];
                    row["Salary"] = reader["Salary"];
                    row["WorkingHours"] = reader["WorkingHours"];
                    row["Phone"] = reader["Phone"];
                    row["Email"] = reader["Email"];
                    row["SSN"] = reader["SSN"];
                    row["StaffSupervisorID"] = reader["StaffSupervisorID"] != DBNull.Value ? (object)Convert.ToInt32(reader["StaffSupervisorID"]) : DBNull.Value;
                    row["Password"] = reader["Password"];
                    tb_StaffInfo.Rows.Add(row);
                }
                reader.Close();
                DGV_AllStaff.DataSource = tb_StaffInfo;
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

        private void AddNewStaff(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Insert into Account table first (due to foreign key constraint)
                string cmdStringAccount = @"INSERT INTO Account (Password, Email, Position)
                                            VALUES (@password, @Email, @position)";
                using (SqlCommand cmdAccount = new SqlCommand(cmdStringAccount, con))
                {
                    cmdAccount.CommandType = CommandType.Text;
                    cmdAccount.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    cmdAccount.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    cmdAccount.Parameters.AddWithValue("@position", "Staff");
                    cmdAccount.ExecuteNonQuery();
                }

                // Get the next StaffID
                string maxIdCmd = "SELECT COALESCE(MAX(StaffID), 0) + 1 FROM Staff";
                using (SqlCommand maxCmd = new SqlCommand(maxIdCmd, con))
                {
                    int nextId = (int)maxCmd.ExecuteScalar();

                    // Validate SupervisorID (can be null)
                    int? supervisorID = null;
                    //if (!string.IsNullOrWhiteSpace(SupervisorIDTxt.Text) && int.TryParse(SupervisorIDTxt.Text, out int parsedSupervisorID))
                    //{
                    //    supervisorID = parsedSupervisorID;
                    //}

                    // Insert into Staff table
                    string cmdString = @"INSERT INTO Staff (StaffID, FirstName, LastName, Role, Salary, WorkingHours, Phone, Email, SSN, StaffSupervisorID, Password)
                                         VALUES (@StaffID, @FirstName, @LastName, @Role, @Salary, @WorkingHours, @Phone, @Email, @SSN, @StaffSupervisorID, @Password)";
                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@StaffID", nextId);
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
                        cmd.Parameters.AddWithValue("@Role", RoleTxt.Text);
                        cmd.Parameters.AddWithValue("@Salary", decimal.Parse(NewSalaryTxt.Text));
                        cmd.Parameters.AddWithValue("@WorkingHours", int.Parse(WorkingHoursTxt.Text));
                        cmd.Parameters.AddWithValue("@Phone", PhoneTxt.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
                        cmd.Parameters.AddWithValue("@SSN", SSNTxt.Text);
                        cmd.Parameters.AddWithValue("@StaffSupervisorID", (object)supervisorID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Staff added successfully");
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
        private void ChangeRole(object sender, EventArgs e) { }
        private void SearchByStaffName(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();
                string searchName = staffNameSearch.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchName))
                {
                    MessageBox.Show("Please enter a name to search.");
                    return;
                }
                SqlCommand cmd = new SqlCommand(
                    @"SELECT * FROM Staff 
                      WHERE CONCAT(FirstName, ' ', LastName) LIKE '%' + @SearchName + '%'",
                    con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SearchName", searchName);
                reader = cmd.ExecuteReader();
                DataTable tb_StaffInfo = new DataTable();
                tb_StaffInfo.Columns.Add("StaffID", typeof(int));
                tb_StaffInfo.Columns.Add("FirstName");
                tb_StaffInfo.Columns.Add("LastName");
                tb_StaffInfo.Columns.Add("Role");
                tb_StaffInfo.Columns.Add("Salary");
                tb_StaffInfo.Columns.Add("WorkingHours");
                tb_StaffInfo.Columns.Add("Phone");
                tb_StaffInfo.Columns.Add("Email");
                tb_StaffInfo.Columns.Add("SSN");
                tb_StaffInfo.Columns.Add("StaffSupervisorID");
                tb_StaffInfo.Columns.Add("Password");
                DataRow row;
                while (reader.Read())
                {
                    row = tb_StaffInfo.NewRow();
                    row["StaffID"] = Convert.ToInt32(reader["StaffID"]);
                    row["FirstName"] = reader["FirstName"];
                    row["LastName"] = reader["LastName"];
                    row["Role"] = reader["Role"];
                    row["Salary"] = reader["Salary"];
                    row["WorkingHours"] = reader["WorkingHours"];
                    row["Phone"] = reader["Phone"];
                    row["Email"] = reader["Email"];
                    row["SSN"] = reader["SSN"];
                    row["StaffSupervisorID"] = reader["StaffSupervisorID"] != DBNull.Value ? (object)Convert.ToInt32(reader["StaffSupervisorID"]) : DBNull.Value;
                    row["Password"] = reader["Password"];
                    tb_StaffInfo.Rows.Add(row);
                    staffID = (int)row["StaffID"];
                }
                reader.Close();
                DGV_staffSearch.DataSource = tb_StaffInfo;
                if (tb_StaffInfo.Rows.Count == 0)
                {
                    MessageBox.Show("No staff found with the specified name.");
                    staffID = 0;
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

        private void DeleteStaff(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                if (staffID == 0)
                {
                    MessageBox.Show("Please search for a staff member first to select a valid StaffID.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the staff member with ID {staffID}? This action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Step 1: Get the staff's email for Account deletion
                string getEmailQuery = "SELECT Email FROM Staff WHERE StaffID = @ID;";
                string staffEmail = "";
                using (SqlCommand cmdGetEmail = new SqlCommand(getEmailQuery, con))
                {
                    cmdGetEmail.Parameters.AddWithValue("@ID", staffID);
                    var emailObj = cmdGetEmail.ExecuteScalar();
                    if (emailObj != null)
                    {
                        staffEmail = emailObj.ToString();
                    }
                }

                // Step 2: Handle staff supervised by this staff member (set StaffSupervisorID to NULL)
                using (SqlCommand cmdUpdateSupervised = new SqlCommand(
                    "UPDATE Staff SET StaffSupervisorID = NULL WHERE StaffSupervisorID = @ID;", con))
                {
                    cmdUpdateSupervised.Parameters.AddWithValue("@ID", staffID);
                    cmdUpdateSupervised.ExecuteNonQuery();
                }

                // Step 3: Delete dependent records from related tables
                string[] deleteDependentQueries = new string[]
                {
                    "DELETE FROM EquipmentOrder WHERE StaffID = @ID;",
                    "DELETE FROM RepairRecord WHERE StaffID = @ID;" // Assuming RepairRecord has StaffID
                    // Add other tables if StaffID is a foreign key elsewhere
                };
                foreach (var query in deleteDependentQueries)
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", staffID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Step 4: Delete the staff from the Staff table
                int rowsAffected = 0;
                using (SqlCommand deleteCmd = new SqlCommand(@"DELETE FROM Staff WHERE StaffID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", staffID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }

                // Step 5: Delete from Account table
                if (!string.IsNullOrEmpty(staffEmail) && rowsAffected > 0)
                {
                    using (SqlCommand cmdAccount = new SqlCommand(
                        "DELETE FROM Account WHERE Email = @Email AND Position = 'Staff';", con))
                    {
                        cmdAccount.Parameters.AddWithValue("@Email", staffEmail);
                        cmdAccount.ExecuteNonQuery();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Staff deleted successfully.");
                    staffID = 0;
                    DGV_staffSearch.DataSource = null;
                }
                else
                {
                    MessageBox.Show("No staff found with the specified StaffID.");
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


        private void ChangeAttribute(object sender, EventArgs e)
        {
            int editID = 0;
            try
            {
                if (!int.TryParse(StaffIDTxt.Text, out editID))
                {
                    MessageBox.Show("Please enter a valid integer for the ID.");
                    return;
                }
                int.TryParse(StaffIDTxt.Text, out editID);
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

                if (string.IsNullOrWhiteSpace(UpdateTxt.Text))
                {
                    MessageBox.Show($"Please enter a value for {choice}.");
                    return;
                }

                // Determine the column to update and validate the input based on the column type
                string columnToUpdate;
                object updateValue;
                /*  FirstName
   LastName
  Role
  Salary
  WorkingHours
  Phone
  Email
  SSN
  Supervisor ID
  Password*/
                switch (choice)
                {
                    case "firstname":
                        columnToUpdate = "FirstName";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "lastname":
                        columnToUpdate = "LastName";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "role":
                        columnToUpdate = "Role";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "workinghours":
                        columnToUpdate = "WorkingHours";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "phone":
                        columnToUpdate = "Phone";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "email":
                        columnToUpdate = "Email";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "ssn":
                        columnToUpdate = "SSN";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "supervisor id":
                        columnToUpdate = "StaffSupervisorID";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "password":
                        columnToUpdate = "Password";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;

                    default:
                        MessageBox.Show("Please enter a valid attribute to update.");
                        return;
                }

                // Construct the query with the chosen column
                string fullChangeQuery = $"UPDATE Staff SET {columnToUpdate} = @update WHERE StaffID = @ID";

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
                            MessageBox.Show("No staff found with the specified StaffID, or the input is invalid.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attribute: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }



        private void Logout(object sender, EventArgs e)
        {
            Login form2 = new Login();
            form2.Show();
            this.Hide();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit(); // Fully qualified name
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void ManageStaff_Load(object sender, EventArgs e)
        {

        }
        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void RepairedEquipmentTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}