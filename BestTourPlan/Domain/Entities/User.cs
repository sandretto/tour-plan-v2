using System.ComponentModel.DataAnnotations;

namespace BestTourPlan.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Please specify user name")]
        [Display(Name = "Name")]
        public override string Name { get; set; }
        [Required(ErrorMessage = "Please specify email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please specify password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
