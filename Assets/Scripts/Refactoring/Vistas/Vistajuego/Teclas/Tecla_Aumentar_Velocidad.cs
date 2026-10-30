using UnityEngine;
using Refactoring.Presentador;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Aumentar_Velocidad : Tecla
    {
        public Tecla_Aumentar_Velocidad()
        {
            teclaAsignada = KeyCode.V;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.Aumentar_Velocidad();
        }
    }
}