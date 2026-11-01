using System.Collections.Generic;

namespace Refactoring.Modelo.Colisiones
{
    public class Tablero
    {
        private Celda[,] tablero;
        private int ancho_x;
        private int ancho_z;

        public Tablero(int ancho_x, int ancho_z)
        {
            this.ancho_x = ancho_x;
            this.ancho_z = ancho_z;

            // Inicialización de la matriz
            tablero = new Celda[ancho_x, ancho_z];

            for (int i = 0; i < ancho_x; i++)
            {
                for (int j = 0; j < ancho_z; j++)
                {
                    // Le pasamos i, j para que la celda sepa su posición
                    tablero[i, j] = new Celda(i, j);
                }
            }
        }

        public Celda Obtener_Celda(int x, int z)
        {
            // Verificamos que las coordenadas estén dentro de los límites de la matriz
            if (x >= 0 && x < ancho_x && z >= 0 && z < ancho_z)
            {
                return tablero[x, z];
            }
            return null; // Si está fuera de los límites
        }

        public List<Celda> Obtener_Celdas_Libres()
        {
            List<Celda> celdas_libres = new List<Celda>();

            for (int i = 0; i < ancho_x; i++)
            {
                for (int j = 0; j < ancho_z; j++)
                {
                    if (tablero[i, j].Esta_Libre() == true)
                    {
                        celdas_libres.Add(tablero[i, j]);
                    }
                }
            }

            return celdas_libres;
        }
        public int Obtener_Ancho_X()
        {
            return ancho_x;
        }
        public int Obtener_Ancho_Z()
        {
            return ancho_z;
        }
    }
}