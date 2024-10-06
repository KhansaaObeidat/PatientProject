using System.ComponentModel.DataAnnotations;

namespace PatientProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        
        public string FirstName { get; set; }
     
        public string? LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
