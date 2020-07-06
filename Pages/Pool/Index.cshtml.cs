using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rekordpool.Data;
using Rekordpool.Models;
using Microsoft.AspNetCore.Authorization;

namespace Rekordpool.Pages.Pool
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Rekordpool.Data.ApplicationDbContext _context;

        public IndexModel(Rekordpool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Track> Track { get;set; }

        public async Task OnGetAsync()
        {
            Track = await _context.Track.ToListAsync();
        }
    }
}
