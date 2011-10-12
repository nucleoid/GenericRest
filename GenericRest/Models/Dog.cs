

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GenericRest.Models
{
    public class Dog
    {
        private Breed BreedType { get; set; }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Owner { get; set; }

        public string Breed
        {
            get { return BreedType.ToString(); }
            set { BreedType = (Breed)Enum.Parse(typeof(Breed), value); }
        }
    }
}