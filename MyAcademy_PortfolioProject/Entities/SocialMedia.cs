using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }

        [Required]
        [StringLength(100)]
        public string PlatformName { get; set; } = string.Empty;

        [Required]
        [Url]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Icon { get; set; }

        public bool IsActive { get; set; } = true;
    }
}