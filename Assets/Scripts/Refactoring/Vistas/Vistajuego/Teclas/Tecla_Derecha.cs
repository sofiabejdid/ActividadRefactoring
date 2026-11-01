using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Modelo.Movimiento;

namespace Refactoring.Vistas.Teclas
{
    public class Tecla_Derecha : Tecla
    {
        public Tecla_Derecha()
        {
            teclaAsignada = KeyCode.D;
        }

        public override void Ejecutar_Funcionalidad(Presenter p)
        {
            p.CambiarDireccion(Direccion.Derecha);
        }
    }
}