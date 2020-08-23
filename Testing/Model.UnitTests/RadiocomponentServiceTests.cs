using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Model.UnitTests
{
    [TestFixture]
    class RadiocomponentServiceTests
    {
        #region -- TestCasesData --

        public static IEnumerable<TestCaseData>
            ToRadiocomponentTypeBadParameterTestCasesData()
        {
            List<(string, string)> badStringToReadableStringMap
                = new List<(string, string)>
                {
                    (null, "null"),
                    (string.Empty, "'пустая строка'"),
                    ("Some wrong string", "Some wrong string")
                };

            foreach (var (badString, readableString)
                in badStringToReadableStringMap)
            {
                yield return new TestCaseData(badString,
                    typeof(ArgumentException)).SetName(
                    "Когда метод " +
                    $"{nameof(RadiocomponentService.ToRadiocomponentType)} " +
                    $"вызывается с параметром {readableString}, то должно " +
                    "выбрасываться исключение " +
                    $"{typeof(ArgumentException).Name}.");
            }
        }

        public static IEnumerable<TestCaseData>
            ToRadiocomponentTypeGoodParameterTestCasesData()
        {
            List<(string, RadiocomponentType)> stringToRadiocomponentTypeMap
                = new List<(string, RadiocomponentType)>
                {
                    ("Резистор", RadiocomponentType.Resistor),
                    ("Катушка индуктивности", RadiocomponentType.Inductor),
                    ("Конденсатор", RadiocomponentType.Capacitor)
                };

            foreach (var (goodString, expectedRadiocomponentType)
                in stringToRadiocomponentTypeMap)
            {
                yield return new TestCaseData(goodString,
                    expectedRadiocomponentType).SetName(
                    "Когда метод " +
                    $"{nameof(RadiocomponentService.ToRadiocomponentType)} " +
                    $"вызывается с параметром {goodString}, то должно " +
                    "возвращаться значение " +
                    $"{expectedRadiocomponentType.GetType().Name}." +
                    $"{expectedRadiocomponentType}.");
            }
        }

        public static IEnumerable<TestCaseData>
            ValidatePositiveDoubleBadParameterTestCasesData()
        {
            List<(double, Type)> badDoubleToExpectedExceptionTypeMap
                = new List<(double, Type)>
                {
                    (double.NaN, typeof(ArgumentException)),
                    (double.PositiveInfinity,
                        typeof(ArgumentOutOfRangeException)),
                    (-1, typeof(ArgumentOutOfRangeException))
                };

            foreach (var (badDouble, expectedExceptionType)
                in badDoubleToExpectedExceptionTypeMap)
            {
                yield return new TestCaseData(badDouble,
                    expectedExceptionType).SetName(
                    "Когда метод " +
                    $"{nameof(RadiocomponentService.ValidatePositiveDouble)} " +
                    $"вызывается с параметром {badDouble}, то должно " +
                    "выбрасываться исключение " +
                    $"{expectedExceptionType.Name}.");
            }
        }

        public static IEnumerable<TestCaseData>
            ValidatePositiveDoubleGoodParameterTestCasesData()
        {
            double[] goodDoubles =
            {
                0,
                1,
                double.MaxValue
            };

            foreach (var goodDouble in goodDoubles)
            {
                yield return new TestCaseData(goodDouble).SetName(
                    "Когда метод " +
                    $"{nameof(RadiocomponentService.ValidatePositiveDouble)} " +
                    $"вызывается с параметром {goodDouble}, то ничего не " +
                    "должно произойти.");
            }
        }

        #endregion

        #region -- Tests --

        [TestCaseSource(nameof(ToRadiocomponentTypeBadParameterTestCasesData))]
        public void ToRadiocomponentType_BadParameter_ThrowsException(
            string badString, Type expectedExceptionType)
        {
            // Arrange
            TestDelegate BadStringToRadiocomponentType
                = () => badString.ToRadiocomponentType();

            // Assert
            _ = Assert.Throws(expectedExceptionType,
                BadStringToRadiocomponentType);
        }

        [TestCaseSource(nameof(ToRadiocomponentTypeGoodParameterTestCasesData))]
        public void ToRadiocomponentType_GoodParameter_ReturnsValue(
            string goodString, RadiocomponentType expectedRadiocomponentType)
        {
            // Act
            var actualRadiocomponentType = goodString.ToRadiocomponentType();

            // Assert
            Assert.AreEqual(actualRadiocomponentType,
                expectedRadiocomponentType);
        }

        [TestCaseSource(nameof(ValidatePositiveDoubleBadParameterTestCasesData))]
        public void ValidatePositiveDouble_BadParameter_ThrowsException(
            double badDouble, Type expectedExceptionType)
        {
            // Arrange
            TestDelegate validatePosiviveDouble
                = () => RadiocomponentService.ValidatePositiveDouble(
                    badDouble);

            // Assert
            _ = Assert.Throws(expectedExceptionType,
                validatePosiviveDouble);
        }

        #endregion
    }
}
