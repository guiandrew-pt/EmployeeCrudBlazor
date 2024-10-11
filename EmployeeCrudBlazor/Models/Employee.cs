using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrudBlazor.Models
{
	public class Employee
	{
		[Key]
        public int Id { get; set; }

        [Required, MaxLength(50, ErrorMessage = "First Name is too long. Cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

		public string MiddleName { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Last Name is too long. Cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public string Address { get; set; }

        public string PostalCode { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

		public string City { get; set; }

        [Required]
        [RegularExpression(@"^\([\d]{3}\) [\d]{3}-[\d]{4}$", ErrorMessage = "Phone number must be in the format (123) 456-7890")]
        public string PhoneNumber { get; set; }

        public string Designation { get; set; }
    }
}

