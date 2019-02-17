using System;

namespace DesignPatterns.AbstractFactory.ExampleConnection.Mongo
{
    public class MongoConnection : DbConnection
    {
        public override void Open()
        {
            Console.WriteLine("Método Open de Mongo Connection foi chamado");

        }
    }
}
