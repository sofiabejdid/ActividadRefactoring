using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Teclas 
{
    public List<Tecla> Teclas;
    public Presentador presentador;
    public void Verificar_Tecla_Presionada()
    {
        foreach (Tecla t in Teclas){
            if(t.Verificar_Tecla_Ingresada())
            {
                t.Ejecutar_Funcionalidad(presentador);
            }
        }
    }
}
