using System.ComponentModel.DataAnnotations;

namespace E_Primary_School.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public string empName { get; set; }
        [Required(ErrorMessage = "Email address can not empty")]
        public string empEmail { get; set; }
        [Required]
        public string empPhoneNumber { get; set; }
        [Required]
        public string empGender { get; set; }
        [Required]
        public int empSalary { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int userType { get; set; }
    }
}
