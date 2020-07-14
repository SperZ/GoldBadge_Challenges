using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimQueue = new Queue<Claim>();
        private readonly Claim _claim = new Claim();

        public bool AddClaimToQeue(Claim newClaim)
        {
            int startingCount = _claimQueue.Count();
            _claimQueue.Enqueue(newClaim);
            bool wasAddedToQeue = (startingCount < _claimQueue.Count) ? true : false;

            return wasAddedToQeue;

        }

        public Queue<Claim> GetAllClaims()
        {
            return _claimQueue;
        }

        public Claim ClaimNextInQueue()
        {
            Claim nextInQueue = _claimQueue.Peek();

            return nextInQueue;
        }

        public void DisplayContent()
        {
            Console.WriteLine("ClaimId      Type    Description    Amount    DateOfIncident    DateOfClaim     IsValid");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            foreach (Claim s in _claimQueue)
            {
                Console.WriteLine($"{s.ClaimId}  {s.ClaimType}  {s.Description} {s.ClaimAmount}  {s.DateOfIncident}  {s.DateOfClaim} {s.IsValid} \n");
            }
        }

        public bool PullItemFromQueue()
        {
            Claim nextInQueue = _claimQueue.Peek();
            Claim itemTopull = _claimQueue.Dequeue();

            if(itemTopull == nextInQueue )
            {
                return true;
            }
            else
            {
                return false;
            }  

        }

    }
}
