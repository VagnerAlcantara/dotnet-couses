namespace DesignPatterns.AbstractFactory.ExampleConnection.MongoDb
{
    class MongoFactory : DbFactory
    {
        public override DbCommand CreateCommand()
        {
            return new MongoCommand();
        }

        public override DbConnection CreateConnection()
        {
            return new MongoConnection();
        }
    }
}
