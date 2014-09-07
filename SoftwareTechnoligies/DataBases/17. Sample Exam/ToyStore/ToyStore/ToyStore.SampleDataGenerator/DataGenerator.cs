namespace ToyStore.SampleDataGenerator
{
    using ToyStore.Data;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToyStoreEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, ToyStoreEntities toyStoreEntities, int countOfGeneratedOnjects)
        {
            this.random = randomDataGenerator;
            this.db = toyStoreEntities;
            this.count = countOfGeneratedOnjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected ToyStoreEntities Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
