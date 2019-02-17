using System;

namespace DesignPatterns.AbstractFactory.ExampleConnection.Sql
{
    public class SqlCommand : DbCommand
    {
        public override void Execute()
        {
            Console.WriteLine("Executando o comando do sql");
        }
    }
}
