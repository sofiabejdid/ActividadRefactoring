using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla_Abajo : Tecla
{
    private void Awake()
    {
        teclaAsignada = KeyCode.S;
    }

    public override void Ejecutar_Funcionalidad(Presentador p)
    {
        p.Cambiar_Direccion(Direccion.Abajo);
    }
}
