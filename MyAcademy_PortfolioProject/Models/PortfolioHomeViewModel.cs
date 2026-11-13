using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Models;

public class PortfolioHomeViewModel
{
    public About? About { get; init; }
    public Contact? Contact { get; init; }
    public Setting? Settings { get; init; }
    public IReadOnlyList<Education> Educations { get; init; } = [];
    public IReadOnlyList<Experience> Experiences { get; init; } = [];
    public IReadOnlyList<Skill> Skills { get; init; } = [];
    public IReadOnlyList<SocialMedia> SocialLinks { get; init; } = [];
    public Message ContactMessage { get; init; } = new();
    public string DisplayName => About?.NameSurname ?? Settings?.SiteTitle ?? "Portfolyo";
}
