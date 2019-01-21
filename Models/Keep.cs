using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Img { get; set; }
        public bool isPrivate { get; set; }
        [Required]
        public string UserId { get; set; }
        public int Views { get; set; }
        public int VaultAdds { get; set; }
    }
}