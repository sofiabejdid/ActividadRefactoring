using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Modelo.Movimiento;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Izquierda : Tecla
    {
        public Tecla_Izquierda()
        {
            teclaAsignada = KeyCode.A;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.CambiarDireccion(Direccion.Izquierda);
        }
    }
}