using Refactoring.Modelo.Constructor;

using ConstructorBase = Refactoring.Modelo.Constructor.Constructor;

namespace Refactoring.Modelo.Director
{
    public class Director_Nivel_Cargar_Partida : Director
    {
        public Director_Nivel_Cargar_Partida(ConstructorBase constructor) : base(constructor)
        {
        }

        public override void Construir()
        {
            constructor.Cargar_Muros();
            constructor.Cargar_Cabeza_Serpiente();
            constructor.Cargar_Frutas();
            constructor.Cargar_Obstaculos();
        }
    }
}