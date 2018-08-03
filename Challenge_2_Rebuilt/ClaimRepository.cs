using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Rebuilt
{
    class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public int claimCount = 0;

        public void AddClaim(ClaimType type, string desc, decimal amount, DateTime incidentDate, DateTime claimDate)
        {
            claimCount++;

            bool valid = false;
            if (((claimDate - incidentDate).TotalDays) < 30)
                valid = true;

            Claim newClaim = new Claim(claimCount, type, desc, amount, incidentDate, claimDate, valid);
            _claimQueue.Enqueue(newClaim);
        }

        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }

        public void CountDown()
        {
            claimCount--;
        }
    }
}
