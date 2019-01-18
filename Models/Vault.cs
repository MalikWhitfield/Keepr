using System;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool isPrivate { get; set; }
        public string Description { get; set; }
    }
}