using System;

namespace ElEspacio
{
    public static class CoordenadaExtensions
    {
        public static Coordenada Antipoda(this Coordenada actual)
        {
            var newLatitud = -actual.Latitud;
            var newLongitud = (actual.Longitud < 0 ? 1 : -1) * Math.Abs(180 - Math.Abs(actual.Longitud));
            return new Coordenada(newLatitud, newLongitud);
        }

        public static Coordenada AntipodaLongitud(this Coordenada actual)
        {
            var newLongitud = GetNewLongitud(actual.Longitud);
            return new Coordenada(actual.Longitud, newLongitud);
        }

        private static decimal GetNewLongitud(decimal longitud)
        {
            return (longitud < 0 ? 1 : -1) * Math.Abs(180 - Math.Abs(longitud));
        }

        public static Coordenada AntipodaLatitud(this Coordenada actual)
        {
            var newLatitud = -actual.Latitud;
            return new Coordenada(newLatitud, actual.Longitud);
        }

        public static Tuple<Coordenada, Coordenada, Coordenada> GetInterestingPoints(this Coordenada coordenada)
        {
            return Tuple.Create(coordenada.Antipoda(),
                coordenada.AntipodaLongitud(),
                coordenada.AntipodaLatitud());
        }

        public static void Deconstruct(this Coordenada coordenada, out decimal latitud, out decimal longitud,
            out decimal altitude)
        {
            latitud = coordenada.Latitud;
            longitud = coordenada.Longitud;
            altitude = coordenada.Altitud;
        }
    }
}