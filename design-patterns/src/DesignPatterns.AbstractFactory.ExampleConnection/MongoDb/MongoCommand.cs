using System;

namespace DesignPatterns.AbstractFactory.ExampleConnection.MongoDb
{
    public class MongoCommand : DbCommand
    {
        public override void Execute()
        {
            Console.WriteLine("Executando o comando do sql do Mongo");
        }
    }
}
