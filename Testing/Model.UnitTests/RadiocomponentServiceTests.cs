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

        #endregion
    }
}
