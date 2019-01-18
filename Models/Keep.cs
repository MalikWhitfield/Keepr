using System;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isPrivate { get; set; }
        public int UserId { get; set; }
        public int Views { get; set; }
        public int VaultAdds { get; set; }
    }
}