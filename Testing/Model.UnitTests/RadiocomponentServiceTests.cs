using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Model.UnitTests
{
    [TestFixture]
    public class RadiocomponentServiceTests
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
            List<(string, RadiocomponentType_)> stringToRadiocomponentTypeMap
                = new List<(string, RadiocomponentType_)>
                {
                    ("Резистор", RadiocomponentType_.Resistor),
                    ("Катушка индуктивности", RadiocomponentType_.Inductor),
                    ("Конденсатор", RadiocomponentType_.Capacitor)
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

        public static IEnumerable<TestCaseData>
            RadiocomponentTypeToString_GoodParameter_TestCasesData()
        {
            var radiocomponentTypeToExpectedStringMap
                = new List<(RadiocomponentType_, string)>
            {
                (RadiocomponentType_.Resistor, "Резистор"),
                (RadiocomponentType_.Inductor, "Катушка индуктивности"),
                (RadiocomponentType_.Capacitor, "Конденсатор")
            };

            foreach (var (radiocomponentType, expectedString)
                in radiocomponentTypeToExpectedStringMap)
            {
                yield return new TestCaseData(radiocomponentType,
                    expectedString).SetName(
                    $"Когда метод {nameof(RadiocomponentService.ToString)} " +
                    $"вызывается с параметром {radiocomponentType}, то он " +
                    $"должен вернуть {expectedString}.");
            }
        }

        public static IEnumerable<TestCaseData>
            RadiocomponentUnitToString_GoodParameter_TestCasesData()
        {
            var radiocomponentUnitToExpectedStringMap
                = new List<(RadiocomponentUnit, string)>
                {
                    (RadiocomponentUnit.Ohm, "Ом"),
                    (RadiocomponentUnit.Henry, "Гн"),
                    (RadiocomponentUnit.Farad, "Ф")
                };

            foreach (var (radiocomponentUnit, expectedString)
                in radiocomponentUnitToExpectedStringMap)
            {
                yield return new TestCaseData(radiocomponentUnit,
                    expectedString).SetName(
                    $"Когда метод {nameof(RadiocomponentService.ToString)} " +
                    $"вызывается с параметром {radiocomponentUnit}, то он " +
                    $"должен вернуть {expectedString}.");
            }
        }

        public static IEnumerable<TestCaseData>
            RadiocomponentQuantityToString_GoodParameter_TestCasesData()
        {
            var radiocomponentQuantityToExpectedStringMap
                = new List<(RadiocomponentQuantity, string)>
                {
                    (RadiocomponentQuantity.Resistance, "Сопротивление"),
                    (RadiocomponentQuantity.Inductance, "Индуктивность"),
                    (RadiocomponentQuantity.Capacitance, "Емкость")
                };

            foreach (var (radiocomponentQuantity, expectedString)
                in radiocomponentQuantityToExpectedStringMap)
            {
                yield return new TestCaseData(radiocomponentQuantity,
                    expectedString).SetName(
                    $"Когда метод {nameof(RadiocomponentService.ToString)} " +
                    $"вызывается с параметром {radiocomponentQuantity}, " +
                    $"то он должен вернуть {expectedString}.");
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
            string goodString, RadiocomponentType_ expectedRadiocomponentType)
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

        [TestCaseSource(nameof(ValidatePositiveDoubleGoodParameterTestCasesData))]
        public void ValidatePositiveDouble_GoodParameter_DoesNothing(
            double goodDouble)
        {
            // Arrange
            TestDelegate validatePosiviveDouble
                = () => RadiocomponentService.ValidatePositiveDouble(
                    goodDouble);

            // Assert
            Assert.DoesNotThrow(validatePosiviveDouble);
        }

        [TestCaseSource(nameof(RadiocomponentTypeToString_GoodParameter_TestCasesData))]
        public void RadiocomponentTypeToString_GoodParameter_ReturnsValue(
            RadiocomponentType_ radiocomponentType, string expectedString)
        {
            // Act
            var actualString = RadiocomponentService.ToString(
                radiocomponentType);

            // Assert
            Assert.AreEqual(actualString, expectedString);
        }

        [TestCaseSource(nameof(RadiocomponentUnitToString_GoodParameter_TestCasesData))]
        public void RadiocomponentUnitToString_GoodParameter_ReturnsValue(
            RadiocomponentUnit radiocomponentUnit, string expectedString)
        {
            // Act
            var actualString = RadiocomponentService.ToString(
                radiocomponentUnit);

            // Assert
            Assert.AreEqual(actualString, expectedString);
        }

        [TestCaseSource(nameof(RadiocomponentQuantityToString_GoodParameter_TestCasesData))]
        public void
            RadiocomponentQuantityToString_GoodParameter_ReturnsValue(
                RadiocomponentQuantity radiocomponentQuantity,
                string expectedString)
        {
            // Act
            var actualString = RadiocomponentService.ToString(
                radiocomponentQuantity);

            // Assert
            Assert.AreEqual(actualString, expectedString);
        }

        #endregion
    }
}
