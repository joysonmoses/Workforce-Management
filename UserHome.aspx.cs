using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class UserHome : System.Web.UI.Page
{
    protected GlobalsAdmin ga;
    protected DataSet udsUser;
    protected DataSet udsTask;
    protected string ustrQS;
    // protected SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["uname"] == null)
        {
            Response.Redirect("UserHome.aspx");
        }

        else
        {
            ga = new GlobalsAdmin(this);
            fillProject();
            //ga.isAdmin();
            //ga.isUser();

            if (!this.IsPostBack)
            {

                if (Request.QueryString["id"] == "t")
                {
                    lblReportTitle.Text = "Report - All Projects";
                    fillProject();
                }
                else if (Request.QueryString["id"] == "ct")
                {
                    lblReportTitle.Text = "Report - Completed Tasks";
                    fillTask();
                }
                else if (Request.QueryString["id"] == "aa")
                {
                    lblReportTitle.Text = "Open";
                    Response.Redirect("~/Open.aspx");
                }
            }
        }
    }
    public  void fillProject()
    {
        string val = Session["uname"].ToString();
        //string val = "Raja";
        lbl_username.Text = Session["uname"].ToString();
        
        // SqlCommand cmd=new SqlCommand("select U_Name,P_Name,Pr_Name,P_StartDate,P_EndDate,Pl_Name from tblAssign,tblUser,tblProject,tblPriorities,tblPlatform where tblAssign.A_User_ID=tblUser.U_ID and tblAssign.A_Project_ID=tblProject.P_ID and tblPriorities.P_ID=tblProject.P_Priority and tblProject.P_Platform=tblPlatform.P_ID");

        string sql = "select U_Name,Plot_Name,Pro_Name,P_StartDate,P_EndDate from tblAssign,tblUser,tblProject,tblPriorities,tblPlatform where tblAssign.A_User_ID=tblUser.U_ID and tblAssign.A_Project_ID=tblProject.P_ID and tblPriorities.P_ID=tblProject.P_Priority and tblProject.P_Platform=tblPlatform.P_ID and U_UserName='" + val.ToString() + "'";
        //string sql = "select * from tblAssign";
        DataSet mdsProject = ga.fillDataSet(sql, "tblProject");
        this.gvUserHome.DataSource = mdsProject.Tables["tblProject"].DefaultView;
        this.gvUserHome.DataBind();

        try
        {
            gvUserHome.DataBind();

        }
        catch
        {
            gvUserHome.PageIndex = 0;

        }
    }
    public  void fillTask()
    {
        string val = Session["uname"].ToString();
        //string val = "Raja";
        string sql1 = "select T_Name,T_StartDate,T_EndDate,T_EstimatedHours from tblTask,tblProject,tblAssign,tblUser where tblTask.T_Project=tblProject.P_ID and tblAssign.A_Task_ID=tblTask.T_ID and tblAssign.A_User_ID=tblUser.U_ID and U_UserName='" + val.ToString() + "'";
        DataSet mdsProject = ga.fillDataSet(sql1, "tblTask");
        this.gvUserHome.DataSource = mdsProject.Tables["tblTask"].DefaultView;
        this.gvUserHome.DataBind();
        try
        {
            gvUserHome.DataBind();

        }
        catch
        {
            gvUserHome.PageIndex = 0;

        }
     }

}