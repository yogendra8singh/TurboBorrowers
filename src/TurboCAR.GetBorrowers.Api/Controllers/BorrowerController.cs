using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TurboCAR.GetBorrowers.Repository;
using TurboCAR.GetBorrowers.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TurboCAR.GetBorrowers.Api.Controllers
{
    
    [Route("api/[controller]")]
    public class BorrowerController : Controller
    {

        private IBorrowerRepository repository;

        public BorrowerController(IBorrowerRepository _repository)
        {
            repository = _repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<Borrower>> Get()
        {
            return await repository.GetAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Borrower> Get(int id)
        {
            return await repository.GetAsync(id);
        }
    }
}
