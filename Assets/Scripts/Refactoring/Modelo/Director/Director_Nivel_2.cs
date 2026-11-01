using Refactoring.Modelo.Constructor;

using ConstructorBase = Refactoring.Modelo.Constructor.Constructor;

namespace Refactoring.Modelo.Director
{
    public class Director_Nivel_2 : Director
    {
        public Director_Nivel_2(ConstructorBase constructor) : base(constructor)
        {
        }

        public override void Construir()
        {
            // Secuencia de pasos para el nivel 2
            // Por ejemplo:
            // constructor.Hacer_Tablero();
            // constructor.Hacer_Muros_Laberinto();
            // constructor.Hacer_Cabeza_Serpiente();
            // constructor.Hacer_Frutas();
        }
    }
}