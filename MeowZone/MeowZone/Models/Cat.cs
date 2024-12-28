﻿using MeowZone.Enums;

namespace MeowZone.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string? Breed { get; set; }
        public string? Color { get; set; }
        public Gender? Gender { get; set; }
    }
}