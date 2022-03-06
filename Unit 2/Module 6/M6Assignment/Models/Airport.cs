using System.ComponentModel.DataAnnotations;

namespace M6Assignment.Models
{
    public class Airport
    {
        public int AirportID { get; set; }
        [Required(ErrorMessage = "You must enter the code of the airport.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "You must enter the name of the airport.")]
        public string Name { get; set; }
    }
}
