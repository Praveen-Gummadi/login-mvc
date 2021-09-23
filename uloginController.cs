using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using login.Models;
namespace login.Controllers
{
    public class uloginController : Controller
    {
        
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(ulogin l)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select user name and password from login where username='" +l. username + ",and password='" +l. password + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("create");
            }
            else
            {
                con.Close();
                return View("error");
            }
        }
    }
}