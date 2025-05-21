using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseProject
{
    public partial class ManageCoach : Form
    {
        private int editID = 0;

        public ManageCoach()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ViewAll(object sender, EventArgs e)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                con.Open();

                using (var cmd = new SqlCommand(@"SELECT CoachID, FirstName, LastName, Email, SSN, Gender, Rating, CoachSupervisorID, Password FROM Coach", con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tb_CoachInfo = new DataTable();

                        tb_CoachInfo.Columns.Add("CoachID");
                        tb_CoachInfo.Columns.Add("FirstName");
                        tb_CoachInfo.Columns.Add("LastName");
                        tb_CoachInfo.Columns.Add("Email");
                        tb_CoachInfo.Columns.Add("SSN");
                        tb_CoachInfo.Columns.Add("Gender");
                        tb_CoachInfo.Columns.Add("Rating");
                        tb_CoachInfo.Columns.Add("CoachSupervisorID");
                        tb_CoachInfo.Columns.Add("Password");

                        while (reader.Read())
                        {
                            var row = tb_CoachInfo.NewRow();
                            row["CoachID"] = reader["CoachID"];
                            row["FirstName"] = reader["FirstName"]?.ToString() ?? string.Empty;
                            row["LastName"] = reader["LastName"]?.ToString() ?? string.Empty;
                            row["Email"] = reader["Email"]?.ToString() ?? string.Empty;
                            row["SSN"] = reader["SSN"]?.ToString() ?? string.Empty;
                            row["Gender"] = reader["Gender"]?.ToString() ?? string.Empty;
                            row["Rating"] = reader["Rating"]?.ToString() ?? string.Empty;
                            row["CoachSupervisorID"] = reader["CoachSupervisorID"]?.ToString() ?? string.Empty;
                            row["Password"] = reader["Password"]?.ToString() ?? string.Empty;
                            tb_CoachInfo.Rows.Add(row);
                        }

                        DGV_ViewAllCoach.DataSource = tb_CoachInfo;
                    }
                }
            }
        }

        private void ViewAllSlotTimings(object sender, EventArgs e)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                con.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT st.MemberID, st.Timing, m.CoachID 
                      FROM SlotTimings st 
                      JOIN Member m ON st.MemberID = m.MemberID", con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tb_SlotTimings = new DataTable();
                        tb_SlotTimings.Columns.Add("MemberID");
                        tb_SlotTimings.Columns.Add("Timing");
                        tb_SlotTimings.Columns.Add("CoachID");

                        while (reader.Read())
                        {
                            var row = tb_SlotTimings.NewRow();
                            row["MemberID"] = reader["MemberID"]?.ToString() ?? string.Empty;
                            row["Timing"] = reader["Timing"]?.ToString() ?? string.Empty;
                            row["CoachID"] = reader["CoachID"]?.ToString() ?? string.Empty;
                            tb_SlotTimings.Rows.Add(row);
                        }

                        DGV_AllSlotTimings.DataSource = tb_SlotTimings;
                    }
                }
            }
        }

        private void ViewAllCertifications(object sender, EventArgs e)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                con.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT CertificateID, CoachID 
                      FROM Certifications", con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tb_Certifications = new DataTable();
                        tb_Certifications.Columns.Add("CertificateID");
                        tb_Certifications.Columns.Add("CoachID");

                        while (reader.Read())
                        {
                            var row = tb_Certifications.NewRow();
                            row["CertificateID"] = reader["CertificateID"]?.ToString() ?? string.Empty;
                            row["CoachID"] = reader["CoachID"]?.ToString() ?? string.Empty;
                            tb_Certifications.Rows.Add(row);
                        }

                        DGV_AllCertifications.DataSource = tb_Certifications;
                    }
                }
            }
        }

        private void AddNewCoach(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Validate mandatory fields
                if (string.IsNullOrWhiteSpace(FirstNameTxt.Text) || string.IsNullOrWhiteSpace(LastNameTxt.Text) ||
                    string.IsNullOrWhiteSpace(EmailTxt.Text) || string.IsNullOrWhiteSpace(SSNTxt.Text) ||
                    string.IsNullOrWhiteSpace(GenderComboBox.SelectedItem?.ToString()) ||
                    string.IsNullOrWhiteSpace(RatingTxt.Text) || !int.TryParse(RatingTxt.Text, out int rating) ||
                    string.IsNullOrWhiteSpace(PasswordTxt.Text))
                {
                    MessageBox.Show("All fields are mandatory for adding a new coach (except SupervisorID, which is optional).");
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Check if email already exists in Account table
                using (var checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Email = @Email", con))
                {
                    checkEmailCmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    int emailCount = (int)checkEmailCmd.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("This email is already in use. Please use a different email.");
                        return;
                    }
                }

                // Validate SupervisorID if provided
                int? supervisorId = null;
                if (!string.IsNullOrWhiteSpace(SupervisorIDTxt.Text))
                {
                    if (!int.TryParse(SupervisorIDTxt.Text, out int supId))
                    {
                        MessageBox.Show("SupervisorID must be a valid integer.");
                        return;
                    }
                    using (var checkSupCmd = new SqlCommand("SELECT COUNT(*) FROM Coach WHERE CoachID = @SupervisorID", con))
                    {
                        checkSupCmd.Parameters.AddWithValue("@SupervisorID", supId);
                        int supCount = (int)checkSupCmd.ExecuteScalar();
                        if (supCount == 0)
                        {
                            MessageBox.Show("SupervisorID does not exist in the Coach table.");
                            return;
                        }
                        supervisorId = supId;
                    }
                }

                // Insert into Account table
                string cmdString2 = @"INSERT INTO Account (Password, Email, Position)
                                     VALUES (@password, @Email, @position)";
                using (var cmd2 = new SqlCommand(cmdString2, con))
                {
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue("@password", PasswordTxt.Text);
                    cmd2.Parameters.AddWithValue("@Email", EmailTxt.Text);
                    cmd2.Parameters.AddWithValue("@position", "Coach");
                    cmd2.ExecuteNonQuery();
                }

                // Get the next CoachID
                string maxIdCmd = "SELECT COALESCE(MAX(CoachID), 0) + 1 FROM Coach";
                using (var maxCmd = new SqlCommand(maxIdCmd, con))
                {
                    int nextId = (int)maxCmd.ExecuteScalar();

                    // Insert into Coach table
                    string cmdString = @"INSERT INTO Coach (CoachID, FirstName, LastName, Email, SSN, Gender, Rating, CoachSupervisorID, Password)
                                         VALUES (@CoachID, @Fname, @Lname, @Email, @SSN, @Gender, @Rating, @CoachSupervisorID, @password)";
                    using (var cmd = new SqlCommand(cmdString, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CoachID", nextId);
                        cmd.Parameters.AddWithValue("@Fname", FirstNameTxt.Text);
                        cmd.Parameters.AddWithValue("@Lname", LastNameTxt.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailTxt.Text);
                        cmd.Parameters.AddWithValue("@SSN", SSNTxt.Text);
                        cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Rating", rating);
                        cmd.Parameters.AddWithValue("@CoachSupervisorID", supervisorId.HasValue ? (object)supervisorId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@password", PasswordTxt.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Coach added successfully");
                    ViewAll(null, EventArgs.Empty); // Refresh DGV_ViewAllCoach
                    ClearInputFields();
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

        private void SearchByCoachID(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CoachIDTxt.Text) || !int.TryParse(CoachIDTxt.Text, out int coachId))
                {
                    MessageBox.Show("Please enter a valid CoachID.");
                    return;
                }

                using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(
                        @"SELECT CoachID, FirstName, LastName, Email, SSN, Gender, Rating, CoachSupervisorID, Password FROM Coach WHERE CoachID = @CoachID",
                        con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CoachID", coachId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var tb_CoachInfo = new DataTable();
                            tb_CoachInfo.Columns.Add("CoachID", typeof(int));
                            tb_CoachInfo.Columns.Add("FirstName");
                            tb_CoachInfo.Columns.Add("LastName");
                            tb_CoachInfo.Columns.Add("Email");
                            tb_CoachInfo.Columns.Add("SSN");
                            tb_CoachInfo.Columns.Add("Gender");
                            tb_CoachInfo.Columns.Add("Rating");
                            tb_CoachInfo.Columns.Add("CoachSupervisorID");
                            tb_CoachInfo.Columns.Add("Password");
                            while (reader.Read())
                            {
                                var row = tb_CoachInfo.NewRow();
                                row["CoachID"] = Convert.ToInt32(reader["CoachID"]);
                                row["FirstName"] = reader["FirstName"]?.ToString() ?? string.Empty;
                                row["LastName"] = reader["LastName"]?.ToString() ?? string.Empty;
                                row["Email"] = reader["Email"]?.ToString() ?? string.Empty;
                                row["SSN"] = reader["SSN"]?.ToString() ?? string.Empty;
                                row["Gender"] = reader["Gender"]?.ToString() ?? string.Empty;
                                row["Rating"] = reader["Rating"]?.ToString() ?? string.Empty;
                                row["CoachSupervisorID"] = reader["CoachSupervisorID"]?.ToString() ?? string.Empty;
                                row["Password"] = reader["Password"]?.ToString() ?? string.Empty;
                                tb_CoachInfo.Rows.Add(row);
                                editID = (int)row["CoachID"];
                            }
                            DGV_coachSearch.DataSource = tb_CoachInfo;
                            if (tb_CoachInfo.Rows.Count == 0)
                            {
                                MessageBox.Show("No coach found with the specified CoachID.");
                                editID = 0;
                                DGV_SlotTimings.DataSource = null;
                                DGV_Certifications.DataSource = null;
                            }
                            else
                            {
                                LoadSlotTimings(editID);
                                LoadCertifications(editID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadSlotTimings(int coachId)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                con.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT st.MemberID, st.Timing, m.CoachID 
                      FROM SlotTimings st 
                      JOIN Member m ON st.MemberID = m.MemberID 
                      WHERE m.CoachID = @CoachID", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CoachID", coachId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tb_SlotTimings = new DataTable();
                        tb_SlotTimings.Columns.Add("MemberID");
                        tb_SlotTimings.Columns.Add("Timing");
                        tb_SlotTimings.Columns.Add("CoachID");

                        while (reader.Read())
                        {
                            var row = tb_SlotTimings.NewRow();
                            row["MemberID"] = reader["MemberID"]?.ToString() ?? string.Empty;
                            row["Timing"] = reader["Timing"]?.ToString() ?? string.Empty;
                            row["CoachID"] = reader["CoachID"]?.ToString() ?? string.Empty;
                            tb_SlotTimings.Rows.Add(row);
                        }

                        DGV_SlotTimings.DataSource = tb_SlotTimings;
                    }
                }
            }
        }

        private void LoadCertifications(int coachId)
        {
            using (var con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                con.Open();

                using (var cmd = new SqlCommand(
                    @"SELECT CertificateID, CoachID 
                      FROM Certifications 
                      WHERE CoachID = @CoachID", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CoachID", coachId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var tb_Certifications = new DataTable();
                        tb_Certifications.Columns.Add("CertificateID");
                        tb_Certifications.Columns.Add("CoachID");

                        while (reader.Read())
                        {
                            var row = tb_Certifications.NewRow();
                            row["CertificateID"] = reader["CertificateID"]?.ToString() ?? string.Empty;
                            row["CoachID"] = reader["CoachID"]?.ToString() ?? string.Empty;
                            tb_Certifications.Rows.Add(row);
                        }

                        DGV_Certifications.DataSource = tb_Certifications;
                    }
                }
            }
        }

        private void UpdateCoach(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Step 1: Validate editID
                if (editID == 0)
                {
                    MessageBox.Show("Please search for a coach first to select a valid CoachID.");
                    return;
                }

                // Step 2: Validate mandatory fields
                if (string.IsNullOrWhiteSpace(FirstNameTxt.Text))
                {
                    MessageBox.Show("First Name is required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(LastNameTxt.Text))
                {
                    MessageBox.Show("Last Name is required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(EmailTxt.Text))
                {
                    MessageBox.Show("Email is required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(SSNTxt.Text))
                {
                    MessageBox.Show("SSN is required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(GenderComboBox.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Gender is required. Please select M, F, or O.");
                    return;
                }
                if (GenderComboBox.SelectedItem.ToString().Length != 1 || !"MFO".Contains(GenderComboBox.SelectedItem.ToString()))
                {
                    MessageBox.Show("Gender must be 'M', 'F', or 'O'.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(RatingTxt.Text) || !int.TryParse(RatingTxt.Text, out int rating))
                {
                    MessageBox.Show("Rating must be a valid integer.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(PasswordTxt.Text))
                {
                    MessageBox.Show("Password is required.");
                    return;
                }

                // Step 3: Open database connection
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Step 4: Verify the coach exists
                using (var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Coach WHERE CoachID = @ID", con))
                {
                    checkCmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = editID });
                    int coachCount = (int)checkCmd.ExecuteScalar();
                    if (coachCount == 0)
                    {
                        MessageBox.Show("No coach found with the specified CoachID.");
                        return;
                    }
                }

                // Step 5: Update the Coach table (excluding CoachSupervisorID to avoid foreign key issues)
                string cmdString = @"UPDATE Coach 
                                     SET FirstName = @Fname, LastName = @Lname, Email = @Email, 
                                         SSN = @SSN, Gender = @Gender, Rating = @Rating, 
                                         CoachSupervisorID = NULL, Password = @password 
                                     WHERE CoachID = @ID";
                using (var cmd = new SqlCommand(cmdString, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = editID });
                    cmd.Parameters.Add(new SqlParameter("@Fname", SqlDbType.VarChar, 50) { Value = FirstNameTxt.Text });
                    cmd.Parameters.Add(new SqlParameter("@Lname", SqlDbType.VarChar, 50) { Value = LastNameTxt.Text });
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = EmailTxt.Text });
                    cmd.Parameters.Add(new SqlParameter("@SSN", SqlDbType.VarChar, 20) { Value = SSNTxt.Text });
                    cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.Char, 1) { Value = GenderComboBox.SelectedItem.ToString() });
                    cmd.Parameters.Add(new SqlParameter("@Rating", SqlDbType.Int) { Value = rating });
                    cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 50) { Value = PasswordTxt.Text });

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Coach updated successfully");
                        ViewAll(null, EventArgs.Empty); // Refresh DGV_ViewAllCoach
                        SearchByCoachID(null, EventArgs.Empty); // Refresh DGV_coachSearch
                        ClearInputFields();
                        editID = 0; // Reset editID after successful update
                    }
                    else
                    {
                        MessageBox.Show("Failed to update coach. No rows were affected.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message} (Error Number: {sqlEx.Number})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}");
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }

        private void DeleteCoach(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                if (editID == 0)
                {
                    MessageBox.Show("Please search for a coach first to select a valid CoachID.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the coach with ID {editID}? This action cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Get the coach's email to delete from Account table later
                string getEmailQuery = "SELECT Email FROM Coach WHERE CoachID = @ID;";
                string coachEmail = "";
                using (var cmdGetEmail = new SqlCommand(getEmailQuery, con))
                {
                    cmdGetEmail.Parameters.AddWithValue("@ID", editID);
                    var emailObj = cmdGetEmail.ExecuteScalar();
                    if (emailObj != null)
                    {
                        coachEmail = emailObj.ToString();
                    }
                }

                // Delete dependent records first to avoid foreign key violations
                string[] deleteDependentQueries = new string[]
                {
                    "DELETE FROM Certifications WHERE CoachID = @ID;",
                    "UPDATE Member SET CoachID = NULL WHERE CoachID = @ID;"
                };

                foreach (var query in deleteDependentQueries)
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", editID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Delete the coach from the Coach table
                int rowsAffected = 0;
                using (var deleteCmd = new SqlCommand(@"DELETE FROM Coach WHERE CoachID = @ID;", con))
                {
                    deleteCmd.CommandType = CommandType.Text;
                    deleteCmd.Parameters.AddWithValue("@ID", editID);
                    rowsAffected = deleteCmd.ExecuteNonQuery();
                }

                // Delete from Account table where Email matches and Position is "Coach"
                if (!string.IsNullOrEmpty(coachEmail) && rowsAffected > 0)
                {
                    using (var cmdAccount = new SqlCommand(
                        "DELETE FROM Account WHERE Email = @Email AND Position = 'Coach';", con))
                    {
                        cmdAccount.Parameters.AddWithValue("@Email", coachEmail);
                        cmdAccount.ExecuteNonQuery();
                    }
                }

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Coach deleted successfully.");
                    editID = 0;
                    DGV_coachSearch.DataSource = null;
                    DGV_SlotTimings.DataSource = null;
                    DGV_Certifications.DataSource = null;
                    ViewAll(null, EventArgs.Empty); // Refresh DGV_ViewAllCoach
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("No coach found with the specified CoachID.");
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

        private void ClearInputFields()
        {
            FirstNameTxt.Text = string.Empty;
            LastNameTxt.Text = string.Empty;
            EmailTxt.Text = string.Empty;
            SSNTxt.Text = string.Empty;
            GenderComboBox.SelectedItem = null;
            RatingTxt.Text = string.Empty;
            SupervisorIDTxt.Text = string.Empty;
            PasswordTxt.Text = string.Empty;
            CoachIDTxt.Text = string.Empty;
        }

        private void Logout(object sender, EventArgs e)
        {
            Login form2 = new Login();
            form2.Show();
            this.Close();
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
                Application.Exit();
            }
        }

        private void ManageCoach_Load(object sender, EventArgs e)
        {
            GenderComboBox.Items.AddRange(new string[] { "M", "F", "O" });
        }
        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void DGV_coachSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGV_coachSearch.Rows[e.RowIndex];
                editID = Convert.ToInt32(row.Cells["CoachID"].Value);
                FirstNameTxt.Text = row.Cells["FirstName"].Value?.ToString() ?? string.Empty;
                LastNameTxt.Text = row.Cells["LastName"].Value?.ToString() ?? string.Empty;
                EmailTxt.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                SSNTxt.Text = row.Cells["SSN"].Value?.ToString() ?? string.Empty;
                GenderComboBox.SelectedItem = row.Cells["Gender"].Value?.ToString() ?? string.Empty;
                RatingTxt.Text = row.Cells["Rating"].Value?.ToString() ?? string.Empty;
                SupervisorIDTxt.Text = row.Cells["CoachSupervisorID"].Value?.ToString() ?? string.Empty;
                PasswordTxt.Text = row.Cells["Password"].Value?.ToString() ?? string.Empty;

                LoadSlotTimings(editID);
                LoadCertifications(editID);
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
                /*
                 FirstName
LastName
Email
SSN
Gender
Rating
SupervisorID
Password
                */
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
                    case "email":
                        columnToUpdate = "Email";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "ssn":
                        columnToUpdate = "SSN";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "gender":
                        columnToUpdate = "Gender";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "rating":
                        columnToUpdate = "Rating";
                        updateValue = UpdateTxt.Text; // String, no additional validation needed
                        break;
                    case "supervisorid":
                        columnToUpdate = "SupervisorID";
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
                string fullChangeQuery = $"UPDATE Coach SET {columnToUpdate} = @update WHERE CoachID = @ID";

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
                            MessageBox.Show("No coach found with the specified CoachID, or the input is invalid.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attribute: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }











        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void DGV_SlotTimings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}