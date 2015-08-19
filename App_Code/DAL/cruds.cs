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
//using DAL.Dalcs;
using System.IO;
using System.Data.SqlClient;
//using System.Data.OracleClient;
//using System.Data.OracleTypes;

namespace DAL
{

    /// <summary>
    /// Summary description for cruds
    /// </summary>
    public class cruds
    {

        
        public static string Add_User_permission(string username, string usr_mg, string staff_mg)
        {
            int retVal = 0;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Dalcs.hm42ConnectionString;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                
                cmd.CommandText = "update_user_perms";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                cmd.Parameters.Add("p_username", SqlDbType.VarChar, 100).Value = username.ToLower();
                cmd.Parameters.Add("p_usr_mg", SqlDbType.VarChar, 5).Value = usr_mg;
                cmd.Parameters.Add("p_staff_mg", SqlDbType.VarChar, 5).Value = staff_mg;
             
               

                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString ();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }
      
        
        public static int Add_User(string username, string login_ip, string status)
        {
            int retVal = 0;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Dalcs.hm42ConnectionString;

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                //
                //set stored procedure
                //string Oracle = "insert into taccountbilling_summary(unit,institutioncode,institution,volume,value,transtype, devicetype,settlementservice,affilateflag,countrycode,month,year,description,created_by,created_date)" +
                // " values (:unit,:instcode,:instname,:volume,:value,:trantype,:devtype,:sservice,:affflag,:country,:month,:year)";

                cmd.CommandText = "add_user";
                // refNo = refNo.Trim();
                
                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_username", SqlDbType.VarChar, 100).Value = username.ToLower();
                cmd.Parameters.Add("p_login_ip", SqlDbType.VarChar, 100).Value = login_ip;
                cmd.Parameters.Add("p_status", SqlDbType.VarChar, 100).Value = status;
                
                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal;//return val
            }
            catch (Exception ex)
            {
                return 0;
                //return ex.Message;
            }
            //  return 0;
        }


       



     

 
    
    
    }
}