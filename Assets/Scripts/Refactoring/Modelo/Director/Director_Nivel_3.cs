using Refactoring.Modelo.Director;
using Refactoring.Modelo.Constructor;

using ConstructorBase = Refactoring.Modelo.Constructor.Constructor;

namespace Refactoring.Modelo.Director
{
    public class Director_Nivel_3 : Director
    {
        public Director_Nivel_3(ConstructorBase constructor) : base(constructor)
        {
        }

        public override void Construir()
        {
            // Secuencia de pasos para el nivel 3
        }
    }
}