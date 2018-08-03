using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Rebuilt
{
    public enum ClaimType
    {
        Car, Home, Theft
    }

    public class Claim
    {
        public Claim(int id, ClaimType type, string desc, decimal amount, DateTime incidentDate, DateTime claimDate, bool valid)
        {
            ClaimID = id;
            ClaimType = type;
            Description = desc;
            ClaimAmount = amount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
            IsValid = valid;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }
}
