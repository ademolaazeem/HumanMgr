using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Security.Principal.IPrincipal;
//using System.Web
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
//System.Web.Profile
using System.Web.Security;
//

using System.Data;
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
//using DAL.Dalcs;
using System.IO;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//using DAL;
using BLL;
//

public partial class Account_forms_staffPasswordReset : System.Web.UI.UserControl
{
    //onrowcommand="GridView2_RowCommand"
    protected void lnkPersoForm_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;

        string CommandName = btn.CommandName;

        string CommandArgument = btn.CommandArgument;

        //GridViewRow envGridRow;
        //Button ticketButton;
        //String envId;
        userID.Value = CommandArgument;
       // lblUsrId.Text = userID.Value;


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //I just added this code now
        DataTable table;
        table = crudsbLL.list_staff();
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        //End I just added the code now

       // SetDefaultButton(txtsearch, btnsearch);      



    }

    private void SetDefaultButton(TextBox txt, Button defaultButton)
    {
        txt.Attributes.Add("onkeydown", "funfordefautenterkey1(" + defaultButton.ClientID + ",event)");
    }



    ////protected void btnsearch_Click(object sender, EventArgs e)
    ////{
    ////    DataTable table;
    ////    //String staffname = txtsearch.Text.ToUpper;
    ////    table = crudsbLL.list_staff(txtsearch.Text.ToUpper());
    ////    //
    ////    Gridview1.DataSource = table;
    ////    Gridview1.DataBind();
    ////}
    //from google
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }
    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview1.PageIndex = e.NewPageIndex;
        Gridview1.DataBind();
    }

    protected void Gridview1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = Gridview1.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            Gridview1.DataSource = dataView;
            Gridview1.DataBind();
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;
          //  lblUsrId.Text = RowIndex.ToString();

            //


            //// Determine GridRow
            // gvr.d
            //
            //int EmployeeID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[0]);
        }
    }
    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // txtfname.Text = Gridview1.SelectedRow.Cells[1].Text;
        userID.Value = Gridview1.SelectedRow.Cells[3].Text;
        lbluserid.Text = Gridview1.SelectedRow.Cells[3].Text;
        lblusername.Text = Gridview1.SelectedRow.Cells[2].Text;
        username.Value = Gridview1.SelectedRow.Cells[2].Text;
        //ddlocked
        ddlocked.SelectedValue = Gridview1.SelectedRow.Cells[4].Text;
        ddnew_user.SelectedValue = Gridview1.SelectedRow.Cells[5].Text;
       
    }

    //end from google
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string passW = "sHoNH0PwtK/8LxrjbzKo3w==";

        int rst = crudsbLL.update_staff(username.Value, userID.Value, ddlocked.SelectedValue, ddnew_user.SelectedValue, passW);

        if (rst == 1)
        {
            // lblstatus.Text = "Customer Record Setup Successful:" + chkCustId.ToString();
            lblstatus.Text = "SUCCESS: "+ username.Value  +"'s Information has been successfully Updated!";
            lblstatus.ForeColor = System.Drawing.Color.Blue;


            DataTable table;
            //String staffname = txtsearch.Text.ToUpper;
            table = crudsbLL.list_staff();
            //
            Gridview1.DataSource = table;
            Gridview1.DataBind();
            
          
        }
        else
        {
            lblstatus.Text = "ERROR: This Operation has failed, Please try again later!";// +rst.ToString();
            lblstatus.ForeColor = System.Drawing.Color.Red;
        }
    }





   
}