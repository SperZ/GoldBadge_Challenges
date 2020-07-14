using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> DoorAccess { get; set; }

        public Badge() { DoorAccess = new List<string>(); }

        public Badge(int badgeId, List<string> doorAccess)
        {
            BadgeId = badgeId;
            DoorAccess = doorAccess;
        }
    }

}
