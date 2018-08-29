using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;


namespace DavidsCatfishHouse.Models 
{
    public class ShiftList 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string Name { get; set; }
        [DisplayName("Tuesday")]
        public TuesdayShiftList TuesdayShift { get; set; }
        [DisplayName("Wednesday")]
        public WednesdayShiftList WednesdayShift { get; set; }
        [DisplayName("Thursday")]
        public ThursdayShiftList ThursdayShift { get; set; }
        [DisplayName("Friday")]
        public FridayShiftList FridayShift { get; set; }
        [DisplayName("Saturday")]
        public SaturdayShiftList SaturdayShift { get; set; }
        
    }
    public enum TuesdayShiftList
    {
        [Display(Name = "10-2")]
        TenToTwo,
        [Display(Name = "10-4")]
        TenToFour,
        [Display(Name = "4-Close")]
        FourToClose,
        [Display(Name = "Not Available")]
        NotAvailable,
        
    }
   
    public enum WednesdayShiftList
    {
        [Display(Name = "10-2")]
        TenToTwo,
        [Display(Name = "10-4")]
        TenToFour,
        [Display(Name = "4-Close")]
        FourToClose,
        [Display(Name = "Not Available")]
        NotAvailable,

    }
    
    public enum ThursdayShiftList
    {
        [Display(Name = "10-2")]
        TenToTwo,
        [Display(Name = "10-4")]
        TenToFour,
        [Display(Name = "4-Close")]
        FourToClose,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
    public enum FridayShiftList
    {
        [Display(Name = "10-2")]
        TenToTwo,
        [Display(Name = "10-4")]
        TenToFour,
        [Display(Name = "4-Close")]
        FourToClose,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
    public enum SaturdayShiftList
    {
        [Display(Name = "10-2")]
        TenToTwo,
        [Display(Name = "10-4")]
        TenToFour,
        [Display(Name = "4-Close")]
        FourToClose,
        [Display(Name = "Not Available")]
        NotAvailable,
    }
   
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    [Display(Name ="Employee Name")]
    //    [Required]
    //    public string Name { get; set; }
    //    [Required]
    //    public Days Day { get; set; }
    //    [Required]
    //    public Start Start { get; set; }
    //    [Required]
    //    public End End { get; set; }

    //}
    //public enum Days
    //{
    //    Tuesday,
    //    Wednesday,
    //    Thursday,
    //    Friday,
    //    Saturday
    //}
    //public enum Start
    //{
    //    [Display(Name ="10")]
    //    Ten,
    //    [Display(Name = "4")]
    //    Four
    //}
    //public enum End
    //{
    //    [Display(Name = "2")]
    //    Two,
    //    [Display(Name = "4")]
    //    Four,
    //    Close
    //}
}
