using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter ada = new SqlDataAdapter();
    DataSet ds = new DataSet();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //con.ConnectionString = "Data Source=IMRAN;Initial Catalog=login;Integrated Security=True";
        //con.Open();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        cmd.CommandText = "select * from tbl_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";

        cmd.Connection = con;
        ada.SelectCommand = cmd;
        ada.Fill(ds, "tbl_login");

        if (ds.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("About.aspx");
        }
        else
        {
            Response.Write("incorrect login or password");

        }
    }
}