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
//
using DAL;
using System.Data.SqlClient;



public partial class Account_newSite : System.Web.UI.MasterPage
{
    private const string BASE_PATH = "";// "~/DynamicControlLoading/";
    private string controlPath;//= string.Empty;
    //UpdatePanel1
    protected void UpdatePanel1_PreRender(object sender, EventArgs e)
    {
        // This code will only be executed if the partial postback
        //  was raised by a __doPostBack('UpdatePanel1', '')
        if (Request["__EVENTTARGET"] == UpdatePanel1.ClientID)
        {
            // Insert magic here.
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //
       // Label1.Text = HttpContext.Context.User.Identity.Name;
        if (Session["usr"] == null)
        {
            Response.Redirect("~/login.aspx");//rtlHome.aspx...newPage.aspx
        }
       Label1.Text = Session["usr"].ToString ();

       string user = Session["usr"].ToString();
        //
       LoadUserControl();
        //
       CheckAccess(user);
        //
        //menu5.Visible = false;
        //menu1.Visible = false;
        //menu4.Visible = false;

        //
       string ipAddress = Request.UserHostAddress;
       string ipAddress2 = HttpContext.Current.Request.UserHostAddress;

      YearLabel.Text = DateTime.Now.Year.ToString();

    }
    //
    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    //
    private void CheckAccess(string username)
    {
       // !Profile.ModuleAccess.GeneralSetUp 
        //if (!Profile.Upload.UploadRole)
        //{

        //    // UploadPane.Visible = false;
        //}
        ////
        //if (!Profile.usermgt.usermgtRole)
        //{
        //    //UserPane.Visible = false;
        //}
        ////
        //// if (!Profile.Admin.AdminRole)
        ////{
        //// RetailMenuPane.Visible = false;
        ////}
        ////
        //if (!Profile.Report.ReportRole)
        //{
        //    //
        //    // ReportPane.Visible = false;
        //}
        //if (!Profile.Compute.ComputeRole)
        //{
        //    //ComputePane.Visible = false;
        //}
        //if (!Profile.ReportBank.ReportBkRole)
        //{
        //    //ReportPaneBank.Visible = false;
        //}
        //ReportPaneBank
        //
        //if (!Profile)
        //if (! Profile.a)

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Dalcs.hm42ConnectionString;

        ////OracleCommand cmd = new OracleCommand();

        ////c//md.Connection = conn;

        //// con.ConnectionString = Dalcs.MisportalConnection;
       if (conn.State == ConnectionState.Closed)
        conn.Open();//re open if connection closed

        //// string sql2 = " SELECT     COUNT(*) AS Counter " +
        //// " FROM TUSERPWD " +
        ////  " WHERE  USERNAME=: USERNAME AND PASWORD=:PASWORD ";

        ////string sql = "select contract_no from credit_card_customer where email=:email or phone =:phone or contract_no=:contractNo";
        ////string sql = "select contract_no from credit_card_customer where email=:email or phone =:phone";
       string sql = "select * from  HM_PERM where USERNAME=@v_username";
        ////
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.CommandType = CommandType.Text;


        cmd.Parameters.Add("v_username", SqlDbType.VarChar, 100).Value = username;


        System.Data.SqlClient.SqlDataReader reader;
        reader = cmd.ExecuteReader();
        string usr_mg;
        string staff_mg;
        //string rpt_mg;
        //string mail_mg;

        while (reader.Read())
        {//
        //if (email == reader["FILE_NAME"].ToString())// && accNO == reader["cod_acct_no"].ToString())
            //{
            //created = 1;
            // file_name = reader["FILE_NAME"].ToString();
            //File.Move(sourceDir + file_name, destinationDir + file_name);
            //}
            //else
            // {
            //created = 0;
            usr_mg = reader["usr_mg"].ToString();
            staff_mg = reader["staff_mg"].ToString();
            //rpt_mg = reader["rpt_mg"].ToString();
            //mail_mg = reader["mail_mg"].ToString();
            //
            if (usr_mg == "1")
                UserPane.Visible = true;
            else
                UserPane.Visible = false;
            //
            if (staff_mg == "1")
                CustomerPane.Visible = true;
            else
                CustomerPane.Visible = false;

            //if (rpt_mg == "1")
            //    ReportPane.Visible = true;
            //else
            //    ReportPane.Visible = false;

            //if (mail_mg == "1")
            //    SendMailPane.Visible = true;
            //else
            //    SendMailPane.Visible = false;
            // }
        }//end of while
        reader.Close();
        //
        conn.Close();
        //
        //return created;

    }//end of CheckAccess method

    // private const string BASE_PATH = "";// "~/DynamicControlLoading/";

    private string LastLoadedControl
    {
        get
        {
            return ViewState["LastLoaded"] as string;
        }
        set
        {
            ViewState["LastLoaded"] = value;
        }
    }
    //
    private void LoadUserControl()
    {
        controlPath = LastLoadedControl;

        if (!string.IsNullOrEmpty(controlPath))
        {
            ContentPlaceHolder1.Controls.Clear();
            UserControl uc = (UserControl)LoadControl(controlPath);
            ContentPlaceHolder1.Controls.Add(uc);
        }
    }
   
    //protected void Lnkusermgt_Click(object sender, EventArgs e)
    //{
    //    //auditTrail.ascx
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/user.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void lnkadj_Click(object sender, EventArgs e)
    //{
    //    //auditTrail.ascx
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/auditTrail.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void lnkaudit_Click(object sender, EventArgs e)
    //{
    //    //auditTrail.ascx
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/auditTrail.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void lnktarget_Click(object sender, EventArgs e)
    //{
    //    //addtarget.ascx
    //    //auditTrail.ascx
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/addtarget.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void lnkadjust_Click(object sender, EventArgs e)
    //{
        
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/adjustment.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();

    //}
    //protected void lnkmiscode_Click(object sender, EventArgs e)
    //{
        
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/miscode.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void lnkadj_Click1(object sender, EventArgs e)
    //{
       
    //}
    //protected void lnkadjapprove_Click(object sender, EventArgs e)
    //{
    //    //approveadj.ascx
    //    controlPath = string.Empty;
    //    //
    //    controlPath = BASE_PATH + "~/Account/forms/approveadj.ascx";
    //    //
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    lblPageTtile.Text = "Reports Section";
    //    //WebUserControl.ascx
    //    //approveadj.ascx
    //    controlPath = string.Empty;
    //    //
    //   // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
    //    controlPath = BASE_PATH + "~/Account/forms/barChart.ascx";
    //    //tabControl.ascx
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}

