using System;
using System.Web.UI.WebControls;

public partial class Features : System.Web.UI.Page
{
    private CConnectivity Connectivity = new CConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadDataGridViewRoomFeatures();
            }
            catch (Exception ex)
            {
                this.Message1.ShowError(ex.Message.ToString());
            }
        }
    }

    private void LoadDataGridViewRoomFeatures()
    {
        try
        {
            GridViewRoomFeatures.DataSource = new CRoomFeatures().FeaturesDataTable();
            GridViewRoomFeatures.SelectedIndex = -1;
            GridViewRoomFeatures.Columns[1].Visible = true;
            GridViewRoomFeatures.DataBind();
            GridViewRoomFeatures.Columns[1].Visible = false;
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
            int intFeatureId;

            if (GridViewRoomFeatures.SelectedRow != null)
            {
                intFeatureId = int.Parse(GridViewRoomFeatures.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", ""));
            }
            else
            {
                intFeatureId = 0;
            }
            string strFeatureName = txtRoomFeatureName.Text.ToString();

            CRoomFeatures Feature = new CRoomFeatures();
            Feature.RoomFeatureID = intFeatureId;
            Feature.RoomFeatureName = strFeatureName;


            Feature.UpdateFeature();
            LoadDataGridViewRoomFeatures();
            txtRoomFeatureName.Text = "";


            /////////  This is the last thing to do    ///////////
            ///////////////////////////////////////////////
            this.Message1.ShowMessage("Room Feature Updated.");
            //////////////////////////////////////////////


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


    protected void GridViewRoomFeatures_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            GridViewRoomFeatures.DataSource = new CRoomFeatures().FeaturesDataTable();
            GridViewRoomFeatures.SelectedIndex = -1;
            GridViewRoomFeatures.Columns[1].Visible = true;
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
                //GridViewRoomFeatures.Columns[1].Visible = true;
                string strFeatureName =GridViewRoomFeatures.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", "");
                //GridViewRoomFeatures.Columns[1].Visible = false;

                txtRoomFeatureName.Text = strFeatureName;
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
    }
}