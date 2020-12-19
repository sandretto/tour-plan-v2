using System;
using System.ComponentModel.DataAnnotations;

namespace BestTourPlan.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }

        [Required]
        public Guid Id { get; set; }
        [Display(Name = "Name")]
        public virtual string Name { get; set; }
        [Display(Name ="Image Path")]
        public string ImagePath { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } 
    }
}
