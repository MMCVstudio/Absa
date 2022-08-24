using System.Collections.Concurrent;

namespace Absa.UnitConverter.Classes
{
    internal abstract class BaseConverter
    {
        private ConcurrentDictionary<string, UnitBase> _conversions = new ConcurrentDictionary<string, UnitBase>();
        /// <summary>
        /// Converts input value from one unit to another one.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public string Convert(float value, string from, string to)
        {
            if (!ValidateInputs(from, to))
                throw new ArgumentNullException("Inputs from/to must contain value");

            var convType = AddConversionType(from, to);

            var findConversion = _conversions.TryGetValue(convType, out var conversion);
            
            if(!findConversion || conversion is null)
                throw new Exception("No conversion mechanism found");

            var result = conversion.convMechanism(value).ToString();

            if(string.IsNullOrWhiteSpace(result))
                throw new ArgumentNullException("No conversion mechanism found");

            return new string($"{result} {conversion.prefix}");


        }
        /// <summary>
        /// Adds new conversion to conversions dictionary
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="prefix"></param>
        /// <param name="mechanism"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddConversion(string from, string to, string prefix, Func<float, float> mechanism)
        {
            if (!ValidateInputs(from, to))
                throw new ArgumentNullException("Inputs from/to must contain value");

            if (mechanism is null)
                throw new ArgumentNullException("No conversion mechanism found");
            
            if(string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentNullException("Prefix must be defined");

            var convType = AddConversionType(from, to);

            var result = _conversions.TryAdd(
                                convType,
                                new UnitBase(
                                             convType,
                                             prefix,
                                             mechanism
                                             ));
            if (!result)
                throw new InvalidOperationException("This conversion already exists.");

        }
        private bool ValidateInputs(string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return false;

            return true;
        }
        private string AddConversionType(string from, string to)
        {
            return $"{from}x{to}";
        }
    }
}
