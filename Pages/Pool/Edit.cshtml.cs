/*  Currently not using this class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rekordpool.Data;
using Rekordpool.Models;

namespace Rekordpool.Pages.Pool
{
    public class EditModel : PageModel
    {
        private readonly Rekordpool.Data.ApplicationDbContext _context;

        public EditModel(Rekordpool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Track.FirstOrDefaultAsync(m => m.ID == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(Track.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.ID == id);
        }
    }
}*/
