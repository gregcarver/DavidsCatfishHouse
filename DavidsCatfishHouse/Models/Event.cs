using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DavidsCatfishHouse.Models
{
    public class Event
    {
        
        public int Id { get; set; }
        
        public string Subject { get; set; }
        public string Description { get; set; }
        //[Required]
        //[Range(typeof(TimeSpan), "11:00","21:00")]
        public DateTime Start { get; set; }
        //[Required]
        //[Range(typeof(TimeSpan), "11:00", "21:00")]
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}