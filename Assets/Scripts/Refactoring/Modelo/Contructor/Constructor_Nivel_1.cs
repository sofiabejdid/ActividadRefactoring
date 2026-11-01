using Refactoring.Modelo.Colisiones;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo.Movimiento;
using Refactoring.Presentador;
using Refactoring.Modelo.Guardar;
using System;
using System.Collections.Generic;

namespace Refactoring.Modelo.Constructor
{
    public class Constructor_Nivel_1 : Constructor
    {
        private Random aleatorio;
        private int cantidad_obstaculos = 5; // Pod�s ajustar esto por nivel
        private Presenter presenter;

        // Se usa Reset en lugar del constructor vac�o para poder pasarle el Presenter
        public override void Reset(Presenter presentador)
        {
            this.presenter = presentador;
            // Instanciamos el nivel con una velocidad por defecto
            nivel = new Nivel(presentador, 0.2f);
            aleatorio = new Random();
        }

        public override void Hacer_Tablero()
        {
            // Asumimos un tama�o cl�sico, por ejemplo 40x40
            tablero = new Tablero(40, 40);
            nivel.Establecer_Tablero(tablero);
        }

        public override void Hacer_Muros()
        {
            int ancho = tablero.Obtener_Ancho_X();
            int alto = tablero.Obtener_Ancho_Z();

            // Muros horizontales (borde superior e inferior)
            for (int x = 0; x < ancho; x++)
            {
                tablero.Obtener_Celda(x, 0).Establecer_Entidad(new Pared());
                tablero.Obtener_Celda(x, alto - 1).Establecer_Entidad(new Pared());
            }

            // Muros verticales (borde izquierdo y derecho, excluyendo esquinas ya puestas)
            for (int z = 1; z < alto - 1; z++)
            {
                tablero.Obtener_Celda(0, z).Establecer_Entidad(new Pared());
                tablero.Obtener_Celda(ancho - 1, z).Establecer_Entidad(new Pared());
            }
        }
        
        public override void Hacer_Obstaculos()
        {
            for (int i = 0; i < cantidad_obstaculos; i++)
            {
                List<Celda> celdas_libres = tablero.Obtener_Celdas_Libres();
                if (celdas_libres.Count > 0)
                {
                    Celda celda = celdas_libres[aleatorio.Next(celdas_libres.Count)];
                    celda.Establecer_Entidad(new Pared());
                }
            }
        }

        public override void Hacer_Cabeza_Serpiente()
        {
            Parte_Serpiente parte = new Parte_Serpiente();

            List<Celda> celdas_libres = tablero.Obtener_Celdas_Libres();
            Celda celda = celdas_libres[aleatorio.Next(celdas_libres.Count)];

            celda.Establecer_Entidad(parte);
            personaje = new Personaje(celda);
            nivel.Establecer_Personaje(personaje);

            // Tambi�n instanciamos el movimiento aqu�, ya que el Nivel lo requiere para funcionar
            Controlador_Entidades controlEntidades = new Controlador_Entidades(nivel);
            controlador_movimiento = new Controlador_Movimiento(tablero, personaje, controlEntidades);
            nivel.Establecer_Controlador_Movimiento(controlador_movimiento);
        }

        public override void Hacer_Frutas() // En el diagrama figura como Hacer_Fruta
        {
            generador_fruta = new Generador_Fruta(tablero, aleatorio);
            nivel.Establecer_Generador_Fruta(generador_fruta);

            // La fruta inicial se genera al llamar a Comenzar_Nivel() en la clase Nivel,
            // pero si quer�s forzarla ac� como dice tu diagrama, lo pod�s hacer:
            // Celda Celda_Fruta = generador_fruta.Generar_Fruta();
        }

        // --- Interfaces de carga de partida vac�as para este nivel nuevo ---
        public override void Cargar_Muros() { }
        public override void Cargar_Cabeza_Serpiente() { }
        public override void Cargar_Frutas() { }
        public override void Cargar_Obstaculos() { }

        public void Restaurar(DatosPartida datos)
        {
            if (datos == null || datos.version != 1)
            {
                throw new ArgumentException("Los datos guardados no son compatibles.", nameof(datos));
            }

            if (datos.ancho < 3 || datos.ancho > 100 ||
                datos.alto < 3 || datos.alto > 100 || datos.velocidad <= 0f ||
                datos.paredes == null || datos.cuerpoSerpiente == null ||
                datos.cuerpoSerpiente.Count == 0)
            {
                throw new ArgumentException("Los datos guardados de la partida están incompletos.", nameof(datos));
            }

            Direccion direccion = CrearDireccion(datos.direccionX, datos.direccionZ);
            tablero = new Tablero(datos.ancho, datos.alto);
            nivel.Establecer_Tablero(tablero);

            foreach (PosicionGuardada posicion in datos.paredes)
            {
                Celda celda = ObtenerCeldaValida(posicion, datos);
                if (!celda.Esta_Libre())
                {
                    throw new ArgumentException("Los datos guardados contienen posiciones superpuestas.", nameof(datos));
                }
                celda.Establecer_Entidad(new Pared());
            }

            List<Celda> cuerpo = new List<Celda>();
            HashSet<long> posicionesCuerpo = new HashSet<long>();
            foreach (PosicionGuardada posicion in datos.cuerpoSerpiente)
            {
                Celda celda = ObtenerCeldaValida(posicion, datos);
                long clavePosicion = (long)posicion.x * datos.alto + posicion.z;
                if (!celda.Esta_Libre() || !posicionesCuerpo.Add(clavePosicion))
                {
                    throw new ArgumentException("Los datos guardados contienen posiciones superpuestas.", nameof(datos));
                }
                cuerpo.Add(celda);
            }

            personaje = new Personaje(cuerpo);
            nivel.Establecer_Personaje(personaje);
            nivel.Establecer_Velocidad_Juego(datos.velocidad);

            Controlador_Entidades controlEntidades = new Controlador_Entidades(nivel);
            controlador_movimiento = new Controlador_Movimiento(tablero, personaje, controlEntidades, direccion);
            nivel.Establecer_Controlador_Movimiento(controlador_movimiento);

            generador_fruta = new Generador_Fruta(tablero, aleatorio);
            nivel.Establecer_Generador_Fruta(generador_fruta);

            if (datos.tieneFruta)
            {
                Celda fruta = ObtenerCeldaValida(datos.fruta, datos);
                if (!fruta.Esta_Libre())
                {
                    throw new ArgumentException("La fruta guardada ocupa una celda que ya está ocupada.", nameof(datos));
                }
                fruta.Establecer_Entidad(new Fruta());
                nivel.establecer_Celda_Frutita(fruta);
            }
        }

        private Celda ObtenerCeldaValida(PosicionGuardada posicion, DatosPartida datos)
        {
            if (posicion == null || posicion.x < 0 || posicion.x >= datos.ancho ||
                posicion.z < 0 || posicion.z >= datos.alto)
            {
                throw new ArgumentException("Los datos guardados contienen una posición fuera del tablero.", nameof(datos));
            }

            return tablero.Obtener_Celda(posicion.x, posicion.z);
        }

        private Direccion CrearDireccion(int x, int z)
        {
            if (Math.Abs(x) + Math.Abs(z) != 1)
            {
                throw new ArgumentException("La dirección guardada no es válida.");
            }

            return new Direccion(x, z);
        }
    }
}