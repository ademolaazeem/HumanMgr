using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using BLL;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private bool Authenticate(string userName, string password, string domain)
    {
        bool authentic = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
            object nativeObject = entry.NativeObject;
            authentic = true;
        }
        catch (DirectoryServicesCOMException) { }
        return authentic;
       // return false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // string domain = "172.19.2.75";
         string domain = "cdl-ad1";
        
        string username = txtuser.Text;

          bool rst = Authenticate(username.ToLower(), txtpass.Text, domain);
        if (rst == true)
        {
            //lblstatus.Text = "AM IN";
       // crerate or update user details


        int rstUsr = crudsbLL.Add_User(username, Request.UserHostAddress, "Success");
        if (rstUsr == -1)
        {
                        Session["usr"] = username;

                        Response.Redirect("~/Account/accessPage.aspx");//

        }
        else
        {
            lblstatus.Text = "You can not login now, Contact Administrator";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }


        }
        else
        {
            crudsbLL.Add_User(username, Request.UserHostAddress, "Failed");
            lblstatus.Text = "Invalid Window Login Details!";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
   }
}