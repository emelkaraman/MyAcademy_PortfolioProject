using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; }
            = new List<Project>();
    }
}