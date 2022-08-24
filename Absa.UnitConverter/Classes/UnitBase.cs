namespace Absa.UnitConverter.Classes
{
    internal class UnitBase
    {
        public string conversionType { get; init; }
        public string prefix { get; init; }
        public Func<float, float> convMechanism { get; init; }

        public UnitBase(string conversionType, string prefix, Func<float, float> convMechanism)
        {
            this.conversionType = conversionType;
            this.prefix = prefix;
            this.convMechanism = convMechanism;
        }
    }
}
