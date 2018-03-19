using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DavidsCatfishHouse.Models
{
    public class Twilio
    {
        static void Main(string[] args)
        {
            TwilioClient.Init(
                Environment.GetEnvironmentVariable("AC114e1e5fbd21555dbc648c31da2f0e9f"),
                Environment.GetEnvironmentVariable("731d19eae9e531540d696ff443d3ed91"));
            MessageResource.Create(
                to: new PhoneNumber("(845)-608-4783"),
                from: new PhoneNumber("(201) 987-9851"),
                body: "Ahoy from Twilio!");
        }
        

    }
}