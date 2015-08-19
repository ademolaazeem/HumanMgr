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
//

using System.Globalization;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
//using Oracle.Web.Profile.OracleProfileProvider;


//
using BLL;

public partial class Account_forms_reportSummary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
       // {
            BindGridviewData();
       // }
        //
        //ddInstitution.DataSource = get_lists.GetInstitutionList();
        ////table;
        ////
        //ddInstitution.DataTextField = "instituitionname";
        //ddInstitution.DataValueField = "institutncode";
        //ddInstitution.DataBind();
        //end
        //
        DateTime now = DateTime.Now;
        //  ddYearName.Items.Add(now.Year.ToString());
        int last5yr = now.Year - 5;
        int next5yr = now.Year + 5;

        //Label1.Text = last5yr.ToString();
        //Label1.Visible = false;

        //Label2.Visible = false;
        //
        //Label2.Text = next5yr.ToString();

        int thisYear = Convert.ToInt32(System.DateTime.Now.Year);
        for (int i = last5yr; i <= thisYear; i++)
        {
            ddYearName.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        //for (int y = last5yr; last5yr <= next5yr; ++y)
        //{
        //    ddYearName.Items.Add(y.ToString ());
        //}
        //
        //get all months
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

        for (int i = 0; i < months.Length; ++i)
        {
            ddMonthName.Items.Add(new ListItem(months[i], i.ToString()));

        }
        ddMonthName.Items.Insert(0, new ListItem("All", "All"));
        //
    }

    protected void BindGridviewData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("UserId", typeof(Int32));
        dt.Columns.Add("UserName", typeof(string));
        dt.Columns.Add("Education", typeof(string));
        dt.Columns.Add("Location", typeof(string));
        DataRow dtrow = dt.NewRow();    // Create New Row
        dtrow["UserId"] = 1;            //Bind Data to Columns
        dtrow["UserName"] = "SureshDasari";
        dtrow["Education"] = "B.Tech";
        dtrow["Location"] = "Chennai";
        dt.Rows.Add(dtrow);
        dtrow = dt.NewRow();               // Create New Row
        dtrow["UserId"] = 2;               //Bind Data to Columns
        dtrow["UserName"] = "MadhavSai";
        dtrow["Education"] = "MBA";
        dtrow["Location"] = "Nagpur";
        dt.Rows.Add(dtrow);
        dtrow = dt.NewRow();              // Create New Row
        dtrow["UserId"] = 3;              //Bind Data to Columns
        dtrow["UserName"] = "MaheshDasari";
        dtrow["Education"] = "B.Tech";
        dtrow["Location"] = "Nuzividu";
        dt.Rows.Add(dtrow);
        gvDetails.DataSource = dt;
        gvDetails.DataBind();
    }
    //
   protected void btnProcess_Click(object sender, EventArgs e)
    {
            string str = string.Empty;
            string strname = string.Empty;
            foreach(GridViewRow  gvrow in gvDetails.Rows)
            {
            CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
            if (chk != null & chk.Checked)
            {
                    str += gvDetails.DataKeys[gvrow.RowIndex].Value.ToString() + ',';
                    strname += gvrow.Cells[2].Text+',';
            }
            }
            str= str.Trim(",".ToCharArray());
            strname = strname.Trim(",".ToCharArray());
            lblmsg.Text = "Selected UserIds: <b>" + str + "</b><br/>" + "Selected UserNames: <b>" + strname+"</b>";
    }
   
}