using System;
using System.ComponentModel.DataAnnotations;

namespace InnoCVExercise.PresentationLayer.Models
{
    public class UserModel
    {        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public override bool Equals(object obj)
        {
            var castObj = (UserModel)obj;
            bool isEqual = castObj.Id == Id;
            isEqual = isEqual && castObj.Name == Name;
            isEqual = isEqual &&  castObj.Birthdate == Birthdate;

            return isEqual;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
