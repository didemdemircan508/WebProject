using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data.Abstract;
using WebProject.Entities.Entities.Entity;
using WebProject.Shared.Concrete.EnitityFramework;

namespace WebProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfUserPrimeNumberRepository: EfEntitiyRepositoryBase<UserPrimeNumber>,IUserPrimeNumberRepository
    {
        public EfUserPrimeNumberRepository(DbContext context): base(context)
        {
            
        }
    }
}
