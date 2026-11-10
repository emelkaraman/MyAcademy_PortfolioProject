using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Education
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Eğitim başlığı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Eğitim başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Alt başlık en fazla 100 karakter olabilir.")]
        public string? SubTitle { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eğitim süresi boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Eğitim süresi en fazla 50 karakter olabilir.")]
        public string Duration { get; set; } = string.Empty;

        //Veritabanından silmeden aktif değilse gösterilmemesi için IsActive özelliği eklendi.
        public bool IsActive { get; set; } = true;
    }
}