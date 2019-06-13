using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStream.Console;

namespace TesteStream.Test
{
    [TestClass]
    public class StreamTest
    {
        Stream _stream;

        [DataTestMethod]
        [DataRow("aAbBABacfe")]
        [DataRow("aAbBABacfe")]
        [DataRow("aAbBABacfe")]
        [DataRow("aAbBABacfe")]
        public void GetNextTest(string stream)
        {
            //arrange
            _stream = new Stream(stream);

            //act
            char next = new char();
            while (_stream.HasNext())
            {
                next = _stream.GetNext();
            }
            //assert
            Assert.IsTrue(char.Equals(stream[stream.Length - 1], next));
        }
    }
}
