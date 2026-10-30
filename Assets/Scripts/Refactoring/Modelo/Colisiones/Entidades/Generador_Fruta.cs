using System;
using System.Collections.Generic;
using Refactoring.Modelo.Colisiones.Entidades; // Para poder instanciar new Fruta()

namespace Refactoring.Modelo.Colisiones
{
    public class Generador_Fruta
    {
        private Tablero tablero;
        private Random aleatorio;

        public Generador_Fruta(Tablero tablero, Random aleatorio)
        {
            this.tablero = tablero;
            this.aleatorio = aleatorio;
        }

        public Celda Generar_Fruta()
        {
            List<Celda> celdas_libres = tablero.Obtener_Celdas_Libres();

            // Validación de seguridad: si no hay espacio, no generamos fruta
            if (celdas_libres.Count == 0)
            {
                return null;
            }

            // Seleccionamos un índice al azar entre 0 y la cantidad de celdas libres
            int indice = aleatorio.Next(celdas_libres.Count);

            // Obtenemos la celda elegida
            Celda celda = celdas_libres[indice];

            // Instanciamos la nueva fruta y la colocamos en la celda
            celda.Establecer_Entidad(new Fruta());

            return celda;
        }
    }
}   