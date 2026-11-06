namespace MyAcademy_PortfolioProject.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}