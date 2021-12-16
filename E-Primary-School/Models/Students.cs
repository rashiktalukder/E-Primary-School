using System.ComponentModel.DataAnnotations;

namespace E_Primary_School.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userId{ get; set; }
        [Required]
        public string stdName { get; set;}
        [Required]
        public string stdPassword { get; set; }
        [Required]
        public string stdEmail { get; set; }
        [Required]
        public string stdPhone { get; set; }
        [Required]
        public string stdAddress { get; set; }
        [Required]
        public string stdSection { get; set; }
    }
}
