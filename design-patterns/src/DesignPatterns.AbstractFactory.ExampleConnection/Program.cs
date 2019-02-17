using System;
using DesignPatterns.AbstractFactory.ExampleConnection.Sql;

namespace DesignPatterns.AbstractFactory.ExampleConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            DbFactory db = new Mongo.MongoFactory();

            var con = db.CreateConnection();
            con.Open();

            var cmd = db.CreateCommand();

            cmd.Execute();

            Console.ReadLine();

        }
    }
}
