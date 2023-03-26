using System;
namespace CoffeeCupAPI.Models.RequestModels
{
    public class CoffeeCupReqModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public string Material { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [Range(0, Int64.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [Range(0, float.MaxValue)] 
        public float Price { get; set; }
    }
}

