namespace Cars.Tests.JustMock
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using System.Collections.Generic;
    using Cars.Models;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData; //CarRepositoryMock.carsData - all fake methods
        private CarsController controller;

        public CarsControllerTests()
            : this(new CarRepositoryMock())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());


            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void GettingCarByIdShouldReturnADetail()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(100));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GettingCarByIdShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var nullCar = new Car();
            nullCar = null;

            var model = (Car)this.GetModel(() => this.controller.Details(nullCar.Id));
        }

        [TestMethod]
        public void SearchCarsShouldReturnCars()
        {
            var searchString = "Fake String";
            var model = (List<Car>)this.GetModel(() => this.controller.Search(searchString));

            var result = new List<Car>
            {
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
            };


            Assert.AreEqual(result.First<Car>().Id, model.First<Car>().Id);
            Assert.AreEqual(result.First<Car>().Model, model.First<Car>().Model);
            Assert.AreEqual(result.Last<Car>().Make, model.Last<Car>().Make);
            Assert.AreEqual(result.Last<Car>().Year, model.Last<Car>().Year);
        }

        [TestMethod]
        public void SortByMakeShouldReturnSortedCarsCollection()
        {
            var sortByString = "make";

            var model = (List<Car>)this.GetModel(() => this.controller.Sort(sortByString));

            var result = new CarRepositoryMock().FakeCarCollection.OrderBy(m => m.Make).ToList();

            Assert.AreEqual(result.First<Car>().Id, model.First<Car>().Id);
            Assert.AreEqual(result.First<Car>().Model, model.First<Car>().Model);
            Assert.AreEqual(result.Last<Car>().Make, model.Last<Car>().Make);
            Assert.AreEqual(result.Last<Car>().Year, model.Last<Car>().Year);
        }


        [TestMethod]
        public void SortByYearShouldReturnSortedCarsCollection()
        {
            var sortByString = "year";

            var model = (List<Car>)this.GetModel(() => this.controller.Sort(sortByString));

            var result = new CarRepositoryMock().FakeCarCollection.OrderBy(m => m.Make).ToList();

            Assert.AreEqual(result.First<Car>().Id, model.First<Car>().Id);
            Assert.AreEqual(result.First<Car>().Model, model.First<Car>().Model);
            Assert.AreEqual(result.Last<Car>().Make, model.Last<Car>().Make);
            Assert.AreEqual(result.Last<Car>().Year, model.Last<Car>().Year);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByWrongParameterShouldThrowArgumentException()
        {
            var sortByString = "Wrong parameter";

            var model = (List<Car>)this.GetModel(() => this.controller.Sort(sortByString));
        }


        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
