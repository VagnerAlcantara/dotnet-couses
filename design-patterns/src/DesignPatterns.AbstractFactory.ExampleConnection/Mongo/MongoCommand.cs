using System;

namespace DesignPatterns.AbstractFactory.ExampleConnection.Mongo
{
    public class MongoCommand : DbCommand
    {
        public override void Execute()
        {
            Console.WriteLine("xecutando o comando do sql do Mongo");
        }
    }
}
