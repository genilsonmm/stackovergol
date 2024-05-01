using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace stackovergol.Data.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public int Name { get; set; }
    }
}
