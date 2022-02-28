using System.ComponentModel.DataAnnotations;

namespace InClassU2M6.Models
{
    public class Player
    {
        [Required(ErrorMessage = "You must enter a name!")]
        public int PlayerID { get; set; }
        [Required(ErrorMessage = "You must enter a name!")]
        public string Name { get; set; }

    }
}