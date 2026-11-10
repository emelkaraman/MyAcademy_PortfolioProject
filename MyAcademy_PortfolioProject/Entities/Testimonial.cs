using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }

        [Required]
        [StringLength(100)]
        public string NameSurname { get; set; } = string.Empty;

        [StringLength(100)]
        public string? JobTitle { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}