using System;
using System.ComponentModel.DataAnnotations;

namespace Rekordpool.Models
{
    public class Track
    {
        public int ID { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        public string Title { get; set; }
        [Display(Name = "Added By")]
        public string AddedBy { get; set; }
        public string Link { get; set; }
    }
}
