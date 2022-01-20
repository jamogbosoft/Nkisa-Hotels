using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduledEvents : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewScheduledEvents();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString(), "Error Initializing");
            }
        }
    }

    
    private void LoadDataGridViewScheduledEvents()
    {
        try
        {
            GridViewScheduledEvents.DataSource = new CEvents().EventsDataTable();
            GridViewScheduledEvents.SelectedIndex = -1;
            GridViewScheduledEvents.Columns[1].Visible = true;
            GridViewScheduledEvents.DataBind();
            GridViewScheduledEvents.Columns[1].Visible = false;

            if (GridViewScheduledEvents.Rows.Count != 0)
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

    protected void GridViewScheduledEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewScheduledEvents.DataSource = new CEvents().EventsDataTable();
            GridViewScheduledEvents.SelectedIndex = -1;
            GridViewScheduledEvents.Columns[1].Visible = true;
            GridViewScheduledEvents.PageIndex = e.NewPageIndex;

            GridViewScheduledEvents.DataBind();

            GridViewScheduledEvents.Columns[1].Visible = false;
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
    protected void GridViewScheduledEvents_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewScheduledEvents.SelectedRow != null)
            {
                int intContactID;


                GridViewScheduledEvents.Columns[1].Visible = true;


                intContactID = int.Parse(GridViewScheduledEvents.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                
                GridViewScheduledEvents.Columns[1].Visible = false;


                CEvents Events = new CEvents();

                Events.Delete(intContactID);

                LoadDataGridViewScheduledEvents();


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
            this.LoadDataGridViewScheduledEvents();
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
            CEvents Events = new CEvents();
            Events.DeleteAll();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}