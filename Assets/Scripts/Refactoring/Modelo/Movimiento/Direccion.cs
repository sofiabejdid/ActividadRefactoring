namespace Refactoring.Modelo.Movimiento
{
    public class Direccion
    {
        // Instancias estáticas listas para usar en todo el proyecto
        public static readonly Direccion Arriba = new Direccion(0, 1);
        public static readonly Direccion Abajo = new Direccion(0, -1);
        public static readonly Direccion Izquierda = new Direccion(-1, 0);
        public static readonly Direccion Derecha = new Direccion(1, 0);

        private readonly int delta_x;
        private readonly int delta_z;

        public Direccion(int delta_x, int delta_z)
        {
            this.delta_x = delta_x;
            this.delta_z = delta_z;
        }

        public int Obtener_Delta_X()
        {
            return delta_x;
        }

        public int Obtener_Delta_Z()
        {
            return delta_z;
        }

        public bool Es_Opuesta_A(Direccion otra)
        {
            if (otra == null) return false;

            // Retorna true si los deltas son exactamente los inversos
            return delta_x == -otra.Obtener_Delta_X() && delta_z == -otra.Obtener_Delta_Z();
        }
    }
}