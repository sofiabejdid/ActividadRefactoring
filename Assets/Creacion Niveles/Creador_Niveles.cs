using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador_Niveles : MonoBehaviour
{
    //-------Atributos de Instancia--------
    private Constructor constructor ;
    private Director director ;

    //-------Constructor---------
    public Creador_Niveles() ;

    //-------Metodos-------

    public Nivel Nivel_1()
    {
        constructor = new Constructor_Nivel_1() ;
        director = new Director_Nivel_1(constructor) ;
        return (Crear_Nivel(director,constructor)) ;
    }

    public Nivel Nivel_2()
    {
        constructor = new Constructor_Nivel_2() ;
        director = new Director_Nivel_2(constructor) ;
        return (Crear_Nivel(director,constructor)) ;
    }

    public Nivel Nivel_3()
    {
        constructor = new Constructor_Nivel_3() ;
        director = new Director_Nivel_3(constructor) ;
        return (Crear_Nivel(director,constructor)) ;
    }

    private Crear_Nivel(Director director, Constructor constructor)
    {
        director.Construir() ;
        return (constructor.Obtener_Nivel_Terminado()) ;
    }

}
