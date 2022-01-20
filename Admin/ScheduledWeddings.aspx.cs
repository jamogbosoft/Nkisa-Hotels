using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduledWeddings : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewScheduledWeddings();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString(), "Error Initializing");
            }
        }
    }

    
    private void LoadDataGridViewScheduledWeddings()
    {
        try
        {
            GridViewScheduledWeddings.DataSource = new CWedding().WeddingDataTable();
            GridViewScheduledWeddings.SelectedIndex = -1;
            GridViewScheduledWeddings.Columns[1].Visible = true;
            GridViewScheduledWeddings.DataBind();
            GridViewScheduledWeddings.Columns[1].Visible = false;

            if (GridViewScheduledWeddings.Rows.Count != 0)
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

    protected void GridViewScheduledWeddings_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewScheduledWeddings.DataSource = new CWedding().WeddingDataTable();
            GridViewScheduledWeddings.SelectedIndex = -1;
            GridViewScheduledWeddings.Columns[1].Visible = true;
            GridViewScheduledWeddings.PageIndex = e.NewPageIndex;

            GridViewScheduledWeddings.DataBind();

            GridViewScheduledWeddings.Columns[1].Visible = false;
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
    protected void GridViewScheduledWeddings_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewScheduledWeddings.SelectedRow != null)
            {
                int intContactID;


                GridViewScheduledWeddings.Columns[1].Visible = true;


                intContactID = int.Parse(GridViewScheduledWeddings.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                
                GridViewScheduledWeddings.Columns[1].Visible = false;


                CWedding Wedding = new CWedding();

                Wedding.Delete(intContactID);

                LoadDataGridViewScheduledWeddings();


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
            this.LoadDataGridViewScheduledWeddings();
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
            CWedding Wedding = new CWedding();
            Wedding.DeleteAll();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}