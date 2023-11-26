using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_11_1.Domain.Entities;
using Week_11_1.Persistance.Contexts;

namespace Week_11_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        public PerfectAppDbContext _perfectAppDbContext;

        public BankAccountController(PerfectAppDbContext perfectAppDbContext)
        {
            _perfectAppDbContext = perfectAppDbContext;
        }
        [HttpPost("[action]")]
        public void SetDefaultUsersData()
        {
            List<BankAccount> people = new()
            {

                new BankAccount { Id = Guid.Parse("b3f12b11-9d75-4ad4-9a52-8b7e8b6c0572"), CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1", FirstName = "John", LastName = "Doe", PhoneNumber = "123456789" },
                new BankAccount { Id = Guid.Parse("c9d57a19-3e3a-4eab-aa58-2b10e21ef847"), CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1", FirstName = "Jane", LastName = "Smith", PhoneNumber = "987654321" },
                new BankAccount { Id = Guid.Parse("a2a4d3f5-1c6e-48ab-88b8-35a5e5d1bd84"), CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1", FirstName = "Bob", LastName = "Johnson", PhoneNumber = "555666777" },
                new BankAccount { Id = Guid.Parse("6a3b9e1d-c93e-470f-8ad2-4055eb154f37"), CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1", FirstName = "Alice", LastName = "Brown", PhoneNumber = "999888777" },
                new BankAccount { Id = Guid.Parse("f8ac2c11-8b23-4e20-bfea-34c735e00b82"), CreatedOn = DateTime.UtcNow,
                    CreatedByUserId = "1", FirstName = "Hatice", LastName = "Deveci", PhoneNumber = "065627627" },

            };

            _perfectAppDbContext.People.AddRange(people);

            _perfectAppDbContext.SaveChanges();
        }

        /*
        [HttpGet("[action]/{bankAccountId:guid}")]
        public void GetBankAccountData(Guid bankAccountId)
        {
            var bankaccount = _perfectAppDbContext.BankAccounts.FirstOrDefault(x => x.Id == bankAccountId);

            return $"{bankAccountId.FirstName} - {bankAccountId.LastName} - {bankAccountId.Balance}";
        }
        */
    }
}
