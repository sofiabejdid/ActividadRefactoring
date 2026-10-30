using System.Collections.Generic;
using Refactoring.Presentador;

namespace Refactoring.Vistas.Teclas
{
    public class Controlador_Teclas
    {
        private List<Tecla> Teclas;
        private Presenter presentador;

        public Controlador_Teclas(Presenter presentador)
        {
            this.presentador = presentador;
            this.Teclas = new List<Tecla>
            {
                new Tecla_Arriba(),
                new Tecla_Abajo(),
                new Tecla_Izquierda(),
                new Tecla_Derecha(),
                new Tecla_Pausa(),
                new Tecla_Aumentar_Velocidad()
            };
        }

        public void Verificar_Tecla_Presionada()
        {
            foreach (Tecla t in Teclas)
            {
                if (t.Verificar_Tecla_Ingresada())
                {
                    t.Ejecutar_Funcionalidad(presentador);
                }
            }
        }
    }
}