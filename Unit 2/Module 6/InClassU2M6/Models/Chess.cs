using System.ComponentModel.DataAnnotations;

namespace InClassU2M6.Models
{
    public class Chess
    {
        public int ChessID { get; set; }
        [Required(ErrorMessage = "You must enter a name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter the moves!")]
        public string Moves { get; set; }
    }
}