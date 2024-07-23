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
    public partial class Pending : System.Web.UI.Page
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
            string query = "SELECT * FROM [Order]";
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
            int Order_id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Values[0]);
            string query = "INSERT INTO Approved (Fname, Lname, Mobile, Email, Booking, Date_time)" +
                           "SELECT Fname, Lname, Mobile, Email, Booking, Date_time FROM [Order] WHERE Order_id=@Order_id";
            string Delete = "DELETE FROM [Order] WHERE Order_id=@Order_id";
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
                Response.Redirect("Pending.aspx");
            }

            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Order_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "INSERT INTO History (Fname, Lname, Mobile, Email, Booking, Date_time)" +
                           "SELECT Fname, Lname, Mobile, Email, Booking, Date_time FROM [Order] WHERE Order_id=@Order_id";
            string Delete = "DELETE FROM [Order] WHERE Order_id=@Order_id";
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
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to decline this reservation?');";
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }        
    }
}