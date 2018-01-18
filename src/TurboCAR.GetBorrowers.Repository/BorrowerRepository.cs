using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetBorrowers.Model;

namespace TurboCAR.GetBorrowers.Repository
{
    public class BorrowerRepository : IBorrowerRepository
    {
        public BorrowerRepository()
        {
        }

        public async Task<List<Borrower>> GetAsync()
        {

            try
            {
                ConnectionMultiplexer Connection = ConnectionMultiplexer.Connect("52.163.252.25:6379");
                IDatabase cache = Connection.GetDatabase();
                var borrowers = JsonConvert.DeserializeObject<List<Borrower>>(cache.StringGet("TurboCAR.BorrowerList"));
                return borrowers;
            }
            catch (Exception ex)
            {
                Log.Error<Exception>("Error", ex);
                throw;
            }


        }

        public async Task<Borrower> GetAsync(int borrowerId)
        {
            var borrowers = await GetAsync();
            return borrowers.Find(x => x.Id == borrowerId);
        }
    }
}
