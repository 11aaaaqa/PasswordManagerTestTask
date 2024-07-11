using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordManagerTestTask.ViewModels;

namespace PasswordManagerTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordManager(IRepository<PasswordRecord> repository, ApplicationDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PasswordRecord>>> GetAllPasswordsAsync()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PasswordRecord>> CreatePasswordRecordAsync(PasswordRecordViewModel model)
        {
            var record = await context.Passwords.SingleOrDefaultAsync(x => x.SiteOrMailName == model.SiteOrMailName);
            if (record != null) 
                return Conflict("Запись об этом сайте/почте уже существует");

            var addedRecord = await repository.CreateAsync(new PasswordRecord
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                Password = model.Password,
                SiteOrMailName = model.SiteOrMailName
            });
            return Ok(addedRecord);
        }
    }
}
