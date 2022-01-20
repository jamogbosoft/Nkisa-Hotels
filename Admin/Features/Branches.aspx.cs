using System;
using System.Web.UI.WebControls;

public partial class Branches : System.Web.UI.Page
{
    private CBranch Branch;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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


    private void RefreshControls()
    {
        try
        {
            LoadDataGridViewBranches();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   

    private void LoadDataGridViewBranches()
    {
        try
        {
            GridViewBranches.DataSource = new CBranch().BranchDataTable();
            GridViewBranches.SelectedIndex = -1;
            GridViewBranches.Columns[2].Visible = true;
            GridViewBranches.DataBind();

            GridViewBranches.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            GridViewBranches.Columns[2].Visible = false;
        }
    }
       
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {            
            Branch = new CBranch();

            Branch.BranchName = txtBranch.Text.ToString();
            Branch.Address = txtAddress.Text.ToString();

            GridViewBranches.Columns[2].Visible = true;

            if (GridViewBranches.SelectedRow != null)
            {
                Branch.BranchID = int.Parse(GridViewBranches.SelectedRow.Cells[2].Text.ToString().Replace("&nbsp;", ""));                
                Branch.Update();
            }
            else
            {
                Branch.Add();
            }

            txtBranch.Text = "";
            txtAddress.Text = "";

            this.RefreshControls();

            GridViewBranches.Columns[2].Visible = false;

            /////////  This is the last thing to do    ///////////
            ///////////////////////////////////////////////
            this.Message1.ShowMessage("Branch Updated.");
            //////////////////////////////////////////////

        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString(), "Branch Not Updated");
        }
        finally
        {
            GridViewBranches.Columns[2].Visible = false;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("~/Admin/", false);
        }
        catch { }

    }
      
        
    protected void GridViewBranches_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GridViewBranches.SelectedRow != null)
            {
                GridViewBranches.Columns[2].Visible = true;

                txtBranch.Text = GridViewBranches.SelectedRow.Cells[1].Text.ToString().Replace("&nbsp;", "");
                txtAddress.Text = GridViewBranches.SelectedRow.Cells[3].Text.ToString().Replace("&nbsp;", "");

                GridViewBranches.Columns[2].Visible = false;
            }
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
        finally
        {
            GridViewBranches.Columns[2].Visible = false;
        }
    }
    protected void GridViewBranches_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewBranches.DataSource = new CBranch().BranchDataTable();
            GridViewBranches.SelectedIndex = -1;
            GridViewBranches.Columns[2].Visible = true;
            GridViewBranches.PageIndex = e.NewPageIndex;
            GridViewBranches.DataBind();

            GridViewBranches.Columns[2].Visible = false;
        }
        catch (Exception ex)
        {
            this.Message1.ShowError(ex.Message.ToString());
        }
        finally
        {
            GridViewBranches.Columns[2].Visible = false;
        }
    }
}