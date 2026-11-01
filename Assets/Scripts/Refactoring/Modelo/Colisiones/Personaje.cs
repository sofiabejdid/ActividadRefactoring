using System.Collections.Generic;
using Refactoring.Modelo.Colisiones.Entidades;
using Refactoring.Modelo.Movimiento;
// using Refactoring.Modelo.Movimiento; // Descomentar si tu clase 'Direccion' est� en otro namespace

namespace Refactoring.Modelo.Colisiones
{
    public class Personaje
    {       
        private List<Celda> Cuerpo;
        private Celda Cabeza;
        private Celda Cola;
        private Direccion Direccion; // Asumo que Direccion ya la ten�s creada seg�n tus diagramas anteriores

        // Constructor
        public Personaje(Celda parte)
        {
            Cuerpo = new List<Celda>();
            Cuerpo.Add(parte);

            Cabeza = parte;
            Cola = parte;

            // Al nacer, le decimos a esa celda inicial que ahora contiene a la serpiente
            parte.Establecer_Entidad(new Parte_Serpiente());
        }

        public Personaje(List<Celda> cuerpo)
        {
            if (cuerpo == null || cuerpo.Count == 0)
            {
                throw new System.ArgumentException("La serpiente debe tener al menos una celda.", nameof(cuerpo));
            }

            Cuerpo = new List<Celda>(cuerpo);
            Cabeza = Cuerpo[0];
            Cola = Cuerpo[Cuerpo.Count - 1];

            foreach (Celda celda in Cuerpo)
            {
                celda.Establecer_Entidad(new Parte_Serpiente());
            }
        }

        public void ActualizarCabeza(Celda c)
        {
            // 1. Guardamos la referencia de la cola actual antes de movernos
            Cola = Cuerpo[Cuerpo.Count - 1];

            // 2. Eliminamos la entidad Parte_Serpiente de la celda donde estaba la cola
            Entidad parteARemover = Cola.Obtener_Entidades().Find(e => e is Parte_Serpiente);
            if (parteARemover != null)
            {
                Cola.Remover_Entidad();
            }

            // 3. Removemos la �ltima celda de la lista del cuerpo
            Cuerpo.RemoveAt(Cuerpo.Count - 1);

            // 4. Insertamos la nueva celda como cabeza (al principio de la lista, �ndice 0)
            Cuerpo.Insert(0, c);
            Cabeza = c;

            // 5. Le decimos a la nueva celda que ahora tiene una parte de serpiente
            c.Establecer_Entidad(new Parte_Serpiente());
        }

        public void RestituirCola()
        {
            // Este m�todo se llamar� justo despu�s de ActualizarCabeza() si la serpiente comi� una fruta

            // 1. Agrega la celda que hab�amos guardado como 'Cola' de vuelta al final de la lista
            Cuerpo.Add(Cola);

            // 2. Le dice a esa celda que vuelva a tener la entidad Parte_Serpiente
            Cola.Establecer_Entidad(new Parte_Serpiente());
        }

        // --- Getters y Setters �tiles para el Controlador_Movimiento ---
        public Celda Obtener_Cabeza() => Cabeza;
        public List<Celda> Obtener_Cuerpo() => Cuerpo;
        public Direccion Obtener_Direccion() => Direccion;
        public void Establecer_Direccion(Direccion d) => Direccion = d;
    }
}