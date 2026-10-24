using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla_Derecha : Tecla
{
    private void Awake()
    {
        teclaAsignada = KeyCode.D;
    }


    public override void Ejecutar_Funcionalidad(Presentador p)
    {
        p.Cambiar_Direccion(Direccion.Derecha);
    }
}
