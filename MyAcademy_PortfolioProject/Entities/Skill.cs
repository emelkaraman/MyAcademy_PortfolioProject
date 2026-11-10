using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Skill
    {
        public int SkillID { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; } = string.Empty;

        [Range(0, 100)]
        public int SkillLevel { get; set; }

    }
}