using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserPrimeNumberRepository UserPrimeNumbers { get; }
       

        Task<int> SaveAsync();
    }
}
