using System.ComponentModel.DataAnnotations;

namespace BlazorServerCRUD.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public DateTime? Release { get; set; }
    }
}
