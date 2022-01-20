using System;
using System.Web.UI.WebControls;

public partial class RoomTypes : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillDropDownLists();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString());
            }
        }
    }

    /// <summary>
    /// private void FillDropDownLists
    /// </summary>
    private void FillDropDownLists()
    {
        try
        {
            this.FillBranches();

            this.RefreshControls();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// private void Fill Branches
    /// </summary>
    private void FillBranches()
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
       
    private void RefreshControls()
    {
        try
        {
            LoadDataGridViewRoomTypes();
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
            int intBranch = int.Parse(cboBranch.SelectedValue.ToString());

            CRoomTypes RoomType = new CRoomTypes(intBranch);

            GridViewRoomTypes.DataSource = RoomType.RoomTypesDataTable();
            GridViewRoomTypes.SelectedIndex = -1;
            GridViewRoomTypes.Columns[1].Visible = true;
            GridViewRoomTypes.Columns[2].Visible = true;
            GridViewRoomTypes.DataBind();

            GridViewRoomTypes.Columns[1].Visible = false;
            GridViewRoomTypes.Columns[2].Visible = false;
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
            if (this.IsControlsValidated)
            {
                int intRoomTypeId, intBranchId;

                if (GridViewRoomTypes.SelectedRow != null)
                {
                    intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                    intBranchId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
                }
                else
                {
                    intRoomTypeId = 0;
                    intBranchId = int.Parse(cboBranch.SelectedValue.ToString());
                }

                CRoomTypes RoomType = new CRoomTypes();
                RoomType.RoomTypeID = intRoomTypeId;
                RoomType.BranchID = intBranchId;
                RoomType.RoomTypeName = txtRoomTypeName.Text.ToString();
                RoomType.PricePerNight = float.Parse(txtPricePerNight.Text.ToString());
                RoomType.BedSize = txtBedSize.Text.ToString();
                RoomType.MaxOccupancy = int.Parse(cboMaxOccupancy.SelectedValue.ToString());

                RoomType.Update();

                this.SaveImage(RoomType.RoomTypeID.ToString());

                LoadImage(RoomType.RoomTypeID.ToString());

                this.RefreshControls();

                EnableComboBoxes();
                ClearBoxes();

                /////////  This is the last thing to do    ///////////
                ///////////////////////////////////////////////
                this.Message1.ShowMessage("Room Type Updated.");
                //////////////////////////////////////////////

            }
        }

        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString(), "Room Type Not Updated");
        }
    }

    private bool IsControlsValidated
    {
        get
        {
            try
            {
                bool fileOK = false;

                if (FileUploadRoomTypeImage.HasFile)
                {
                    string fileExtension =
                        System.IO.Path.GetExtension(FileUploadRoomTypeImage.FileName).ToLower();

                    string[] allowedExtensions = { ".jpg", ".jpeg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                            break;
                        }
                    }
                }
                
                if (fileOK)
                {
                    if (FileUploadRoomTypeImage.PostedFile.ContentLength > 500000)
                    {
                        Message1.ShowError("Image size should not be more than 500KB", "PASSPORT");
                        return false;
                    }
                }
                else if (FileUploadRoomTypeImage.HasFile)
                {
                    Message1.ShowError("Cannot accept file of this type.\nThe file must be of the type .jpg or .jpeg", "PASSPORT");
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }
    }

    private void SaveImage(string roomTypeId)
    {
        try
        {
            if (FileUploadRoomTypeImage.HasFile)
            {
                string path = Server.MapPath("~/Images/RoomTypes/");

                FileUploadRoomTypeImage.PostedFile.SaveAs(path + roomTypeId.ToString() + ".jpg");
            }
        }
        catch (Exception ex)
        {
            Message1.ShowError(ex.Message.ToString(), "ATTENTION PLEASE");
        }
    }

    private void LoadImage(string roomTypeId)
    {
        try
        {
            string strImagePath = "~/Images/RoomTypes/" + roomTypeId.ToString() + ".jpg";
            RoomTypeImage.ImageUrl = strImagePath;
        }
        catch { }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/Features/RoomTypes.aspx", false);
        }
        catch { }

    }
    
    private void EnableComboBoxes()
    {
        cboBranch.Enabled = true;
    }

    private void DisableComboBoxes()
    {
        cboBranch.Enabled = false;
    }
    private void ClearBoxes()
    {
        try
        {
            txtRoomTypeName.Text = "";
            txtPricePerNight.Text = "";
            txtBedSize.Text = "";
            cboMaxOccupancy.SelectedIndex = 0;
            RoomTypeImage.ImageUrl = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void GridViewRoomTypes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int intBranch = int.Parse(cboBranch.SelectedValue.ToString());

            CRoomTypes RoomType = new CRoomTypes(intBranch);

            GridViewRoomTypes.DataSource = RoomType.RoomTypesDataTable();
            GridViewRoomTypes.SelectedIndex = -1;
            GridViewRoomTypes.Columns[1].Visible = true;
            GridViewRoomTypes.Columns[2].Visible = true;
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
    protected void GridViewRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewRoomTypes.SelectedRow != null)
            {
                GridViewRoomTypes.Columns[1].Visible = true;
                GridViewRoomTypes.Columns[2].Visible = true;
                int intRoomTypeId = int.Parse(GridViewRoomTypes.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
                int intBranch = int.Parse(GridViewRoomTypes.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));
                GridViewRoomTypes.Columns[1].Visible = false;
                GridViewRoomTypes.Columns[2].Visible = false;

                cboBranch.SelectedValue = intBranch.ToString();
                                
                txtRoomTypeName.Text = GridViewRoomTypes.SelectedRow.Cells[3].Text.ToString().Replace("&nbsp;", "");
                txtPricePerNight.Text = GridViewRoomTypes.SelectedRow.Cells[4].Text.ToString().Replace("&nbsp;", "");
                txtBedSize.Text = GridViewRoomTypes.SelectedRow.Cells[5].Text.ToString().Replace("&nbsp;", "");
                cboMaxOccupancy.SelectedValue= GridViewRoomTypes.SelectedRow.Cells[6].Text.ToString().Replace("&nbsp;", "");

                LoadImage(intRoomTypeId.ToString());
 
                DisableComboBoxes();
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
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
    
}