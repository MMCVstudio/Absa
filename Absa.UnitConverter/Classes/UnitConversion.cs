using Absa.UnitConverter.Interfaces;

namespace Absa.UnitConverter.Classes
{
    public class UnitConvesion
    {
        private enum lengths
        {
            milimeter,
            centimeter,
            decimeter,
            meter,
            kilometer,
            inch,
            hand,
            foot,
            yard,
            mile
        }
        private enum dataSet
        {
            dataBit,
            dataByte,
            dataKiloByte

        }
        private enum temperatureSet
        {
            celsius,
            farenheit
        }
        public List<IUnitConverter> unitList = new List<IUnitConverter>();
        public UnitConvesion()
        {
            BuildConverter();
        }
        private void BuildConverter()
        {
            AddLenghts();
            AddData();
            AddTemperature();

        }

        private void AddLenghts()
        {
            var lenght = new LengthConverter();
            #region milimeter conversions
            lenght.AddConversion(
                            lengths.milimeter.ToString(),
                            lengths.centimeter.ToString(),
                            "cm",
                            (f) => f * 0.1F);

            lenght.AddConversion(
                            lengths.milimeter.ToString(),
                            lengths.decimeter.ToString(),
                            "dm",
                            (f) => f * 0.01F);

            lenght.AddConversion(
                            lengths.milimeter.ToString(),
                            lengths.meter.ToString(),
                            "m",
                            (f) => f * 0.001F);

            lenght.AddConversion(
                            lengths.milimeter.ToString(),
                            lengths.kilometer.ToString(),
                            "km",
                            (f) => f * 0.000001F);

            #endregion

            #region assignment
            lenght.AddConversion(
                            lengths.meter.ToString(),
                            lengths.foot.ToString(),
                            "foot",
                            (f) => f / 0.3048F);
            lenght.AddConversion(
                            lengths.foot.ToString(),
                            lengths.meter.ToString(),
                            "meter",
                            (f) => f * 0.3048F);
            lenght.AddConversion(
                            lengths.meter.ToString(),
                            lengths.inch.ToString(),
                            "inch",
                            (f) => f / 0.0254F);

            lenght.AddConversion(
                            lengths.inch.ToString(),
                            lengths.meter.ToString(),
                            "meter",
                            (f) => f * 0.0254F);
            lenght.AddConversion(
                            lengths.inch.ToString(),
                            lengths.foot.ToString(),
                            "foot",
                            (f) => f * 0.08333333F);

            lenght.AddConversion(
                            lengths.foot.ToString(),
                            lengths.inch.ToString(),
                            "inch",
                            (f) => f / 0.08333333F);
            #endregion


            unitList.Add(lenght);


        }

        private void AddData()
        {
            var data = new DataConverter();
            #region assignment
            data.AddConversion(
                           dataSet.dataBit.ToString(),
                           dataSet.dataByte.ToString(),
                           "byte",
                           (f) => f * 0.125F);
            data.AddConversion(
                            dataSet.dataByte.ToString(),
                            dataSet.dataBit.ToString(),
                            "bit",
                            (f) => f / 0.125F);
            data.AddConversion(
                            dataSet.dataBit.ToString(),
                            dataSet.dataKiloByte.ToString(),
                            "KB",
                            (f) => f * 0.125F * 0.001F);
            data.AddConversion(
                            dataSet.dataKiloByte.ToString(),
                            dataSet.dataBit.ToString(),
                            "bit",
                            (f) => f / 0.125F * 1_000);
            #endregion
            unitList.Add(data);
        }

        private void AddTemperature()
        {
            var temperatures = new TemperatureConverter();
            #region assignment
            temperatures.AddConversion(
                            temperatureSet.celsius.ToString(),
                            temperatureSet.farenheit.ToString(),
                            "°F",
                            (f) => (f / 0.5556F) + 32);
            temperatures.AddConversion(
                            temperatureSet.farenheit.ToString(),
                            temperatureSet.celsius.ToString(),
                            "°C",
                            (f) => (f - 32) * 0.5556F);


            #endregion
            unitList.Add(temperatures);
        }
        /// <summary>
        /// Gets avaiable conversions of length type.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IUnitConverter GetLenghtsConverions()
        {
            if (unitList[0] is null)
                throw new ArgumentException("Requested converter not found");

            return unitList[0];
        }
        /// <summary>
        /// Gets avaiable conversions of data type.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IUnitConverter GetDataConversions()
        {
            if (unitList[1] is null)
                throw new ArgumentException("Requested converter not found");

            return unitList[1];
        }
        /// <summary>
        /// Gets avaiable conversions of temperature type.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public IUnitConverter GetTemperatureConversions()
        {
            if (unitList[2] is null)
                throw new ArgumentException("Requested converter not found");

            return unitList[2];
        }

    }
}
