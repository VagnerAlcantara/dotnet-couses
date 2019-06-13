using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteStream.Console;

namespace TesteStream.Test
{
    [TestClass]
    public class StreamTest
    {
        Stream _stream;

        [DataTestMethod]
        [TestCategory("FirstChar")]
        [DataRow("aAbBABacfa")]
        [DataRow("aAbBABacfe")]
        [DataRow("aAbBABacfi")]
        [DataRow("aAbBABacfu")]
        [DataRow("aAbBABacfo")]
        public void FirstCharSuccessTest(string stream)
        {
            //arrange
            _stream = new Stream(stream);

            //act
            var charValue = _stream.FirstChar();
            //assert
            Assert.IsTrue(char.Equals(stream[stream.Length - 1], charValue));
        }

        [DataTestMethod]
        [TestCategory("FirstChar")]
        [DataRow("aAbBABaicfi")]
        [DataRow("123a")]
        [DataRow("aAbB")]
        [DataRow("ffff")]
        [DataRow("faa")]
        public void FirstCharFailTest(string stream)
        {
            //arrange
            _stream = new Stream(stream);

            //act
            var charValue = _stream.FirstChar();
            
            //assert
            Assert.IsNull(charValue);
        }


        [DataTestMethod]
        [TestCategory("GetNext")]
        [DataRow("aAbBABacfe")]
        [DataRow("aAbBABacfi")]
        [DataRow("aAbBABacfu")]
        [DataRow("aAbBABacfo")]
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

        [DataTestMethod]
        [TestCategory("Vogal")]
        [DataRow('a')]
        [DataRow('A')]
        [DataRow('e')]
        [DataRow('E')]
        [DataRow('i')]
        [DataRow('I')]
        [DataRow('o')]
        [DataRow('O')]
        [DataRow('u')]
        [DataRow('U')]
        public void IsVogalTest(char stream)
        {
            //arrange

            //act
            bool isVogal = Stream.IsVogal(stream);
            //assert
            Assert.IsTrue(isVogal);
        }

        [DataTestMethod]
        [TestCategory("Vogal")]
        [DataRow('b')]
        [DataRow('c')]
        [DataRow('1')]
        [DataRow('2')]
        [DataRow('-')]
        [DataRow('z')]
        public void IsNotVogalTest(char stream)
        {
            //arrange

            //act
            bool isVogal = Stream.IsVogal(stream);
            //assert
            Assert.IsFalse(isVogal);
        }

        [DataTestMethod]
        [TestCategory("Consonant")]
        [DataRow('B')]
        [DataRow('C')]
        [DataRow('H')]
        [DataRow('K')]
        [DataRow('Z')]
        public void IsConsonatTest(char stream)
        {
            //arrange

            //act
            bool isConsonant = Stream.IsConsonant(stream);
            //assert
            Assert.IsTrue(isConsonant);
        }

        [DataTestMethod]
        [TestCategory("Consonant")]
        [DataRow('a')]
        [DataRow('1')]
        [DataRow('-')]
        [DataRow('5')]
        [DataRow('9')]
        public void IsNotConsonatTest(char stream)
        {
            //arrange

            //act
            bool isConsonant = Stream.IsConsonant(stream);
            //assert
            Assert.IsFalse(isConsonant);
        }
    }
}
