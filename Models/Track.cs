using System;
using System.ComponentModel.DataAnnotations;

namespace Rekordpool.Models
{
    public class Track
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
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$",
            ErrorMessage = "Link must be a valid URL.  "
            + "Please copy link directly from Spotify or SoundCloud.")]
        //[RegularExpression(@"^[a-zA-Z0-9-,]*spotify|soundcloud[a-zA-Z0-9-,]*$",
          //  ErrorMessage = "Must be a valid Spotify or SoundCloud link.")]
        public string Link { get; set; }
    }
}
