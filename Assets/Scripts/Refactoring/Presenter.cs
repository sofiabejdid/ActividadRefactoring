using Refactoring.Modelo;
using Refactoring.Modelo.Colisiones;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo.Movimiento;
using Refactoring.Vistas;
using Refactoring.Vistas.Vistajuego;
using Refactoring.Modelo.Guardar;
using UnityEngine;
// using Refactoring.Vistas.Vistajuego; // Descomentar si tu Vista_Juego est� en un sub-namespace

namespace Refactoring.Presentador
{
    public class Presenter
    {
        // --- Referencias a las Vistas (Unity) ---
        private Vista_Menu vista_menu;
        private Vista_Niveles vista_niveles;
        private Vista_Pausa vista_pausa;
        private Vista_Perdiste vista_perdiste;
        private Vista_Juego vista_juego; // Debe contener m�todos como dibujar_pared(), etc.
        private Guardar_y_cargar gurdarycargar;

        // --- Referencias al Modelo (L�gica) ---
        private Tablero tablero_juego;
        private Nivel nivel_actual; // Impl�cito en los m�todos de tu diagrama
        private Creador_De_Niveles creador_de_niveles;

        public Presenter()
        {
            creador_de_niveles = new Creador_De_Niveles();
            gurdarycargar = new Guardar_y_cargar();
        }

        // --------------------------------------------------------
        // M�TODOS DE INSTANCIACI�N DE VISTAS (Inyecci�n de dependencias)
        // --------------------------------------------------------

        public void Instanciar_Vista_Menu(Vista_Menu v)
        {
            vista_menu = v;
        }

        public void Instanciar_Vista_Niveles(Vista_Niveles v)
        {
            vista_niveles = v;
        }

        public void Instanciar_Vista_Pausa(Vista_Pausa v)
        {
            vista_pausa = v;
        }

        public void Instanciar_Vista_Perdiste(Vista_Perdiste v)
        {
            vista_perdiste = v;
        }

        public void Instanciar_Vista_Juego(Vista_Juego v)
        {
            vista_juego = v;
        }

        // --------------------------------------------------------
        // FLUJO Y NAVEGACI�N ENTRE MEN�S
        // --------------------------------------------------------

        public void Click_Boton_Seleccionar()
        {
            // L�gica para ir de Men� a Selecci�n de Niveles
            vista_menu?.Ocultar_Panel_Menu();
            vista_niveles?.Mostrar_Panel_Niveles();
            vista_perdiste?.Ocultar_Panel_Perdiste();
            vista_juego?.Ocultar_Panel_Juego();
        }

        public void Cargar_Partida()
        {
            DatosPartida datos = gurdarycargar.CargarPartida();
            if (datos == null)
            {
                return;
            }

            Nivel nivelCargado = creador_de_niveles.Cargar_Nivel_1(this, datos);
            nivel_actual?.Detener();
            vista_juego?.LimpiarTablero();
            nivel_actual = nivelCargado;
            tablero_juego = nivel_actual.Obtener_Tablero();
            vista_menu?.Ocultar_Panel_Menu();
            vista_niveles?.Ocultar_Panel_Niveles();
            vista_pausa?.Ocultar_Panel_Pausa();
            vista_perdiste?.Ocultar_Panel_Perdiste();
            vista_juego?.Mostrar_Panel_Juego();
            DibujarNivelInicio();
            nivel_actual.Comenzar_Nivel(false);
        }

        public void Click_Boton_Continuar_Partida()
        {
            Cargar_Partida();
        }

        public void Click_en_Boton_Nivel_1()
        {
            vista_juego.LimpiarTablero();
            nivel_actual = creador_de_niveles.Crear_Nivel_1(this);

            // Asumimos que Nivel tiene un m�todo Obtener_Tablero() para poder dibujarlo
            tablero_juego = nivel_actual.Obtener_Tablero();

            Avisar_Se_Creo_Nivel();
            DibujarNivelInicio();
            nivel_actual.Comenzar_Nivel();
        }

        public void Click_en_Boton_Nivel_2()
        {
            nivel_actual = creador_de_niveles.Crear_Nivel_2();
            tablero_juego = nivel_actual.Obtener_Tablero();
            Avisar_Se_Creo_Nivel();
            DibujarNivelInicio();
            nivel_actual.Comenzar_Nivel();
        }

        public void Click_en_Boton_Nivel_3()
        {
            nivel_actual = creador_de_niveles.Crear_Nivel_3();
            tablero_juego = nivel_actual.Obtener_Tablero();
            Avisar_Se_Creo_Nivel();
            DibujarNivelInicio();
            nivel_actual.Comenzar_Nivel();
        }
    
