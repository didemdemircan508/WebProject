using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebProject.Shared.Abstract;

namespace WebProject.Shared.Concrete.EnitityFramework
{
    public class EfEntitiyRepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public EfEntitiyRepositoryBase(DbContext context)
        {
            _context = context;


        }

        public async  Task AddAsync(T model)
        {
          var result=await _context.Set<T>().AddAsync(model);
         }

        public async  Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.ToListAsync();
        }

      

    }
}
