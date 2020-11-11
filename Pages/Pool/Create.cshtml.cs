using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rekordpool.Data;
using Rekordpool.Models;

using System.IO;

using System.Net.Http;
using System.Net;

namespace Rekordpool.Pages.Pool
{
    public class CreateModel : PageModel
    {
        private readonly Rekordpool.Data.ApplicationDbContext _context;

        public CreateModel(Rekordpool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Track Track { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Track.Link.Contains("soundcloud")) 
            {
                try 
                {
                    string[] parts = Track.Link.Split("none;\">");
                
                    string artist = parts[1].Substring(0, parts[1].IndexOf("</a>"));
                    string title = parts[2].Substring(0, parts[2].IndexOf("</a>"));

                    artist = artist.Replace("&#x27;", "'");
                    artist = artist.Replace("&amp;", "&");
                    title = title.Replace("&#x27;", "'");
                    title = title.Replace("&amp;", "&");

                    Track.ArtistName = artist;
                    Track.Title = title;

                    _context.Track.Add(Track);
                    await _context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            // Coming soon...Spotify support
            /*else if (Track.Link.Contains("spotify"))
            {
                var client = new HttpClient();
                HttpResponseMessage response = MyGet(client, Track.Link).Result;
                HttpContent responseContent = response.Content;
                String htmlText = ReadHtml(responseContent).Result;
                Console.WriteLine(htmlText);
            }*/

            /*else
            {
            }*/

            //_context.Track.Add(Track);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public async Task<HttpResponseMessage> MyGet(HttpClient client, String link)
        {
            return await client.GetAsync(link);
        }

        public async Task<String> ReadHtml(HttpContent responseContent) {
            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
