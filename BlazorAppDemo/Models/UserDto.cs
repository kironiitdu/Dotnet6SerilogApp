using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Models
{
    public class UserDto
    {

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
    }
}
