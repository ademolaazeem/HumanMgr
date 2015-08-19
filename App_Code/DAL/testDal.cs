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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data.SqlClient;
//using DAL.Dalcs;


namespace DAL
{
    /// <summary>
    /// Summary description for testDal
    /// </summary>
    public class testDal
    {
        //public testDal()
       // {
            //
            // TODO: Add constructor logic here
            //
        //}
        
        public static DataTable GetByUsername(string username)
        //public static DataTable GetByUsername()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Dalcs.hm42ConnectionString;
                
                con.Open();
                //credit_card_perm

                string sql = "select * from HM_PERM where USERNAME <> @username";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("username", username);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
   
    }

}