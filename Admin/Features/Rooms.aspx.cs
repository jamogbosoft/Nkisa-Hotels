using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rooms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillBranch();
                RefreshControls();

                GridViewRooms.Columns[1].Visible = false;
                GridViewRooms.Columns[2].Visible = false;
                GridViewRoomTypes.Columns[1].Visible = false;
                GridViewRoomTypes.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString());
            }
        }
    }

    private void FillBranch()
    {
        try
        {
            cboBranch.DataSource = new CBranch().BranchDataTable();
            cboBranch.DataTextField = "BranchName";
            cboBranch.DataValueField = "BranchID";
            cboBranch.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillRoomNumbers()
    {
        try
        {
            int intBranchId = int.Parse(cboBranch.SelectedValue.ToString());

            cboRoomNumbers.DataSource = new CRoomNumbers().AvailableRoomNumbersDataTable(intBranchId);
            cboRoomNumbers.DataTextField = "RoomNumber";
            cboRoomNumbers.DataValueField = "RoomID";
            cboRoomNumbers.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void RefreshControls()
    {
        try
        {
            FillRoomNumbers();
            LoadDataGridViewRoomTypes();
            ClearDataDridViewRooms();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void LoadDataGridViewRoomTypes()
    {
        try
        {
            int intBranchId = int.Parse(cboBranch.SelectedValue.ToString());

            GridViewRoomTypes.Columns[1].Visible = true;
            GridViewRoomTypes.Columns[2].Visible = true;
            GridViewRoomTypes.DataSource = new CRoomTypes(intBranchId).RoomTypesDataTable();
            GridViewRoomTypes.SelectedIndex = -1;
            GridViewRoomTypes.DataBind();
            GridViewRoomTypes.Columns[1].Visible = false;
            GridViewRoomTypes.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadDataGridViewRooms()
    {
        try
        {
            int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
            string strRoomTypeName = GridViewRoomTypes.SelectedRow.Cells[3].Text.ToString().Replace("&nbsp;", "");

            lblRoomType.Text = strRoomTypeName;

            CRooms Room = new CRooms();
            Room.RoomTypeID = intRoomTypeId;
            Room.BranchID = intBranchId;

            GridViewRooms.Columns[1].Visible = true;
            GridViewRooms.Columns[2].Visible = true;
            GridViewRooms.DataSource = Room.RoomsDataTable();
            GridViewRooms.SelectedIndex = -1;
            GridViewRooms.DataBind();
            GridViewRooms.Columns[1].Visible = false;
            GridViewRooms.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomTypes.SelectedRow != null)
            {
                int temp;
                if (int.TryParse(cboRoomNumbers.SelectedValue.ToString(), out temp))
                {
                    int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                    int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
                    string strRoomNumber = cboRoomNumbers.SelectedItem.Text;

                    CRooms Room = new CRooms();
                    Room.RoomTypeID = intRoomTypeId;
                    Room.BranchID = intBranchId;
                    Room.RoomNumber = strRoomNumber;

                    Room.Add();

                    LoadDataGridViewRooms();

                    FillRoomNumbers();
                }
                else { this.Message1.ShowError("Select the room number first.", "Room Number Not Updated"); }
            }
            else { this.Message1.ShowError("Select room type first.", "Room Number Not Updated"); }
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

    protected void GridViewRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomTypes.SelectedRow != null)
            {
                LoadDataGridViewRooms();
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRoomTypes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewRoomTypes.Columns[1].Visible = true;
            GridViewRoomTypes.Columns[2].Visible = true;
            GridViewRoomTypes.DataSource = new CRoomTypes().RoomTypesDataTable();
            GridViewRoomTypes.SelectedIndex = -1;
            GridViewRoomTypes.PageIndex = e.NewPageIndex;
            GridViewRoomTypes.DataBind();
            GridViewRoomTypes.Columns[1].Visible = false;
            GridViewRoomTypes.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }

    private void ClearDataDridViewRooms()
    {
        try
        {
            GridViewRooms.DataSource = new DataTable();
            GridViewRooms.SelectedIndex = -1;
            GridViewRooms.DataBind();


            lblRoomType.Text = "";
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRooms_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));


            CRooms Room = new CRooms();
            Room.RoomTypeID = intRoomTypeId;
            Room.BranchID = intBranchId;

            GridViewRooms.Columns[1].Visible = true;
            GridViewRooms.Columns[2].Visible = true;
            GridViewRooms.DataSource = Room.RoomsDataTable();
            GridViewRooms.SelectedIndex = -1;
            GridViewRooms.PageIndex = e.NewPageIndex;
            GridViewRooms.DataBind();
            GridViewRooms.Columns[1].Visible = false;
            GridViewRooms.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRooms_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRooms.SelectedRow != null)
            {
                GridViewRooms.Columns[1].Visible = true;
                GridViewRooms.Columns[2].Visible = true;

                int intBranchId = int.Parse(GridViewRooms.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                int intRoomTypeId = int.Parse(GridViewRooms.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
                string strRoomNumber = GridViewRooms.SelectedRow.Cells[4].Text.ToString().Replace("&nbsp;", "");

                GridViewRooms.Columns[1].Visible = false;
                GridViewRooms.Columns[2].Visible = false;


                CRooms Room = new CRooms();
                Room.BranchID = intBranchId;
                Room.RoomTypeID = intRoomTypeId;
                Room.RoomNumber = strRoomNumber;

                Room.Delete();

                LoadDataGridViewRooms();

                FillRoomNumbers();

            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.RefreshControls();
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void ImageButtonEditFeatures_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/Features/RoomNumbers.aspx");
    }
}