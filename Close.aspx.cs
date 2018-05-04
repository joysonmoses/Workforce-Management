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

public partial class Close : System.Web.UI.Page
{
    protected GlobalsAdmin ga;
    protected DataSet mdsTask;
    int mintErrorCnt;
    protected bool mboolT_Status;
    protected void Page_Load(object sender, EventArgs e)
    {
        ga = new GlobalsAdmin(this);
         this.btnSave.Attributes.Add("OnClick", "return confirm('Do you want to Close the time for this task ?');");

        if (!this.IsPostBack)
        {
            fillTask();
            this.tbC_StartTime.Enabled = false;
            this.tbC_EndTime.Enabled = false;
            this.tbC_EstHrs.Enabled = false;
            this.tbC_SpentTime.Enabled = false;
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

    protected void ddlC_Task_SelectedIndexChanged(object sender, EventArgs e)
    {
        showTimings();
    }

    protected void fillTask()
    {
        this.mdsTask = ga.fillDataSet("spClose_SelectTask", "@T_ID", 0, "tblOpenIn");
        this.ddlC_Task.DataValueField = "O_Task_ID";
        this.ddlC_Task.DataTextField = "T_Name";
        this.ddlC_Task.Items.Clear();
        this.ddlC_Task.DataSource = this.mdsTask.Tables["tblOpenIn"].DefaultView;
        this.ddlC_Task.DataBind();

        this.ddlC_Task.Items.Insert(0, new ListItem("--- Select a Task ---", "0"));
    }

    private void showTimings()
    {
        if (this.ddlC_Task.SelectedIndex == 0)
        {
            this.tbC_StartTime.Text = "";
            this.tbC_EndTime.Text = "";
            this.tbC_EstHrs.Text = "";
            this.tbC_SpentTime.Text = "";
            return;
        }

        SqlCommand cmd = this.ga.gCn.CreateCommand();
        cmd.CommandText = "spClose_SelectTask";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@T_ID", this.ddlC_Task.SelectedValue);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            DateTime dtStartTime = DateTime.Parse(dr[1].ToString());
            TimeSpan EstHrs = TimeSpan.Parse(dr[4].ToString());

            this.tbC_StartTime.Text = dtStartTime.ToString();
            this.tbC_EstHrs.Text = EstHrs.ToString();

            DateTime dtCloseTime = DateTime.Parse(System.DateTime.Now.ToLocalTime().ToString());
            tbC_EndTime.Text = dtCloseTime.ToString();
            TimeSpan  tsSpentTime = ((DateTime.Parse(System.DateTime.Now.ToLocalTime().ToString())) - ((DateTime.Parse(dtStartTime.ToString()))));
            this.tbC_SpentTime.Text = tsSpentTime.ToString();

            // Measure the performance of employee for this particular task. Status = 1 if he finishes the task within the estimated time.
            if (tsSpentTime < EstHrs)
            {
                mboolT_Status = true;
            }
            else
                mboolT_Status = false;
        }        
    }

    private void checkMandatory()
    {
        isExistClose();

        if (this.ddlC_Task.SelectedIndex == 0 || this.cbC_Active.Checked == false)
        {
            mintErrorCnt = 1;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "All Fields are Mandatory. Mandatory Fields should not be blank";
            return;
        }
    }

    protected void isExistClose()
    {
        SqlCommand cmd = this.ga.gCn.CreateCommand();
        cmd.CommandText = "spClose_ExistTask";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@C_Task_ID", this.ddlC_Task.SelectedValue);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "The Task has beeb Closed already.";

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
        cmd.CommandText = "spCloseOut_Insert";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter parC_ID = new SqlParameter("@C_ID", SqlDbType.Int);
        parC_ID.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(parC_ID);

        SqlParameter parRecordCount = new SqlParameter("@RowCount", SqlDbType.Int);
        parRecordCount.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(parRecordCount);

        int intCActive;
        if (this.cbC_Active.Checked == true)
            intCActive = 1;
        else
            intCActive = 0;

        cmd.Parameters.AddWithValue("@C_Task_ID", this.ddlC_Task.SelectedValue);
        cmd.Parameters.AddWithValue("@C_CloseTime", this.tbC_EndTime.Text);
        cmd.Parameters.AddWithValue("@C_TimeSpent", this.tbC_SpentTime.Text);
        cmd.Parameters.AddWithValue("@C_Status", mboolT_Status);
        cmd.Parameters.AddWithValue("@C_Active", intCActive);
        cmd.ExecuteNonQuery();

        if (parRecordCount.Value.ToString() != "0")
        {
            lblMsg.ForeColor = Color.DarkGreen;
            lblMsg.Text = "This task has been closed successfully !!!";
        }
        else
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = "Sorry. This task has not been closed. ";
        }
    }

    private void reset()
    {
        this.ddlC_Task.SelectedIndex = 0;
        this.cbC_Active.Checked = false;
        this.tbC_EndTime.Text = "";
        this.tbC_EstHrs.Text = "";
        this.tbC_SpentTime.Text = "";
        this.tbC_StartTime.Text = "";
    }
    }
