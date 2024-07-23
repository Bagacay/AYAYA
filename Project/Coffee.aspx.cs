using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        protected void ORDER_Btn_Click(object sender, EventArgs e)
        {
            con.Open();
            string insert = "INSERT INTO [Order](Fname, Lname, Mobile, Email, Booking, Date_time) " +
            "values(@Fname, @Lname, @Mobile, @Email, @Booking, @Date_time)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@Fname", Fname.Text);
            cmd.Parameters.AddWithValue("@Lname", Lname.Text);
            cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
            cmd.Parameters.AddWithValue("@Email", Email.Text);
            cmd.Parameters.AddWithValue("@Booking", Booking.Text);
            cmd.Parameters.AddWithValue("@Date_time", Date_time.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script type='text/javascript'>");
            Response.Write("alert('Successfully Added!');");
            Response.Write("document.location.href='Coffee.aspx';");
            Response.Write("</script>");
        }
    }
}