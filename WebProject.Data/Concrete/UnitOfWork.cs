using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Data.Concrete.EntityFramework.Context;
using WebProject.Data.Concrete.EntityFramework.Repositories;

namespace WebProject.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly EfUserPrimeNumberRepository _userPrimeNumberRepository;
      

        public IUserPrimeNumberRepository UserPrimeNumbers=> _userPrimeNumberRepository ?? new EfUserPrimeNumberRepository(_context);

     


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async  ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
