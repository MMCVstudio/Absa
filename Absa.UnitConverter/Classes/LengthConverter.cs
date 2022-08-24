using Absa.UnitConverter.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Absa.UnitTests")]

namespace Absa.UnitConverter.Classes
{
    internal class LengthConverter:BaseConverter,IUnitConverter
    {
    }
}
