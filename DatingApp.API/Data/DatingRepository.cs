using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
private DataContext _context;

public DatingRepository(DataContext context)
{
    _context = context;
}

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo; 
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _context.Users.Include(c => c.Photos).FirstOrDefaultAsync(u => u.Id == userId);

            return user; 
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(c => c.Photos).ToListAsync();
            return users; 
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0; 
        }
    }
}