            public void Click_Boton_Reintentar()
        {
            nivel_actual?.Detener();
            vista_juego.LimpiarTablero();

            nivel_actual = creador_de_niveles.Crear_Nivel_1(this);
            tablero_juego = nivel_actual.Obtener_Tablero();

            DibujarNivelInicio();
            nivel_actual.Comenzar_Nivel();

            vista_perdiste.Ocultar_Panel_Perdiste();
            vista_juego.Mostrar_Panel_Juego();
        }
     

        public void Click_Boton_Volver_al_Menu()
        {
            vista_perdiste?.Ocultar_Panel_Perdiste();
            vista_niveles?.Ocultar_Panel_Niveles();
            vista_pausa?.Ocultar_Panel_Pausa();
            vista_juego?.Ocultar_Panel_Juego();
            vista_menu?.Mostrar_Panel_Menu();
        }

        public void Avisar_Se_Creo_Nivel()
        {
            vista_niveles.Ocultar_Panel_Niveles();
            vista_juego.Mostrar_Panel_Juego();
        }

        // --------------------------------------------------------
        // PUENTE DE DIBUJO (MODELO -> VISTA)
        // --------------------------------------------------------

        public void DibujarNivelInicio()
        {
            int ancho = tablero_juego.Obtener_Ancho_X();
            int alto = tablero_juego.Obtener_Ancho_Z();

            // Recorremos la matriz l�gica para dibujar su estado inicial
            for (int x = 0; x < ancho; x++)
            {
                for (int z = 0; z < alto; z++)
                {
                    Celda celda = tablero_juego.Obtener_Celda(x, z);
                    if (celda != null && !celda.Esta_Libre())
                    {
                        foreach (Entidad entidad in celda.Obtener_Entidades())
                        {
                            // Gracias al polimorfismo, la entidad sabe c�mo dibujarse a s� misma usando este presentador
                            entidad.Dibujar(this, celda.Obtener_Posicion_X(), celda.Obtener_Posicion_Z());
                        }
                    }
                }
            }
        }

        public void dibujar_pared(int Pos_X, int Pos_Z)
        {
            vista_juego.dibujar_Pared(Pos_X, Pos_Z);
        }

        public void dibujar_fruta(int Pos_X, int Pos_Z)
        {
            vista_juego.dibujar_Fruta(Pos_X, Pos_Z);
        }

        public void dibujar_snake(int Pos_X, int Pos_Z)
        {
            vista_juego.dibujar_snake(Pos_X, Pos_Z);
        }

        public void destruir_fruta(int Pos_X, int Pos_Z)
        {
            vista_juego.Destruir_Fruta(Pos_X, Pos_Z); // Pasamos coordenadas para saber cu�l destruir
        }

        public void dibujar_avance_serpiente(Celda Cabeza, Celda Cola)
        {
            // Dibuja el nuevo cubo de la cabeza
            vista_juego.dibujar_snake(Cabeza.Obtener_Posicion_X(), Cabeza.Obtener_Posicion_Z());

            // Le avisa a la vista que destruya el cubo visual asociado a las coordenadas de la cola l�gica
            vista_juego.Destruir_Cola(Cola.Obtener_Posicion_X(), Cola.Obtener_Posicion_Z());
        }
        public void Actualizar_Juego(float deltaTiempo)
        {
            nivel_actual?.Actualizar(deltaTiempo);
        }

        // --------------------------------------------------------
        // INTERACCI�N DEL USUARIO (VISTA -> MODELO)
        // --------------------------------------------------------

        public void CambiarDireccion(Direccion direccion)
        {
            if (nivel_actual != null)
            {
                nivel_actual.Cambiar_Direccion(direccion);
            }
        }

        public void Pausar()
        {
            if (nivel_actual != null)
            {
                nivel_actual.Detener();
                vista_pausa.Mostrar_Panel_Pausa();
            }
        }

        public void Aumentar_Velocidad()
        {
            if (nivel_actual != null)
            {
                nivel_actual.Aumentar_Velocidad();
            }
        }

        public void Avisar_Perdiste()
        {
            vista_juego.Ocultar_Panel_Juego();
            vista_perdiste.Mostrar_Panel_Perdiste();
        }
        //logica de guardar el nivel

        public void Click_boton_guardar_nivel()
        {
            if (nivel_actual == null)
            {
                Debug.LogWarning("No hay una partida activa para guardar.");
                return;
            }

            gurdarycargar.GuardarPartida(nivel_actual.Crear_Datos_Partida());
        }
    }
}