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
    public partial class OwnerMore : Form
    {
        public OwnerMore()
        {
            InitializeComponent();
            // Set form size to match the primary screen's working area
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            // Optional: Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }
























        //    // 10. Call sp_GetAvailableCoaches (display result in DGV_More)
        //    private void GetAvailableCoaches(object sender, EventArgs e)
        //    {
        //        SqlConnection con = null;
        //        SqlDataReader reader = null;
        //        try
        //        {
        //            con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
        //            con.Open();

        //            using (SqlCommand cmd = new SqlCommand("sp_GetAvailableCoaches", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                reader = cmd.ExecuteReader();

        //                DataTable tb_AvailableCoaches = new DataTable();
        //                tb_AvailableCoaches.Columns.Add("CoachID", typeof(int));
        //                tb_AvailableCoaches.Columns.Add("CoachName");
        //                tb_AvailableCoaches.Columns.Add("Email");
        //                tb_AvailableCoaches.Columns.Add("Rating", typeof(decimal));
        //                tb_AvailableCoaches.Columns.Add("CurrentMemberCount", typeof(int));

        //                DataRow row;
        //                while (reader.Read())
        //                {
        //                    row = tb_AvailableCoaches.NewRow();
        //                    row["CoachID"] = reader["CoachID"] != DBNull.Value ? Convert.ToInt32(reader["CoachID"]) : 0;
        //                    row["CoachName"] = reader["CoachName"] != DBNull.Value ? reader["CoachName"].ToString() : "";
        //                    row["Email"] = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
        //                    row["Rating"] = reader["Rating"] != DBNull.Value ? Convert.ToDecimal(reader["Rating"]) : 0m;
        //                    row["CurrentMemberCount"] = reader["CurrentMemberCount"] != DBNull.Value ? Convert.ToInt32(reader["CurrentMemberCount"]) : 0;
        //                    tb_AvailableCoaches.Rows.Add(row);
        //                }
        //                reader.Close();
        //                DGV_More.DataSource = tb_AvailableCoaches;

        //                if (tb_AvailableCoaches.Rows.Count == 0)
        //                {
        //                    MessageBox.Show("No available coaches found.");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            if (reader != null && !reader.IsClosed) reader.Close();
        //            if (con != null && con.State == ConnectionState.Open) con.Close();
        //        }
        //    }

        //    // 11. Call fn_CalculateMemberBMI (display result in DGV_More)
        //    private void CalculateMemberBMI(object sender, EventArgs e)
        //    {
        //        SqlConnection con = null;
        //        SqlDataReader reader = null;
        //        try
        //        {
        //            if (!int.TryParse(Member.Text, out int memberID))
        //            {
        //                MessageBox.Show("MemberID must be a valid integer.");
        //                return;
        //            }

        //            con = new SqlConnection("Data Source=.;Initial Catalog=GymProject_V3;Integrated Security=SSPI");
        //            con.Open();

        //            using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_CalculateMemberBMI(@MemberID) AS BMI", con))
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Parameters.AddWithValue("@MemberID", memberID);
        //                reader = cmd.ExecuteReader();

        //                DataTable tb_Result = new DataTable();
        //                tb_Result.Columns.Add("MemberID", typeof(int));
        //                tb_Result.Columns.Add("BMI", typeof(decimal));

        //                DataRow row = tb_Result.NewRow();
        //                if (reader.Read())
        //                {
        //                    row["MemberID"] = memberID;
        //                    row["BMI"] = reader["BMI"] != DBNull.Value ? Convert.ToDecimal(reader["BMI"]) : 0m;
        //                    tb_Result.Rows.Add(row);
        //                }
        //                reader.Close();
        //                DGV_More.DataSource = tb_Result;

        //                if (tb_Result.Rows.Count == 0)
        //                {
        //                    MessageBox.Show("No result returned.");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            if (reader != null && !reader.IsClosed) reader.Close();
        //            if (con != null && con.State == ConnectionState.Open) con.Close();
        //        }
        //    }
        //}
    



























    private void Back(object sender, EventArgs e)
        {
            // Create an instance of Form2
            OwnerMenu form2 = new OwnerMenu(1);
            form2.Show(); // Show Form2
            this.Hide(); // Hide Form1
        }

    }
}
