
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Models
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int ActiveProjects { get; set; }
        public int TotalSkills { get; set; }
        public int TotalExperiences { get; set; }
        public int TotalEducations { get; set; }

        public int TotalMessages { get; set; }
        public int ReadMessages { get; set; }
        public int UnreadMessages { get; set; }

        public List<Message> RecentMessages { get; set; } = new();
        public List<Project> RecentProjects { get; set; } = new();

        public Dictionary<string, int> ProjectsByCategory { get; set; } = new();
    }
}
