using Refactoring.Presentador;

namespace Refactoring.Modelo.Colisiones.Entidades
{
    public class Pared : Entidad
    {
        public bool Verificar_Tipo_Entidad(Celda c)
        {
            // Verifica si la celda contiene una pared
            return c != null && c.Obtener_Entidades().Exists(e => e is Pared);
        }

        public override void Ejecutar_Funcionalidad(Controlador_Entidades c)
        {
            c.Avisar_Funcionalidad_Pared();
        }

        public override void Dibujar(Presenter presentador, int posX, int posZ)
        {
            presentador.dibujar_pared(posX, posZ);
        }
    }
}