namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;

    public class CarRepositoryMock : ICarsRepositoryMock
    {
        public CarRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCarsRepositoryMock();
        }

        public ICarsRepository CarsData { get; private set; }

        public ICollection<Car> FakeCarCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeCarCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A4", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };
        }

        protected void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.Remove(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(x => x.Make).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(x => x.Year).ToList());
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}
