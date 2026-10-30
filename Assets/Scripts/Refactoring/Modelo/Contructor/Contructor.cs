using Refactoring.Modelo.Colisiones;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo.Movimiento;
using Refactoring.Presentador;
using System;

namespace Refactoring.Modelo.Constructor
{
    public abstract class Constructor
    {
        // Atributos lógicos protegidos, accesibles por los constructores concretos
        protected Tablero tablero;
        protected Personaje personaje;
        protected Nivel nivel;
        protected Generador_Fruta generador_fruta;
        protected Controlador_Movimiento controlador_movimiento;

        // Métodos de inicialización del patrón Builder
        public abstract void Reset(Presenter presentador);

        // Pasos de construcción para niveles nuevos
        public abstract void Hacer_Tablero();
        public abstract void Hacer_Muros();
        public abstract void Hacer_Obstaculos();
        public abstract void Hacer_Cabeza_Serpiente();
        public abstract void Hacer_Frutas();

        // Pasos de construcción para cargar partida
        public abstract void Cargar_Muros();
        public abstract void Cargar_Cabeza_Serpiente();
        public abstract void Cargar_Frutas();
        public abstract void Cargar_Obstaculos();

        // Devuelve el producto terminado (Lógico, no un GameObject)
        public Nivel Obtener_Nivel_Terminado()
        {
            return nivel;
        }
    }
}