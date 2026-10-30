using Refactoring.Presentador;

namespace Refactoring.Modelo.Colisiones.Entidades
{
    public abstract class Entidad
    {
        public abstract void Ejecutar_Funcionalidad(Controlador_Entidades c);

        public abstract void Dibujar(Presenter presentador, int posX, int posZ);
    }
}