using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DavidsCatfishHouse.Models
{
    public class ShiftChangeRequest
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Current Employee")]
        public string CurrentEmployee { get; set; }
        [DisplayName("New Employee")]
        public string NewEmployee { get; set; }
        public string Message { get; internal set; }
        public string Subject { get; internal set; }
        public string Email { get; internal set; }
    }
}