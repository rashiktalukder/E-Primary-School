using System.ComponentModel.DataAnnotations;

namespace E_Primary_School.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string userId { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int userType { get; set; }




    }
}
