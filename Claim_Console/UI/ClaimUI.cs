using ChallengeTwo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Console.UI
{
    public class ClaimUI
    {
        private readonly ClaimRepository _claimRepository = new ClaimRepository();
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
                Console.WriteLine("Choose a menu item \n" +
                "1. See all claims \n" +
                "2. Take care of a claim \n" +
                "3. Enter a new claim");

                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        SeeAllClaims();
                        break;

                    case 2:
                        TakeCareOfClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    default:
                        continueToRun = false;
                        break;
                }
            }

        }

        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimQueue = _claimRepository.GetAllClaims();
            _claimRepository.DisplayContent();
            Console.WriteLine("Press any key to conitue");
            Console.ReadKey();
        }

        public void TakeCareOfClaim()
        {
            Console.Clear();

            Claim newClaim = _claimRepository.ClaimNextInQueue();

            Console.WriteLine($"ClaimID: {newClaim.ClaimId} \n" +
                $"Type: {newClaim.ClaimType} \n" +
                $"Description: {newClaim.Description}  \n" +
                $"Amount: {newClaim.ClaimAmount} \n" +
                $"DateOfIncident: {newClaim.DateOfIncident} \n" +
                $"DateOfClaim: {newClaim.DateOfClaim} \n" +
                $"IsValid: {newClaim.IsValid}");

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            char r = char.Parse(Console.ReadLine());

            if (r == 'y')
            {
                _claimRepository.PullItemFromQueue();
                Console.ReadKey();
                Console.Clear();
            }
            else if (r == 'n')
            {
                Console.Clear();

            }
        }

        public void EnterNewClaim()
        {
            Claim newClaimItem = new Claim();
            Console.WriteLine("Enter ClaimId:");
            newClaimItem.ClaimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int number = int.Parse(Console.ReadLine());

            switch (number)
            {
                case 1:
                    newClaimItem.ClaimType = TypeOfClaim.Car;
                    break;
                case 2:
                    newClaimItem.ClaimType = TypeOfClaim.Home;
                    break;
                case 3:
                    newClaimItem.ClaimType = TypeOfClaim.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid type");
                    break;
            }

            Console.WriteLine("Enter a claim description:");
            newClaimItem.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage:");
            newClaimItem.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("DateOfAccident:");
            newClaimItem.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("DateOfClaim:");
            newClaimItem.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            if (newClaimItem.IsValid == true)
            {
                Console.WriteLine("This claim is valid");
            }
            else
            {
                Console.WriteLine("This claim is not valid");
            }
            Console.ReadKey();
            _claimRepository.AddClaimToQeue(newClaimItem);
        }

        public void SeedContent()
        {
            Claim claim1 = new Claim(1, TypeOfClaim.Car, "Car Accident on 465", 400.00d, new DateTime(2018, 4, 25), new DateTime(2018, 4, 28));
            Claim claim2 = new Claim(2, TypeOfClaim.Home, "House fire in Kitchen", 4000.00d, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(3, TypeOfClaim.Theft, "Stolen pancakes", 4.00d, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _claimRepository.AddClaimToQeue(claim1);
            _claimRepository.AddClaimToQeue(claim2);
            _claimRepository.AddClaimToQeue(claim3);
        }
    }
}
