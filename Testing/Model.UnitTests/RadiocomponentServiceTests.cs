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
            string[] badStrings =
            {
                null,
                string.Empty,
                "Some wrong string"
            };

            foreach (var badString in badStrings)
            {
                yield return new TestCaseData(badString,
                    typeof(ArgumentException)).SetName(
                    "Когда метод " +
                    $"{nameof(RadiocomponentService.ToRadiocomponentType)} " +
                    $"вызывается с параметром {badString}, то должно " +
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
                    $"возвращаться значение {expectedRadiocomponentType}.");
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

        #endregion
    }
}
