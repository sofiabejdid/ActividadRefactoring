using Refactoring.Modelo.Constructor;
using Refactoring.Modelo.Director;
using Refactoring.Presentador;
using Refactoring.Modelo.Guardar;

namespace Refactoring.Modelo
{
    public class Creador_De_Niveles
    {
        // Usamos el nombre completamente calificado (Namespace.Clase) por si el 
        // namespace "Constructor" y la clase "Constructor" generan conflicto en Unity.
        private Refactoring.Modelo.Constructor.Constructor constructor;
        private Refactoring.Modelo.Director.Director director;

        public Creador_De_Niveles()
        {
        }

        public Nivel Crear_Nivel_1(Presenter presentador)
        {
            constructor = new Constructor_Nivel_1();
            constructor.Reset(presentador);
            director = new Director_Nivel_1(constructor);

            return Crear_Nivel(director, constructor);
        }

        public Nivel Cargar_Nivel_1(Presenter presentador, DatosPartida datos)
        {
            Constructor_Nivel_1 constructorNivel = new Constructor_Nivel_1();
            constructorNivel.Reset(presentador);
            constructorNivel.Restaurar(datos);
            return constructorNivel.Obtener_Nivel_Terminado();
        }

        public Nivel Crear_Nivel_2()
        {
            throw new System.NotSupportedException("Nivel 2 aun no esta implementado.");
        }

        // Correg� el nombre de Nivel_3() a Crear_Nivel_3() para mantener la consistencia
        public Nivel Crear_Nivel_3()
        {
            throw new System.NotSupportedException("Nivel 3 aun no esta implementado.");
        }

        private Nivel Crear_Nivel(Refactoring.Modelo.Director.Director direc, Refactoring.Modelo.Constructor.Constructor constr)
        {
            direc.Construir();
            return constr.Obtener_Nivel_Terminado();
        }
    }
}