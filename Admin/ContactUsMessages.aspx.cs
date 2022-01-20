using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUsMessages : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewContactUsMessages();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString(), "Error Initializing");
            }
        }
    }

    
    private void LoadDataGridViewContactUsMessages()
    {
        try
        {
            GridViewContactUsMessages.DataSource = new CContactUs().ContactUsDataTable();
            GridViewContactUsMessages.SelectedIndex = -1;
            GridViewContactUsMessages.Columns[1].Visible = true;
            GridViewContactUsMessages.DataBind();
            GridViewContactUsMessages.Columns[1].Visible = false;

            if (GridViewContactUsMessages.Rows.Count != 0)
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

    protected void GridViewContactUsMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewContactUsMessages.DataSource = new CContactUs().ContactUsDataTable();
            GridViewContactUsMessages.SelectedIndex = -1;
            GridViewContactUsMessages.Columns[1].Visible = true;
            GridViewContactUsMessages.PageIndex = e.NewPageIndex;

            GridViewContactUsMessages.DataBind();

            GridViewContactUsMessages.Columns[1].Visible = false;
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

    protected void GridViewContactUsMessages_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewContactUsMessages.SelectedRow != null)
            {
                int intContactID;


                GridViewContactUsMessages.Columns[1].Visible = true;


                intContactID = int.Parse(GridViewContactUsMessages.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                
                GridViewContactUsMessages.Columns[1].Visible = false;


                CContactUs ContactUs = new CContactUs();

                ContactUs.Delete(intContactID);

                LoadDataGridViewContactUsMessages();


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
            this.LoadDataGridViewContactUsMessages();
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
            CContactUs ContactUs = new CContactUs();
            ContactUs.DeleteAll();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }    
}