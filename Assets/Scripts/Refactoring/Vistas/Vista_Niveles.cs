using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vista_Niveles : MonoBehaviour
{
    public GameObject Panel_Niveles;
    public Button Boton_Nivel_1;
    public Button Boton_Nivel_2;
    public Button Boton_Nivel_3;
    public Button Boton_Volver_Al_Menu;
    public Presentador presenter;

    public void Instanciar_Presentador(Presentador p)
    {
        presenter = p;
    }
    public void Ocultar_Panel_Niveles()
    {
        Panel_Niveles.SetActive(false);
    }
    public void Mostrar_Panel_Niveles()
    {
        Panel_Niveles.SetActive(true);
    }
    public void Clic_Boton_Nivel_1()
    {
        presenter.Clic_Boton_Nivel_1();
    }
    public void Clic_Boton_Nivel_2()
    {
        presenter.Clic_Boton_Nivel_2();
    }
    public void Clic_Boton_Nivel_3()
    {
        presenter.Clic_Boton_Nivel_3();
    }
    public void Clic_En_Boton_Volver_Al_Menu()
    {
        presenter.Clic_Boton_Volver_Al_Menu();
    }
}
