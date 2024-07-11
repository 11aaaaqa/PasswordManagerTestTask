using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PasswordManagerTestTask.ViewModels;

namespace PasswordManagerTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordManager(IRepository<PasswordRecord> repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PasswordRecord>>> GetAllPasswordsAsync()
        {
            return new OkObjectResult(await repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PasswordRecord>> CreatePasswordRecordAsync(PasswordViewModel model)
        {
            var record = new PasswordRecord
                { Id = Guid.NewGuid(), Password = model.Password, CreatedAt = DateOnly.FromDateTime(DateTime.Now) }; // todo: SiteOrMailName
            await repository.CreateAsync(record);
            return new OkObjectResult(record);
        }
    }
}
