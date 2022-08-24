using Absa.UnitConverter.Classes;

namespace Absa.UnitTests
{
    public class ConverterTests
    {
        private LengthConverter _converter;
        [SetUp]
        public void Setup()
        {
            _converter = new LengthConverter();

        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void AddConversion_NoInputsAdded_Fails(string error)
        {
            Assert.That(() => _converter.AddConversion(error, "b", "ab", b => b), Throws.ArgumentNullException); 
            Assert.That(() => _converter.AddConversion("a", error, "ab", b => b), Throws.ArgumentNullException); 
        }
        [Test]
        [TestCase("")]
        public void AddConversion_NoPrefixAdded_Fails(string error)
        {
            Assert.That(() => _converter.AddConversion("a", "b", "", b => b), Throws.ArgumentNullException);
        }

        [Test]
        public void AddConversion_NoMechanismAdded_Fails()
        {
            Assert.That(() => _converter.AddConversion("a", "b", "ab", null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddConversion_AddSameConversion_Fails()
        {
            _converter.AddConversion("a", "b", "ab", b => b);
            Assert.That(() => _converter.AddConversion("a", "b", "ab", b => b), Throws.InvalidOperationException);
        }

        [Test]
        public void Convert_DoesConversion_Succed()
        {
            _converter.AddConversion("a", "b", "ab", b => b);

            var result = _converter.Convert(1, "a", "b");

            Assert.AreEqual(result, "1 ab");
        }

        [Test]
        public void Convert_DoesConversion_Fails()
        {
            _converter.AddConversion("a", "b", "ab", b => b);

            Assert.That(() => _converter.Convert(1, "ab", "b"), Throws.Exception);
        }
    }
}