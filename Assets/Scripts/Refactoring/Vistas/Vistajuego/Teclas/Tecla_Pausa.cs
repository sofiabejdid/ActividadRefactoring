using UnityEngine;
using Refactoring.Presentador;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Pausa : Tecla
    {
        public Tecla_Pausa()
        {
            teclaAsignada = KeyCode.P;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.Pausar();
        }
    }
}