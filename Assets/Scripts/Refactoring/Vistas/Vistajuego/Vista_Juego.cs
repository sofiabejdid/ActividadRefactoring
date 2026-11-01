using System.Collections.Generic;
using UnityEngine;
using Refactoring.Presentador;
using Refactoring.Vistas.Teclas;

namespace Refactoring.Vistas.Vistajuego
{
    public class Vista_Juego : MonoBehaviour
    {
        private Presenter presentador;
        private Controlador_Teclas controlador_teclas;

        // Referencias a los objetos instanciados en Unity
        private GameObject Fruta;
        private List<GameObject> Snake = new List<GameObject>();
        private readonly List<GameObject> objetosDelTablero = new List<GameObject>();

        // Método para ocultar/mostrar el panel (mencionado en el Presenter)
        public GameObject panelJuegoUI;

        private void Awake()
        {
            // Inicializa la lista por seguridad
            Snake = new List<GameObject>();
        }

        private void Update()
        {
            // En cada frame de Unity, verificamos si el usuario apretó algo
            if (controlador_teclas != null)
            {
                controlador_teclas.Verificar_Tecla_Presionada();
            }
        }

        public void Instanciar_Presentador(Presenter p)
        {
            this.presentador = p;
            // Una vez que tenemos el presentador, inicializamos las teclas
            this.controlador_teclas = new Controlador_Teclas(p);
        }

        // --- MÉTODOS DE DIBUJADO 3D (Llamados por el Presenter) ---

        public void dibujar_snake(int Pos_X, int Pos_Z)
        {
            GameObject nuevaParte = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objetosDelTablero.Add(nuevaParte);
            nuevaParte.transform.position = new Vector3(Pos_X, 0, Pos_Z);
            nuevaParte.GetComponent<Renderer>().material.color = Color.red;

            // La agregamos al principio de la lista visual (es la nueva cabeza)
            Snake.Insert(0, nuevaParte);
        }

        public void dibujar_Fruta(int Pos_X, int Pos_Z)
        {
            Fruta = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Fruta.transform.position = new Vector3(Pos_X, 0, Pos_Z);
            Fruta.GetComponent<Renderer>().material.color = Color.yellow;
            objetosDelTablero.Add(Fruta);

        }

        public void Destruir_Fruta(int Pos_X, int Pos_Z)
        {
            // Se reciben las coordenadas por si hay múltiples frutas en un nivel avanzado,
            // pero para el diseño actual con una sola fruta, basta con destruirla.
            if (Fruta != null)
            {
                Destroy(Fruta);
                Fruta = null; // Limpiamos la referencia
            }
            objetosDelTablero.Remove(Fruta);

        }

        public void Destruir_Cola(int Pos_X, int Pos_Z)
        {
            if (Snake.Count > 0)
            {
                // Obtenemos el último cubo 3D de la lista
                GameObject cola = Snake[Snake.Count - 1];

                // Lo removemos de la lista y lo destruimos de la escena
                Snake.RemoveAt(Snake.Count - 1);
                Destroy(cola);
                objetosDelTablero.Remove(cola);
            }
        }

        public void dibujar_Pared(int Pos_X, int Pos_Z)
        {
            GameObject Pared = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Pared.transform.position = new Vector3(Pos_X, 0, Pos_Z);
            Pared.GetComponent<Renderer>().material.color = Color.black;
            objetosDelTablero.Add(Pared);
        }
        public void LimpiarTablero()
        {
            foreach (GameObject objeto in objetosDelTablero)
            {
                if (objeto != null)
                {
                    Debug.Log($"Destruyendo objeto en posición: {objeto.transform.position}");
                    Destroy(objeto);
                }
            }

            objetosDelTablero.Clear();
            Snake.Clear();
            Fruta = null;
        }

        // --- MÉTODOS DE UI ---

        public void Mostrar_Panel_Juego()
        {
            if (panelJuegoUI != null) panelJuegoUI.SetActive(true);
        }

        public void Ocultar_Panel_Juego()
        {
            if (panelJuegoUI != null) panelJuegoUI.SetActive(false);
        }
    }
}