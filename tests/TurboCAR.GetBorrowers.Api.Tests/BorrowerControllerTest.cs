using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurboCAR.GetBorrowers.Api.Controllers;
using TurboCAR.GetBorrowers.Model;
using TurboCAR.GetBorrowers.Repository;
using Xunit;

namespace TurboCAR.GetBorrowers.Api.Tests
{
    public class BorrowerControllerTest
    {
        private BorrowerController controller = null;
        private IBorrowerRepository repository = null;
        private Borrower expectedBorrower = null;
        private List<Borrower> borrowers = null;
        public BorrowerControllerTest()
        {
            repository = Substitute.For<IBorrowerRepository>();
            controller = new BorrowerController(repository);
            expectedBorrower = new Borrower() { Id = 1, Name = "MICROSEMI CORP- POWER PRODUCTS GRP", CIF = "100000004" };
            borrowers = JsonConvert.DeserializeObject<List<Borrower>>("[{\"id\":1,\"name\":\"MICROSEMI CORP- POWER PRODUCTS GRP\",\"cif\":\"100000004\"},{\"id\":2,\"name\":\"NEUROCOM INTERNATIONAL INC\",\"cif\":\"100000013\"},{\"id\":3,\"name\":\"DANIEL D JACKSON & JEANNE R JACKSON 1995 IRREVOCABLE TRUST\",\"cif\":\"100000036\"}]");
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            repository.GetAsync().Returns(Task.Run(() => borrowers));
            var result = controller.Get();
            int actual = result.Result.Count;
            Assert.True(actual == borrowers.Count);
        }

        [Fact]
        public async Task GetAsyncWithParameterTest()
        {
            repository.GetAsync(Arg.Any<int>()).Returns(Task.Run(() => expectedBorrower));
            var actual = repository.GetAsync(1).Result;
            Assert.True(actual.Id == expectedBorrower.Id && actual.Name == expectedBorrower.Name && actual.CIF== expectedBorrower.CIF);
        }
    }
}
