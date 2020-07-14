using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Cost { get; set; }

        public MenuItem() { Ingredients = new List<string>(); } // we need to set the ingredinets to a new list of strings here.

        public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, double cost)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Cost = cost;

        }

    }
}
