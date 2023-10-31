using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities.DataAnnotations;

namespace WebProject.Entities.Dtos
{
    public class UserPrimeAddDto
    {
      


        public int UserId { get; set; }

        [CommaSeparated(ErrorMessage = "Girilen değerler virgülle ayrılmış sayılar olmalıdır.")]
        public string Numbers { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
