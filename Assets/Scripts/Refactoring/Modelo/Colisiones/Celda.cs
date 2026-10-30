using System.Collections.Generic;
using Refactoring.Modelo.Colisiones.Entidades; // Para poder usar la clase Entidad

namespace Refactoring.Modelo.Colisiones
{
    public class Celda
    {
        private List<Entidad> Entidades;
        private int x;
        private int z;

        // Constructor para inicializar la posición y la lista
        public Celda(int x, int z)
        {
            this.x = x;
            this.z = z;
            this.Entidades = new List<Entidad>();
        }

        public bool Esta_Libre()
        {
            return Entidades.Count == 0;
        }

        public void Establecer_Entidad(Entidad entidad)
        {
            if (entidad != null && !Entidades.Contains(entidad))
            {
                Entidades.Add(entidad);
            }
        }
        public List<Entidad> Obtener_Entidades()
        {
            return new List<Entidad>(Entidades);
        }   

        public void Remover_Entidad()
        {
            if (Entidades.Count > 0)
            {
                Entidades.RemoveAt(Entidades.Count - 1);
            }
        }

        public int Obtener_Posicion_X()
        {
            return x;
        }

        public int Obtener_Posicion_Z()
        {
            return z;
        }
    }
}