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
    public partial class ManageMembers : Form
    {

        int editID = 0;
        public ManageMembers()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void ViewAll(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Member", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;


            // Ensure the parameter type matches the StaffID column in the database
            // If StaffID is an integer, convert ID: cmd.Parameters[0].SqlDbType = SqlDbType.Int; cmd.Parameters[0].Value = int.Parse(ID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tb_MemberInfo = new DataTable();

            tb_MemberInfo.Columns.Add("MemberID");
            tb_MemberInfo.Columns.Add("FirstName");
            tb_MemberInfo.Columns.Add("LastName");
            tb_MemberInfo.Columns.Add("Gender");
            tb_MemberInfo.Columns.Add("BirthDate");
            tb_MemberInfo.Columns.Add("JoinDate");
            tb_MemberInfo.Columns.Add("Phone");
            tb_MemberInfo.Columns.Add("Email");
            tb_MemberInfo.Columns.Add("SSN");
            tb_MemberInfo.Columns.Add("Weight");
            tb_MemberInfo.Columns.Add("Height");
            tb_MemberInfo.Columns.Add("LockerNumber");
            tb_MemberInfo.Columns.Add("CoachID");
            tb_MemberInfo.Columns.Add("Password");


            DataRow row;
            while (reader.Read())
            {
                row = tb_MemberInfo.NewRow();
                row["MemberID"] = reader["MemberID"];
                row["FirstName"] = reader["FirstName"];
                row["LastName"] = reader["LastName"];
                row["Gender"] = reader["Gender"];
                row["BirthDate"] = reader["BirthDate"];
                row["JoinDate"] = reader["JoinDate"];
                row["Phone"] = reader["Phone"];
                row["Email"] = reader["Email"];
                row["SSN"] = reader["SSN"];
                row["Weight"] = reader["Weight"];
                row["Height"] = reader["Height"];
                row["LockerNumber"] = reader["LockerNumber"];
                row["CoachID"] = reader["CoachID"];
                row["Password"] = reader["Password"];

                tb_MemberInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_ViewAllMem.DataSource = tb_MemberInfo;
        }

        private void AddNewMember(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con.Open();

                    // Insert into Account table first (due to foreign key constraint)
                    string cmdString2 = @"INSERT INTO Account (Password, Email, Position)
                                 VALUES (@password, @Email, @position)";
                    using (SqlCommand cmd2 = new SqlCommand(cmdString2, con))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@password", PasswordTxt.Text);
                        cmd2.Parameters.AddWithValue("@Email", EmailTxt.Text);
                        cmd2.Parameters.AddWithValue("@position", "Member");
                        cmd2.ExecuteNonQuery();
                    }

                    // Use sp_AddNewMember to insert into Member table
                    using (SqlCommand cmd = new SqlCommand("sp_AddNewMember", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for sp_AddNewMember
                        cmd.Parameters.AddWithValue("@FirstName", FirstNameTxt.Text);
                        cmd.Parameters.AddWithValue("@LastName", LastNameTxt.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
                        cmd.Parameters.AddWithValue("@SSN", SSNTxt.Text);
                        cmd.Parameters.AddWithValue("@Gender", Gender.Text);
                        cmd.Parameters.AddWithValue("@Phone", PhoneTxt.Text);
                        cmd.Parameters.AddWithValue("@BirthDate", birthDateInput.Value);
                        cmd.Parameters.AddWithValue("@Weight", Convert.ToDecimal(WeightTxt.Text));
                        cmd.Parameters.AddWithValue("@Height", Convert.ToDecimal(HeightTxt.Text));
                        cmd.Parameters.AddWithValue("@LockerNumber", DBNull.Value); // Since LockerNumber is NULL in your original query
                        cmd.Parameters.AddWithValue("@CoachID", DBNull.Value); // Since CoachID is NULL in your original query
                        cmd.Parameters.AddWithValue("@Password", PasswordTxt.Text);

                        // Output parameter for MemberID
                        SqlParameter memberIDParam = new SqlParameter("@MemberID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(memberIDParam);

                        cmd.ExecuteNonQuery();

                        int newMemberID = (int)memberIDParam.Value;
                        MessageBox.Show($"Member added successfully. Member ID: {newMemberID}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        private void SearchByMail(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
                {
                    con.Open();

                    string mail = memNameSearch.Text.Trim(); // Trim whitespace from input
                    if (string.IsNullOrWhiteSpace(mail))
                    {
                        MessageBox.Show("Please enter an email.");
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT * FROM Member 
                  WHERE Email LIKE '%' + @Email + '%'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Email", mail); // Fixed parameter name

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable tb_MemberInfo = new DataTable();
                            tb_MemberInfo.Columns.Add("MemberID", typeof(int));
                            tb_MemberInfo.Columns.Add("FirstName", typeof(string));
                            tb_MemberInfo.Columns.Add("LastName", typeof(string));
                            tb_MemberInfo.Columns.Add("Gender", typeof(string));
                            tb_MemberInfo.Columns.Add("BirthDate", typeof(DateTime));
                            tb_MemberInfo.Columns.Add("JoinDate", typeof(DateTime));
                            tb_MemberInfo.Columns.Add("Phone", typeof(string));
                            tb_MemberInfo.Columns.Add("Email", typeof(string));
                            tb_MemberInfo.Columns.Add("SSN", typeof(string));
                            tb_MemberInfo.Columns.Add("Weight", typeof(decimal));
                            tb_MemberInfo.Columns.Add("Height", typeof(decimal));
                            tb_MemberInfo.Columns.Add("LockerNumber", typeof(int));
                            tb_MemberInfo.Columns.Add("CoachID", typeof(int));
                            tb_MemberInfo.Columns.Add("Password", typeof(string));

                            DataRow row;
                            while (reader.Read())
                            {
                                row = tb_MemberInfo.NewRow();
                                row["MemberID"] = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0;
                                row["FirstName"] = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : string.Empty;
                                row["LastName"] = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : string.Empty;
                                row["Gender"] = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                                row["BirthDate"] = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]) : DateTime.MinValue;
                                row["JoinDate"] = reader["JoinDate"] != DBNull.Value ? Convert.ToDateTime(reader["JoinDate"]) : DateTime.MinValue;
                                row["Phone"] = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty;
                                row["Email"] = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                                row["SSN"] = reader["SSN"] != DBNull.Value ? reader["SSN"].ToString() : string.Empty;
                                row["Weight"] = reader["Weight"] != DBNull.Value ? Convert.ToDecimal(reader["Weight"]) : 0m;
                                row["Height"] = reader["Height"] != DBNull.Value ? Convert.ToDecimal(reader["Height"]) : 0m;
                                row["LockerNumber"] = reader["LockerNumber"] != DBNull.Value ? Convert.ToInt32(reader["LockerNumber"]) : 0;
                                row["CoachID"] = reader["CoachID"] != DBNull.Value ? Convert.ToInt32(reader["CoachID"]) : 0;
                                row["Password"] = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;

                                tb_MemberInfo.Rows.Add(row);
                                editID = (int)row["MemberID"];
                            }

                            DGV_memSearch.DataSource = tb_MemberInfo;

                            if (tb_MemberInfo.Rows.Count == 0)
                            {
                                MessageBox.Show("No members found with the specified email.");
                                editID = 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching by email: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }
        private void ChangeCoach(object sender, EventArgs e) { }


        private void ChangeAttribute(object sender, EventArgs e)
        {
            try
            {
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

                if (string.IsNullOrWhiteSpace(UpdateTxt.Text))
                {
                    MessageBox.Show($"Please enter a value for {choice}.");
                    return;
                }

                // Determine the column to update and validate the input based on the column type
                string columnToUpdate;
                object updateValue;

                switch (choice)
                {
                    case "first name":
                        columnToUpdate = "FirstName";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "last name":
                        columnToUpdate = "LastName";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "weight":
                        columnToUpdate = "Weight";
                        if (!decimal.TryParse(UpdateTxt.Text, out decimal weight) || weight < 0)
                        {
                            MessageBox.Show("Weight must be a valid positive number.");
                            return;
                        }
                        updateValue = weight;
                        break;
                    case "height":
                        columnToUpdate = "Height";
                        if (!decimal.TryParse(UpdateTxt.Text, out decimal height) || height < 0)
                        {
                            MessageBox.Show("Height must be a valid positive number.");
                            return;
                        }
                        updateValue = height;
                        break;
                    case "locker number":
                        columnToUpdate = "LockerNumber";
                        if (!int.TryParse(UpdateTxt.Text, out int lockerNumber) || lockerNumber < 0)
                        {
                            MessageBox.Show("Locker Number must be a valid positive integer.");
                            return;
                        }
                        updateValue = lockerNumber;
                        break;
                    case "coach id":
                        columnToUpdate = "CoachID";
                        if (!int.TryParse(UpdateTxt.Text, out int coachID) || coachID < 0)
                        {
                            MessageBox.Show("Coach ID must be a valid positive integer.");
                            return;
                        }
                        updateValue = coachID;
                        break;
                    default:
                        MessageBox.Show("Please enter a valid attribute to update (e.g., 'first name', 'last name', 'weight', 'height', 'locker number', 'coach id').");
                        return;
                }

                // Construct the query with the chosen column
                string fullChangeQuery = $"UPDATE Member SET {columnToUpdate} = @update WHERE MemberID = @ID";

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
        private void DeleteMember(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Validate that a member has been selected
                if (editID == 0) // Using class-level editID
                {
                    MessageBox.Show("Please search for a member first to select a valid MemberID.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the member with ID {editID}? This action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Step 1: Get the member's email to delete from Account table later
                string getEmailQuery = "SELECT Email FROM Member WHERE MemberID = @ID;";
                string memberEmail = "";
                using (SqlCommand cmdGetEmail = new SqlCommand(getEmailQuery, con))
                {
                    cmdGetEmail.Parameters.AddWithValue("@ID", editID);
                    var emailObj = cmdGetEmail.ExecuteScalar();
                    if (emailObj != null)
                    {
                        memberEmail = emailObj.ToString();
                    }
                }

                // Step 2: Delete dependent records first to avoid foreign key violations
                string[] deleteDependentQueries = new string[]
                {
            "DELETE FROM GuestVisitLog WHERE MemberID = @ID;",
            "DELETE FROM SlotTimings WHERE MemberID = @ID;",
            "DELETE FROM Membership_Member WHERE MemberID = @ID;",
            "DELETE FROM MembershipType_Member WHERE MemberID = @ID;",
            "DELETE FROM Membership WHERE MemberID = @ID;"
                };

                foreach (var query in deleteDependentQueries)
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", editID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Step 3: Delete the member from the Member table
                int rowsAffected = 0;
                using (SqlCommand deleteCmd = new SqlCommand(@"DELETE FROM Member WHERE MemberID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", editID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }

                // Step 4: Delete from Account table where Email matches and Position is "Member"
                if (!string.IsNullOrEmpty(memberEmail) && rowsAffected > 0)
                {
                    using (SqlCommand cmdAccount = new SqlCommand(
                        "DELETE FROM Account WHERE Email = @Email AND Position = 'Member';", con))
                    {
                        cmdAccount.Parameters.AddWithValue("@Email", memberEmail);
                        cmdAccount.ExecuteNonQuery();
                    }
                }

                // Step 5: Provide feedback to the user
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Member deleted successfully.");
                    editID = 0; // Reset class-level editID
                    DGV_memSearch.DataSource = null; // Clear the DataGridView
                }
                else
                {
                    MessageBox.Show("No member found with the specified MemberID.");
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

        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }

        private void ManageMembers_Load(object sender, EventArgs e)
        {

        }
    }
}
