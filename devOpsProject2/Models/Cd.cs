using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devOpsProject2.Models
{
    public class CD
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Artists { get; set; }
        public int ReleaseYear { get; set; }
        public int TotalTracks { get; set; }
        public int TotalDuration { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
    public class Track
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Authors { get; set; }
        public int Duration { get; set; }
        [Required]
        public int CDId { get; set; }
        public virtual CD CD { get; set; }
    }
}
