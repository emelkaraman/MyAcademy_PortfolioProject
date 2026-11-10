using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Experience
    {
        public int ExperienceID { get; set; }

        [Required(ErrorMessage = "Deneyim başlığı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şirket adı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Şirket adı en fazla 100 karakter olabilir.")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Yan başlık en fazla 100 karakter olabilir.")]
        public string? SideTitle { get; set; }

        [Required(ErrorMessage = "Çalışma süresi boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Çalışma süresi en fazla 50 karakter olabilir.")]
        public string Duration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Çalışma türü boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Çalışma türü en fazla 50 karakter olabilir.")]
        public string WorkType { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}