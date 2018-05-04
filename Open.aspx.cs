using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Open : System.Web.UI.Page
{
    protected GlobalsAdmin ga;
    protected DataSet mdsTask;
    int mintErrorCnt;

    protected void Page_Load(object sender, EventArgs e)
    {
        ga = new GlobalsAdmin(this);

       // ga.isAdmin();

        this.btnSave.Attributes.Add("OnClick", "return confirm('Do you want to Open the time for this task ?');");

        if (!this.IsPostBack)
        {
            fillTask();
            this.tbO_StartDate.Enabled = false;
            this.tbO_EndDate.Enabled = false;
            this.tbO_EstHrs.Enabled = false;
            this.tbO_OpenTime.Enabled = false;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        checkMandatory();
        if (mintErrorCnt < 1)
        {
            insertValues();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void ddlO_Task_SelectedIndexChanged(object sender, EventArgs e)
    {
        showTimings();
    }

    protected void fillTask()
    {
        this.mdsTask = ga.fillDataSet("spTask_Fill", "@T_ID", 0, "tblTask");
        this.ddlO_Task.DataValueField = "A_Task_ID";
        this.ddlO_Task.DataTextField = "T_Name";
        this.ddlO_Task.Items.Clear();
        this.ddlO_Task.DataSource = this.mdsTask.Tables["tblTask"].DefaultView;
        this.ddlO_Task.DataBind();

        this.ddlO_Task.Items.Insert(0, new ListItem("--- Select a Task ---", "0"));
    }

    private void showTimings()
    {
        if (this.ddlO_Task.SelectedIndex == 0)
        {
            this.tbO_StartDate.Text = "";
            this.tbO_EndDate.Text = "";
            this.tbO_EstHrs.Text = "";
            this.tbO_OpenTime.Text = "";
            return;
        }

        SqlCommand cmd = this.ga.gCn.CreateCommand();
        cmd.CommandText = "spTask_Fill";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@T_ID", this.ddlO_Task.SelectedValue);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            DateTime dtStartDate = DateTime.Parse(dr[3].ToString());
            DateTime dtEndDate = DateTime.Parse(dr[4].ToString());
            float dtEstHrs = float.Parse(dr[5].ToString());

            this.tbO_StartDate.Text = dtStartDate.ToString();
            this.tbO_EndDate.Text = dtEndDate.ToString();
            this.tbO_EstHrs.Text = dtEstHrs.ToString();
        }
        DateTime dtOpenTime = DateTime.Parse(System.DateTime.Now.ToLocalTime().ToString());
        tbO_OpenTime.Text = dtOpenTime.ToString();
    }

    private void checkMandatory()
    {
        isExistOpen();

        if (this.ddlO_Task.SelectedIndex == 0 || this.cbO_Active.Checked == false)
        {
            mintErrorCnt = 1;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "All Fields are Mandatory. Mandatory Fields should not be blank";
            return;
        }
    }

    protected void isExistOpen()
    {
        SqlCommand cmd = this.ga.gCn.CreateCommand();
        cmd.CommandText = "spOpen_ExistTask";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@O_Task_ID", this.ddlO_Task.SelectedValue);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "The Task has beeb opened already.";

            mintErrorCnt = 1;

            dr.Close();
            cmd.Dispose();
            return;
        }
        dr.Close();
        cmd.Dispose();
    }

    protected void insertValues()
    {
        SqlCommand cmd = this.ga.gCn.CreateCommand();
        cmd.CommandText = "spOpenIn_Insert";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter parO_ID = new SqlParameter("@O_ID", SqlDbType.Int);
        parO_ID.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parO_ID);

        SqlParameter parRecordCount = new SqlParameter("@RowCount", SqlDbType.Int);
        parRecordCount.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(parRecordCount);

        int intOActive;
        if (this.cbO_Active.Checked == true)
            intOActive = 1;
        else
            intOActive = 0;

        cmd.Parameters.AddWithValue("@O_Task_ID", this.ddlO_Task.SelectedValue);
        cmd.Parameters.AddWithValue("@O_OpenTime", this.tbO_OpenTime.Text);
        cmd.Parameters.AddWithValue("@O_Active", intOActive);
        cmd.ExecuteNonQuery();

        if (parRecordCount.Value.ToString() != "0")
        {
            lblMsg.ForeColor = Color.DarkGreen;
            lblMsg.Text = "New Task has been created successfully !!!";
        }
        else
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "Sorry. This Project has not been created.";
        }
    }

    private void reset()
    {
        this.ddlO_Task.SelectedIndex = 0;
        this.tbO_StartDate.Text = "";
        this.tbO_EndDate.Text = "";
        this.tbO_OpenTime.Text = "";
        this.tbO_EstHrs.Text = "";
        this.cbO_Active.Checked = false;
    }
}
