using Refactoring.Modelo.Colisiones;

namespace Refactoring.Modelo.Movimiento
{
    public class Controlador_Movimiento
    {
        private Tablero tablero;
        private Personaje personaje;
        private Controlador_Entidades controlEntidades;
        private Direccion direccion_actual;
        private Direccion direccion_pendiente;

        // Constructor adaptado para recibir tambi�n el Controlador_Entidades necesario para chequear colisiones
        public Controlador_Movimiento(Tablero tablero, Personaje personaje, Controlador_Entidades controlEntidades)
            : this(tablero, personaje, controlEntidades, Direccion.Derecha)
        {
        }

        public Controlador_Movimiento(Tablero tablero, Personaje personaje, Controlador_Entidades controlEntidades, Direccion direccionInicial)
        {
            this.tablero = tablero;
            this.personaje = personaje;
            this.controlEntidades = controlEntidades;
            this.direccion_actual = direccionInicial ?? Direccion.Derecha;
            this.direccion_pendiente = this.direccion_actual;
        }

        // El diagrama indica recibir la direcci�n pendiente por par�metro, pero al tenerla como 
        // atributo de clase (establecida por Establecer_Direccion_Pendiente), usamos el atributo.
        public void Actualizar_Cabeza()
        {
            Celda celda_actual = personaje.Obtener_Cabeza();

            // 1. Calculamos las coordenadas de la pr�xima celda objetivo
            int x = celda_actual.Obtener_Posicion_X() + direccion_pendiente.Obtener_Delta_X();
            int z = celda_actual.Obtener_Posicion_Z() + direccion_pendiente.Obtener_Delta_Z();

            // 2. Le pedimos al tablero la celda en esas coordenadas
            Celda celda_siguiente = tablero.Obtener_Celda(x, z);

            if (celda_siguiente != null)
            {
                // 3. Chequeamos qu� hay en la celda destino ANTES de mover la cabeza
                controlEntidades.Chequear_Colision(celda_siguiente);

                // 4. Desplazamos f�sicamente la serpiente
                personaje.ActualizarCabeza(celda_siguiente);

                // 5. La direcci�n pendiente se convierte en la actual (la serpiente ya efectu� el movimiento)
                direccion_actual = direccion_pendiente;
            }
        }

        public void Establecer_Direccion_Pendiente(Direccion direccion)
        {
            // Validamos que el jugador no intente ir hacia atr�s repentinamente
            if (direccion != null && !direccion.Es_Opuesta_A(direccion_actual))
            {
                direccion_pendiente = direccion;
            }
        }

        public Direccion Obtener_Direccion_Pendiente()
        {
            return direccion_pendiente;
        }
    }
}