using System.Collections.Generic;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo;

namespace Refactoring.Modelo.Colisiones
{
    public class Controlador_Entidades
    {
        private readonly Nivel nivel;

        public Controlador_Entidades(Nivel nivel)
        {
            this.nivel = nivel ;
        }

        public bool Chequear_Colision(Celda cabezaActual, bool ignorarSerpiente = false)
        {
            if (cabezaActual == null) return true;


            //esto podria no estar creo 
            // Creamos una copia local de la lista para evitar excepciones si la lista se modifica durante la iteraci�n
            List<Entidad> entidadesEnCelda = new List<Entidad>(cabezaActual.Obtener_Entidades());
            //si hay 2 estidades en la lista de la celda llamo a ajecutar funcionalidad de cada una de ellas
            //si solo hay 1 entidad en la celda, no hay colision y no se ejecuta funcionalidad
            foreach (Entidad e in entidadesEnCelda)
            {
                if (ignorarSerpiente && e is Parte_Serpiente)
                {
                    continue;
                }

                e.Ejecutar_Funcionalidad(this);
                if (!nivel.Esta_Jugando)
                {
                    return false;
                }
            }

            return true;
        }

        public void Avisar_Funcionalidad_Pared()
        {
            nivel.Avisar_Funcionalidad_Pared();
        }

        public void Avisar_Funcionalidad_Fruta()
        {
            nivel.Avisar_Funcionalidad_Fruta();
        }

        public void Avisar_Funcionalidad_Serpiente()
        {
            nivel.Avisar_Funcionalidad_Serpiente();
        }
    }
}