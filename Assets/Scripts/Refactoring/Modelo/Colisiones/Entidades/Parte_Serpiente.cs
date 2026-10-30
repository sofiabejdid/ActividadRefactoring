using Refactoring.Presentador;

namespace Refactoring.Modelo.Colisiones.Entidades
{
    public class Parte_Serpiente : Entidad
    {
        public bool Verificar_Tipo_Entidad(Celda c)
        {
            // Verifica si la celda contiene parte de la serpiente
            return c != null && c.Obtener_Entidades().Exists(e => e is Parte_Serpiente);
        }

        public override void Ejecutar_Funcionalidad(Controlador_Entidades c)
        {
            c.Avisar_Funcionalidad_Serpiente();
        }

        public override void Dibujar(Presenter presentador, int posX, int posZ)
        {
            presentador.dibujar_snake(posX, posZ);
        }
    }
}