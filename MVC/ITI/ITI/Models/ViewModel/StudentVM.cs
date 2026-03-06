using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITI.Models.ViewModel
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*"), StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(10, 30)]
        public int Age { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Remote("CheckEmail", "Student", AdditionalFields = "Id")]
        public string Email { get; set; }
        public int DeptNo { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string CPassword { get; set; }
    }
}
