using System;
using System.Collections.Generic;

namespace Refactoring.Modelo.Guardar
{
    [Serializable]
    public class DatosPartida
    {
        public int version = 1;
        public int ancho;
        public int alto;
        public float velocidad;
        public int direccionX;
        public int direccionZ;
        public List<PosicionGuardada> paredes = new List<PosicionGuardada>();
        public List<PosicionGuardada> cuerpoSerpiente = new List<PosicionGuardada>();
        public bool tieneFruta;
        public PosicionGuardada fruta;
    }

    [Serializable]
    public class PosicionGuardada
    {
        public int x;
        public int z;

        public PosicionGuardada()
        {
        }

        public PosicionGuardada(int x, int z)
        {
            this.x = x;
            this.z = z;
        }
    }
}
