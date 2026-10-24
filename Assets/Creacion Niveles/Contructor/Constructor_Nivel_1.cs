using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructor_Nivel_1 : Constructor
{
    //Hereda los atributos de instancia de Constructor
    protected static int ancho_x = 40 ;
    protected static int ancho_z = 40 ;

    protected static int cantidad_de_obstaculos = 300 ;


    // ------- Constructor -------
    public Constructor_Nivel_1()
    {
        nivel = new Nivel() ;
    }

    public void Hacer_Tablero()
    {
        tablero = new Tablero(ancho_x,ancho_z) ;
        nivel.Establecer_Tablero(tablero);
    }
    public void Hacer_Muros()
    {
        for (int x = 0 ; x < ancho_x - 1 ; x++)
        {
          (tablero.Obtener_Celda(x,0)).Establecer_Entidad(new Pared()); //Borde Superior
          (tablero.Obtener_Celda(x,ancho_z-1)).Establecer_Entidad(new Pared()); //Borde Inferior
        }
        for (int z = 1 ; z < ancho_z - 1; z++)
        {
          (tablero.Obtener_Celda(0,z)).Establecer_Entidad(new Pared()); //Borde Izquierdo
          (tablero.Obtener_Celda(ancho_x - 1,z)).Establecer_Entidad(new Pared()); //Borde Derecho 
        }
    }
    public void Hacer_Obstaculos()
    {
        for (int i = 0 ; i < cantidad_de_obstaculos; i++)
        {
            List<Celda> Celdas_Libres = tablero.Obtener_Celdas_Libres() ;
            System.Random aleatorio = new System.Random();
            celda = Celdas_Libres[aleatorio.Next(Celdas_Libres.Count)];
            celda.Establecer_Entidad(new Pared()) ;
        }
    }
    public void Hacer_Cabeza_Serpiente()
    {
        pa
        
    }
    public void Hacer_Fruta()
    {
        
    }

    // ------- Metodo Obtener Nivel terminado heredado de clase abstracta Constructor
}
