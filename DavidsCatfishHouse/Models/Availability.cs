using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DavidsCatfishHouse.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [DisplayName("Tuesday")]
        public TuesdayShift TuesdayShift { get; set; }
        [DisplayName("Wednesday")]
        public WednesdayShift WednesdayShift { get; set; }
        [DisplayName("Thursday")]
        public ThursdayShift ThursdayShift { get; set; }
        [DisplayName("Friday")]
        public FridayShift FridayShift { get; set; }
        [DisplayName("Saturday")]
        public SaturdayShift SaturdayShift { get; set; }
    }
    public enum TuesdayShift
    {
        [Display(Name = "Morning Shift")]
        MorningShift,
        [Display(Name = "Evening Shift")]
        EveningShift,
        [Display(Name = "All Day Shift")]
        AllDay,
        [Display(Name = "Not Available")]
        NotAvailable,

    }
    public enum WednesdayShift
    {
        [Display(Name = "Morning Shift")]
        MorningShift,
        [Display(Name = "Evening Shift")]
        EveningShift,
        [Display(Name = "All Day Shift")]
        AllDay,
        [Display(Name = "Not Available")]
        NotAvailable,

    }
    public enum ThursdayShift
    {
        [Display(Name = "Morning Shift")]
        MorningShift,
        [Display(Name = "Evening Shift")]
        EveningShift,
        [Display(Name = "All Day Shift")]
        AllDay,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
    public enum FridayShift
    {
        [Display(Name = "Morning Shift")]
        MorningShift,
        [Display(Name = "Evening Shift")]
        EveningShift,
        [Display(Name = "All Day Shift")]
        AllDay,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
    public enum SaturdayShift
    {
        [Display(Name = "Morning Shift")]
        MorningShift,
        [Display(Name = "Evening Shift")]
        EveningShift,
        [Display(Name = "All Day Shift")]
        AllDay,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
}