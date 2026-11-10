using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Url]
        [StringLength(300)]
        public string? Linkedin { get; set; }

        [StringLength(150)]
        public string? Locatioan { get; set; }

        [Url]
        [StringLength(300)]
        public string? Github { get; set; }

        [StringLength(500)]
        public string? SubDescription { get; set; }

    }
}