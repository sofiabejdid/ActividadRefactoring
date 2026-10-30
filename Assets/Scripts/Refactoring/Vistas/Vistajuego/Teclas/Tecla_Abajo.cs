using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Modelo.Movimiento;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Abajo : Tecla
    {
        public Tecla_Abajo()
        {
            teclaAsignada = KeyCode.S;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.CambiarDireccion(Direccion.Abajo);
        }
    }
}