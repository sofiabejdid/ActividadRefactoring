using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Vistas;
using Refactoring.Vistas.Vistajuego;

public class Iniciador : MonoBehaviour
{
    public Vista_Menu vistaMenu;
    public Vista_Niveles vistaNiveles;
    public Vista_Pausa vistaPausa;
    public Vista_Perdiste vistaPerdiste;
    public Vista_Juego vistaJuego;

    private Presenter presenter;

    void Start()
    {
        presenter = new Presenter();

        // Inyección de vistas
        presenter.Instanciar_Vista_Menu(vistaMenu);
        presenter.Instanciar_Vista_Niveles(vistaNiveles);
        presenter.Instanciar_Vista_Pausa(vistaPausa);
        presenter.Instanciar_Vista_Perdiste(vistaPerdiste);
        presenter.Instanciar_Vista_Juego(vistaJuego);

        vistaMenu.Instanciar_Presentador(presenter);
        vistaNiveles.Instanciar_Presentador(presenter);
        vistaPausa.Instanciar_Presentador(presenter);
        vistaPerdiste.Instanciar_Presentador(presenter);
        vistaJuego.Instanciar_Presentador(presenter);

        // FORZAMOS el inicio del nivel para probar directamente
        //presenter.Click_en_Boton_Nivel_1();
    }

    void Update()
    {
        // En cada frame, le inyectamos el tiempo transcurrido a nuestra lógica pura
        if (presenter != null)
        {
            presenter.Actualizar_Juego(Time.deltaTime);
        }
    }
}