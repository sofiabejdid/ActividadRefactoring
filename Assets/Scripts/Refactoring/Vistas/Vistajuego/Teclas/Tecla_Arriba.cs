using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla_Arriba : Tecla
{
    private void Awake()
    {
        teclaAsignada = KeyCode.W;
    }

    public override void Ejecutar_Funcionalidad(Presentador p)
    {
        p.Cambiar_Direccion(Direccion.Arriba);
    }
}
