using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla_Izquierda : Tecla
{
    private void Awake()
    {
        teclaAsignada = KeyCode.A;
    }

    public override void Ejecutar_Funcionalidad(Presentador p)
    {
        p.Cambiar_Direccion(Direccion.Izquierda);
    }
}
