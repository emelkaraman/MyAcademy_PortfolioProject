
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_PortfolioProject.Context;
using MyAcademy_PortfolioProject.Entities;

namespace MyAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList(string? search, string? sort)
        {
            var query = _context.Messages
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.NameSurname.Contains(search) ||
                    x.Subject.Contains(search));
            }

            query = sort == "oldest"
                ? query.OrderBy(x => x.SendDate)
                : query.OrderByDescending(x => x.SendDate);

            ViewBag.Search = search;
            ViewBag.Sort = sort;
            ViewBag.UnreadCount = _context.Messages
                .Count(x => !x.IsRead);

            return View(query.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsRead(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
                return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeReadStatus(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
                return NotFound();

            message.IsRead = !message.IsRead;
            _context.SaveChanges();

            return RedirectToAction(nameof(MessageList));
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMessage(Message message)
        {
            if (!ModelState.IsValid)
                return View(message);

            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesaj başarıyla kaydedildi.";

            return RedirectToAction(nameof(MessageList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
                return NotFound();

            _context.Messages.Remove(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesaj başarıyla silindi.";

            return RedirectToAction(nameof(MessageList));
        }
    }
}
