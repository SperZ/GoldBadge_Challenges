using ChallengeThree.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console.UI
{
    public class BadgesUI
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        BadgeRepository _badgeRepo = new BadgeRepository();
        Badge _newBadge = new Badge();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option below\n" + 
                    "1. Enter a new badge\n" +
                    "2. Update Doors on a badge\n" +
                    "3. See all badges");

                var userResponse = int.Parse(Console.ReadLine());

                switch (userResponse) 
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                    case 3:
                        SeeAllBadges();
                        break;
                    default:
                        continueToRun = false;
                        break;
                }
            }
        }

        public void UpdateBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> newDictionary = _badgeRepo.GetAllBadges();
            _badgeRepo.DisplayBadges();
            Console.WriteLine("Which badge would you like to edit");
            int badgeToEdit = int.Parse(Console.ReadLine());
            List<string> newList = newDictionary[badgeToEdit];
            Console.WriteLine("Would you like to add or remove a door \n" + 
                "1. Remove\n" +
                "2. Add\n");
            int response = int.Parse(Console.ReadLine());
            if(response == 1)
            {
                Console.WriteLine("Which string would you like to Remove");
                foreach (string s in newList)
                {
                    Console.WriteLine($"{s}");
                }
                string tobeRemoved = Console.ReadLine().ToLower();
                _badgeRepo.RemoveDoor(badgeToEdit, tobeRemoved);
            }
            else if(response == 2)
            {
                Console.WriteLine("What door would you like to add");
                string toBeAdded = Console.ReadLine().ToUpper();
                _badgeRepo.AddDoor(badgeToEdit, toBeAdded);
            }
        }

        public void CreateNewBadge()
        {
            Console.WriteLine("Enter the new  numerical BadgeId:");
            _newBadge.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Add a door that it needs to access.");
            _newBadge.DoorAccess.Add(Console.ReadLine().ToUpper());

            bool continueToLoop = true;
            do
            {
                Console.WriteLine("Any other door it needs to access? (y/n)");
                char answer = char.Parse(Console.ReadLine().ToLower());
                if(answer == 'y')
                {
                    Console.WriteLine("Add a door that it needs to access.");
                    _newBadge.DoorAccess.Add(Console.ReadLine().ToUpper());
                }
                else
                {
                    continueToLoop = false;
                }
            } while (continueToLoop);;

            _badgeRepo.AddBadgeToDictionary(_newBadge);
        }

        public void SeeAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> newDictionary = _badgeRepo.GetAllBadges();
            _badgeRepo.DisplayBadges();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }

        public void SeedContent()
        {
            Badge badge1 = new Badge(15, new List<string> { "A1", "B11" });
            Badge badge2 = new Badge(16, new List<string> { "B15", "C9" });
            Badge badge3 = new Badge(17, new List<string> { "C4", "D2" });

            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);
        }
    }
}
