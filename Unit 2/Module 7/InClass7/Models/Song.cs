using System;
using System.ComponentModel.DataAnnotations;

namespace InClass7.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Album { get; set; }
        [Required]
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}