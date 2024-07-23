using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Project
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                GridView1.Visible = false;
                GridView2.Visible = false;

            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Approved]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Order]"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            Label1.Text = "Approved Reservations: "  + (GridView1.DataSource as DataTable).Rows.Count;
        }

        protected void AOnDataBound(object sender, EventArgs e)
        {
            Label2.Text = "Pending Reservations: " + (GridView2.DataSource as DataTable).Rows.Count;
        }


    }
}
                
    
