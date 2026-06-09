using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseActivity
{
    public partial class student : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadStudents();
        }

        void LoadStudents()
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Students", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvStudents.DataSource = dt;
                gvStudents.DataBind();
            }
        }

        bool ValidateForm()
        {
            if (txtID.Text == "") { lblMessage.Text = "ID required"; return false; }
            if (txtFirst.Text == "") { lblMessage.Text = "First name required"; return false; }
            if (txtLast.Text == "") { lblMessage.Text = "Last name required"; return false; }
            if (txtDepartment.Text == "") { lblMessage.Text = "Department required"; return false; }
            if (txtTelephone.Text == "") { lblMessage.Text = "Phone required"; return false; }

            return true;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                MySqlCommand check = new MySqlCommand(
                    "SELECT COUNT(*) FROM Students WHERE StudentID=@id", con);
                check.Parameters.AddWithValue("@id", txtID.Text);

                int exists = Convert.ToInt32(check.ExecuteScalar());

                if (exists > 0)
                {
                    lblMessage.Text = "Student already exists!";
                    return;
                }

                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO Students(StudentID,FirstName,LastName,Gender,Department,Telephone) " +
                    "VALUES(@id,@f,@l,@g,@d,@t)", con);

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@f", txtFirst.Text);
                cmd.Parameters.AddWithValue("@l", txtLast.Text);
                cmd.Parameters.AddWithValue("@g", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@d", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@t", txtTelephone.Text);

                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Inserted Successfully";
            LoadStudents();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM Students WHERE StudentID=@id", con);
                cmd.Parameters.AddWithValue("@id", txtID.Text);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtFirst.Text = dr["FirstName"].ToString();
                    txtLast.Text = dr["LastName"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();
                    txtDepartment.Text = dr["Department"].ToString();
                    txtTelephone.Text = dr["Telephone"].ToString();

                    lblMessage.Text = "Found";
                }
                else
                {
                    lblMessage.Text = "Not Found";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE Students SET FirstName=@f,LastName=@l,Gender=@g,Department=@d,Telephone=@t WHERE StudentID=@id", con);

                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@f", txtFirst.Text);
                cmd.Parameters.AddWithValue("@l", txtLast.Text);
                cmd.Parameters.AddWithValue("@g", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@d", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@t", txtTelephone.Text);

                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Updated Successfully";
            LoadStudents();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM Students WHERE StudentID=@id", con);

                cmd.Parameters.AddWithValue("@id", txtID.Text);

                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Deleted Successfully";
            LoadStudents();
        }

    }
}