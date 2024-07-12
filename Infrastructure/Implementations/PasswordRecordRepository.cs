using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class PasswordRecordRepository : IRepository<PasswordRecord>
    {
        private readonly ApplicationDbContext context;
        public PasswordRecordRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<PasswordRecord>> GetAllAsync() =>
            await context.Passwords.OrderByDescending(x => x.CreatedAt).ToListAsync();

        public async Task<PasswordRecord> CreateAsync(PasswordRecord entity)
        {
            context.Passwords.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<PasswordRecord> UpdateAsync(PasswordRecord entity)
        {
            context.Passwords.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var record = await context.Passwords.SingleOrDefaultAsync(x => x.Id == id);
            if (record == null)
                throw new ArgumentException("Пользователя с таким идентификатором не существует");
            context.Passwords.Remove(record);
            await context.SaveChangesAsync();
        }
    }
}
