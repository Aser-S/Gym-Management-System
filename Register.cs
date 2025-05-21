// ONLY MISSING PASSWORD

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void RegisterNewMember(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(FirstNameTxt.Text) ||
                string.IsNullOrWhiteSpace(LastNameTxt.Text) ||
                string.IsNullOrWhiteSpace(EmailTxt.Text) ||
                string.IsNullOrWhiteSpace(PasswordTxt.Text) ||
                string.IsNullOrWhiteSpace(SSNTxt.Text) ||
                string.IsNullOrWhiteSpace(Gender.Text) ||
                string.IsNullOrWhiteSpace(PhoneTxt.Text) ||
                string.IsNullOrWhiteSpace(memWeight.Text) ||
                string.IsNullOrWhiteSpace(memHeight.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Email format validation
            if (!Regex.IsMatch(EmailTxt.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Phone validation (digits only, 10-15 characters)
            if (!Regex.IsMatch(PhoneTxt.Text, @"^\d{10,15}$"))
            {
                MessageBox.Show("Phone number must contain 10–15 digits.");
                return;
            }

            // SSN validation (digits only, 10-20 characters)
            if (!Regex.IsMatch(SSNTxt.Text, @"^\d{10,20}$"))
            {
                MessageBox.Show("SSN must be 10–20 digits.");
                return;
            }
            if (PasswordTxt.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.");
                return;
            }


            // Weight and Height validation (numeric)
            if (!double.TryParse(memWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Weight must be a valid positive number.");
                return;
            }

            if (!double.TryParse(memHeight.Text, out double height) || height <= 0)
            {
                MessageBox.Show("Height must be a valid positive number.");
                return;
            }

            // Birth date must be before today
            if (birthDateInput.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Birth date must be before today.");
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            try
            {
                // Insert into Account table
                string cmdString2 = @"INSERT INTO Account (Password, Email, Position)
                              VALUES (@password, @Email, @position)";
                SqlCommand cmd2 = new SqlCommand(cmdString2, con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Add(new SqlParameter("@password", PasswordTxt.Text));
                cmd2.Parameters.Add(new SqlParameter("@Email", EmailTxt.Text));
                cmd2.Parameters.Add(new SqlParameter("@position", "Member"));
                cmd2.ExecuteNonQuery();

                // Get next MemberID
                string maxIdCmd = "SELECT COALESCE(MAX(MemberID), 0) + 1 FROM Member";
                SqlCommand maxCmd = new SqlCommand(maxIdCmd, con);
                int nextId = (int)maxCmd.ExecuteScalar();

                // Insert into Member table
                string cmdString = @"INSERT INTO Member (MemberID, FirstName, LastName, Email, SSN, Gender, Phone, BirthDate, JoinDate, Weight, Height, LockerNumber, CoachID, Password)
                             VALUES (@MemberID, @Fname, @Lname, @Email, @SSN, @Gender, @Phone, @Bdate, GETDATE(), @memWeight, @memHeight, NULL, NULL, @password)";
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@MemberID", nextId));
                cmd.Parameters.Add(new SqlParameter("@Fname", FirstNameTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@Lname", LastNameTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@Email", EmailTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@SSN", SSNTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@Gender", Gender.Text));
                cmd.Parameters.Add(new SqlParameter("@Phone", PhoneTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@Bdate", birthDateInput.Value));
                cmd.Parameters.Add(new SqlParameter("@memWeight", weight));
                cmd.Parameters.Add(new SqlParameter("@memHeight", height));
                cmd.Parameters.Add(new SqlParameter("@password", PasswordTxt.Text));

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Member added successfully.");

                MemberMenu form2 = new MemberMenu(nextId);
                form2.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
            }
        }
        private void AlreadyHaveAnAccount(object sender, EventArgs e)
        {
            MessageBox.Show("Returning to login page!");
            Login form2 = new Login();
            form2.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
