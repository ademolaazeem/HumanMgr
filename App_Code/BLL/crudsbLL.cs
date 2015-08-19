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
//
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
//
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
//
using System.Globalization;

using System.ComponentModel;// for backgroundworker class
//
using System.Threading;
//
using DAL;
//using DAL.Dalcs;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BLL
{


    /// <summary>
    /// Summary description for crudsbLL
    /// </summary>
    public class crudsbLL
    {
        //public crudsbLL()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}
        //public static int Add_Perso_EComm(string unit, string instCode, string instName, double volume, double value, string tranType, string devType,
        //    string sService, string affFlag, string country, string month, string year, string desc, string createdby)
        //{
        //    return cruds.Add_Perso_EComm(unit, instCode, instName, volume, value, tranType, devType, sService, affFlag, country, month, year, desc, createdby);
        //}

        //BackgroundWorker worker = new BackgroundWorker();
        //
        //public static int Add_User_permission(string username, string usr_mg, string cust_mg, string rpt_mg, string mail_mg)
        //{
        //    return crudsbLL.Add_User_permission( username,  usr_mg,  cust_mg,  rpt_mg,  mail_mg);
        //}
        public static int Add_User(string username, string login_ip, string status)
        {
            return cruds.Add_User( username,  login_ip, status);
        }
        

        
        //
        //public static string check_customer(string contractNo, string email, string phone)
        //{
        //    return check_customer( contractNo,  email,  phone);
        //}
        //
        //function to search for contract no
        private static int IndexOf(string str, string substr)
        {
            bool match;

            for (int i = 0; i < str.Length - substr.Length + 1; ++i)
            {
                match = true;
                for (int j = 0; j < substr.Length; ++j)
                {
                    if (str[i + j] != substr[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return i;
            }

            return -1;
        }
        //

        
        static void MailDeliveryComplete(object sender,System.ComponentModel.AsyncCompletedEventArgs e)
        {
           // Console.WriteLine("Message \"{0}\".", e.UserState);

            if (e.Error != null)
                Console.WriteLine("Error sending email.");
            else if (e.Cancelled)
                Console.WriteLine("Sending of email cancelled.");
            else
                Console.WriteLine("Message sent.");
        }
        //


         //Mine Addition
        public static int update_staff(string username, string UsrId, string lock_val, string new_user, string passW)
        {
            int retVal = 0;
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Dalcs.hm42ConnectionString;
                //string sql = "";
                //    //="";
                //if(lock_val=="U")
                //{
                //    sql = "update para16 set new_user=@v_new_user, password=@v_passW where user_id=@v_UsrId";
                //}
                //else if (lock_val == "L")
                //{
                //    sql = "update para16 set user_in=@v_lock_val, new_user=@v_new_user, password=@v_passW where user_id=@v_UsrId";
                //}

                string sql = "update para16 set user_in=@v_lock_val, new_user=@v_new_user, password=@v_passW where user_id=@v_UsrId";


                // cmd.CommandType = CommandType.Text;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("v_lock_val", SqlDbType.VarChar, 100).Value = lock_val;
                cmd.Parameters.Add("v_new_user", SqlDbType.VarChar, 100).Value = new_user;
                cmd.Parameters.Add("v_passW", SqlDbType.VarChar, 100).Value = passW;
                cmd.Parameters.Add("v_UsrId", SqlDbType.VarChar, 100).Value = UsrId;

                //cmd.CommandType = CommandType.StoredProcedure;
                //
                //if (lock_val == "U")
                //{
                //    //cmd.Parameters.Add("v_lock_val", SqlDbType.VarChar, 100).Value = lock_val;
                //    cmd.Parameters.Add("v_new_user", SqlDbType.VarChar, 100).Value = new_user;
                //    cmd.Parameters.Add("v_passW", SqlDbType.VarChar, 100).Value = passW;
                //    cmd.Parameters.Add("v_UsrId", SqlDbType.VarChar, 100).Value = UsrId;
                //}
                //else if (lock_val == "L")
                //{
                //    cmd.Parameters.Add("v_lock_val", SqlDbType.VarChar, 100).Value = lock_val;
                //    cmd.Parameters.Add("v_new_user", SqlDbType.VarChar, 100).Value = new_user;
                //    cmd.Parameters.Add("v_passW", SqlDbType.VarChar, 100).Value = passW;
                //    cmd.Parameters.Add("v_UsrId", SqlDbType.VarChar, 100).Value = UsrId;
                
                //}
                //
                // cmd.Parameters.Add("p_contract_no", OracleDbType.Varchar2, 100).Value = contract;
                //cmd.Parameters.Add("p_category", OracleDbType.Varchar2, 100).Value = category;
                //
                //cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 100).Value = status;
                //cmd.Parameters.Add("p_file_format1", OracleDbType.Varchar2, 100).Value = file_fromat1;

                //cmd.Parameters.Add("p_file_format2", OracleDbType.Varchar2, 100).Value = file_fromat2;

                //
                //
                //cmd.Parameters.Add("p_createdby", OracleDbType.Varchar2, 100).Value = createdby;
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
        public static DataTable list_staff(string staffname)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Dalcs.hm42ConnectionString;

                con.Open();

                string sql;
                sql = "select * from para16 where name like @v_staffname";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@v_staffname", "%" + staffname + "%"); 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }

        public static DataTable list_staff()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Dalcs.hm42ConnectionString;

                con.Open();
                //
                string sql;
                sql = "select * from para16 order by name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
               // cmd.Parameters.AddWithValue("@v_staffname", "%" + staffname + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        
        //End Mine Addition
    
    }
}