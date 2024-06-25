using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public enum DayTime
    {
        [Display(Name = "Morning")]
        Morning,
        [Display(Name = "Afternoon")]
        Afternoon,
        [Display(Name = "Evening")]
        Evening,
        [Display(Name ="Night")]
        Night
    }

    public class DayTimeViewModel
    {
        public DayTime Period { get; set; }
    }
}
