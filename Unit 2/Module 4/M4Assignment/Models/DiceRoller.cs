/* 
* Marshall Westbrook
* CPT-231-S14
* U2-M4 Assignment
* Spring 2022
* A project that demonstrates how to use the basics of ASP.net Core MVC
*/


using System;
using System.ComponentModel.DataAnnotations;
namespace M4Assignment.Models
{
    public class DiceRoller
    {
        [Required]
        [Range(2, 1000)]
        public int Sides { get; set; } = 2;
        [Required]
        [Range(1, 1000)]
        public int DiceCount { get; set; } = 1;
        public int RollAmount { get; set; } = 0;
        public int Roll()
        {
            Random random = new Random();
            for (int i = 0; i < DiceCount; i++)
            {
                RollAmount += random.Next(1, Sides + 1);
            }
            return RollAmount;
        }
    }
}
