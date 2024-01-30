using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockBytes.Models;

namespace StockBytes.Controllers
{
    public class StockByteController : Controller
    {
        public readonly DatabaseContext _context;
        public StockByteController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult memberRegistration()
        {

            return View();
        }

        [HttpPost]
        public IActionResult memberRegistration(memberRegModel obj)
        {

            string msg = "";
            if (obj.watchlist1 == true)
            {
                msg = msg + "Hindalco" + "";
            }

            if (obj.watchlist2 == true)
            {
                msg = msg + ", Sail" + "";
            }
            if (obj.watchlist3 == true)
            {
                msg = msg + ", Eicher-Motors" + "";
            }
            if (obj.watchlist4 == true)
            {
                msg = msg + ", Wipro" + "";
            }
            if (obj.watchlist5 == true)
            {
                msg = msg + ", Tata-Motors" + "";
            }
            if (obj.watchlist6 == true)
            {
                msg = msg + ", SBI" + "";
            }
            if (obj.watchlist7 == true)
            {
                msg = msg + ", Greenply" + "";
            }
            if (obj.watchlist8 == true)
            {
                msg = msg + ", HCL" + "";
            }
            if (obj.watchlist9 == true)
            {
                msg = msg + ", Kotak" + "";
            }
            if (obj.watchlist10 == true)
            {
                msg = msg + ", Tech-Mahindra" + "";
            }


            string sql = "exec sp_inserttoMemberRecords @First_Name,@Last_Name,@EmailID,@Password,@Contact_Number,@Gender,@Dob,@Watchlist";
            List<SqlParameter> param = new List<SqlParameter>() {

            new SqlParameter { ParameterName = "@First_Name", Value = obj.First_Name },
            new SqlParameter {ParameterName = "@Last_Name", Value = obj.Last_Name},
            new SqlParameter { ParameterName = "@EmailID", Value = obj.EmailID },
            new SqlParameter { ParameterName = "@Password", Value = obj.Password },
             new SqlParameter {ParameterName = "@Contact_Number", Value = obj.Contact_Number},
             new SqlParameter {ParameterName = "@Gender", Value = obj.Gender},
             new SqlParameter { ParameterName = "@Dob", Value = obj.DOB },
            new SqlParameter { ParameterName = "@Watchlist", Value = msg },
        };
            var res = _context.Database.ExecuteSqlRaw(sql, param.ToArray());
            if (res > 0)
            {
                ViewBag.SuccessMessage = "Your Account Has been created successfully!";
                //return RedirectToAction("memberLogin", "StockByte");
                return View();
            }
            else
            {
                return View();
            }
            return View();
        }



        [HttpGet]
        public IActionResult memberLogin()
        {
            return View();
        }



        [HttpPost]
        public IActionResult memberLogin(memberLoginModel obj)
        {

            try
            {
                var EmailID = new SqlParameter("@EmailID", obj.EmailID);
                var Password = new SqlParameter("@Password", obj.Password);
                var res = _context.memberLoginModel.FromSqlRaw("exec sp_memberLogins @EmailID, @Password", EmailID, Password).AsEnumerable().FirstOrDefault();


                if (res != null)
                {
                    return RedirectToAction("memberRegistration", "StockByte");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
                }

                //HttpContext.Session.SetString("Uname", dr["Student_Name"].ToString());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "An error occurred during login.");
                return View();
            }
        }
        public IActionResult homePage()
        {
            return View();
        }
    }
}
