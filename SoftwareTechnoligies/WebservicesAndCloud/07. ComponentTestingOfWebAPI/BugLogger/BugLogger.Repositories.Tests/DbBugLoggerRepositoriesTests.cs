namespace BugLogger.Repositories.Tests
{
    using DataLayer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using global::Repositories;
    using System.Transactions;
    using System;

    [TestClass]
    public class DbBugLoggerRepositoriesTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void Testinit()
        {
            tran = new TransactionScope();
        }

        [TestMethod]
        public void AddBug_WhenBugIsValid_ShouldAddToDb()
        {
            // Arrange
            var bug = this.GetValidTestBug();

            var context = new BugLoggerContext();
            DbBugsRepository repo = new DbBugsRepository(context);

            //// Act
            repo.Add(bug);
            repo.Save();

            // Assert
            var bugInDb = context.Bugs.Find(bug.Id);
            Assert.IsNotNull(tran);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void FindById_WhenObjectIsInDb_ShouldReturnObject()
        {
            // Arrange
            var bug = this.GetValidTestBug();

            var context = new BugLoggerContext();
            DbBugsRepository repo = new DbBugsRepository(context);

            //// Act
            context.Bugs.Add(bug);
            context.SaveChanges();

            // Assert
            var bugInDb = repo.Find(bug.Id);
            Assert.IsNotNull(tran);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        private Bug GetValidTestBug()
        {
            var bug = new Bug()
            {
                Text = "Test New bug",
                LoggedDate = DateTime.Now,
                Status = Status.Pending,
            };
            return bug;
        }
    }
}
