// DONE BUT MISSING HAVING THE ID OF THE USER


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
    public partial class OwnerMenu : Form
    {
        int ID1 = 0; 
        public OwnerMenu(int id)
        {
            ID1 = id;
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }



        private void OwnerMenu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void ShowInfo(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Staff WHERE StaffID = @ID", con); // Added con to constructor
            cmd.CommandType = CommandType.Text;

            SqlParameter paramID = new SqlParameter("@ID", ID1);
            cmd.Parameters.Add(paramID);

            // Ensure the parameter type matches the StaffID column in the database
            // If StaffID is an integer, convert ID: cmd.Parameters[0].SqlDbType = SqlDbType.Int; cmd.Parameters[0].Value = int.Parse(ID);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tb_OwnerInfo = new DataTable();

            tb_OwnerInfo.Columns.Add("StaffID");
            tb_OwnerInfo.Columns.Add("FirstName");
            tb_OwnerInfo.Columns.Add("LastName");
            tb_OwnerInfo.Columns.Add("Role");
            tb_OwnerInfo.Columns.Add("Salary");
            tb_OwnerInfo.Columns.Add("WorkingHours");
            tb_OwnerInfo.Columns.Add("Phone");
            tb_OwnerInfo.Columns.Add("Email");
            tb_OwnerInfo.Columns.Add("SSN");
            tb_OwnerInfo.Columns.Add("StaffSupervisorID");

            DataRow row;
            while (reader.Read())
            {
                row = tb_OwnerInfo.NewRow();
                row["StaffID"] = reader["StaffID"];
                row["FirstName"] = reader["FirstName"];
                row["LastName"] = reader["LastName"];
                row["Role"] = reader["Role"];
                row["Salary"] = reader["Salary"];
                row["WorkingHours"] = reader["WorkingHours"];
                row["Phone"] = reader["Phone"];
                row["Email"] = reader["Email"];
                row["SSN"] = reader["SSN"];
                row["StaffSupervisorID"] = reader["StaffSupervisorID"];
                tb_OwnerInfo.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            DGV_Owner.DataSource = tb_OwnerInfo;
        }

        private void Members(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageMembers form3 = new ManageMembers();
            form3.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void staff(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageStaff form2 = new ManageStaff();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void Equipment(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageEquipment form2 = new ManageEquipment();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void Suppliers(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageSuppliers form2 = new ManageSuppliers();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void Orders(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageOrders form2 = new ManageOrders();
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
        private void Coach(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageCoach form2 = new ManageCoach();
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }
        private void Membership(object sender, EventArgs e)
        {
            // Create an instance of Form2
            ManageMembership form2 = new ManageMembership();
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
