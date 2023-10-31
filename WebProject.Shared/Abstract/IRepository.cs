using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task  AddAsync(T entitiy);
    }
}
