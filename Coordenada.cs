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
        private string _name;

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

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == null)
                    throw new ArgumentException($"{nameof(value)} cannot be null");
                _name = value;
            }
        }

        public string Descripcion => $"{Name}: Latitud: {Latitud} ({HemisferioNorteSur}), Longitud: {Longitud} ({HemisferioEsteOeste}), Altitud {Altitud}";


        public override string ToString() => $"Latitud: {Latitud}, Longitud: {Longitud}";

        public void Deconstruct(out decimal latitud, out decimal longitud)
        {
            latitud = Latitud;
            longitud = Longitud;
        }
    }
}