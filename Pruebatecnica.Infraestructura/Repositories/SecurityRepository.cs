using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebatecnica.Infrastructura.Data;
using PruebaTecnica.Core.Entities;
using PruebaTecnica.Core.Interfaces;

namespace Pruebatecnica.Infraestructura.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly DatabaseContext _dbContext;

        public SecurityRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Security> Get(int id)
        {
            var response = await _dbContext.Security.FirstOrDefaultAsync(x => x.Id == id);
            return response;
        }


        public async Task<Security> Get(string userName, string password)
        {
            var response = await _dbContext.Security.FirstOrDefaultAsync(x => x.Email == userName && x.Password == password);
            return response;
        }

        public async Task<Security> GetByEmail(string email)
        {
            var response = await _dbContext.Security.FirstOrDefaultAsync(x => x.Email == email);
            return response;
        }


        public async Task Insert(Security item)
        {
            _dbContext.Security.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(Security item)
        {
            var current = await Get(item.Id);
            _dbContext.Security.Update(item);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await Get(id);
            _dbContext.Security.Remove(current);

            int rowAfected = await _dbContext.SaveChangesAsync();
            return rowAfected > 0;
        }
    }
}
