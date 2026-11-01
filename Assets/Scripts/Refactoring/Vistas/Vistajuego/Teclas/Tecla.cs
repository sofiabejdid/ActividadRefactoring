using UnityEngine;
using Refactoring.Presentador;

namespace Refactoring.Vistas.Teclas
{
    public abstract class Tecla
    {
        public KeyCode teclaAsignada;

        public bool Verificar_Tecla_Ingresada()
        {
            return Input.GetKeyDown(teclaAsignada);
        }

        public abstract void Ejecutar_Funcionalidad(Presenter p);
    }
}