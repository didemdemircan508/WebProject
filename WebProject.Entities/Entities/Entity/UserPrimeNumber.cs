using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Entities.Entities.Entity
{
    public class UserPrimeNumber
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Numbers { get; set; } 

        public int LargestPrimeNumber { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
