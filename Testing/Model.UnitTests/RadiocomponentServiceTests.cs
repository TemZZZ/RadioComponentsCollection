﻿using System;
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
