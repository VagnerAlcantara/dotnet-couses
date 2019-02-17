using System;

namespace DesignPatterns.AbstractFactory.ExampleConnection.Sql
{
    public class SqlConnection : DbConnection
    {
        public override void Open()
        {
            Console.WriteLine("Método Open de SQL Connection foi chamado");
        }
    }
}
