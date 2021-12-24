using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Travelo.Models;


namespace Travelo.Controllers
{
    public class AccountController : Controller
    {
        // SignUP
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult  Signup(User_Tabel S, HttpPostedFileBase image)
        {
            TravelODBContext db = new TravelODBContext();

            

            if (ModelState.IsValid)
            {
                
                 var Test = db.UserTabel.FirstOrDefault(u => u.Email == S.Email);
                string path = Path.Combine(Server.MapPath("~/Images_Users") + "\\" + S.Email + ".jpg");
                image.SaveAs(path);
                db.UserTabel.Add(S);
               
                if (Test == null)
                {
                    Session["message"] = S.Email;
                    db.SaveChanges();
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ViewBag.error = "This Eamil Already Used Please Choose Another";

                }
                ModelState.Clear();
            }
                
 
            return View();
        }
        // LogIN
        public ActionResult LogIn()
        {
            Session["message"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User_Tabel Log)
        {
            using(TravelODBContext db = new TravelODBContext())
            {
                var user = db.UserTabel.FirstOrDefault(u => u.Email == Log.Email && u.Password == Log.Password);
                
                if (user != null)
                {
                    Session["message"] = user.Email;
                    if (user.Email == "admin6712@gmail.com")
                    {
                        return RedirectToAction("DB_Booking", "Account");

                    }
                    else
                    {
                        return RedirectToAction("Home", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong");
                }
            }
            return View();  
        }
        public ActionResult Contact_us()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact_us(User_Messages M)
        {
            TravelODBContext db = new TravelODBContext();
            if (ModelState.IsValid)
            { 
                db.UserMessage.Add(M);
                db.SaveChanges();
                ViewBag.message = "Your Message has been sent Successfully";
                ModelState.Clear();
            }
            return View();
        }
        
        public ActionResult Forget_Password()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forget_Password(User_Tabel Forg_Pass)
        {
            using (TravelODBContext db = new TravelODBContext())
            {
                var Pass = db.UserTabel.FirstOrDefault(u => u.Email == Forg_Pass.Email);
                string strEmail = "";
                string strPass = "";
                string strName = "";
                if (Pass != null)
                {
                    strEmail = Pass.Email.ToString();
                    strPass = Pass.Password.ToString();
                    strName = Pass.FirstName.ToString();
                   sendEmail(strEmail, strPass , strName);
                }
                else
                {
                    ModelState.AddModelError("", "This Email Address Not Exist");
                }
            }

            return View();
        }

        protected void sendEmail(string strEmail, string strPass , string strName)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("egyptology000@gmail.com");
            msg.To.Add(strEmail);
            msg.Subject = "Forgot Password";
            msg.Body = "Hi" +" "+ strName + ","
                + "There was a request to change your password,"
                + " Your password:" + " " + strPass;

            SmtpClient Sclient = new SmtpClient();
            Sclient.Host = "smtp.gmail.com";

            NetworkCredential auth = new NetworkCredential();
            auth.UserName = "egyptology000@gmail.com";
            auth.Password = "Ilove@cairo3";
            Sclient.Credentials = auth;
            Sclient.Port = 587;
            Sclient.EnableSsl = true;
            try
            {
                Sclient.Send(msg);
                ViewBag.ForgPass_Msg = "A Message has been sent to your registered  Email Address with your Password!!";
            }
            catch (Exception ex)
            {
                ViewBag.ForgPass_Msg = ex.Message;
            }

        }
        public ActionResult DB_Booking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DB_Booking(Booking DB)
        {
            using (TravelODBContext db = new TravelODBContext())
            {
                if (ModelState.IsValid)
                {
                    db.booking.Add(DB);
                    db.SaveChanges();
                    ViewBag.error = "Success Saving DataBase!!";

                }
            }
                return View();
        }
    }
}