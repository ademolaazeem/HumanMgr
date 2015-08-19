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

using System.Data;
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
//
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
//
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
//
namespace DAL
{
/// <summary>
/// Summary description for Dalcs
/// </summary>
public class Dalcs
{
	///public Dalcs()
	//{
		//
		// TODO: Add constructor logic here
		//
	//}

    public static string hm42ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["hm42ConnectionString"].ConnectionString;
        }
    }
   

    public static string MisPortalStandbyConnection
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["MisPortalStandbyConnection"].ConnectionString;
        }
    }

    public static string TWOConnection
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["TWOConnectionString"].ConnectionString;
        }
    }
    public static string ApplicationURL
    {
        get
        {
            return ConfigurationManager.AppSettings["ApplicationURL"];
        }
    }
 }
}