using System.ComponentModel.DataAnnotations;

namespace PatientProject.Models.Dtos
{
    public class AddPatientDto
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Name has to be maximum 100 character")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum 100 character")]
        public string? LastName { get; set; }
        [Required]
        
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 digits")]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
