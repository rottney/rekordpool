using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rekordpool.Data;
using Rekordpool.Models;

namespace Rekordpool.Pages.Pool
{
    public class DetailsModel : PageModel
    {
        private readonly Rekordpool.Data.ApplicationDbContext _context;

        public DetailsModel(Rekordpool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
