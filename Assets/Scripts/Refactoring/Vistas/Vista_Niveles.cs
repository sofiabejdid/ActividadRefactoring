using UnityEngine;
using UnityEngine.UI;
using Refactoring.Presentador;

namespace Refactoring.Vistas
{
    public class Vista_Niveles : MonoBehaviour
    {
        public GameObject Panel_Niveles;
        public Button Boton_Nivel_1;
        public Button Boton_Nivel_2;
        public Button Boton_Nivel_3;
        public Button Boton_Volver_al_Menu;

        private Presenter presentador;

        public void Instanciar_Presentador(Presenter p)
        {
            this.presentador = p;
        }

        public void Ocultar_Panel_Niveles()
        {
            if (Panel_Niveles != null) Panel_Niveles.SetActive(false);
        }

        public void Mostrar_Panel_Niveles()
        {
            if (Panel_Niveles != null)
            {
                Panel_Niveles.SetActive(true);


            }
        }
        public void Click_en_Boton_Nivel_1()
        {
            presentador?.Click_en_Boton_Nivel_1();
        }

        public void Click_en_Boton_Nivel_2()
        {
            presentador?.Click_en_Boton_Nivel_2();
        }

        public void Click_en_Boton_Nivel_3()
        {
            presentador?.Click_en_Boton_Nivel_3();
        }

        public void Click_en_Boton_Volver_al_Menu()
        {
            presentador?.Click_Boton_Volver_al_Menu();
        }
    }
}
/*

using Refactoring.Presentador;
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
    public Presenter presenter;

    public void Instanciar_Presentador(Presenter p)
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
        presenter.Click_en_Boton_Nivel_1();
    }
    public void Clic_Boton_Nivel_2()
    {
        presenter.Click_en_Boton_Nivel_2();
    }
    public void Clic_Boton_Nivel_3()
    {
        presenter.Click_en_Boton_Nivel_3();
    }
    public void Clic_En_Boton_Volver_Al_Menu()
    {
        presenter.Click_Boton_Volver_al_Menu();
    }
}*/