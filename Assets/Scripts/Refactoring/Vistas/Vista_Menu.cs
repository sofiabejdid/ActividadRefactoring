using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vista_Menu : MonoBehaviour
{
    public GameObject Panel_Menu;
    public Button Boton_Seleccionar_Nivel;
    public Button Boton_Cargar_Partida;
    public Image Imagen_Snake;
    public Presentador presenter;

    public void Instanciar_presentador(Presentador p)
    {
          presenter = p;
    }
    public void Ocultar_Panel_Menu()
    {
        Panel_Menu.SetActive(false);
    }
    public void Mostrar_Panel_Menu()
    {
        Panel_Menu.SetActive(true);
    }
    public void Clic_En_Boton_Seleccionar_Nivel()
    {
        presenter.Clic_Boton_Seleccionar();
    }
    public void Clic_En_Boton_Cargar_Partida()
    {
        presenter.Cargar_Partida();
    }
}
