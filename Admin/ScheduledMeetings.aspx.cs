using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduledMeetings : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewScheduledMeetings();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString(), "Error Initializing");
            }
        }
    }

    
    private void LoadDataGridViewScheduledMeetings()
    {
        try
        {
            GridViewScheduledMeetings.DataSource = new CMeeting().MeetingDataTable();
            GridViewScheduledMeetings.SelectedIndex = -1;
            GridViewScheduledMeetings.Columns[1].Visible = true;
            GridViewScheduledMeetings.DataBind();
            GridViewScheduledMeetings.Columns[1].Visible = false;

            if (GridViewScheduledMeetings.Rows.Count != 0)
            {
                btnDeleteAll.Visible = true;
            }
            else { btnDeleteAll.Visible = false; }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridViewScheduledMeetings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewScheduledMeetings.DataSource = new CMeeting().MeetingDataTable();
            GridViewScheduledMeetings.SelectedIndex = -1;
            GridViewScheduledMeetings.Columns[1].Visible = true;
            GridViewScheduledMeetings.PageIndex = e.NewPageIndex;

            GridViewScheduledMeetings.DataBind();

            GridViewScheduledMeetings.Columns[1].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }

    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        //this.txtRemark.Text = "Deleted"; //Testing! Teasting!! Testing!!!
    }
    protected void GridViewScheduledMeetings_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewScheduledMeetings.SelectedRow != null)
            {
                int intContactID;


                GridViewScheduledMeetings.Columns[1].Visible = true;


                intContactID = int.Parse(GridViewScheduledMeetings.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                
                GridViewScheduledMeetings.Columns[1].Visible = false;


                CMeeting Meeting = new CMeeting();

                Meeting.Delete(intContactID);

                LoadDataGridViewScheduledMeetings();


                /////////  This is the last thing to do    //////
                ///////////////////////////////////////////////
                this.Message1.ShowMessage("Message Deleted.");
                //////////////////////////////////////////////
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        try
        {
            this.DeleteAllMessages();
            this.LoadDataGridViewScheduledMeetings();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString(), "Error");
        }
    }

    /// <summary>
    /// Delete All Messages
    /// </summary>
    private void DeleteAllMessages()
    {
        try
        {
            CMeeting Meeting = new CMeeting();
            Meeting.DeleteAll();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}