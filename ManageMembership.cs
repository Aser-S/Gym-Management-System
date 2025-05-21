using MaterialSkin;
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
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;




namespace DatabaseProject
{
    public partial class ManageMembership : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public ManageMembership()
        {
            InitializeComponent();


            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Set to LIGHT theme
            materialSkinManager.ColorScheme = new ColorScheme(
                Color.FromArgb(0x3e, 0x51, 0xb4),   // Primary 6988EC
                Color.FromArgb(0x06, 0x09, 0x30), // 8193D1
               Color.FromArgb(0x59, 0x5B, 0x83),
                Color.FromArgb(0x3e, 0x51, 0xb4), // Reusing as accent
              TextShade.WHITE// or BLACK depending on theme // Text color (black for contrast)
            );

            this.MinimumSize = new Size(800, 400); // Adjust based on your layout needs

            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void ManageMembership_Load(object sender, EventArgs e)
        {


            LoadMembershipTypes();

            StyleForm();
            // Ensure the form doesn't shrink below a reasonable size
            ApplyMaterialSkinStyles();


        }



        private void ViewAll(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                m.MembershipID, 
                m.MemberID, 
                mem.FirstName + ' ' + mem.LastName AS MemberName, 
                m.TypeID, 
                mt.Name AS TypeName, 
                m.Duration, 
                m.StartDate, 
                m.ExpiryDate 
            FROM Membership m
            JOIN Member mem ON m.MemberID = mem.MemberID
            JOIN MembershipType mt ON m.TypeID = mt.TypeID", con);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable tb_MembershipInfo = new DataTable();

                // Define columns with more descriptive names
                tb_MembershipInfo.Columns.Add("MembershipID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberName", typeof(string));
                tb_MembershipInfo.Columns.Add("TypeID", typeof(int));
                tb_MembershipInfo.Columns.Add("TypeName", typeof(string));
                tb_MembershipInfo.Columns.Add("Duration", typeof(int));
                tb_MembershipInfo.Columns.Add("StartDate", typeof(DateTime));
                tb_MembershipInfo.Columns.Add("ExpiryDate", typeof(DateTime));

                DataRow row;
                while (reader.Read())
                {
                    row = tb_MembershipInfo.NewRow();
                    row["MembershipID"] = reader["MembershipID"];
                    row["MemberID"] = reader["MemberID"];
                    row["MemberName"] = reader["MemberName"];
                    row["TypeID"] = reader["TypeID"];
                    row["TypeName"] = reader["TypeName"];
                    row["Duration"] = reader["Duration"];
                    row["StartDate"] = reader["StartDate"];
                    row["ExpiryDate"] = reader["ExpiryDate"];

                    tb_MembershipInfo.Rows.Add(row);
                }

                reader.Close();
                DGV_ViewAll.DataSource = tb_MembershipInfo;

                // Optional: Customize column headers for better readability
                DGV_ViewAll.Columns["MembershipID"].HeaderText = "Membership ID";
                DGV_ViewAll.Columns["MemberID"].HeaderText = "Member ID";
                DGV_ViewAll.Columns["MemberName"].HeaderText = "Member Name";
                DGV_ViewAll.Columns["TypeID"].HeaderText = "Type ID";
                DGV_ViewAll.Columns["TypeName"].HeaderText = "Membership Type";
                DGV_ViewAll.Columns["Duration"].HeaderText = "Duration (Months)";
                DGV_ViewAll.Columns["StartDate"].HeaderText = "Start Date";
                DGV_ViewAll.Columns["ExpiryDate"].HeaderText = "Expiry Date";
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                con?.Close();
            }
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
                    case "startdate":
                        orderByClause += "m.StartDate";
                        break;
                    case "expirydate":
                        orderByClause += "m.ExpiryDate";
                        break;
                    case "duration":
                        orderByClause += "m.Duration";
                        break;
                    case "member":
                        orderByClause += "mem.LastName, mem.FirstName"; // Sort by member name
                        break;
                    case "type":
                        orderByClause += "mt.TypeID"; // Sort by membership type name
                        break;
                    default:
                        MessageBox.Show("Please enter a valid sort option: 'StartDate', 'ExpiryDate', 'Duration', 'Member', or 'Type'.");
                        return;
                }

