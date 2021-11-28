using System.Collections.Generic;
using System.Threading.Tasks;
using FileData;
using LoginExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace api.Impl
{
    public class SqliteService
    {
        private DBContext _dbContext;


        public SqliteService(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        
        public async Task<IList<Adult>> GetAdults()
        {
            return await _dbContext.Adults.ToListAsync();
        }
        
        public async Task<Adult> addAdult(Adult adult)
        {
            EntityEntry<Adult> newAdult = await _dbContext.Adults.AddAsync(adult);
            await _dbContext.SaveChangesAsync();
            return newAdult.Entity;
        }
        
        
        public async Task RemoveAdult(int id)
        {
            Adult adultToRemove = await _dbContext.Adults.FirstAsync(adult => adult.Id == id);
            if (adultToRemove != null)
            {
                _dbContext.Adults.Remove(adultToRemove);
                _dbContext.SaveChangesAsync();
            }

        }


        public async Task<IList<User>> getUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }


        public async Task<User> addUser(User user)
        {
            EntityEntry<User> newAdult = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return newAdult.Entity;
        }

        
        
    }
}