using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Modelo.Movimiento;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Arriba : Tecla
    {
        public Tecla_Arriba()
        {
            teclaAsignada = KeyCode.W;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.CambiarDireccion(Direccion.Arriba);
        }
    }
}