    protected void lnkUserManager_Click(object sender, EventArgs e)
    {
        lblPageTtile.Text = "User Management Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/userManager.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void SearchStaffForm_Click(object sender, EventArgs e)
    {

        lblPageTtile.Text = "Search Staff Information";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/staffPasswordReset.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();


        //lblPageTtile.Text = "Upload Credit Card Statement Customer";
        ////WebUserControl.ascx
        ////approveadj.ascx
        //controlPath = string.Empty;
        ////
        //// controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        //controlPath = BASE_PATH + "~/Account/forms/bulkupload.ascx";
        ////tabControl.ascx
        //LastLoadedControl = controlPath;
        //LoadUserControl();
    }
    //protected void lnkComForm_Click(object sender, EventArgs e)
    //{

    //    lblPageTtile.Text = "PERSO Form Section";
    //    //WebUserControl.ascx
    //    //approveadj.ascx
    //    controlPath = string.Empty;
    //    //
    //    // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
    //    controlPath = BASE_PATH + "~/Account/forms/userManager.ascx";
    //    //tabControl.ascx
    //    LastLoadedControl = controlPath;
    //    LoadUserControl();
    //}
    protected void lnkProcessOthers_Click(object sender, EventArgs e)
    {
        lblPageTtile.Text = "Process Card Services, Settlements and Processing Account Billing Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/processOther.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkRptDet_Click(object sender, EventArgs e)
    {
        //reportDetails.ascx
        lblPageTtile.Text = "Monthly Detail Report Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/InvoiceSum.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkRptSummary_Click(object sender, EventArgs e)
    {
        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "View Report Summary Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/reportSummary.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkInvDet_Click(object sender, EventArgs e)
    {
        //InvoiceSum.ascx
        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "View Report Details Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/InvoiceDet.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkInvSum_Click(object sender, EventArgs e)
    {
        //InvoiceSum.ascx
        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "View Report Summary Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/InvoiceSum.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnksendmail_Click(object sender, EventArgs e)
    {
        //InvoiceSum.ascx
        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "Send Credit Card Statements to Customers";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/InvoiceDet.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkRptSum_Click(object sender, EventArgs e)
    {
        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "Monthly Report Summary Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/reportSummary.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkcustList_Click(object sender, EventArgs e)
    {
        //reportDetails.ascx

        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "View Customer Lists Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/reportDetails.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnkRptSum_Click1(object sender, EventArgs e)
    {

        //reportDetails.ascx

        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "View Summary Report";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/reportSummary.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void lnklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        //
        Session.Clear();
        //
        Response.Redirect("~/login.aspx");//rtlHome.aspx...newPage.aspx


    }
    protected void lnkModfiy_Click(object sender, EventArgs e)
    {
        //perso.ascx

        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "Modify Customers Details Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/perso.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        //reportSummary.ascx
        //perso.ascx

        //reportSummary.ascx
        //reportDetails.ascx
        lblPageTtile.Text = "FGRID VIEW TEST Details Section";
        //WebUserControl.ascx
        //approveadj.ascx
        controlPath = string.Empty;
        //
        // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        controlPath = BASE_PATH + "~/Account/forms/reportSummary.ascx";
        //tabControl.ascx
        LastLoadedControl = controlPath;
        LoadUserControl();
    }
}
