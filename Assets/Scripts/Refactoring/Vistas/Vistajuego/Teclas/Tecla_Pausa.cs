using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla_Pausa : Tecla
{
  
        private void Awake()
        {
            teclaAsignada = KeyCode.P;
        }

        public override void Ejecutar_Funcionalidad(Presentador p)
        {
            p.Pausar();
        }
    }

