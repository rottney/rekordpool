using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rekordpool.Data;
using Rekordpool.Models;

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

        //static readonly HttpClient client = new HttpClient();

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client = new HttpClient();

            if (Track.Link.Contains("soundcloud")) 
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
            }
            else if (Track.Link.Contains("spotify"))
            {
                try	
                {
                    HttpResponseMessage response = await client.GetAsync(Track.Link);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }

                /*using (WebClient client = new WebClient())
                {
                    string htmlCode = client.DownloadString(Track.Link);
                    Console.WriteLine(htmlCode);
                }*/
            }
            else
            {
                try	
                {
                    HttpResponseMessage response = await client.GetAsync(Track.Link);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                    Console.WriteLine("dErPy dOo-DoO");
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");	
                    Console.WriteLine("Message :{0} ",e.Message);
                }
            }

            _context.Track.Add(Track);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
