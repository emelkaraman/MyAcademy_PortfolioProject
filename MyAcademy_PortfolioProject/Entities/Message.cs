using System.ComponentModel.DataAnnotations;

namespace MyAcademy_PortfolioProject.Entities
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Ad soyad boş bırakılamaz.")]
        [StringLength(100)]
        public string NameSurname { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Konu boş bırakılamaz.")]
        [StringLength(150)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mesaj boş bırakılamaz.")]
        [StringLength(2000)]
        public string MessageDetail { get; set; } = string.Empty;

        public DateTime SendDate { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}