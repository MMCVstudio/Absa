using Absa.UnitConverter.Classes;


namespace Absa.Console
{
    internal class Calculations
    {
        public void Calculate()
        {
            var test = new UnitConvesion();

            var temperatureConv = test.GetTemperatureConversions();
            System.Console.WriteLine(temperatureConv.Convert(10, "celsius", "farenheit"));
            System.Console.WriteLine(temperatureConv.Convert(50, "farenheit", "celsius"));

            var lengthConv = test.GetLenghtsConverions();
            System.Console.WriteLine(lengthConv.Convert(10, "milimeter", "centimeter"));
            System.Console.WriteLine(lengthConv.Convert(10, "meter", "foot"));
            System.Console.WriteLine(lengthConv.Convert(10, "foot", "meter"));
        }
    }
}
