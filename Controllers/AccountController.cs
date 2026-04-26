using ASPNETMVCCRUDADOSPDROP.DAL;
using ASPNETMVCCRUDADOSPDROP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCCRUDADOSPDROP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DbHelper db = new DbHelper();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using (SqlConnection con = db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", model.Username);
                cmd.Parameters.AddWithValue("@Password", model.Password);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    Session["User"] = model.Username;
                    return RedirectToAction("Index", "Employee");
                }
            }
            ViewBag.Message = "Invalid Login";
            return View();
        }
    }
}