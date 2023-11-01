using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities.Dtos;
using WebProject.Entities.Entities.Entity;
using WebProject.Services.Abstract;

namespace WebProject.Services.Concrete
{
    public class UserPrimeNumberManager : IUserPrimeNumberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserPrimeNumberManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(UserPrimeAddDto userPrimeAddDto)
        {
            var userPrime = _mapper.Map<UserPrimeNumber>(userPrimeAddDto);

            string numbersString = userPrimeAddDto.Numbers;
            string[] numberStrings = numbersString.Split(',');
            int[] integerArray = numberStrings.Select(int.Parse).ToArray();

            int maxPrime = int.MinValue;

            foreach (int number in integerArray)
            {
                if (IsPrime(number) && number > maxPrime)
                {
                    maxPrime = number;
                }
            }

            if (maxPrime != int.MinValue)
            {
                userPrime.LargestPrimeNumber= maxPrime;
            }
           

            await _unitOfWork.UserPrimeNumbers.AddAsync(userPrime);
            await _unitOfWork.SaveAsync();
           

        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;

        }

        public async Task<List<UserPrimeDto>> GetAll()
        {
            var userPrimeList = await _unitOfWork.UserPrimeNumbers.GetAllAsync();
            var userPrimeListDto = _mapper.Map<List<UserPrimeDto>>(userPrimeList);
            return userPrimeListDto;
        }

      

    }
}
