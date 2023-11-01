using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Entities.Dtos;
using WebProject.Entities.Entities.Entity;

namespace WebProject.Services.Abstract
{
    public interface IUserPrimeNumberService
    {
        Task<List<UserPrimeDto>> GetAll();

        Task Add(UserPrimeAddDto userPrimeAddDto);
    }
}
