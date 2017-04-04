using System;

namespace ElEspacio
{
    internal class Program
    {
        private const decimal LatitudEverest = 27.9858m;
        private const decimal LongitudEverest = 86.9236m;

        private const double EarthDiameterInKms = 12_756;
        private const int PaleBlueDotColor = 0xA0_DF_E6;
        private const long Earth = 0b01000101_01100001_01110010_01110100_01101000;

        private static void Main(string[] args)
        {
            var everest = new Coordenada(LatitudEverest, LongitudEverest);
            Console.WriteLine($"Everest: {everest}");
            Console.WriteLine($"Antípoda Everest: {everest.Antipoda()}");
            Console.WriteLine();

            everest.Deconstruct(out decimal evLat, out decimal evLong);
            Console.WriteLine($"Latitud y longitud del Everest: {evLat} y {evLong}");

            (decimal evLat1, decimal evLong1) = everest;
            Console.WriteLine($"Latitud y longitud del Everest: {evLat1} y {evLong1}");
            Console.WriteLine();

            var interesingPoints = everest.GetInterestingPoints();
            Console.WriteLine(
                $"Puntos interesantes del Everest:\n\t{interesingPoints.antipoda.Descripcion}\n\t{interesingPoints.antipodaLatitud.Descripcion}\n\t{interesingPoints.antipodaLongitud.Descripcion}");
            Console.WriteLine();

            Planeta planetaMisterioso = new Tierra();

            if (planetaMisterioso is Tierra t && t.Poblacion > 0)
                Console.WriteLine($"Es la Tierra habitada con {t.Poblacion} habitantes");

            switch (planetaMisterioso)
            {
                case Tierra tierra when tierra.Poblacion > 0:
                    Console.WriteLine($"Es la Tierra habitada con {tierra.Poblacion} habitantes");
                    break;
                case Tierra tierra:
                    Console.WriteLine($"Es la Tierra deshabitada :(");
                    break;
                case Urano ur:
                    Console.WriteLine($"Es Urano");
                    break;
                default:
                    break;
            }

            Console.Read();
        }
    }
}