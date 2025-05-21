using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(EmailLogin.Text) || string.IsNullOrWhiteSpace(PasswordLogin.Text))
                {
                    MessageBox.Show("Please enter both email and password.");
                    return;
                }



                // Email validation (basic pattern)
                if (!Regex.IsMatch(EmailLogin.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    EmailLogin.Focus();
                    return;
                }

                // Password validation (at least 6 characters)
                if (PasswordLogin.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.");
                    PasswordLogin.Focus();
                    return;
                }


                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-G54V24P;Initial Catalog=GymProject_V3;Integrated Security=True;"))
                {
                    con.Open();

                    // Check if the account exists and get password and position
                    string cmdString = @"SELECT Password, Position FROM Account WHERE Email = @EmailLogin";
                    using (SqlCommand cmd = new SqlCommand(cmdString, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@EmailLogin", EmailLogin.Text);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPass = reader["Password"].ToString();
                                string position = reader["Position"].ToString();

                                // Note: Passwords should be hashed in the database and compared using a secure hashing mechanism.
                                // For now, comparing plain text as per the current schema.
                                if (PasswordLogin.Text == storedPass)
                                {
                                    reader.Close(); // Close the reader before executing the next query

                                    int userId = GetUserId(con, position, EmailLogin.Text);
                                    if (userId == 0)
                                    {
                                        MessageBox.Show($"{position} not found in corresponding table.");
                                        return;
                                    }

                                    // Navigate to the appropriate form based on position
                                    if (position == "Owner")
                                    {
                                        OwnerMenu form2 = new OwnerMenu(userId);
                                        form2.Show();
                                        this.Hide();
                                    }
                                    else if (position == "Member")
                                    {
                                        MemberMenu form2 = new MemberMenu(userId);
                                        form2.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Position.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Password. Please try again.");
                                    PasswordLogin.Text = ""; // Clear password field
                                    PasswordLogin.Focus();
                                }
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show(
                                "No account exists with this email. Would you like to register a new account?",
                                "Register New Account",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                                if (result == DialogResult.Yes)
                                {
                                    Register form2 = new Register();
                                    form2.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    EmailLogin.Focus(); // Return focus to the email field for correction
                                }
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

        // Helper method to fetch user ID based on position
        private int GetUserId(SqlConnection con, string position, string email)
        {
            string idCmdString = "";
            string idColumn = "";

            if (position == "Owner")
            {
                idCmdString = @"SELECT StaffID FROM Staff WHERE Email = @EmailLogin";
                idColumn = "StaffID";
            }
            else if (position == "Member")
            {
                idCmdString = @"SELECT MemberID FROM Member WHERE Email = @EmailLogin";
                idColumn = "MemberID";
            }
            else
            {
                return 0; // Invalid position
            }

            using (SqlCommand idCmd = new SqlCommand(idCmdString, con))
            {
                idCmd.CommandType = CommandType.Text;
                idCmd.Parameters.AddWithValue("@EmailLogin", email);
                object idResult = idCmd.ExecuteScalar();
                return idResult != null ? Convert.ToInt32(idResult) : 0;
            }
        }


        private void Register(object sender, EventArgs e)
        {
            Register form2 = new Register();
            form2.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}