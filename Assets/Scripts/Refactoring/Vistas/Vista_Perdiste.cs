using UnityEngine;
using UnityEngine.UI;
using Refactoring.Presentador;

namespace Refactoring.Vistas
{
    public class Vista_Perdiste : MonoBehaviour
    {
        public GameObject Panel_Perdiste;
        public Button Boton_Volver_Al_Menu;
        public Button Boton_Seleccionar_Nuevo_Nivel;
        public Button Boton_Reintentar_Nivel;

        private Presenter presentador;

        public void Instanciar_Presentador(Presenter p)
        {
            this.presentador = p;
        }

        public void Ocultar_Panel_Perdiste()
        {
            if (Panel_Perdiste != null) Panel_Perdiste.SetActive(false);
        }

        public void Mostrar_Panel_Perdiste()
        {
            if (Panel_Perdiste != null) Panel_Perdiste.SetActive(true);
        }

        public void Click_en_Boton_Volver_Al_Menu()
        {
            presentador?.Click_Boton_Volver_al_Menu();
        }

        public void Click_en_Boton_Seleccionar_Nuevo_Nivel()
        {
            presentador?.Click_Boton_Seleccionar();
        }

        public void Click_en_Boton_Reintentar()
        {
            
            presentador?.Click_Boton_Reintentar();
        }
    }
}
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vista_Perdiste : MonoBehaviour
{
    public GameObject Panel_Perdiste;
    public Button Boton_Volver_Al_Menu;
    public Button Boton_Seleccionar_Nuevo_Nivel;
    public Button Boton_Reintentar_Nivel;
    public Presentador presenter;

    public void Instanciar_Presentador(Presentador p)
    {
        presenter = p;
    }

    public void Mostrar_Panel_Perdiste()
    {
        Panel_Perdiste.SetActive(true);
    }
    public void Ocultar_Panel_Perdiste()
    {
        Panel_Perdiste.SetActive(false);
    }
    public void Clic_Boton_Volver_Al_Menu()
    {
        presenter.Clic_Boton_Volver_Menu();
    }
    public void Clic_Boton_Seleccionar_Nuevo_Nivel()
    {
        presenter.Clic_Boton_Seleccionar();
    }
    public void Clic_Boton_Reintentar()
    {
        presenter.Clic_Boton_Reintentar();
    }
}
 * */