using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetBorrowers.Model;

namespace TurboCAR.GetBorrowers.Repository
{
    public interface IBorrowerRepository
    {
        Task<List<Borrower>> GetAsync();
        Task<Borrower> GetAsync(int borrowerId);
    }
}
