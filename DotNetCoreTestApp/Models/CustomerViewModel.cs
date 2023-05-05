using DotNetCoreTestApp.Controllers;

namespace DotNetCoreTestApp.Models
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; } 
    }

}
