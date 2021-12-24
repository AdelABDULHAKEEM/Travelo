using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travelo.Models;

namespace Travelo.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Booking()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Booking(Booking B)
        {
            using (TravelODBContext db = new TravelODBContext())
            {
                var booking = db.booking.FirstOrDefault(u => u.Check_In == B.Check_In && u.Check_Out == B.Check_Out
                && u.Duration == B.Duration && u.Members == B.Members && u.Hotel_Location == B.Hotel_Location);

                if (booking != null)
                {

                    ViewBag.MSG = "Congratulations, There is a room at the " + " " + booking.Hotel_Name + " " + "Hotel in"
                       + "  " + booking.Hotel_Location + " " + "on" + " " + booking.Check_In + " " + "With Price:" 
                       + " "+ booking.Hotel_Price;
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, No Hotels Available Please Search Again ");
                }
            }
            return View();

        }



        // GET: Booking_Flights
        public ActionResult Booking_Flights()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Booking_Flights(Booking F)
        {
            using (TravelODBContext db = new TravelODBContext())
            {
                var booking = db.booking.FirstOrDefault(u => u.From == F.From && u.TO == F.TO
                && u.Departure == F.Departure && u.Return == F.Return && u.Adults == F.Adults
                && u.Childs == F.Childs && u.Class == F.Class);

                if (booking != null)
                {

                    ViewBag.MSG = "Congratulations, There is a Flight From the " + " " + booking.From + " " + "TO"
                      + "  " + booking.TO + " " + "on" + " " + booking.Flight_Date + " "+ "With Price:"
                      + " " + booking.Flight_Price;
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, No Flights Available Please Search Again ");
                }
            }
            return View();

        }
    }
}