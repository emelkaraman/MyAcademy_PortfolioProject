namespace MyAcademy_PortfolioProject.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
        public string CoverImgUrl { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
