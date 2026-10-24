using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Contructor
{
    // ------- Atributos de Instancia -------
    protected Tablero tablero ;
    protected Personaje personaje ;
    protected Nivel nivel ;
    protected Celda celda ;
    protected Entidad entidad ;

    public Nivel Obtener_Nivel_Terminado()
    {
        return (nivel) ;
    }
}
