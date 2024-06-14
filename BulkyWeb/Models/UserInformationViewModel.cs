using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public record UserInformationViewModel(
        [Required]
        string Email,

        [Required]
        [DataType(DataType.Password)]
        string Password,

        [Required]
        [DataType(DataType.Password)]
        string ConfirmPassword,

        [Required]
        string FirstName,

        [Required]
        string LastName,

        [Required]
        DateTime DateOfBirth
    );
}
