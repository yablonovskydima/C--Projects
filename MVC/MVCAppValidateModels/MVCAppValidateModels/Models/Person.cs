using System.ComponentModel.DataAnnotations;

namespace MVCAppValidateModels.Models
{
    public class Person
    {
        
        [Required(ErrorMessage = "Invalid Name")]
        [StringLength(20, MinimumLength =2, ErrorMessage ="Leghts must be from 2 to 20 charachters")]
        public string? Name { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Invalid Email")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+@\.[A-Za-z]{2,4}", ErrorMessage = "Incorrext input")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Incorrect password")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Leghts must be from 5 to 30 charachters")]
        public string? Password { get; set; }
        [CreditCard(ErrorMessage ="Invalid card number")]
        public string? CreditCard { get; set; }
        [Url(ErrorMessage = "Inccorect link")]
        public string? Site { get; set; }
    }
}
