
using Microsoft.AspNetCore.Mvc;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            if (_context.Contacts.Any())
                return RedirectToAction("ContactList");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            if (_context.Contacts.Any())
            {
                TempData["Error"] = "İletişim bilgisi zaten mevcut.";
                return RedirectToAction("ContactList");
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            var existing = _context.Contacts.Find(contact.ContactId);

            if (existing == null)
                return NotFound();

            existing.Description = contact.Description;
            existing.Email = contact.Email;
            existing.Linkedin = contact.Linkedin;
            existing.Locatioan = contact.Locatioan;
            existing.Github = contact.Github;
            existing.SubDescription = contact.SubDescription;

            _context.SaveChanges();

            return RedirectToAction("ContactList");
        }
    }
}
