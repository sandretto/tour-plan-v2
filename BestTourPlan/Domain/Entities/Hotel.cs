using System.ComponentModel.DataAnnotations;

namespace BestTourPlan.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        [Required(ErrorMessage = "Please specify hotel name")]
        [Display(Name = "Name")]
        public override string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please specify hotel rating")]
        [Display(Name = "Rating")]
        public double Rating { get; set; }
        [Required(ErrorMessage = "Please specify price per room")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
