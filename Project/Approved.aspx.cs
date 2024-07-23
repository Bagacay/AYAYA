using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project
{
    public partial class Approved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            string query = "SELECT * FROM [Approved]";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }



        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int Order_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Fname = (row.FindControl("Fname") as TextBox).Text;
            string Lname = (row.FindControl("Lname") as TextBox).Text;
            string Mobile = (row.FindControl("Mobile") as TextBox).Text;
            string Email = (row.FindControl("Email") as TextBox).Text;
            string Booking = (row.FindControl("Booking") as TextBox).Text;
            string Date_time = (row.FindControl("Date_time") as TextBox).Text;
            string query = "UPDATE [Approved] SET Fname=@Fname, Lname=@Lname, Mobile=@Mobile, Email=@Email, Booking=@Booking, Date_time=@Date_time WHERE Order_id=@Order_id";
            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Order_id", Order_id);
                    cmd.Parameters.AddWithValue("@Fname", Fname);
                    cmd.Parameters.AddWithValue("@Lname", Lname);
                    cmd.Parameters.AddWithValue("@Mobile", Mobile);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Booking", Booking);
                    cmd.Parameters.AddWithValue("@Date_time", Date_time);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Order_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "INSERT INTO History (Fname, Lname, Mobile, Email, Booking, Date_time)" +
                           "SELECT Fname, Lname, Mobile, Email, Booking, Date_time FROM [Approved] WHERE Order_id=@Order_id";
            string Delete = "DELETE FROM [Approved] WHERE Order_id=@Order_id";
            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Order_id", Order_id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                using (SqlCommand cmd = new SqlCommand(Delete))
                {
                    cmd.Parameters.AddWithValue("@Order_id", Order_id);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this reservation?');";
            }
        }


        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

    }
}