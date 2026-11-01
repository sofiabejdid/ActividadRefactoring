using Refactoring.Modelo.Constructor; // Asumiendo que tu interfaz/clase Constructor estar� aqu�

using ConstructorBase = Refactoring.Modelo.Constructor.Constructor;

namespace Refactoring.Modelo.Director
{
    public abstract class Director
    {
        protected ConstructorBase constructor;

        public Director(ConstructorBase constructor)
        {
            this.constructor = constructor;
        }

        public abstract void Construir();
    }
}