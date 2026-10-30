using Refactoring.Modelo.Constructor;

using ConstructorBase = Refactoring.Modelo.Constructor.Constructor;

namespace Refactoring.Modelo.Director
{
    public class Director_Nivel_1 : Director
    {
        public Director_Nivel_1(ConstructorBase constructor) : base(constructor)
        {
        }

        public override void Construir()
        {
            constructor.Hacer_Tablero();
            constructor.Hacer_Muros();
            constructor.Hacer_Obstaculos();
            constructor.Hacer_Cabeza_Serpiente();
            constructor.Hacer_Frutas();
        }
    }
}