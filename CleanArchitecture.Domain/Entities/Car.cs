﻿using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public int EnginePower { get; set; }


    }
}
