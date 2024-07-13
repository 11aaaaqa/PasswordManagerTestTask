using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordManagerTestTask.DTOs;

namespace PasswordManagerTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordManagerController : ControllerBase
    {
        private readonly IRepository<PasswordRecord> repository;
        private readonly ApplicationDbContext context;
        public PasswordManagerController(IRepository<PasswordRecord> repository, ApplicationDbContext context)
        {
            this.context = context;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<PasswordRecord>>> GetAllPasswordsAsync()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PasswordRecord>> CreatePasswordRecordAsync(PasswordRecordDto model)
        {
            if (model.RecordType == "email")
            {
                var email = new EmailAddressAttribute();
                if (email.IsValid(model.SiteOrMailName) == false)
                    return BadRequest("Такой почты не существует");
            }
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
