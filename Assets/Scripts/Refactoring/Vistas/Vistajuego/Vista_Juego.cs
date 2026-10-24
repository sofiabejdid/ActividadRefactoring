using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista_Juego : MonoBehaviour
{
    public Presentador presenter;
    public Controlador_Teclas controlador_teclas;
    public GameObject cabeza_serpiente;
    public GameObject pared;
    public GameObject fruta; 

    public void Instanciar_Presentador(Presentador p)
    {
        presenter = p;
    }

    public void Dibujar_Snake()
    {
        
    }

    public void Dibujar_Fruta()
    {
        fruta = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fruta.transform.position();
            //terminar idea con genrador fruta 
    }

    public void Destruir_Fruta()
    {
        Destroy(fruta);

    }

    public void Dibujar_Pared(int pos_x, int pos_z)
    {
        pared = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pared.transform.position = new Vector3(pos_x, 0, pos_z);
        pared.GetComponent<Renderer>().material.color = Color.black;
    }
}

