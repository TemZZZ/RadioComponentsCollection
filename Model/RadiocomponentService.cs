using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Сервисный класс со вспомогательными функциями для работы с
    /// радиокомпонентами
    /// </summary>
    public static class RadiocomponentService
    {
        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// физические величины и единицы измерения
        /// </summary>
        private static readonly
            Dictionary<RadioComponentType,
                (RadiocomponentQuantity Quantity, RadiocomponentUnit Unit)>
            _radiocomponentTypeToPropertiesMap
                = new Dictionary<RadioComponentType,
                    (RadiocomponentQuantity, RadiocomponentUnit)>
                {
                    [RadioComponentType.Resistor]
                        = (RadiocomponentQuantity.Resistance,
                            RadiocomponentUnit.Ohm),
                    [RadioComponentType.Inductor]
                        = (RadiocomponentQuantity.Inductance,
                            RadiocomponentUnit.Henry),
                    [RadioComponentType.Capacitor]
                        = (RadiocomponentQuantity.Capacitance,
                            RadiocomponentUnit.Farad)
                };

        /// <summary>
        /// Словарь, ставящий в соответствие типам радиокомпонентов их
        /// строковые представления
        /// </summary>
        private static readonly Dictionary<RadioComponentType, string>
            _radiocomponentTypeToStringMap
                = new Dictionary<RadioComponentType, string>
                {
                    [RadioComponentType.Resistor] = "Резистор",
                    [RadioComponentType.Inductor] = "Катушка индуктивности",
                    [RadioComponentType.Capacitor] = "Конденсатор"
                };
    }
}
