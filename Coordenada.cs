using System;

namespace ElEspacio
{
    public enum HemisferioNorteSur
    {
        Sur,
        Norte
    }

    public enum HemisferioEsteOeste
    {
        Este,
        Oeste
    }

    public class Coordenada
    {
        public Coordenada(decimal latitud, decimal longitud) : this(latitud, longitud, 0)
        {
        }

        public Coordenada(decimal latitud, decimal longitud, decimal altitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Altitud = altitud;
        }

        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public decimal Altitud { get; set; }

        public HemisferioNorteSur HemisferioNorteSur => Latitud < 0 ? HemisferioNorteSur.Sur : HemisferioNorteSur.Norte;

        public HemisferioEsteOeste HemisferioEsteOeste => Longitud < 0 ? HemisferioEsteOeste.Oeste : HemisferioEsteOeste.Este;

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentException($"{nameof(value)} cannot be null");
        }


        public override string ToString() => $"Latitud: {Latitud}, Longitud: {Longitud}";

        public string Descripcion => $"{Name}: Latitud: {Latitud} ({HemisferioNorteSur}), Longitud: {Longitud} ({HemisferioEsteOeste}), Altitud {Altitud}";

        public void Deconstruct(out decimal latitud, out decimal longitud)
        {
            latitud = Latitud;
            longitud = Longitud;
        }
    }
}