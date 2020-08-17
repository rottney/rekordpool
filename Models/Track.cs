using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rekordpool.Models
{
    public class Track : IValidatableObject
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Display(Name = "Added By")]
        public string AddedBy { get; set; }

        [Required]
        [RegularExpression(@"^http(s)?://(soundcloud.|open.spotify.)([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$",
            ErrorMessage = "Link must be a valid Spotify or Soundcloud URL.  "
            + "Please copy link directly from Spotify or SoundCloud app.")]
        public string Link { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Console.WriteLine("beep");  // DELETEME

            if (ArtistName == AddedBy) 
            {
                yield return new ValidationResult(
                    "u can't add ur own tracks (4 now)",
                    new[] { nameof(ArtistName), nameof(AddedBy) }); 
            }
        }
    }
}
