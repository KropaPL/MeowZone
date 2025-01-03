using MeowZone.Enums;

namespace MeowZone.Models
{
    public class Cat
    {
        /// <summary>
        /// Domain Model for Cat
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string? Breed { get; set; }
        public string? Color { get; set; }
        public GenderOptions? Gender { get; set; }
    }
}
