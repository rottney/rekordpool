using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

using System.Data;

using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace Rekordpool.Models
{
    public class Track// : IValidatableObject
    {
        public int ID { get; set; }

        //[Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        //[Required]
        public string Title { get; set; }
        
        [Display(Name = "Added By")]
        public string AddedBy { get; set; }

        [Required]
        // Currently only supporting SoundCloud
        [RegularExpression(@"^.*https://w.soundcloud.com/player.*$",
            ErrorMessage = "Not a valid SoundCloud mini embed link.  " 
            + "Please see help page for instructions.")]
        public string Link { get; set; }


        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // OLD VALIDATION
            //var client = new HttpClient();
            //HttpResponseMessage response = MyGet(client, Link).Result;
            //HttpContent responseContent = response.Content;
            //String htmlText = ReadHtml(responseContent).Result;

            //if (htmlText.ToUpper().IndexOf(ArtistName.ToUpper()) == -1
            //    || htmlText.ToUpper().IndexOf(Title.ToUpper()) == -1)
            //{

            // FIX MEEEE...
            if (validationContext.Equals(null))
            {
                yield return new ValidationResult(
                    "Artist Name and Title do not match provided link.",
                    new[] { nameof(Link) });
            }
        }*/

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
