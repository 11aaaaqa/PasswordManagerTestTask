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
    }
}
