using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class About
    {
        public int AboutID { get; set; }

        [Required]
        [StringLength(100)]
        public string NameSurname { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Location { get; set; }

        [StringLength(200)]
        public string? Expert { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(100)]
        public string? OpenToWork { get; set; }

    }
}