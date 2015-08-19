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
//

public partial class Account_forms_reportDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ddInstitution.DataSource = get_lists.GetInstitutionList();
        ////table;
        ////
        //ddInstitution.DataTextField = "instituitionname";
        //ddInstitution.DataValueField = "institutncode";
        //ddInstitution.DataBind();
        //ddInstitution.Items.Insert(0, new ListItem("All", "0"));
        //
        btnDw.Visible = false;
    }
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
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        DataTable table;
        table = crudsbLL.customer_lists( ddInstitution.SelectedValue);
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
    }
}