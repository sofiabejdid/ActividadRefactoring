using UnityEngine;
using UnityEngine.UI;
using Refactoring.Presentador;

namespace Refactoring.Vistas
{
    public class Vista_Pausa : MonoBehaviour
    {
        public GameObject Panel_Pausa;
        public Button Boton_Guardar_Partida;
        public Button Boton_Volver_Al_Menu;
        public Button Boton_Continuar_Partida;

        private Presenter presentador;

        public void Instanciar_Presentador(Presenter p)
        {
            this.presentador = p;
        }

        public void Ocultar_Panel_Pausa()
        {
            if (Panel_Pausa != null) Panel_Pausa.SetActive(false);
        }

        public void Mostrar_Panel_Pausa()
        {
            if (Panel_Pausa != null) Panel_Pausa.SetActive(true);
        }

        public void Click_en_Boton_Guardar_Partida()
        {
            presentador?.Click_boton_guardar_nivel();
        }

        public void Click_en_Boton_Volver_Al_Menu()
        {
            presentador?.Click_Boton_Volver_al_Menu();
        }

        public void Click_en_Boton_Continuar_Partida()
        {
            presentador?.Click_Boton_Continuar_Partida();
        }
    }
}
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vista_Pausa : MonoBehaviour
{
    public Presentador presenter;
    public Button Boton_Guardar_Partida;
    public Button Boton_Volver_Al_Menu;
    public Button Boton_Continuar_Partida;
    public GameObject Panel_Pausa;

    public void Instanciar_Presentador(Presentador p)
    {
        presenter = p;
    }
    public void Mostrar_Panel_Pausa()
    {
        Panel_Pausa.SetActive(true);
    }
    public void Ocultar_Panel_Pausa()
    {
        Panel_Pausa.SetActive(false);
    }
    public void Clic_Boton_Guardar_Partida()
    {
        presenter.Clic_Boton_Guardar();
    }
    public void Clic_Boton_Volver_Al_Menu()
    {
        presenter.Clic_Boton_Volver_Menu();
    }
    public void Clic_Boton_Continuar_Partida()
    {
        presenter.Clic_Boton_Continuar_Partida();
    }
}
*/