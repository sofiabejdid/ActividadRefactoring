using Refactoring.Presentador;

namespace Refactoring.Modelo.Colisiones.Entidades
{
    public class Fruta : Entidad
    {
        public bool Verificar_Tipo_Entidad(Celda c)
        {
            // Verifica si la celda contiene una fruta
            return c != null && c.Obtener_Entidades().Exists(e => e is Fruta);
        }

        public override void Ejecutar_Funcionalidad(Controlador_Entidades c)
        {
            c.Avisar_Funcionalidad_Fruta();
        }

        public override void Dibujar(Presenter presentador, int posX, int posZ)
        {
            presentador.dibujar_fruta(posX, posZ);
        }
    }
}