                // Enhanced query with joins for readable data
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                m.MembershipID, 
                m.MemberID, 
                mem.FirstName + ' ' + mem.LastName AS MemberName, 
                m.TypeID, 
                mt.Name AS TypeName, 
                m.Duration, 
                m.StartDate, 
                m.ExpiryDate 
              FROM Membership m
              JOIN Member mem ON m.MemberID = mem.MemberID
              JOIN MembershipType mt ON m.TypeID = mt.TypeID " + orderByClause,
                    con);
                cmd.CommandType = CommandType.Text;

                reader = cmd.ExecuteReader();
                DataTable tb_MembershipInfo = new DataTable();

                // Define columns with appropriate types and readable names
                tb_MembershipInfo.Columns.Add("MembershipID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberName", typeof(string));
                tb_MembershipInfo.Columns.Add("TypeID", typeof(int));
                tb_MembershipInfo.Columns.Add("TypeName", typeof(string));
                tb_MembershipInfo.Columns.Add("Duration", typeof(int));
                tb_MembershipInfo.Columns.Add("StartDate", typeof(DateTime));
                tb_MembershipInfo.Columns.Add("ExpiryDate", typeof(DateTime));

                DataRow row;
                while (reader.Read())
                {
                    row = tb_MembershipInfo.NewRow();
                    row["MembershipID"] = reader["MembershipID"] != DBNull.Value ? Convert.ToInt32(reader["MembershipID"]) : 0;
                    row["MemberID"] = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0;
                    row["MemberName"] = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : "Unknown";
                    row["TypeID"] = reader["TypeID"] != DBNull.Value ? Convert.ToInt32(reader["TypeID"]) : 0;
                    row["TypeName"] = reader["TypeName"] != DBNull.Value ? reader["TypeName"].ToString() : "Unknown";
                    row["Duration"] = reader["Duration"] != DBNull.Value ? Convert.ToInt32(reader["Duration"]) : 0;
                    row["StartDate"] = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : DBNull.Value;
                    row["ExpiryDate"] = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : DBNull.Value;

                    tb_MembershipInfo.Rows.Add(row);
                }

                reader.Close();
                DGV_Sort.DataSource = tb_MembershipInfo;

                // Customize DataGridView column headers for readability
                DGV_Sort.Columns["MembershipID"].HeaderText = "Membership ID";
                DGV_Sort.Columns["MemberID"].HeaderText = "Member ID";
                DGV_Sort.Columns["MemberName"].HeaderText = "Member Name";
                DGV_Sort.Columns["TypeID"].HeaderText = "Type ID";
                DGV_Sort.Columns["TypeName"].HeaderText = "Membership Type";
                DGV_Sort.Columns["Duration"].HeaderText = "Duration (Months)";
                DGV_Sort.Columns["StartDate"].HeaderText = "Start Date";
                DGV_Sort.Columns["ExpiryDate"].HeaderText = "Expiry Date";

                if (tb_MembershipInfo.Rows.Count == 0)
                {
                    MessageBox.Show("No memberships found.");
                }
                else
                {
                    MessageBox.Show($"Memberships sorted by {sortBy} successfully.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }



        private void LoadMembershipTypes()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT TypeID, Name FROM MembershipType";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable(); // Create a DataTable instance
                            dataTable.Load(reader); // Populate the DataTable with the reader data
                            TypeNameComboBox.DisplayMember = "Name";
                            TypeNameComboBox.ValueMember = "TypeID";
                            TypeNameComboBox.DataSource = dataTable; // Assign the populated DataTable
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading membership types: {ex.Message}");
                }
            }
        }

        private void AddMembership(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Validate inputs
                if (string.IsNullOrWhiteSpace(MemberIDTxt.Text) || !int.TryParse(MemberIDTxt.Text, out int memberID))
                {
                    MessageBox.Show("Please enter a valid Member ID (numeric value).");
                    return;
                }
                if (TypeNameComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a membership type.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(DurationMonthTxt.Text) || !int.TryParse(DurationMonthTxt.Text, out int duration) || duration <= 0)
                {
                    MessageBox.Show("Please enter a valid duration in months (positive number).");
                    return;
                }

                // Validate MemberID exists in Member table
                using (SqlCommand checkMemberCmd = new SqlCommand("SELECT COUNT(*) FROM Member WHERE MemberID = @MemberID", con))
                {
                    checkMemberCmd.Parameters.AddWithValue("@MemberID", memberID);
                    int count = (int)checkMemberCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        DialogResult result =
                         MessageBox.Show($"MemberID {memberID} does not exist in the Member table.\nDo you want to add a new member?", "Alert", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ManageMembers form2 = new ManageMembers();
                            form2.Show(); // Show Form2
                            this.Hide(); // Hide Form1

                        }
                        return;
                    }
                }

                // Get TypeID from the selected ComboBox item
                int typeID = Convert.ToInt32(TypeNameComboBox.SelectedValue);

                // Execute sp_CreateMembership
                using (SqlCommand cmd = new SqlCommand("sp_CreateMembership", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    SqlParameter membershipIDParam = new SqlParameter("@MembershipID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(membershipIDParam);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.Parameters.AddWithValue("@TypeID", typeID);
                    cmd.Parameters.AddWithValue("@Duration", duration);

                    cmd.ExecuteNonQuery();

                    int newMembershipID = (int)membershipIDParam.Value;
                    MessageBox.Show($"New membership created successfully. Membership ID: {newMembershipID}");

                    // Optional: Refresh the view or clear fields
                    MemberIDTxt.Text = "";
                    DurationMonthTxt.Text = "";
                    TypeNameComboBox.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                con?.Close();
            }
        }


        private void Logout(object sender, EventArgs e)
        {
            // Create an instance of Form2
            Login form2 = new Login();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void BackToOwner(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(11);
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


        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Validate MembershipID
                if (string.IsNullOrWhiteSpace(MemberShipIDtxt.Text) || !int.TryParse(MemberShipIDtxt.Text, out int membershipID) || membershipID <= 0)
                {
                    MessageBox.Show("Please enter a valid Membership ID (positive integer).");
                    return;
                }

                // Check if MembershipID exists
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Membership WHERE MembershipID = @MembershipID", con))
                {
                    checkCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show($"Membership ID {membershipID} does not exist.");
                        return;
                    }
                }

                // Validate UpdateAttribute
                string attribute = UpdateAttribute.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(attribute) || UpdateAttribute.SelectedIndex == -1 ||
                    (attribute != "duration" && attribute != "typeid" && attribute != "memberid"))
                {
                    MessageBox.Show("Please select a valid attribute to update (only 'Duration', 'Type', or 'MemberID' are allowed).");
                    return;
                }

                // Fetch StartDate for ExpiryDate calculation (needed for Duration update)
                DateTime startDate;
                using (SqlCommand fetchCmd = new SqlCommand("SELECT StartDate FROM Membership WHERE MembershipID = @MembershipID", con))
                {
                    fetchCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                    object result = fetchCmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Failed to retrieve StartDate for this membership.");
                        return;
                    }
                    startDate = Convert.ToDateTime(result);
                }

                // Validate UpdateValue based on attribute
                string newValue = UpdateValtxt.Text.Trim();
                int newIntValue = 0; // Initialize to avoid unassigned variable error
                bool isTransfer = false; // Flag to determine if this is a MemberID update (transfer)

                switch (attribute)
                {
                    case "duration":
                        if (string.IsNullOrWhiteSpace(newValue) || !int.TryParse(newValue, out newIntValue) || newIntValue <= 0)
                        {
                            MessageBox.Show("Please enter a valid positive integer for Duration.");
                            return;
                        }
                        break;

                    case "type":
                        if (string.IsNullOrWhiteSpace(newValue))
                        {
                            MessageBox.Show("Please enter a valid Type Name.");
                            return;
                        }
                        // Look up TypeID based on TypeName
                        using (SqlCommand checkTypeCmd = new SqlCommand("SELECT TypeID FROM MembershipType WHERE Name = @TypeName", con))
                        {
                            checkTypeCmd.Parameters.AddWithValue("@TypeName", newValue);
                            object typeIdResult = checkTypeCmd.ExecuteScalar();
                            if (typeIdResult == null || typeIdResult == DBNull.Value)
                            {
                                MessageBox.Show($"Type Name '{newValue}' does not exist in MembershipType.");
                                return;
                            }
                            newIntValue = Convert.ToInt32(typeIdResult);
                        }
                        break;

                    case "memberid":
                        if (string.IsNullOrWhiteSpace(newValue) || !int.TryParse(newValue, out newIntValue) || newIntValue <= 0)
                        {
                            MessageBox.Show("Please enter a valid positive integer for MemberID.");
                            return;
                        }
                        // Verify MemberID exists in Member table
                        using (SqlCommand checkMemberCmd = new SqlCommand("SELECT COUNT(*) FROM Member WHERE MemberID = @MemberID", con))
                        {
                            checkMemberCmd.Parameters.AddWithValue("@MemberID", newIntValue);
                            int memberCount = (int)checkMemberCmd.ExecuteScalar();
                            if (memberCount == 0)
                            {
                                MessageBox.Show($"MemberID {newIntValue} does not exist in Member table.");
                                return;
                            }
                        }
                        isTransfer = true; // Mark this as a transfer
                        break;

                    default:
                        MessageBox.Show("Invalid attribute selected.");
                        return;
                }

                // Calculate new ExpiryDate if Duration is updated
                if (attribute == "duration")
                {
                    DateTime newExpiryDate = startDate.AddMonths(newIntValue);
                    using (SqlCommand updateExpiryCmd = new SqlCommand(
                        "UPDATE Membership SET ExpiryDate = @NewExpiryDate WHERE MembershipID = @MembershipID", con))
                    {
                        updateExpiryCmd.Parameters.AddWithValue("@NewExpiryDate", newExpiryDate);
                        updateExpiryCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                        updateExpiryCmd.ExecuteNonQuery();
                    }
                }

                // Update the specified attribute
                using (SqlCommand cmd = new SqlCommand(
                    $"UPDATE Membership SET {(attribute == "type" ? "TypeID" : attribute == "memberid" ? "MemberID" : attribute)} = @NewValue WHERE MembershipID = @MembershipID", con))
                {
                    cmd.Parameters.AddWithValue("@NewValue", newIntValue);
                    cmd.Parameters.AddWithValue("@MembershipID", membershipID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (isTransfer)
                        {
                            MessageBox.Show($"Membership ID {membershipID} transferred successfully to MemberID {newIntValue}.");
                        }
                        else
                        {
                            MessageBox.Show($"Membership ID {membershipID} updated successfully. {(attribute == "duration" ? $"ExpiryDate updated to {startDate.AddMonths(newIntValue):d}" : "")}");
                        }
                        // Refresh the view
                        ViewAll(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                con?.Close();
            }
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                string email = SearchEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Please enter an email to search.");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                m.MembershipID, 
                m.MemberID, 
                mem.FirstName + ' ' + mem.LastName AS MemberName, 
                m.TypeID, 
                mt.Name AS TypeName, 
                m.Duration, 
                m.StartDate, 
                m.ExpiryDate 
              FROM Membership m
              JOIN Member mem ON m.MemberID = mem.MemberID
              JOIN MembershipType mt ON m.TypeID = mt.TypeID
              WHERE mem.Email = @Email",
                    con);
                cmd.Parameters.AddWithValue("@Email", email);

                reader = cmd.ExecuteReader();
                DataTable tb_MembershipInfo = new DataTable();

                tb_MembershipInfo.Columns.Add("MembershipID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberID", typeof(int));
                tb_MembershipInfo.Columns.Add("MemberName", typeof(string));
                tb_MembershipInfo.Columns.Add("TypeID", typeof(int));
                tb_MembershipInfo.Columns.Add("TypeName", typeof(string));
                tb_MembershipInfo.Columns.Add("Duration", typeof(int));
                tb_MembershipInfo.Columns.Add("StartDate", typeof(DateTime));
                tb_MembershipInfo.Columns.Add("ExpiryDate", typeof(DateTime));

                DataRow row;
                while (reader.Read())
                {
                    row = tb_MembershipInfo.NewRow();
                    row["MembershipID"] = reader["MembershipID"] != DBNull.Value ? Convert.ToInt32(reader["MembershipID"]) : 0;
                    row["MemberID"] = reader["MemberID"] != DBNull.Value ? Convert.ToInt32(reader["MemberID"]) : 0;
                    row["MemberName"] = reader["MemberName"] != DBNull.Value ? reader["MemberName"].ToString() : "Unknown";
                    row["TypeID"] = reader["TypeID"] != DBNull.Value ? Convert.ToInt32(reader["TypeID"]) : 0;
                    row["TypeName"] = reader["TypeName"] != DBNull.Value ? reader["TypeName"].ToString() : "Unknown";
                    row["Duration"] = reader["Duration"] != DBNull.Value ? Convert.ToInt32(reader["Duration"]) : 0;
                    row["StartDate"] = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : DBNull.Value;
                    row["ExpiryDate"] = reader["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(reader["ExpiryDate"]) : DBNull.Value;

                    tb_MembershipInfo.Rows.Add(row);
                }

                reader.Close();
                DGV_ViewAll.DataSource = tb_MembershipInfo;

                DGV_ViewAll.Columns["MembershipID"].HeaderText = "Membership ID";
                DGV_ViewAll.Columns["MemberID"].HeaderText = "Member ID";
                DGV_ViewAll.Columns["MemberName"].HeaderText = "Member Name";
                DGV_ViewAll.Columns["TypeID"].HeaderText = "Type ID";
                DGV_ViewAll.Columns["TypeName"].HeaderText = "Membership Type";
                DGV_ViewAll.Columns["Duration"].HeaderText = "Duration (Months)";
                DGV_ViewAll.Columns["StartDate"].HeaderText = "Start Date";
                DGV_ViewAll.Columns["ExpiryDate"].HeaderText = "Expiry Date";

                if (tb_MembershipInfo.Rows.Count == 0)
                {
                    MessageBox.Show($"No memberships found for email {email}.");
                }
                else
                {
                    MessageBox.Show($"Found {tb_MembershipInfo.Rows.Count} membership(s) for email {email}.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                if (con != null && con.State == ConnectionState.Open) con.Close();
            }
        }




        private void ApplyMaterialSkinStyles()
        {
            // Labels (e.g., label1, label3, label5, etc.)
            foreach (Control control in this.Controls)
            {

                if (control is Label label)
                {
                    label.ForeColor = Color.Black; // Ensure text is readable
                    label.Font = new Font("Roboto", 10F, FontStyle.Regular); // Material Design font
                }
                else if (control is Button button5)
                {
                    button5.BackColor = materialSkinManager.ColorScheme.AccentColor; // Orange accent
                    button5.ForeColor = Color.White;
                    button5.FlatStyle = FlatStyle.Flat;
                    button5.Font = new Font("Roboto", 9F, FontStyle.Bold);
                    MakeControlRounded(button5, 20);

                }
                else if (control is TextBox TB)
                {
                    TB.BackColor = Color.White;
                    TB.ForeColor = Color.Black;
                    TB.BorderStyle = BorderStyle.FixedSingle;
                    TB.Font = new Font("Roboto", 10F);
                    MakeControlRounded(TB, 20);

                }
                else if (control is ComboBox CB)
                {
                    CB.BackColor = Color.White;
                    CB.ForeColor = Color.Black;
                    CB.FlatStyle = FlatStyle.Flat;
                    CB.Font = new Font("Roboto", 10F);

                }
                else if (control is DataGridView DGV)
                {
                    StyleDataGridView(DGV);
                }
                else if (control is DateTimePicker DTP)
                {
                    // DateTimePicker (e.g., dateTimePicker1)
                    DTP.BackColor = Color.White;
                    DTP.ForeColor = Color.Black;
                    DTP.Font = new Font("Roboto", 10F);
                    StyleDatePicker(DTP, 20);
                }
            }


        }
        public static void StyleDatePicker(DateTimePicker datePicker, int cornerRadius)
        {
            // Ensure the control is not null
            if (datePicker == null) return;

            // Create a rounded region for pill-like shape
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = datePicker.ClientRectangle;
            bounds.Inflate(-1, -1); // Prevent clipping of borders

            int diameter = cornerRadius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Define rounded rectangle path
            path.AddArc(arc, 180, 90); // Top-left
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90); // Top-right
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90); // Bottom-right
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90); // Bottom-left
            path.CloseFigure();

            // Apply rounded region to main control
            datePicker.Region = new Region(path);

            // Style the dropdown calendar with gym-related theme
            datePicker.CalendarForeColor = Color.Black; // Bold black for day numbers
            datePicker.CalendarTitleBackColor = Color.FromArgb(200, 0, 0); // Deep red for header (energy)
            datePicker.CalendarTitleForeColor = Color.White; // White header text for contrast
            datePicker.CalendarTrailingForeColor = Color.DarkGray; // Subtle gray for trailing days
            datePicker.CalendarMonthBackground = Color.FromArgb(240, 240, 240); // Light gray background
            datePicker.ShowUpDown = false; // Ensure dropdown calendar is used

            // Highlight weekends (e.g., gym days) by handling date selection
            datePicker.DropDown += (sender, e) =>
            {
                // Refresh calendar with styled colors
                datePicker.Invalidate();
            };
            datePicker.CloseUp += (sender, e) =>
            {
                // Refresh main control when dropdown closes
                datePicker.Invalidate();
            };

            // Handle custom painting for the main control with gym theme
            datePicker.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw background (gray for a rugged gym feel)
                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(220, 220, 220)))
                {
                    g.FillPath(bgBrush, path);
                }

                // Draw border (red for energy, with sketch-style roughness)
                using (Pen borderPen = new Pen(Color.FromArgb(200, 0, 0), 2))
                {
                    borderPen.DashStyle = DashStyle.Dot; // Simulate sketch-style with dotted pattern
                    g.DrawPath(borderPen, path);
                }

                // Draw date text (centered, bold black for strength)
                string dateText = datePicker.Text;
                using (Font font = datePicker.Font)
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    SizeF textSize = g.MeasureString(dateText, font);
                    PointF textLocation = new PointF(
                        (datePicker.Width - textSize.Width - 40) / 2 + 20, // Adjust for icon and arrow
                        (datePicker.Height - textSize.Height) / 2
                    );
                    g.DrawString(dateText, font, textBrush, textLocation);
                }

                // Draw gym icon (simple dumbbell) on the left
                Point[] dumbbell = new Point[]
                {
                    new Point(10, datePicker.Height / 2 - 2), // Left weight
                    new Point(12, datePicker.Height / 2 - 2),
                    new Point(12, datePicker.Height / 2 + 2),
                    new Point(10, datePicker.Height / 2 + 2)
                };
                Point[] dumbbellRight = new Point[]
                {
                    new Point(18, datePicker.Height / 2 - 2), // Right weight
                    new Point(20, datePicker.Height / 2 - 2),
                    new Point(20, datePicker.Height / 2 + 2),
                    new Point(18, datePicker.Height / 2 + 2)
                };
                using (SolidBrush iconBrush = new SolidBrush(Color.Black))
                {
                    g.FillRectangle(iconBrush, 12, datePicker.Height / 2 - 1, 6, 2); // Bar
                    g.FillPolygon(iconBrush, dumbbell); // Left weight
                    g.FillPolygon(iconBrush, dumbbellRight); // Right weight
                }

                // Draw dropdown arrow (red triangle to match border)
                Point[] arrow = new Point[]
                {
                    new Point(datePicker.Width - 20, datePicker.Height / 2 - 3),
                    new Point(datePicker.Width - 10, datePicker.Height / 2 - 3),
                    new Point(datePicker.Width - 15, datePicker.Height / 2 + 3)
                };
                using (SolidBrush arrowBrush = new SolidBrush(Color.FromArgb(200, 0, 0)))
                {
                    g.FillPolygon(arrowBrush, arrow);
                }
            };

            // Refresh on focus and value changes
            datePicker.GotFocus += (sender, e) => datePicker.Invalidate();
            datePicker.LostFocus += (sender, e) => datePicker.Invalidate();
            datePicker.ValueChanged += (sender, e) => datePicker.Invalidate();

            // Use short date format for clarity
            datePicker.Format = DateTimePickerFormat.Short;
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            // General appearance

            dgv.BackgroundColor = Color.FromArgb(245, 245, 245); // Very light gray for background
            dgv.ForeColor = Color.Black;
            dgv.BorderStyle = BorderStyle.None;

            // Cell styles
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Roboto", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = materialSkinManager.ColorScheme.AccentColor; // Orange when selected
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Header styles
            dgv.ColumnHeadersDefaultCellStyle.BackColor = materialSkinManager.ColorScheme.PrimaryColor; // Light gray
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10F, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Allow custom styling of headers

            // Row styles
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230); // Slightly darker for alternating rows

            // Grid lines
            dgv.GridColor = Color.FromArgb(200, 200, 200); // Light gray grid lines
            dgv.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(0, 0, dgv.Width - 1, dgv.Height - 1));
                }

                // If empty, show placeholder
                if (dgv.Rows.Count == 0)
                {
                    string placeholder = "Here will appear some data";
                    using (Font f = new Font("Segoe UI", 10, FontStyle.Italic))
                    using (Brush b = new SolidBrush(Color.Gray))
                    {
                        e.Graphics.DrawString(placeholder, f, b, new PointF(10, 10));
                    }
                }
            };


        }
        public static void MakeControlRounded(Control control, int cornerRadius)
        {
            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = control.ClientRectangle;

            // Adjust bounds to account for border and ensure text remains centered
            bounds.Inflate(-1, -1); // Slight reduction to prevent clipping

            // Define rounded rectangle with specified corner radius
            int diameter = cornerRadius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Top-left corner
            path.AddArc(arc, 180, 90);
            // Top-right corner
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom-right corner
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom-left corner
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            // Close the path
            path.CloseFigure();

            // Apply the rounded region to the control
            control.Region = new Region(path);

            // Ensure text alignment remains centered (for buttons)
            if (control is Button button)
            {
                button.TextAlign = ContentAlignment.MiddleCenter;
            }
            // Ensure text box text is not clipped and remains centered
            if (control is TextBox textBox)
            {
                textBox.TextAlign = HorizontalAlignment.Center;
                // Add padding to prevent text from touching edges
                textBox.Padding = new Padding(cornerRadius / 2, 0, cornerRadius / 2, 0);
            }
        }
        public static void StyleMaterialForm(Form form, string imagePath, Color borderColor, int borderWidth)
        {
            // Ensure the form is not null
            if (form == null) return;

            // Initialize MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;

            // Set the background image
            try
            {
                if (System.IO.File.Exists(imagePath))
                {
                    form.BackgroundImage = Image.FromFile(imagePath);
                    form.BackgroundImageLayout = ImageLayout.Stretch; // Stretch to fit form
                }
                else
                {
                    MessageBox.Show($"Background image not found at: {imagePath}. Please ensure the file exists and the path is correct.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.BackgroundImage = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading background image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.BackgroundImage = null;
            }

            // Custom painting for the border (overriding MaterialSkin's default border)
            form.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Define the border rectangle (inset by borderWidth / 2 to avoid clipping)
                Rectangle borderRect = new Rectangle(
                    borderWidth / 2,
                    borderWidth / 2,
                    form.ClientSize.Width - borderWidth,
                    form.ClientSize.Height - borderWidth
                );

                // Draw the custom colored border
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    borderPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; // Sketch-style
                    g.DrawRectangle(borderPen, borderRect);
                }
            };

            // Ensure the form repaints when resized
            form.Resize += (sender, e) =>
            {
                form.Invalidate();
            };
        }

        private void StyleForm()
        {

            // Center the form on the screen
            // Disable AutoSize to allow manual control
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly; // Allow growth but not shrinking

            // Calculate the size needed to fit all controls
            int maxRight = 0;
            int maxBottom = 0;
            foreach (Control control in this.Controls)
            {
                maxRight = Math.Max(maxRight, control.Right + control.Margin.Right);
                maxBottom = Math.Max(maxBottom, control.Bottom + control.Margin.Bottom);
            }

            // Define margins for all four directions
            int margin = 20; // Adjust as needed

            // Calculate the new client size with margins and a buffer
            int buffer = 50; // Additional buffer to avoid cutting off components
            int newClientWidth = maxRight + (margin * 2) + buffer;
            int newClientHeight = maxBottom + (margin * 2) + buffer;

            // Set the new ClientSize to fit all controls plus margins and buffer
            this.ClientSize = new Size(newClientWidth, newClientHeight);

            if (newClientWidth < this.MinimumSize.Width || newClientHeight < this.MinimumSize.Height)
            {
                this.ClientSize = this.MinimumSize;
            }
        }



        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteMembership(sender, e);
        }

        private void DeleteMembership(object sender, EventArgs e)
        {


            DataGridView selectedGrid = DGV_ViewAll.SelectedRows.Count > 0 ? DGV_ViewAll : DGV_Sort;

            // Validate that exactly one row is selected
            if (selectedGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select exactly one membership row to delete.");
                return;
            }

            int membershipID = Convert.ToInt32(selectedGrid.SelectedRows[0].Cells["MembershipID"].Value);
            if (membershipID <= 0)
            {
                MessageBox.Show("Invalid Membership ID selected.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete Membership ID {membershipID}?\nThis action will cacscade.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.No)
            {
                return;
            }

            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                con.Open();

                // Step 1: Delete dependent records in Membership_Member
                using (SqlCommand deleteDependentCmd = new SqlCommand(
                    "DELETE FROM Membership_Member WHERE MembershipID = @MembershipID", con))
                {
                    deleteDependentCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                    deleteDependentCmd.ExecuteNonQuery();
                }

                // Step 2: Delete the membership
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Membership WHERE MembershipID = @MembershipID", con))
                {
                    cmd.Parameters.AddWithValue("@MembershipID", membershipID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Membership ID {membershipID} deleted successfully.");
                        ViewAll(sender, e); // Refresh the grid
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted. Membership ID may not exist.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                con?.Close();
            }
        }

        private void DGV_ViewAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Assuming ViewAll method exists to refresh the grid


        /*    private void DeleteBtn_Click(object sender, EventArgs e)
            {

                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
                    con.Open();

                    // Validate MembershipID
                    if (string.IsNullOrWhiteSpace(MemberShipIDtxt.Text) || !int.TryParse(MemberShipIDtxt.Text, out int membershipID) || membershipID <= 0)
                    {
                        MessageBox.Show("Please enter a valid Membership ID (positive integer).");
                        return;
                    }

                    // Check if MembershipID exists
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Membership WHERE MembershipID = @MembershipID", con))
                    {
                        checkCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show($"Membership ID {membershipID} does not exist.");
                            return;
                        }
                    }

                    // Delete the row from Membership table
                    using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM Membership WHERE MembershipID = @MembershipID", con))
                    {
                        deleteCmd.Parameters.AddWithValue("@MembershipID", membershipID);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Membership ID {membershipID} deleted successfully.");
                            // Refresh the view
                            ViewAll(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Deletion failed.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
                finally
                {
                    con?.Close();
                }
            }
        }*/
    }
}
