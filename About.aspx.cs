using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool Authenticate(string userName,string password, string domain)
    {
        bool authentic = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain,
                userName, password);
            object nativeObject = entry.NativeObject;
            authentic = true;
        }
        catch (DirectoryServicesCOMException) { }
        return authentic;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //try
        //{

        //    DirectoryEntry dentry = new DirectoryEntry("LDAP://" + "172.19.2.75", TextBox1.Text, TextBox31.Text );

        //    object obj = dentry.NativeObject;               //if username and password doesn't match it throws login failure exception

        //    DirectorySearcher search = new DirectorySearcher(dentry);

        //    search.Filter = "(samaccountname=" + TextBox1.Text + ")";

        //    search.PropertiesToLoad.Add("samAccountName"); //username

        //    SearchResult result = search.FindOne();

        //   // if (result != null)
        //    //{
        //        Label1.Text = result.ToString();
        //    //}

        //}
        //catch (DirectoryServicesCOMException ex)
        //{

        //    Label1.Text = "Error: "+ex.Message;

        //}
        string domain="172.19.2.75";
        //
        string username = TextBox1.Text;

        bool rst = Authenticate(username.ToLower(), TextBox31.Text, domain);
        if (rst == true)
            Label1.Text = "AM IN";
        else
            Label1.Text = "GET LOST!";
    }
}
