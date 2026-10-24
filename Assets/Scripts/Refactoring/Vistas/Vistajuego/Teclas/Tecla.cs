using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class Tecla 
    {
        public KeyCode teclaAsignada;

        public  bool Verificar_Tecla_Ingresada()
        {
            return Input.GetKeyDown(teclaAsignada);
        }

        public abstract void Ejecutar_Funcionalidad(Presentador p);
    }

