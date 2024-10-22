using WuwaTrackerBackend.Containers;
using WuwaTrackerBackend.Models;
using Moq;
using WuwaTrackerBackend.Repositories;
using WuwaTrackerBackend.DTOs;

namespace WuWaTrackerBackendTests
{
    [TestClass]
    public class FlowerTests
    {
        [TestMethod]
        public void GetAllFlowers_ShouldReturnAllFlowers()
        {
            var repository = new Mock<IFlowerRepository>();
            repository.Setup(db => db.GetAll()).Returns(GetTestFlowers());
            var testFlowers = GetTestFlowers();
            var container = new FlowerContainer(repository.Object);

            IEnumerable<FlowerDTO> result = container.GetAll();
            Assert.AreEqual(testFlowers.Count, result.ToList().Count);
        }

        private List<Flower> GetTestFlowers()
        {
            var testFlowers = new List<Flower>();
            testFlowers.Add(new Flower { ID = new Guid("cb133b66-2370-4770-8cac-94fa1f2d29cd"), Name = "test1" });
            testFlowers.Add(new Flower { ID = new Guid("6e1f6d12-5642-4654-a3be-f984cdb56d1f"), Name = "test2" });
            testFlowers.Add(new Flower { ID = new Guid("d5c266aa-f010-48cf-942e-3e9e52bbbdf1"), Name = "test3" });
            testFlowers.Add(new Flower { ID = new Guid("a6838615-f0fa-4af6-81d5-5e183ab3f64a"), Name = "test4" });

            return testFlowers;
        }
    }
}