using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DavidsCatfishHouse.Models
{
    public class ShiftChange
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [DisplayName("Current Employee")]
        public string CurrentEmployee { get; set; }
        [Required]
        [DisplayName("New Employee")]
        public string NewEmployee { get; set; }
        [DisplayName("Start of Shift")]
        [Required]
        public int Start { get; set; }
        [Required]
        [DisplayName("End of Shift")]
        public int End { get; set; }
        public string Reason { get; internal set; }
        [EmailAddress]
        public string Email { get; internal set; }
    }
}