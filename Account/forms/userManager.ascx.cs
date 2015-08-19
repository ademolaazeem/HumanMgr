using System.Linq;
//
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
//using System.Web.Profile;
//using System.Web.Security;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



//using Oracle.Web.Profile.OracleProfileProvider;
using BLL;
using DAL;

public partial class Account_forms_userManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Session["usr"].ToString();
        DataTable table;
        table = testBLL.GetByUsername(username);
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        //
        //ddBankList.Visible = false;
        //lblBanks.Visible = false;
        ////
        //ddBankList.DataSource = get_lists.GetInstitutionList_NG();
        ////table;
        ////
        //ddBankList.DataTextField = "instituitionname";
        //ddBankList.DataValueField = "bankfiid";
        //ddBankList.DataBind();
        //
        //string strName = "";
        //if (Session["usr"] == null)
        //{
        //    strName = Session["usr"].ToString();
        //}
        ////
        ////string strName = HttpContext.Current.User.Identity.Name.ToString();
        //lblstatus0.Text = strName;
        DateTime today = DateTime.Now;
        DateTime meetingAppt = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second);
       // lblstatus0.Text = today.Day.ToString() + "" + today.Hour.ToString ();


       // btnUpdateProfile0.Visible = false;
    }
    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // txtfname.Text = Gridview1.SelectedRow.Cells[1].Text;
        txtuser.Text = Gridview1.SelectedRow.Cells[1].Text;
        //retrieve user profile: permissions
        //ProfileCommon profile = this.Profile;

        //profile = this.Profile.GetProfile(txtuser.Text);
        //chkAccess_user.Checked = profile.usermgt.usermgtRole;
        ////
        //chkAccess_adj.Checked =profile.Upload.UploadRole ;
        ////
        //chkAccess_ojc.Checked = profile.Report.ReportRole;
        ////
        //chkAccess_audit.Checked = profile.Compute.ComputeRole;
    }

    //
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
    //
    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        //if (txtuser.Text == string.Empty)
        //{
        //    lblstatus.Text = "Enter Username";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //if (txtfName.Text  == string.Empty)
        //{
        //    lblstatus.Text = "Enter Full Name";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //if (txtEmail.Text == string.Empty)
        //{
        //    lblstatus.Text = "Enter Email Address";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        ////txtEmail
        //string bankfid="";
        //int bankfid_new = 0;

        //if (ddCategory.SelectedValue == "2")
        //{
        //    if (ddBankList.Visible == true)
        //    {

        //        bankfid = ddBankList.SelectedValue;
        //    }
        //    //else
        //    //{
        //    //    bankfid = "";
        //    //}
        //}
        //else
        //{
        //    bankfid_new = 1;
        //}
        
        //// defaultPassword = Membership.GeneratePassword(8, 2);
        ////
        //string  defaultPassword = Membership.GeneratePassword(8, 2);
        //int rst = crudsbLL.CreateUser(txtuser.Text, txtfName.Text, txtEmail.Text, ddCategory.SelectedValue, bankfid_new, Profile.UserName, defaultPassword);
        ////check for exsiting username
        //if (rst == 3)
        //{
        //    lblstatus.Text = "User: " + txtuser.Text + " already created";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;

        //    btnUpdateProfile0.Visible = true;
        //    btnUpdateProfile.Visible = false;
        //    return;//3;//duplicate username
        //}
        //if (rst == -1)
        //{
        //    ProfileCommon profile = this.Profile;
        //    profile = this.Profile.GetProfile(txtuser.Text);

        //    //cannot delete and modify current profile
        //    //if (Context.User.Identity.Name == txtuser.Text)
        //    // {
        //    //  lblstatus.Text = "You cannot modify current profile";
        //    //  lblstatus.ForeColor = System.Drawing.Color.Red;
        //    // return;
        //    //}
        //    //
        //    if (chkAccess_admin.Checked)
        //    {


        //        profile.usermgt.usermgtRole = chkAccess_user.Checked = true;
        //        //
        //        profile.Upload.UploadRole = chkAccess_adj.Checked = true;
        //        //
        //        profile.Report.ReportRole = chkAccess_ojc.Checked = true;
        //        //
        //        profile.Compute.ComputeRole = chkAccess_audit.Checked = true;

        //    }
        //    else
        //    {

        //        // profile.Admin.AdminRole = chkAccess_admin.Checked == true ? true : false;
        //        //
        //        profile.usermgt.usermgtRole = chkAccess_user.Checked == true ? true : false;
        //        //
        //        profile.Upload.UploadRole = chkAccess_adj.Checked == true ? true : false;
        //        //
        //        profile.Report.ReportRole = chkAccess_ojc.Checked == true ? true : false;
        //        //
        //        profile.Compute.ComputeRole = chkAccess_audit.Checked == true ? true : false;
        //        //
        //    }
        //    profile.Save();
        //    //
           
        //    //KEEP AUDIT LOG
        //    string action_performed = "PERMISSION GRANTED: ";
        //    //chkAccess_GeneralSetUpModule.Checked == true
        //    if (chkAccess_user.Checked == true)
        //        action_performed += "User Managements";
        //    else if (chkAccess_adj.Checked == true)
        //        action_performed += "Setup Data Module";
        //    else if (chkAccess_ojc.Checked == true)
        //        action_performed += "Process Module";
        //    else if (chkAccess_audit.Checked == true)
        //        action_performed += "Reports Module";
        //    else
        //        action_performed += "Admin Permission";

        //    userAuditBLL.Add_Permission(txtuser.Text, action_performed, Profile.UserName);
        //    //txtuser.Text, txtfName.Text, txtEmail.Text
        //    crudsbLL.SendEmailToUser(txtEmail.Text, txtuser.Text, defaultPassword, "Your account has been created ");
        //    lblstatus.Text = "Username Profile has been created";
        //    lblstatus.ForeColor = System.Drawing.Color.Blue;

        //    //RESET CONTROLS
        //    btnUpdateProfile0.Visible = false;
        //    btnUpdateProfile.Visible = true;
        //    //clear text boxes
        //}
        //else
        //{
        //    lblstatus.Text = "Error: Operation failed ";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //}
        ////
        
        //int audit= userAuditBLL.Add_Permission(txtuser.Text, action_performed, Profile.UserName);
        //if (audit == -1)
        //{
        //    lblstatus0.Text = audit.ToString();
        //}
        //
       
    }
    //protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddCategory.SelectedValue == "2")
    //    {
    //        ddBankList.Visible = true;
    //        lblBanks.Visible = true;
    //    }
    //}
    protected void btnUpdateProfile0_Click(object sender, EventArgs e)
    {
        //ProfileCommon profile = this.Profile;
        //profile = this.Profile.GetProfile(txtuser.Text);

        //cannot delete and modify current profile
        //if (Context.User.Identity.Name == txtuser.Text)
        // {
        //  lblstatus.Text = "You cannot modify current profile";
        //  lblstatus.ForeColor = System.Drawing.Color.Red;
        // return;
        //}
        //
        //if (chkAccess_admin.Checked)
        //{


        //    profile.usermgt.usermgtRole = chkAccess_user.Checked = true;
        //    //
        //    profile.Upload.UploadRole = chkAccess_adj.Checked = true;
        //    //
        //    profile.Report.ReportRole = chkAccess_ojc.Checked = true;
        //    //
        //    profile.Compute.ComputeRole = chkAccess_audit.Checked = true;

        //}
        //else
        //{

        //    // profile.Admin.AdminRole = chkAccess_admin.Checked == true ? true : false;
        //    //
        //    profile.usermgt.usermgtRole = chkAccess_user.Checked == true ? true : false;
        //    //
        //    profile.Upload.UploadRole = chkAccess_adj.Checked == true ? true : false;
        //    //
        //    profile.Report.ReportRole = chkAccess_ojc.Checked == true ? true : false;
        //    //
        //    profile.Compute.ComputeRole = chkAccess_audit.Checked == true ? true : false;
        //    //
        //}
        //profile.Save();
        //
        //if (Context.User.Identity.Name == txtuser.Text)
        //{
        //    lblstatus.Text = "You cannot modify current profile";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //
        string userID = Session["usr"].ToString();
        //
        string user = "0";
        if (chkAccess_user.Checked == true)//? true : false;
            user = "1";
        //else
        string staff = "0";
        if (chkAccess_stf.Checked == true)//? true : false;
            staff = "1";
        

        //
        if (txtuser.Text == string.Empty)
        {
            lblstatus.Text = "Enter Username";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //add user permissions
        try
        {
         
                string usr = cruds.Add_User_permission(txtuser.Text, user, staff);
                if (usr == "-1")
                {
                    //

                    //KEEP AUDIT LOG
                    //string action_performed = "PERMISSION GRANTED: ";
                    ////chkAccess_GeneralSetUpModule.Checked == true
                    //if (chkAccess_user.Checked == true)
                    //    action_performed += "User Managements";
                    //else if (chkAccess_stf.Checked == true)
                    //    action_performed += "Manage Customer Module";
                    //else
                    //    action_performed += "Admin Permission";

                    //userAuditBLL.Add_Permission(txtuser.Text, action_performed, userID);
                    //txtuser.Text, txtfName.Text, txtEmail.Text
                    //crudsbLL.SendEmailToUser(txtEmail.Text, txtuser.Text, "", "Your account has been updated ");
                    lblstatus.Text = "Username Profile has been updated";
                    lblstatus.ForeColor = System.Drawing.Color.Blue;

                }
                else
                {
                    //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                    lblstatus.Text = "Error: Operation failed " + usr.ToString() ;// +rst.ToString();
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                    return;

                }
          }
           catch (Exception ex)
           {
               lblstatus.Text = "Object Error: " + ex.Message;
               lblstatus.ForeColor = System.Drawing.Color.Red;
               return;
           }
        //
       
    }


    
}