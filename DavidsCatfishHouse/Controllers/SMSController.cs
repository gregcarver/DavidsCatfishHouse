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






namespace DavidsCatfishHouse.Controllers
{
    public class SMSController : TwilioController
    {
        public ActionResult SendSms()
        {
            var accountSid = "AC114e1e5fbd21555dbc648c31da2f0e9f";
            var authToken = "731d19eae9e531540d696ff443d3ed91";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+18456084783");
            var from = new PhoneNumber("+12512415058");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "The schedule has been updated please check calendar"
                );
            return Content("Success");
            
        }
    }
}