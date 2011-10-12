using System.Collections.Generic;
using System.Linq;

namespace GenericRest.Models
{
    public static class DogDB
    {
        public static int IDCount = 5;
        public static IList<Dog> Dogs = new List<Dog>
            {
                new Dog {ID = 1, Age = 13, Breed = Breed.Cockapoo.ToString(), Name = "Duncan", Owner = "abcdefg123"},
                new Dog {ID = 2, Age = 11, Breed = Breed.GermanShepherd.ToString(), Name = "Zeke", Owner = "abcdefg123"},
                new Dog {ID = 3, Age = 9, Breed = Breed.Pitbull.ToString(), Name = "Ruby", Owner = "123abcdefg"},
                new Dog {ID = 4, Age = 4, Breed = Breed.Pitbull.ToString(), Name = "Joey", Owner = "abcdef1234"},
            };

        public static Dog AddOrUpdateDog(Dog dog)
        {
            if(dog.ID == 0)
            {
                dog.ID = IDCount++;
                Dogs.Add(dog);
            } else
            {
                var toUpdate = Dogs.SingleOrDefault(x => x.ID == dog.ID);
                toUpdate.Age = dog.Age;
                toUpdate.Breed = dog.Breed;
                toUpdate.Name = dog.Name;
                toUpdate.Owner = dog.Owner;
            }
           
            return dog;
        }

        public static bool RemoveDog(int dogID)
        {
            var dog = Dogs.SingleOrDefault(x => x.ID == dogID);
            return Dogs.Remove(dog);
        }
    }
}