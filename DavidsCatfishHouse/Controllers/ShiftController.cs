using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using DavidsCatfishHouse.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DavidsCatfishHouse.Controllers
{        
    //[Authorize]
    public class ShiftController : TwilioController
    {
        // GET: Shift
        //[Authorize(Roles = "SuperUser")]
        //[Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetShifts()
        {
            using(ApplicationDbContext dc = new ApplicationDbContext())
            {
                var events = dc.Events.ToList();
                
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult SaveEvent(Event e)
        {
            
            var status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                if (e.Id > 0 )
                {
                    //var v = dc.Events.Where(a => a.Id == e.Id).FirstOrDefault();
                    var v = dc.Events.ToList().Find(a => a.Id == e.Id);
                    if(v != null)
                    {
                        v.Subject = e.Subject;

                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        //v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        
                    }
                    
                }
                else
                {
                    dc.Events.Add(e);
                    
                };
                dc.SaveChanges();
                status = true;
                
            }
            
            return new JsonResult { Data = new { status = status } };
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult DeleteEvent(int Id)
        {
            var status = false;
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                var v = dc.Events.Where(a => a.Id == Id).FirstOrDefault();
                if ( v != null)
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
                return new JsonResult { Data = new { status = status } };
        }





    }
}