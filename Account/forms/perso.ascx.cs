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
//
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
//
//using System.IO;
//using System.Data;
//
using Excel;
//
//
using System.Text.RegularExpressions;
//using Oracle.Web.Profile.OracleProfileProvider;


//
using BLL;
using DAL;

//
public partial class Account_forms_perso : System.Web.UI.UserControl
{
    ZipOutputStream zos;
    String strBaseDir;
    //
    protected void Page_Load(object sender, EventArgs e)
    {
        Button2.Visible = false;
        //
        btnUpdate.Visible = false;

        //if (!IsPostBack)
        //{
        //populate institutions
        // DataTable table;
        //table=get_lists.GetInstitutionList();
        //    ddInstitution.DataSource = get_lists.GetInstitutionList();
        //   //table;
        //   //
        //    ddInstitution.DataTextField = "instituitionname";
        //    ddInstitution.DataValueField = "institutncode";
        //    ddInstitution.DataBind();
        //    //end
        ////}
        ////get current year
        //    DateTime now = DateTime.Now;
        //    ddYearName.Items.Add(now.Year.ToString ());
        ////
        ////get all months
        //    var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

        //    for (int i = 0; i < months.Length; ++i)
        //    {
        //        ddMonthName.Items.Add(new ListItem(months[i], i.ToString()));

        //    }
        //
        //populate grid on load
        DataTable table;
        table = crudsbLL.customer_lists_list();
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        //
    }
    //
    void ClearTextBoxes(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            TextBox textBox = child as TextBox;
            if (textBox == null)
                ClearTextBoxes(child);
            else
                textBox.Text = string.Empty;
        } //loop
    } //ClearTextBoxes

    //

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //
        if (txtemail.Text == string.Empty)
        {
            lblstatus.Text = "Email Address Required";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //
        if (txtPhone.Text == string.Empty)
        {
            lblstatus.Text = "Phone No Required";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //
        if (txtContractNo.Text == string.Empty)
        {
            lblstatus.Text = "Contract Number Required";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //
        Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        if (!regex.IsMatch(txtemail.Text))
        {
            lblstatus.Text = "Invalid Email Address";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //
        Validation objValidate = new Validation();

        //;
        //
        if (!objValidate.IsNumber(txtPhone.Text))
        {
            lblstatus.Text = "Phone No Must be numeric";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //if (!objValidate.IsNumber(txtvalue.Text))
        //{
        //    lblstatus.Text = "Value Must be numeric";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //txtDesc.Text
        // lblstatus.Text = ddMonthName.SelectedItem.Text + " " + ddYearName.SelectedValue + "  " + ddInstitution.SelectedValue;

        int chkCustId = cruds.check_customer(txtemail.Text);
        int chkCustContrctNo = cruds.check_customer_contractNo(txtContractNo.Text);
        int chkphone = cruds.check_customer_phone(txtPhone.Text);

        //  if (!string.IsNullOrEmpty(chkCustId))
        if (chkCustId == 1 || chkCustContrctNo == 1 || chkphone == 1)
        {

            // lblstatus.Text = "ALERT: Customer Record already setup:" + chkCustId.ToString();// +rst.ToString();
            lblstatus.Text = "ALERT: Customer Record already setup";// +rst.ToString();
            lblstatus.ForeColor = System.Drawing.Color.Red;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
            //
           // txtemail.ReadOnly = true;

           // txtPhone.ReadOnly = true;

            return;
        }
        if (chkCustId == 2)
        {

            //lblstatus.Text = "Error: Operation failed, please retry:" + chkCustId.ToString();// +rst.ToString();
            lblstatus.Text = "Error: Operation failed, please retry";// +rst.ToString();
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //operations here
        try
        {
            //double volume = Convert.ToDouble(txtname.Text);

            //double value = Convert.ToDouble(txtvalue.Text);
            //
            string userID = Session["usr"].ToString();
            //
            int rst = crudsbLL.Add_credit_customer(txtname.Text, txtemail.Text, txtPhone.Text, txtContractNo.Text, ddCategory.SelectedValue, ddStatus.SelectedValue,
                userID);

            if (rst == -1)
            {
                // lblstatus.Text = "Customer Record Setup Successful:" + chkCustId.ToString();
                lblstatus.Text = "Customer Record Setup Successful";
                lblstatus.ForeColor = System.Drawing.Color.Blue;
                //
                ClearTextBoxes(this);
                //REFRESH GRID
                DataTable table;
                table = crudsbLL.customer_lists_list();
                //
                Gridview1.DataSource = table;
                Gridview1.DataBind();

            }
            else
            {
                //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                lblstatus.Text = "Error: Operation failed ";// +rst.ToString();
                lblstatus.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblstatus.Text = "Object Error: " + ex.Message;
            lblstatus.ForeColor = System.Drawing.Color.Red;
            //return;
        }
        //
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StartZip(Server.MapPath(@"images"), "AllImages");
    }
    protected void StartZip(string strPath, string strFileName)
    {
        MemoryStream ms = null;
        Response.ContentType = "application/octet-stream";
        strFileName = HttpUtility.UrlEncode(strFileName).Replace('+', ' ');
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName + ".zip");
        ms = new MemoryStream();
        zos = new ZipOutputStream(ms);
        strBaseDir = strPath + "\\";
        addZipEntry(strBaseDir);
        zos.Finish();
        zos.Close();
        Response.Clear();
        Response.BinaryWrite(ms.ToArray());
        Response.End();
    }


    protected void addZipEntry(string PathStr)
    {
        DirectoryInfo di = new DirectoryInfo(PathStr);
        foreach (DirectoryInfo item in di.GetDirectories())
        {
            addZipEntry(item.FullName);
        }
        foreach (FileInfo item in di.GetFiles())
        {
            FileStream fs = File.OpenRead(item.FullName);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            string strEntryName = item.FullName.Replace(strBaseDir, "");
            ZipEntry entry = new ZipEntry(strEntryName);
            zos.PutNextEntry(entry);
            zos.Write(buffer, 0, buffer.Length);
            fs.Close();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ////
        //if (txtemail.Text == string.Empty)
        //{
        //    lblstatus.Text = "Email Address Required";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}

        ////
        //if (txtPhone.Text == string.Empty)
        //{
        //    lblstatus.Text = "Phone No Required";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //

       
        //Response.Redirect(String.Format("Helpdesk\\HelpdeskDetail.aspx?ENV_ID={0}", envId));


        //
        if (txtContractNo.Text == string.Empty)
        {
            lblstatus.Text = "Contract Number Required";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //
        //Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        //if (!regex.IsMatch(txtemail.Text))
        //{
        //    lblstatus.Text = "Invalid Email Address";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        ////
        //Validation objValidate = new Validation();

        ////;
        ////
        //if (!objValidate.IsNumber(txtPhone.Text))
        //{
        //    lblstatus.Text = "Phone No Must be numeric";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}


        int chkCustId = cruds.check_customer(txtemail.Text);
        ////  if (!string.IsNullOrEmpty(chkCustId))
        //if (chkCustId == 0)
        //{

        //    // lblstatus.Text = "ALERT: Customer Record already setup:" + chkCustId.ToString();// +rst.ToString();
        //    lblstatus.Text = "ALERT: Customer Record Does not Exist";// +rst.ToString();
        //    lblstatus.ForeColor = System.Drawing.Color.Red;

        //    btnSave.Visible = false;
        //    btnUpdate.Visible = true;
        //    //
        //    //
        //    //
        //    return;
        //}
        if (chkCustId == 2)
        {

            //lblstatus.Text = "Error: Operation failed, please retry:" + chkCustId.ToString();// +rst.ToString();
            lblstatus.Text = "Error: Operation failed, please retry";// +rst.ToString();
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //operations to update
        try
        {
            //double volume = Convert.ToDouble(txtname.Text);

            //double value = Convert.ToDouble(txtvalue.Text);
            //
            string userIDSe = Session["usr"].ToString();
            //
            int rst = crudsbLL.update_credit_customer(userID.Value, txtname.Text, txtemail.Text, txtPhone.Text, txtContractNo.Text, ddCategory.SelectedValue, ddStatus.SelectedValue,
                userIDSe);

            if (rst == -1)
            {
                //
                // lblstatus.Text = "Customer Record Setup Successful:" + chkCustId.ToString();
                lblstatus.Text = "Customer Record Update Successful";
                lblstatus.ForeColor = System.Drawing.Color.Blue;
                //
                ClearTextBoxes(this);
                //
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                //
                //
                txtemail.ReadOnly = false;

                txtPhone.ReadOnly = false;
                //REFRESH GRID
                DataTable table;
                table = crudsbLL.customer_lists_list();
                //
                Gridview1.DataSource = table;
                Gridview1.DataBind();


            }
            else
            {
                //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                lblstatus.Text = "Error: Operation failed ";// +rst.ToString();
                lblstatus.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblstatus.Text = "Object Error: " + ex.Message;
            lblstatus.ForeColor = System.Drawing.Color.Red;
        }
        //
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

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // txtfname.Text = Gridview1.SelectedRow.Cells[1].Text;
        txtname.Text = Gridview1.SelectedRow.Cells[2].Text;
        txtemail.Text = Gridview1.SelectedRow.Cells[3].Text;
        txtPhone.Text = Gridview1.SelectedRow.Cells[4].Text;
        txtContractNo.Text = Gridview1.SelectedRow.Cells[5].Text;
        ddCategory.Text = Gridview1.SelectedRow.Cells[6].Text;
        //
        btnSave.Visible = false;
        btnUpdate.Visible = true;
        //

        
        //ticketButton = (Button)sender;
        //envGridRow = (GridViewRow)ticketButton.NamingContainer;


        //// Derive DataKey from GridRow
        //envId = (String)(Gridview1.DataKeys[envGridRow.RowIndex].Values[0].ToString());

        
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        DataTable table;
        table = crudsbLL.customer_lists_all(txtsearch.Text);
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
    }
    //

    protected void lnkPersoForm_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;

        string CommandName = btn.CommandName;

        string CommandArgument = btn.CommandArgument;

        //GridViewRow envGridRow;
        //Button ticketButton;
        //String envId;
        userID.Value = CommandArgument;
        lblUsrId.Text = userID.Value;

       
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;
           // lblstatus.Text = RowIndex.ToString();

            //

           
            //// Determine GridRow
           // gvr.d
            //
            //int EmployeeID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values[0]);
        }
        //if (e.CommandName == "Insert")
        //{
        //    //TextBox txtusername = (TextBox)GridView1.FooterRow.FindControl("txtftrusrname");
        //    //TextBox txtfirstname = (TextBox)GridView1.FooterRow.FindControl("txtftrfname");
        //    //TextBox txtlastname = (TextBox)GridView1.FooterRow.FindControl("txtftrlname");
        //    //TextBox txtCity = (TextBox)GridView1.FooterRow.FindControl("txtftrcity");
        //    //TextBox txtDesgnation = (TextBox)GridView1.FooterRow.FindControl("txtftrDesignation");
        //    //dsDetails.InsertParameters["UserName"].DefaultValue = txtusername.Text;
        //    //dsDetails.InsertParameters["FirstName"].DefaultValue = txtfirstname.Text;
        //    //dsDetails.InsertParameters["LastName"].DefaultValue = txtlastname.Text;
        //    //dsDetails.InsertParameters["City"].DefaultValue = txtCity.Text;
        //    //dsDetails.InsertParameters["Designation"].DefaultValue = txtDesgnation.Text;
        //    //dsDetails.Insert();
        //    //lblresult.Text = txtusername.Text + " Details Inserted Successfully";
        //    //lblresult.ForeColor = System.Drawing.Color.Green;
        //}
        //if (e.CommandName == "Update")
        //{
        //    GridViewRow gvrow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
        //    // Label lblusername = (Label)gvrow.FindControl("lbleditusr");//....lbleditusr
        //    //
        //    //Label lblusername1 = (Label)gvrow.FindControl("lblitemUsr");
        //    //
        //    TextBox txtAccName = (TextBox)gvrow.FindControl("txtAccName");//txtfname
        //    TextBox txtMiscode = (TextBox)gvrow.FindControl("txtMiscode");
        //    //TextBox txtCity = (TextBox)gvrow.FindControl("txtcity");
        //    //TextBox txtDesgnation = (TextBox)gvrow.FindControl("txtDesg");
        //    dsDetails.UpdateParameters["ACCOUNT_NAME"].DefaultValue = txtAccName.Text;
        //    dsDetails.UpdateParameters["MISCODE"].DefaultValue = txtMiscode.Text;
        //    //
        //    dsDetails.UpdateParameters["MODIFIED_BY"].DefaultValue = Context.User.Identity.Name;
        //    dsDetails.UpdateParameters["MODIFIED_DATE"].DefaultValue = DateTime.Now.ToString();
        //    //MODIFIED_DATE
        //    // dsDetails.UpdateParameters["LastName"].DefaultValue = txtlastname.Text;
        //    // dsDetails.UpdateParameters["City"].DefaultValue = txtCity.Text;
        //    // dsDetails.UpdateParameters["Designation"].DefaultValue = txtDesgnation.Text;
        //    dsDetails.Update();
        //    //
        //    lblresult.Text = txtAccName.Text + " Details Updated Successfully";
        //    lblresult.ForeColor = System.Drawing.Color.Blue;
        //}
        //if (e.CommandName == "Delete")
        //{
        //    GridViewRow gvdeleterow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
        //    Label lblusername = (Label)gvdeleterow.FindControl("lblitemUsr");
        //    lblresult.Text = lblusername.Text + " Details Deleted Successfully";
        //    lblresult.ForeColor = System.Drawing.Color.Red;
        //}
    }
}