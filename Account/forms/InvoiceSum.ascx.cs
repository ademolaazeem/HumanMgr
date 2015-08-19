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
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Globalization;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

using System.Collections.Specialized;
using System.Text;
//using Oracle.Web.Profile.OracleProfileProvider;


//
using BLL;
using DAL;


public partial class Account_forms_InvoiceSum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        //ddInstitution.DataSource = get_lists.GetInstitutionList();
        ////table;
        ////
        //ddInstitution.DataTextField = "instituitionname";
        //ddInstitution.DataValueField = "institutncode";
        //ddInstitution.DataBind();
        //end
        //
        //if (!Page.IsPostBack)
        //{
            DateTime now = DateTime.Now;
            //  ddYearName.Items.Add(now.Year.ToString());
            int last5yr = now.Year - 5;
            int next5yr = now.Year + 5;

            //Label1.Text = last5yr.ToString();
            Label1.Visible = false;

            Label2.Visible = false;
            //
            //Label2.Text = next5yr.ToString();

            int thisYear = Convert.ToInt32(System.DateTime.Now.Year);
            for (int i = thisYear; i >= last5yr; i--)
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
        //}

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
        table = crudsbLL.credit_card_report(ddMonthName.SelectedItem.ToString(), ddYearName.SelectedValue);
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();

        //Label1.Text = ddMonthName.SelectedItem.ToString ();
        ////
        //Label2.Text = ddYearName.SelectedValue;
    }
    public static void ExportToSpreadsheet(DataTable table, string name)
    {
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        foreach (DataColumn column in table.Columns)
        {
            context.Response.Write(column.ColumnName + ";");
        }
        context.Response.Write(Environment.NewLine);
        foreach (DataRow row in table.Rows)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
            }
            context.Response.Write(Environment.NewLine);
        }
        context.Response.ContentType = "text/csv";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".csv");
        context.Response.End();
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {

        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=gridviewdata.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sWriter = new StringWriter();
            HtmlTextWriter hWriter = new HtmlTextWriter(sWriter);
            Gridview1.RenderControl(hWriter);
            Response.Output.Write(sWriter.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }

    #region Multiple Delete
    private void DeleteRecords(StringCollection sc)
    {
        OracleConnection conn = new OracleConnection(Dalcs.MisportalConnection);
        StringBuilder sb = new StringBuilder(string.Empty);

        foreach (string item in sc)
        {
            const string sqlStatement = "DELETE FROM Customers WHERE CustomerID";
            sb.AppendFormat("{0}='{1}'; ", sqlStatement, item);
        }
        try
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand(sb.ToString(), conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion


    protected void ButtonDelete_Click(object sender, EventArgs e)
    {
        StringCollection sc = new StringCollection();
        string id = string.Empty;
        //loop the GridView Rows
        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)Gridview1.Rows[i].Cells[0].FindControl("CheckBox1"); //find the CheckBox
            if (cb != null)
            {
                if (cb.Checked)
                {
                    id = Gridview1.Rows[i].Cells[1].Text; // get the id of the field to be deleted
                    sc.Add(id); // add the id to be deleted in the StringCollection
                }
            }
        }

        DeleteRecords(sc); // call method for delete and pass the StringCollection values
       // BindGridView(); // Bind GridView to reflect changes made here
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) //check for RowType
        {
            //access the LinkButton from the Header TemplateField using FindControl
            Button b = (Button)e.Row.FindControl("ButtonDelete");
            //attach the JavaScript function
            b.Attributes.Add("onclick", "return ConfirmOnDelete();");
        }
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //}

}