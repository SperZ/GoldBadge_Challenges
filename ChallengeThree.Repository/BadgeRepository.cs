using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class BadgeRepository
    {
        private readonly Badge _badgeInfo = new Badge();
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public bool AddBadgeToDictionary(Badge newBadge)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadge.BadgeId, newBadge.DoorAccess);

            if (startingCount < _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public bool RemoveDoor(int x, string remove)
        {
            if (_badgeDictionary.ContainsKey(x))
            {
                bool wasRemoved = _badgeDictionary[x].Remove(remove);
                return wasRemoved;
            }
            else
            {
                return false;
            }
        }

        public string AddDoor(int y, string add)
        {
            if (_badgeDictionary.ContainsKey(y))
            {
                _badgeDictionary[y].Add(add);
            }
            return add;
        }

        public void DisplayBadges()
        {
            Console.WriteLine("Badge #        DoorAccess");
            foreach (KeyValuePair<int, List<string>> s in _badgeDictionary)
            { string doorAccess = string.Join(" & ", s.Value); 
              Console.WriteLine($"{s.Key}             {doorAccess}");
            }
        }

            
    }
}
