﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InnoCVExercise.PresentationLayer.Models
{
    public class UserModel
    {        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}