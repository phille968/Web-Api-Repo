using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http;
using System.Collections;
using System.IO;

namespace Test2
{
    public class UserPersistence
    {
        public List<User> GetUsers()
        {
           List<User> persons = new List<User>();

            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

               
                SqlDataReader mySqlReader = null;
                
                String sqlstring = "select * from [User]";
                
                SqlCommand cmd = new SqlCommand(sqlstring, conn);
                
                mySqlReader = cmd.ExecuteReader();
              
               
                while (mySqlReader.Read())
                {
                    User u = new User();

                    u.Id = (Int32)mySqlReader["Id"];
                    u.UserName = mySqlReader["UserName"].ToString();
                    u.Password = mySqlReader["Password"].ToString();
                    u.Email = mySqlReader["Email"].ToString();
                    u.Role = mySqlReader["Role"].ToString();


                    persons.Add(u);
                }
               

                return persons;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public long SaveUser(User UserToSave)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();
               var path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Images/profilePic.png"); 
               var pic = File.ReadAllBytes(path);

                string sqlSaveUser = "insert into [User] (UserName, Password, Email, Role, ProfilePicture) values('" + UserToSave.UserName + "','" + UserToSave.Password + "','" + UserToSave.Email + "','" + UserToSave.Role + "'); SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sqlSaveUser, conn);
                decimal id = (decimal)cmd.ExecuteScalar();
                return (long)id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUser(int Id)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

                User u = new User();
                SqlDataReader mySqlReader = null;

                String sqlstring = "select * from [User] where Id = " + Id.ToString();
                SqlCommand cmd = new SqlCommand(sqlstring, conn);


                mySqlReader = cmd.ExecuteReader();

                if (mySqlReader.Read())
                {
                    u.FirstName = mySqlReader["FirstName"].ToString();
                    u.LastName = mySqlReader["LastName"].ToString();
                    u.Id = (Int32)mySqlReader["Id"];
                    u.UserName = mySqlReader["UserName"].ToString();
                    u.Password = mySqlReader["Password"].ToString();
                    u.Email = mySqlReader["Email"].ToString();
                    u.Role = mySqlReader["Role"].ToString();
                    u.Section = mySqlReader["Section"].ToString();

                    if (u.ProfilePicture != null || u.ProfilePicture.Length > 2)
                    {
                        u.ProfilePicture = (Byte[])mySqlReader["ProfilePicture"];
                    }
                
                    if(u.PhoneNumber != 0)
                    {
                        u.PhoneNumber = (Int32)mySqlReader["PhoneNumber"];
   
                    }

                    return u;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        [Route("api/User{Id}")]
        public bool DeleteUser(int id)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new SqlConnection();
            try
            {
                conn.ConnectionString = myConnectionString;
                conn.Open();

               
                String sqlstring = "delete from [User] where Id = " + id.ToString();
                SqlCommand cmd = new SqlCommand(sqlstring, conn);

                if (sqlstring != null)
                {  
                    cmd.ExecuteNonQuery();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }


        [Route("api/User{Id}")]
        public bool ChangeUser(int id, User UserToSave)
    {
        SqlConnection conn;
        string myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
        conn = new SqlConnection();

        SqlDataReader mySqlReader = null;
        try
        {
            conn.ConnectionString = myConnectionString;
            conn.Open();


            String sqlstring = "select * from [User] where Id = " + id.ToString();

            SqlCommand cmd = new SqlCommand(sqlstring, conn);

            mySqlReader = cmd.ExecuteReader();
            if (mySqlReader.Read())
            {
                sqlstring  = "update [User] SET UserName= '"+ UserToSave.UserName + "' where Id=" + id.ToString();
                   // sqlstring = "update [User] SET UserName= '" + UserToSave.UserName + "', Password= '" + UserToSave.Password + "', Email= '" + UserToSave.Email + "', Role='" + UserToSave.Role + "' where Id=" + id.ToString();

                    cmd = new SqlCommand(sqlstring, conn);
                cmd.ExecuteNonQuery();
                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            conn.Close();
        }

    }

}
}