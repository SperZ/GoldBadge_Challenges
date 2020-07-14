using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repository
{
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _menuCatalog = new List<MenuItem>();

        //Create
        public bool AddMenuItems(MenuItem item)
        {
            int startingCount = _menuCatalog.Count;
            _menuCatalog.Add(item);
            bool menuItemAdded = (startingCount < _menuCatalog.Count) ? true : false;
            return menuItemAdded;
        }


        public void DisplayContent(MenuItem item)
        {
            var joinedIngredients = string.Join(", ", item.Ingredients) ; //takes all of the items in ingredients list and joining the together seperated items
            Console.WriteLine($"Meal Number:{item.MealNumber} \n" +
                $"Meal Name: {item.MealName} \n" +
                $"Description: {item.Description} \n" +
                $"Ingredients: {joinedIngredients} \n" + /// need to convert items to string // this will print a string of items in a list joined together
                $"Cost: {item.Cost}");
        }

        //Read
        public List<MenuItem> ReturnMenuItems()
        {
            return _menuCatalog;
        }

        public MenuItem GetMenuItemByMealNumber(int number)
        {
            foreach (MenuItem s in _menuCatalog)
            {
                if (s.MealNumber == number)
                {
                    return s;
                }
            }
            return null;
        }

        //Update
        public bool UpdateMenuItem(int number, MenuItem newItem)
        {
            MenuItem oldItem = GetMenuItemByMealNumber(number);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Description = newItem.Description;
                oldItem.Cost = newItem.Cost;
                return true;
            }

            else
            {
                return false;
            }

        }

        public bool RemoveMenuItem(MenuItem item)
        {
            bool itemWasRemoved = _menuCatalog.Remove(item);

            return itemWasRemoved;
        }
    }
}
