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

namespace DavidsCatfishHouse.Controllers
{
    public class ShiftController : TwilioController
    {
        // GET: Shift
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
                    var v = dc.Events.Where(a => a.Id == e.Id).FirstOrDefault();
                    if(v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        throw new Exception("Error message");
                    }
                    throw new Exception("Error message");
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
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
        
        public ActionResult SendSms(Event e)
        {


            var accountSid = "AC114e1e5fbd21555dbc648c31da2f0e9f";
            var authToken = "731d19eae9e531540d696ff443d3ed91";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+18456084783");
            var from = new PhoneNumber("+12512415058");

            var message = MessageResource.Create(

                to: to,
                from: from,
                body: "The work scheduled has been updated please check the calendar"
                );
            return Content(message.Sid);
        }
        public ActionResult ReceiveSms()
        {
            var response = new MessagingResponse();
            response.Message("The dogs are hairy");
            return TwiML(response);
        }
    }
}