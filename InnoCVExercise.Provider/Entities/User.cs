﻿using System;
using System.ComponentModel.DataAnnotations;

namespace InnoCVExercise.Provider.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
