using NUnit.Framework;
using VS.Assessment.Process;

namespace VS.Assessment.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Heellooo Hooww arree yooouu doing")]
        public void SentenceParser(string input)
        {
            //act
            string result = Program.SentenceParser(input);

            //assert
            Assert.AreEqual(result, "H3o H2w a2e y2u d3g");
        }


        [TestCase("To Two")]
        public void SentenceParserCount2(string input)
        {
            //act
            string result = Program.SentenceParser(input);

            //assert
            Assert.AreEqual(result, "T0o T1o");
        }

        [TestCase(null)]
        public void SentenceParserCount3(string input)
        {
            //act
            string result = Program.SentenceParser(input);

            //assert
            Assert.AreEqual(result, string.Empty);
        }

        [TestCase("A")]
        public void SentenceParserCount4(string input)
        {
            //act
            string result = Program.SentenceParser(input);

            //assert
            Assert.AreEqual(result, input);
        }
    }
}