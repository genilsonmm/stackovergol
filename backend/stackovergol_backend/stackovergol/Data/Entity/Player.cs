using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    [Index(nameof(Username), IsUnique = true)]
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [StringLength(100)]
        public required string Username { get; set; }

        [MaxLength(10), MinLength(6)]
        [Required]
        public required string Password { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public string? Photo { get; set; }

        [Required]
        [MaxLength(5)]
        public int Rating { get; set; }

        [Required]
        public bool IsMember { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
