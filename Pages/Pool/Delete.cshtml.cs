using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rekordpool.Models;

namespace Rekordpool.Pages.Pool
{
    public class DeleteModel : PageModel
    {
        private readonly Rekordpool.Data.ApplicationDbContext _context;

        public DeleteModel(Rekordpool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(string link)
        {
            Console.WriteLine(link);
            if (link == null)
            {
                return NotFound();
            }

            Track = await _context.Track.FirstOrDefaultAsync(m => m.Link.Equals(link));

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string link)
        {
            if (link == null)
            {
                return NotFound();
            }

            Track = await _context.Track.FindAsync(link);

            if (Track != null)
            {
                _context.Track.Remove(Track);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
