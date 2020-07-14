using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
{
    public enum TypeOfClaim { Car, Home, Theft }

    public class Claim
    {
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan duration = DateOfClaim - DateOfIncident;// equation can go inside get statements
                int days = duration.Days;

                if (days > 30)// needs a fix;  
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Claim() { }
        public Claim(int claimId, TypeOfClaim claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

    }
}
