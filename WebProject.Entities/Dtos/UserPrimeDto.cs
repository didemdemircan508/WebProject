using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities.Entities.Entity;

namespace WebProject.Entities.Dtos
{
    public class UserPrimeDto
    {
        public int UserId { get; set; }

        public string Numbers { get; set; }

        public int LargestPrimeNumber { get; set; }
    }
}
