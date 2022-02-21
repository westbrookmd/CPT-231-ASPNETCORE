using System;
using System.ComponentModel.DataAnnotations;

namespace InClass04.Models
{
    public class DiceRoller
    {
        [Required]
        [Range(2, 1000)]
        public int Sides { get; set; }
        [Required]
        [Range(1, 1000)]
        public int DiceCount { get; set; }
        public int Roll()
        {
            Random random = new Random();
            int total = 0;
            for(int i = 0; i < DiceCount; i++)
            {
                total += random.Next(1, Sides + 1);
            }
            return total;
        }
    }
}
