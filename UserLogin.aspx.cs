using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
    protected Globals gg;

    protected void Page_Load(object sender, EventArgs e)
    {
        gg = new Globals(this);
        gg.openConnection();

        Page.SetFocus(tbUserName); 
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // Must be called in the Page Unload.
        if (gg != null)
            gg.closeConnection();
        gg = null;
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        Session["uname"] = tbUserName.Text;
        if (tbUserName.Text != null || tbPassword.Text != null)
        {
            VerifyAuthentication();
        }
        else
        {
            lblMsg.Text = "Username or Password must not be blank";
            lblMsg.ForeColor = Color.Red;
        }
    }

    private void VerifyAuthentication()
    {
        SqlCommand cmd = this.gg.gCn.CreateCommand();
        cmd.CommandText = "spUser_Check";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter parRecordCount = new SqlParameter("@RowCount", SqlDbType.Int);
        parRecordCount.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(parRecordCount);

        cmd.Parameters.AddWithValue("@U_UserName", this.tbUserName.Text);
        cmd.Parameters.AddWithValue("@U_Password", this.tbPassword.Text);
        cmd.ExecuteNonQuery();

        if (parRecordCount.Value.ToString()== "1")
        {
            Response.Redirect("UserHome.aspx?id=t");
           // tbUserName.Text = "aaa";
           
        }
        else
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "Invalid UserName or Password.";
        }
    }
}