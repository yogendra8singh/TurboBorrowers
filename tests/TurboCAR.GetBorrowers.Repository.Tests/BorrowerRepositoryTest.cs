using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetBorrowers.Model;
using Xunit;

namespace TurboCAR.GetBorrowers.Repository.Tests
{
    public class BorrowerRepositoryTest
    {
        private BorrowerRepository repository = null;
        private Borrower expectedBorrower = null;
        private int expectedCount = 494;
        public BorrowerRepositoryTest()
        {
            repository = new BorrowerRepository();
            expectedBorrower = new Borrower() { Id = 1, Name = "MICROSEMI CORP- POWER PRODUCTS GRP", CIF = "100000004" };
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var result = repository.GetAsync();
            int actual = result.Result.Count;
            Assert.True(actual == expectedCount);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            var actual = repository.GetAsync(1).Result;
            Assert.True(actual.Id == expectedBorrower.Id && actual.Name == expectedBorrower.Name && actual.CIF == expectedBorrower.CIF);
        }
    }
}
