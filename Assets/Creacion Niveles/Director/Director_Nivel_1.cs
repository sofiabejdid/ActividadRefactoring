using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director_Nivel_1 : Director
{   
    // ------- Constructor -------
    public Director_Nivel_1(Constructor constructor)
    {
        this.constructor = constructor ;
    }

    // ------- Metodos -------

    public void Construir()
    {
        constructor.Hacer_Tablero() ;
        constructor.Hacer_Muros() ;
        constructor.Hacer_Obstaculos() ;
        constructor.Hacer_Cabeza_Serpiente() ;
        constructor.Hacer_Frutas() ;
    }
}
