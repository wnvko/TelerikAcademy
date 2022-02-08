namespace Company.DataGenerator
{
    using Contracts;
    using Company.Data;

    internal abstract class DataGenerator : IDataGenerator
    {
        private readonly IRandomDataGenerator random;
        private CompanyEntities db;
        private readonly int count;
        private readonly ILogger logger;

        public DataGenerator(IRandomDataGenerator random, CompanyEntities companyEntities, int numberOfItemsToBeGenerated, ILogger logger)
        {
            this.random = random;
            this.db = companyEntities;
            this.count = numberOfItemsToBeGenerated;
            this.logger = logger;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected CompanyEntities Database
        {
            get
            {
                return this.db;
            }

            set
            {
                this.db = value;
            }
        }

        protected int Count
        {
            get
            {
                return this.count;
            }
        }

        protected ILogger Logger
        {
            get
            {
                return this.logger;
            }
        }

        public abstract void Generate();
    }
}
