using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomFeatures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillBranch();
                FillFeatures();
                RefreshControls();
                GridViewRoomFeatures.Columns[1].Visible = false;
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

    private void FillFeatures()
    {
        try
        {
            cboRoomFeature.DataSource = new CRoomFeatures().FeaturesDataTable();
            cboRoomFeature.DataTextField = "FeatureName";
            cboRoomFeature.DataValueField = "FeatureID";
            cboRoomFeature.DataBind();
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
            LoadDataGridViewRoomTypes();
            ClearDataDridViewRoomFeatures();
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

    private void LoadDataGridViewRoomFeatures()
    {
        try
        {
            int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
            string strRoomTypeName = GridViewRoomTypes.SelectedRow.Cells[3].Text.ToString().Replace("&nbsp;", "");

            lblRoomType.Text = strRoomTypeName;

            CRoomFeatures RoomFeature = new CRoomFeatures();
            RoomFeature.RoomTypeID = intRoomTypeId;
            RoomFeature.BranchID = intBranchId;

            GridViewRoomFeatures.Columns[1].Visible = true;
            GridViewRoomFeatures.DataSource = RoomFeature.RoomFeaturesDataTable();
            GridViewRoomFeatures.SelectedIndex = -1;
            GridViewRoomFeatures.DataBind();
            GridViewRoomFeatures.Columns[1].Visible = false;
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
                if (int.TryParse(cboRoomFeature.SelectedValue.ToString(), out temp))
                {
                    int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                    int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
                    string strRoomFeatureName = cboRoomFeature.SelectedItem.Text;

                    CRoomFeatures RoomFeature = new CRoomFeatures();
                    RoomFeature.RoomTypeID  = intRoomTypeId;
                    RoomFeature.BranchID = intBranchId;
                    RoomFeature.RoomFeatureName = strRoomFeatureName;

                    RoomFeature.Add();

                    LoadDataGridViewRoomFeatures();

                    //this.Message1.ShowMessage("Room Feature Updated.");
                }
                else { this.Message1.ShowError("Select the room feature first.", "Room Feature Not Updated"); }
            }
            else { this.Message1.ShowError("Select room type first.", "Room Feature Not Updated"); }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString(), "Room Feature Not Updated");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/Features/RoomFeatures.aspx", false);
        }
        catch { }

    }

    protected void GridViewRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomTypes.SelectedRow != null)
            {
                LoadDataGridViewRoomFeatures();
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

    private void ClearDataDridViewRoomFeatures()
    {
        try
        {
            GridViewRoomFeatures.DataSource = new DataTable();
            GridViewRoomFeatures.SelectedIndex = -1;
            GridViewRoomFeatures.DataBind();


            lblRoomType.Text = "";
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRoomFeatures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            int intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));

            CRoomFeatures RoomFeature = new CRoomFeatures();
            RoomFeature.RoomTypeID  = intRoomTypeId;
            RoomFeature.BranchID = intBranchId;

            GridViewRoomFeatures.Columns[1].Visible = true;
            GridViewRoomFeatures.DataSource = RoomFeature.RoomFeaturesDataTable();
            GridViewRoomFeatures.SelectedIndex = -1;
            GridViewRoomFeatures.PageIndex = e.NewPageIndex;
            GridViewRoomFeatures.DataBind();
            GridViewRoomFeatures.Columns[1].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
    protected void GridViewRoomFeatures_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomFeatures.SelectedRow != null)
            {
                GridViewRoomFeatures.Columns[1].Visible = true;

                int intRoomFeatureId = int.Parse(GridViewRoomFeatures.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));

                GridViewRoomFeatures.Columns[1].Visible = false;

                CRoomFeatures RoomFeature = new CRoomFeatures();
                RoomFeature.Delete(intRoomFeatureId);

                LoadDataGridViewRoomFeatures();

                /////////  This is the last thing to do    //////
                ///////////////////////////////////////////////
               // this.Message1.ShowMessage("Room Feature Deleted.");
                //////////////////////////////////////////////
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
        Response.Redirect("~/Admin/Features/Features.aspx");
    }
}