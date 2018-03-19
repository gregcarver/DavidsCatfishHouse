using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DavidsCatfishHouse.Models
{
    public class ShiftChangeRequest
    {
        public string CurrentEmployee { get; set; }
        public string NewEmployee { get; set; }
    }
}