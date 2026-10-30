using Refactoring.Modelo.Colisiones;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo.Guardar;
using Refactoring.Modelo.Movimiento;
using System;
using Refactoring.Presentador;

namespace Refactoring.Modelo
{
    public class Nivel
    {
        private float velocidad_juego;
        private float tiempo_acumulado;
        private Tablero tablero;
        private Personaje personaje;
        private Generador_Fruta generador_fruta;
        private Controlador_Movimiento controlador_movimiento;
        private Celda Celda_Frutita;

        // Referencia al presentador para indicarle qu� dibujar seg�n tu diagrama
        private Presenter p;

        // Bandera de estado que reemplaza la necesidad del CancelInvoke() de Unity
        private bool estaJugando;

        public Nivel(Presenter presentador, float velocidad_inicial)
        {
            this.p = presentador;
            this.velocidad_juego = velocidad_inicial;
            this.estaJugando = false;
        }

        public bool Esta_Jugando
        {
            get { return estaJugando; }
        }

        //revisemos esto despues 
        public Tablero Obtener_Tablero()
        {
            return tablero;
        }

        public void Establecer_Tablero(Tablero tablero)
        {
            this.tablero = tablero;
        }

        public void Establecer_Generador_Fruta(Generador_Fruta generador)
        {
            this.generador_fruta = generador;
        }

        public void Establecer_Personaje(Personaje personaje)
        {
            this.personaje = personaje;
        }

        public void Establecer_Controlador_Movimiento(Controlador_Movimiento controlador)
        {
            this.controlador_movimiento = controlador;
        }

        // -----------------------------------------------------------------
        // EVENTOS DE COLISI�N (Llamados indirectamente tras el movimiento)
        // -----------------------------------------------------------------
        public void establecer_Celda_Frutita(Celda fruta)
        {
            this.Celda_Frutita = fruta;
        }
        public void Avisar_Funcionalidad_Pared()
        {
            Detener();
            p.Avisar_Perdiste();
        }

        public void Avisar_Funcionalidad_Serpiente()
        {
            Detener();
            p.Avisar_Perdiste();
        }

        public void Avisar_Funcionalidad_Fruta()
        {
            // 1. Evitamos que se borre la cola l�gica
            personaje.RestituirCola();

            // 2. Le decimos al presentador que destruya el cubo visual de la fruta
            p.destruir_fruta(Celda_Frutita.Obtener_Posicion_X(), Celda_Frutita.Obtener_Posicion_Z());

            // 3. Le decimos al presentador que dibuje un cubo rojo (serpiente) donde antes iba a borrar la cola
            // Obtenemos la �ltima celda de la lista (que ahora vuelve a ser parte del cuerpo)
            Celda cola = personaje.Obtener_Cuerpo()[personaje.Obtener_Cuerpo().Count - 1];
            p.dibujar_snake(cola.Obtener_Posicion_X(), cola.Obtener_Posicion_Z());

            // 4. Generamos una nueva fruta en la matriz l�gica
            Celda_Frutita = generador_fruta.Generar_Fruta();

            // 5. Instanciamos la nueva fruta visual
            if (Celda_Frutita != null)
            {
                p.dibujar_fruta(Celda_Frutita.Obtener_Posicion_X(), Celda_Frutita.Obtener_Posicion_Z());
            }
        }

        // -----------------------------------------------------------------
        // CONTROL DEL BUCLE DE JUEGO
        // -----------------------------------------------------------------

        public void Comenzar_Nivel(bool generarFruta = true)
        {
            if (generarFruta)
            {
                Celda_Frutita = generador_fruta.Generar_Fruta();
                if (Celda_Frutita != null)
                {
                    p.dibujar_fruta(Celda_Frutita.Obtener_Posicion_X(), Celda_Frutita.Obtener_Posicion_Z());
                }
            }

            tiempo_acumulado = 0f;
            estaJugando = true;
        }

        public void Actualizar(float deltaTiempo)
        {
            if (!estaJugando)
            {
                return;
            }

            tiempo_acumulado += deltaTiempo;
            while (estaJugando && tiempo_acumulado >= velocidad_juego)
            {
                tiempo_acumulado -= velocidad_juego;
                Execute();
            }
        }

        public void Detener()
        {
            // Al poner esto en false, Execute() no har� nada (equivalente a CancelInvoke)
            estaJugando = false;
        }

        public void Execute()
        {
            if (!estaJugando) return;

            // Guardamos la celda de la cola antes de movernos para saber de d�nde borrar el cubo 3D
            Celda colaAnterior = personaje.Obtener_Cuerpo()[personaje.Obtener_Cuerpo().Count - 1];

            // Actualiza l�gicamente la matriz y chequea colisiones
            controlador_movimiento.Actualizar_Cabeza();

            if (estaJugando) // Si no choc� contra una pared durante la actualizaci�n
            {
                Celda cabezaNueva = personaje.Obtener_Cabeza();

                // Le manda al presentador las referencias para dibujar el nuevo avance visual
                p.dibujar_avance_serpiente(cabezaNueva, colaAnterior);
            }
        }

        public float Obtener_Velocidad_Juego()
        {
            return velocidad_juego;
        }

        public void Aumentar_Velocidad()
        {
            // Restamos tiempo (lo hace m�s r�pido) con un l�mite m�nimo para que no de negativo
            velocidad_juego = velocidad_juego > 0.05f ? velocidad_juego - 0.02f : 0.05f;
        }

        public void Cambiar_Direccion(Direccion direccion)
        {
            controlador_movimiento.Establecer_Direccion_Pendiente(direccion);
        }

        public void Establecer_Velocidad_Juego(float velocidad)
        {
            if (velocidad <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(velocidad), "La velocidad debe ser mayor que cero.");
            }

            velocidad_juego = velocidad;
        }

        public DatosPartida Crear_Datos_Partida()
        {
            if (tablero == null || personaje == null || controlador_movimiento == null)
            {
                throw new InvalidOperationException("El nivel no está completamente inicializado.");
            }

            DatosPartida datos = new DatosPartida
            {
                ancho = tablero.Obtener_Ancho_X(),
                alto = tablero.Obtener_Ancho_Z(),
                velocidad = velocidad_juego
            };

            Direccion direccion = controlador_movimiento.Obtener_Direccion_Pendiente();
            datos.direccionX = direccion.Obtener_Delta_X();
            datos.direccionZ = direccion.Obtener_Delta_Z();

            for (int x = 0; x < datos.ancho; x++)
            {
                for (int z = 0; z < datos.alto; z++)
                {
                    Celda celda = tablero.Obtener_Celda(x, z);
                    foreach (Entidad entidad in celda.Obtener_Entidades())
                    {
                        if (entidad is Pared)
                        {
                            datos.paredes.Add(new PosicionGuardada(x, z));
                            break;
                        }
                    }
                }
            }

            foreach (Celda celda in personaje.Obtener_Cuerpo())
            {
                datos.cuerpoSerpiente.Add(new PosicionGuardada(
                    celda.Obtener_Posicion_X(),
                    celda.Obtener_Posicion_Z()));
            }

            if (Celda_Frutita != null)
            {
                datos.tieneFruta = true;
                datos.fruta = new PosicionGuardada(
                    Celda_Frutita.Obtener_Posicion_X(),
                    Celda_Frutita.Obtener_Posicion_Z());
            }

            return datos;
        }
    }
}