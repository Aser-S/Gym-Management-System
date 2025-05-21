// HANDLE EXCEPTION IF COACH DOESNT EXIST

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


// lblUserName.Text = $"Welcome, {userName}!";


namespace DatabaseProject
{
    public partial class MemberMenu : Form
    {
        int ID1 = 1;
        public MemberMenu(int ID)
        {
            this.ID1 = ID;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            string welcomeMessage = "Welcome, "; // Default message

            // First database operation: Retrieve FirstName
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(@"SELECT FirstName FROM Member WHERE MemberID = @ID", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", ID1);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "Guest";
                                welcomeMessage += firstName;
                            }
                            else
                            {
                                welcomeMessage += "Guest";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving member details: {ex.Message}");
                    welcomeMessage += "Guest";
                }
            }

            WelcomeMsg.Text = welcomeMessage; // Set the welcome message

            // Second database operation: Retrieve MembershipType data
            using (SqlConnection con2 = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con2.Open();

                    using (SqlCommand cmd2 = new SqlCommand(@"
                            SELECT 
                              mt.Name, 
                              mt.GuestVisitsNo, 
                              STRING_AGG(p.Privilege, ', ') AS Privileges
                            FROM MembershipType mt
                            LEFT JOIN Privileges p 
                              ON mt.TypeID = p.TypeID
                            WHERE mt.TypeID IN (1,2,3)
                            GROUP BY mt.Name, mt.GuestVisitsNo
                        ", con2))
                    {
                        cmd2.CommandType = CommandType.Text;
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            DataTable tb = new DataTable();
                            tb.Columns.Add("Name", typeof(string));
                            tb.Columns.Add("Visits Allowed", typeof(int));
                            tb.Columns.Add("Privileges", typeof(string));

                            while (reader2.Read())
                            {
                                var row = tb.NewRow();
                                row["Name"] = reader2["Name"].ToString();
                                row["Visits Allowed"] = Convert.ToInt32(reader2["GuestVisitsNo"]);
                                row["Privileges"] = reader2["Privileges"].ToString();
                                tb.Rows.Add(row);
                            }

                            DGV_Types.DataSource = tb;
                            if (tb.Rows.Count == 0)
                                MessageBox.Show("No membership types found.");
                        }
                    
                }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving membership types: {ex.Message}");
                }
            }
        }
        private void AddMembership(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (ID1 == 0)
                {
                    MessageBox.Show("Invalid Member ID. Please try logging in again.");
                    return;
                }

                string selectedType = TypeTxt.SelectedItem?.ToString()?.Trim();
                if (string.IsNullOrWhiteSpace(selectedType) || !new[] { "silver", "gold", "platinum" }.Contains(selectedType.ToLower()))
                {
                    MessageBox.Show("Please select a valid membership type (Silver, Gold, or Platinum).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate Duration
                if (string.IsNullOrWhiteSpace(DurationNum.Text) || !int.TryParse(DurationNum.Text.Trim(), out int duration) || duration < 1 || duration > 36)
                {
                    MessageBox.Show("Please enter a valid duration (between 1 and 36 months).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Get the TypeID based on the selected type
                int typeID = 0;
                switch (selectedType.ToLower())
                {
                    case "silver":
                        typeID = 1;            // Should be 1, 2, 3 but i will still make changes in the data yall made
                        break;
                    case "gold":
                        typeID = 2;
                        break;
                    case "platinum":
                        typeID = 3;
                        break;
                    default:
                        MessageBox.Show("Invalid membership type selected.");
                        return;
                }


                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
                {
                    con.Open();

                    // Check if the member already has an active membership
                    string checkQuery = @"SELECT m.MembershipID, m.ExpiryDate 
                                FROM Membership m 
                                JOIN Membership_Member mm ON m.MembershipID = mm.MembershipID 
                                WHERE mm.MemberID = @MemberID AND m.ExpiryDate >= @Today";
                    int existingMembershipID = 0;
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@MemberID", ID1);
                        checkCmd.Parameters.AddWithValue("@Today", DateTime.Now.Date);
                        using (SqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                existingMembershipID = Convert.ToInt32(reader["MembershipID"]);
                            }
                        }
                    }

                    if (existingMembershipID > 0)
                    {
                        // Inform user to consult receptionist for changes
                        DialogResult result = MessageBox.Show(
                            $"You already have an active membership (ID: {existingMembershipID}). To change your membership, please consult with a receptionist.",
                            "Active Membership",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        return; // Exit the method; no changes allowed through the system
                    }
                    else
                    {
                        // Create new membership using sp_CreateMembership
                        using (SqlCommand cmd = new SqlCommand("    `", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MemberID", ID1);
                            cmd.Parameters.AddWithValue("@TypeID", typeID);
                            cmd.Parameters.AddWithValue("@Duration", duration);

                            SqlParameter membershipIDParam = new SqlParameter("@MembershipID", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(membershipIDParam);

                            cmd.ExecuteNonQuery();
                            int newMembershipID = (int)membershipIDParam.Value;

                            MessageBox.Show($"Membership created successfully: {selectedType} for {duration} months. Membership ID: {newMembershipID}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating membership: {ex.Message}");
            }
        }













        private void BookCoach(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            try
            {
                // Validate CoachID input
                if (!int.TryParse(txtCoachID.Text, out int coachId) || coachId <= 0)
                {
                    MessageBox.Show("Coach ID must be a valid positive number.");
                    return;
                }

                // Validate Timing input
                string[] validTimings = { "Morning", "Afternoon", "Midday", "Evening", "Midnight" };
                string timingInput = txtTiming.Text.Trim();

                if (!validTimings.Contains(timingInput, StringComparer.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Invalid timing. Allowed values are: Morning, Afternoon, Midday, Evening, Midnight.");
                    return;
                }

                // Check if CoachID exists
                string checkCoachCmdString = "SELECT COUNT(*) FROM Coach WHERE CoachID = @CoachID";
                SqlCommand checkCoachCmd = new SqlCommand(checkCoachCmdString, con);
                checkCoachCmd.Parameters.AddWithValue("@CoachID", coachId);

                int coachExists = (int)checkCoachCmd.ExecuteScalar();
                if (coachExists == 0)
                {
                    MessageBox.Show("Error: CoachID does not exist in the Coach table.");
                    return;
                }

                // Update Member table
                string updateMemberCmd = "UPDATE Member SET CoachID = @CoachID WHERE MemberID = @ID";
                SqlCommand updateCmd = new SqlCommand(updateMemberCmd, con);
                updateCmd.Parameters.AddWithValue("@CoachID", coachId);
                updateCmd.Parameters.AddWithValue("@ID", ID1);
                updateCmd.ExecuteNonQuery();

                // Check if timing record exists
                string checkSlot = "SELECT COUNT(*) FROM SlotTimings WHERE MemberID = @ID";
                SqlCommand checkSlotCmd = new SqlCommand(checkSlot, con);
                checkSlotCmd.Parameters.AddWithValue("@ID", ID1);
                int slotExists = (int)checkSlotCmd.ExecuteScalar();

                if (slotExists > 0)
                {
                    // Update timing
                    string updateSlot = "UPDATE SlotTimings SET Timing = @Timing WHERE MemberID = @ID";
                    SqlCommand updateSlotCmd = new SqlCommand(updateSlot, con);
                    updateSlotCmd.Parameters.AddWithValue("@Timing", timingInput);
                    updateSlotCmd.Parameters.AddWithValue("@ID", ID1);
                    updateSlotCmd.ExecuteNonQuery();
                }
                else
                {
                    // Insert new timing
                    string insertSlot = "INSERT INTO SlotTimings (MemberID, Timing) VALUES (@ID, @Timing)";
                    SqlCommand insertSlotCmd = new SqlCommand(insertSlot, con);
                    insertSlotCmd.Parameters.AddWithValue("@ID", ID1);
                    insertSlotCmd.Parameters.AddWithValue("@Timing", timingInput);
                    insertSlotCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Updates completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void SetLockerNumber(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            if (!double.TryParse(txtLockerNumber.Text, out double locker) || locker <= 0)
            {
                MessageBox.Show("Height must be a valid positive number.");
                return;
            }


            string cmdString = @"UPDATE Member SET LockerNumber = @LockerNumber WHERE MemberID = @ID;";
            SqlCommand cmd = new SqlCommand(cmdString, con);
            cmd.CommandType = CommandType.Text;

            SqlParameter paramID = new SqlParameter("@ID", ID1);
            cmd.Parameters.Add(paramID);

            SqlParameter paramLocker = new SqlParameter("@LockerNumber", txtLockerNumber.Text);
            cmd.Parameters.Add(paramLocker);

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Updates completed successfully");
        }



        private void ShowInfo(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Member WHERE MemberID = @ID", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;

            SqlParameter paramID = new SqlParameter("@ID", ID1);
            cmd.Parameters.Add(paramID);

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
                tb_MemberInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_Member.DataSource = tb_MemberInfo;
        }
        private void ShowGuestLog(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM GuestVisitLog WHERE MemberID = @ID", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;

            SqlParameter paramID = new SqlParameter("@ID", ID1);
            cmd.Parameters.Add(paramID);

            // Ensure the parameter type matches the StaffID column in the database
            // If StaffID is an integer, convert ID: cmd.Parameters[0].SqlDbType = SqlDbType.Int; cmd.Parameters[0].Value = int.Parse(ID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tb_MemberInfo = new DataTable();

            tb_MemberInfo.Columns.Add("MemberID");
            tb_MemberInfo.Columns.Add("VisitDate");
            tb_MemberInfo.Columns.Add("GuestRelation");
            tb_MemberInfo.Columns.Add("GuestName");

            DataRow row;
            while (reader.Read())
            {
                row = tb_MemberInfo.NewRow();
                row["MemberID"] = reader["MemberID"];
                row["VisitDate"] = reader["VisitDate"];
                row["GuestRelation"] = reader["GuestRelation"];
                row["GuestName"] = reader["GuestName"];
                tb_MemberInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_Guests.DataSource = tb_MemberInfo;
        }
        private void AddGuest(object sender, EventArgs e)
        {
            if (ID1 <= 0)
            {
                MessageBox.Show("Invalid Member ID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string guestName = GuestNameTxt.Text.Trim();
            string guestRelation = GuestRelationTxt.Text.Trim();
            if (string.IsNullOrEmpty(guestName) || string.IsNullOrEmpty(guestRelation))
            {
                MessageBox.Show("Please enter both guest name and relation.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con.Open();

                    // 1) Fetch active membership info + allowed visits/month
                    const string infoSql = @"
SELECT m.MembershipID, m.Duration, mt.GuestVisitsNo
FROM Membership m
JOIN MembershipType mt ON m.TypeID = mt.TypeID
WHERE m.MemberID = @MemberID
  AND m.ExpiryDate >= @Today
ORDER BY m.ExpiryDate DESC";    // pick the most‑recent active

                    int duration = 0, visitsPerMonth = 0;
                    using (SqlCommand infoCmd = new SqlCommand(infoSql, con))
                    {
                        infoCmd.Parameters.AddWithValue("@MemberID", ID1);
                        infoCmd.Parameters.AddWithValue("@Today", DateTime.Now.Date);

                        using (var r = infoCmd.ExecuteReader())
                        {
                            if (!r.Read())
                            {
                                MessageBox.Show("No active membership found. Cannot log guest visit.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            duration = r.GetInt32(r.GetOrdinal("Duration"));
                            visitsPerMonth = r.GetInt32(r.GetOrdinal("GuestVisitsNo"));
                        }
                    }

                    int allowedVisits = duration * visitsPerMonth;

                    // 2) Count how many visits have already been used
                    const string countSql = @"
SELECT COUNT(*) 
FROM GuestVisitLog 
WHERE MemberID = @MemberID";
                    int usedVisits;
                    using (SqlCommand countCmd = new SqlCommand(countSql, con))
                    {
                        countCmd.Parameters.AddWithValue("@MemberID", ID1);
                        usedVisits = (int)countCmd.ExecuteScalar();
                    }

                    if (usedVisits >= allowedVisits)
                    {
                        MessageBox.Show(
                            $"You have used all your allowed guest visits ({usedVisits} of {allowedVisits}).",
                            "Limit Reached",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // 3) Log the new guest visit
                    using (SqlCommand cmd = new SqlCommand("sp_LogGuestVisit", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GuestName", guestName);
                        cmd.Parameters.AddWithValue("@GuestRelation", guestRelation);
                        cmd.Parameters.AddWithValue("@MemberID", ID1);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Guest visit logged ({usedVisits + 1} of {allowedVisits}).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void MemberMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
