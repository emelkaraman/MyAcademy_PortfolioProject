using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Proje başlığı boş bırakılamaz.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proje açıklaması boş bırakılamaz.")]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [StringLength(500)]
        public string? GithubUrl { get; set; }

        [StringLength(500)]
        public string? CoverImgUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
        public int CategoryID { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}