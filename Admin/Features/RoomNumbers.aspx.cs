using System;
using System.Web.UI.WebControls;

public partial class RoomNumbers : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewRoomNumbers();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString());
            }
        }
    }

    private void LoadDataGridViewRoomNumbers()
    {
        try
        {
            GridViewRoomNumbers.DataSource = new CRoomNumbers().RoomNumbersDataTable();
            GridViewRoomNumbers.SelectedIndex = -1;
            GridViewRoomNumbers.Columns[1].Visible = true;
            GridViewRoomNumbers.DataBind();
            GridViewRoomNumbers.Columns[1].Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int intRoomId;

            if (GridViewRoomNumbers.SelectedRow != null)
            {
                intRoomId = int.Parse(GridViewRoomNumbers.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            }
            else
            {
                intRoomId = 0;
            }
            string strRoomNumber = txtRoomNumber.Text.ToString();

            CRoomNumbers Room = new CRoomNumbers();
            Room.RoomID = intRoomId;
            Room.RoomNumber = strRoomNumber;
            
            Room.Update();
            LoadDataGridViewRoomNumbers();
            txtRoomNumber.Text = "";


            /////////  This is the last thing to do    ///////////
            ///////////////////////////////////////////////
            this.Message1.ShowMessage("Room Number Updated.");
            //////////////////////////////////////////////


        }

        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString(), "Room Number Not Updated");
        }
    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/Features/Rooms.aspx", false);
        }
        catch { }

    }


    
    protected void GridViewRoomNumbers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomNumbers.SelectedRow != null)
            {
                //GridViewRoomNumbers.Columns[1].Visible = true;
                string strRoomNumber = GridViewRoomNumbers.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", "");
                //GridViewRoomNumbers.Columns[1].Visible = false;

                txtRoomNumber.Text = strRoomNumber;
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRoomNumbers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewRoomNumbers.DataSource = new CRoomNumbers().RoomNumbersDataTable();
            GridViewRoomNumbers.SelectedIndex = -1;
            GridViewRoomNumbers.Columns[1].Visible = true;
            GridViewRoomNumbers.PageIndex = e.NewPageIndex;
            GridViewRoomNumbers.DataBind();
            GridViewRoomNumbers.Columns[1].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
}