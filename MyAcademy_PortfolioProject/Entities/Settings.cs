
using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Setting
    {
        public int SettingID { get; set; }

        [Required(ErrorMessage = "Site başlığı boş bırakılamaz.")]
        [StringLength(150)]
        public string SiteTitle { get; set; } = string.Empty;

        [StringLength(500)]
        public string? SiteDescription { get; set; }

        [StringLength(500)]
        public string? CvFilePath { get; set; }
    }
}
