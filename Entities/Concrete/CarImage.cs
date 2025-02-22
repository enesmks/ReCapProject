﻿using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int CarImageId;

        [Key]
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; } 
    }
}
