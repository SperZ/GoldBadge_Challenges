using ChallengeOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console.UI
{
    public class MenuUI
    {
        private readonly MenuItemRepository _menuRepo = new MenuItemRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continuetoRun = true;
            while (continuetoRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the option you would like to choose. \n" +
                    "1) View all Menu Items \n" +
                    "2) Add New Menu Item \n" +
                    "3) Delete Menu Item \n");

                int userSelection = int.Parse(Console.ReadLine());

                switch (userSelection)
                {
                    case 1:
                        ViewAllItems();
                        break;
                    case 2:
                        AddNewItem();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    default:
                        Console.WriteLine("Press any key to continue...");
                        break;
                }

            }

        }

        public void ViewAllItems()
        {
            Console.Clear();
            List<MenuItem> allItems = _menuRepo.ReturnMenuItems();

            foreach (MenuItem item in allItems)
            {
                _menuRepo.DisplayContent(item);
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void AddNewItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();
            newItem.Ingredients = new List<string>(); // not rec
            Console.WriteLine("Please Enter the Number you wish to assign to the new menu item");
            //newItem.MealNumber = (int.TryParse(Console.ReadLine(), out int result) ? result : 6) ;
            bool numberNotEntered = true;

            while (numberNotEntered)
            {
                if (int.TryParse(Console.ReadLine(), out int mealNumber)) // (true, false)
                {
                    newItem.MealNumber = mealNumber; // .parse is quicker, tryparse converts to boolean; try check is away of catching an exception without blowing up.
                    numberNotEntered = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }


            Console.WriteLine("Please enter the name of the menu item");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a brief description of the meal");
            newItem.Description = Console.ReadLine();

            bool continueToAddIngredients = true;
            while (continueToAddIngredients)
            {
                Console.WriteLine("Would you like to add a new ingredient \n" + "Yes or no");
                string answer = Console.ReadLine();

                switch (answer.ToLower())
                {
                    case "yes":
                        Console.WriteLine("Please enter a list of ingredients for the menu item");
                        string ingredientToadd = Console.ReadLine();
                        newItem.Ingredients.Add(ingredientToadd);
                        break;
                    case "no":
                        continueToAddIngredients = false;
                        break;
                    default:
                        Console.WriteLine("Press any key to continue");
                        break;
                }

            }

            Console.WriteLine("Please enter the cost of the new menu item");
            newItem.Cost = Convert.ToDouble(Console.ReadLine());

            _menuRepo.AddMenuItems(newItem);
            ;
        }

        public void RemoveItem()
        {
            Console.WriteLine("Which item would you like to remove");
            List<MenuItem> menuList = _menuRepo.ReturnMenuItems();

            int count = 0;
            foreach (MenuItem item in menuList)
            {
                count++;
                Console.WriteLine($"{count} {item.MealName}");

            }

            int targetedMenuItem = int.Parse(Console.ReadLine());
            int menuItemIndex = targetedMenuItem - 1;

            if (menuItemIndex > 0 && menuItemIndex < menuList.Count)
            {
                MenuItem itemToBeRemoved = menuList[menuItemIndex];
                if (_menuRepo.RemoveMenuItem(itemToBeRemoved))
                {
                    Console.WriteLine($"{itemToBeRemoved.MealName} was successfully removed");

                }
                else
                {
                    Console.WriteLine($"{ itemToBeRemoved.MealName} was not removed");
                }
            }
            Console.ReadKey(); 
        }

        public void SeedContent()
        {
            MenuItem item1 = new MenuItem(1, "Fried Chicken", "Fried Chicken and mashed potatoes with gray", new List<string> { "chicken", "flour", "seasonings", "oil", "potatoes", "milk", "butter", "flour" }, 5.50d);
            MenuItem item2 = new MenuItem(2, "Cheesburger", "One quarter pound cheeseburger with fries", new List<string> { "burger patty", "cheese", "pickles", "onion", "ketchup", "mustard" }, 4.00d);
            MenuItem item3 = new MenuItem(3, "Two hard tacos", "Two hard shell tacos with meat and cheese and a churro ", new List<string> { "hard shell tortilla", "meat", "cheese", "churro" }, 4.75d);
            MenuItem item4 = new MenuItem(4, "MeatLoaf", "Meatloaf with mashed potatoes and red gravy", new List<string> { "meat", "bread", "seasonings", "potatoes", "milk", "butter", "flour", "tomato paste" }, 5.50d);
            MenuItem item5 = new MenuItem(5, "Spaghetti and Meatballs", "Spaghetti with marinara, two meatballs, and garlic toast", new List<string> { "pasta", "meat", "bread", "seasonings", "tomatoes", "garlic", "butter" }, 5.00d);

            _menuRepo.AddMenuItems(item1);
            _menuRepo.AddMenuItems(item2);
            _menuRepo.AddMenuItems(item3);
            _menuRepo.AddMenuItems(item4);
            _menuRepo.AddMenuItems(item5);
        }


    }


}

