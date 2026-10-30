using UnityEngine;
using System;
using Refactoring.Modelo.Guardar;

public class Guardar_y_cargar
{
    private const string CLAVE_GUARDADO = "SnakeSaveData";

    public void GuardarPartida(DatosPartida datos)
    {
        if (datos == null)
        {
            throw new ArgumentNullException(nameof(datos));
        }

        string json = JsonUtility.ToJson(datos);
        if (string.IsNullOrEmpty(json))
        {
            throw new InvalidOperationException("No se pudieron serializar los datos de la partida.");
        }

        PlayerPrefs.SetString(CLAVE_GUARDADO, json);
        PlayerPrefs.Save();
        Debug.Log("Partida guardada exitosamente: " + json);
    }

    public DatosPartida CargarPartida()
    {
        if (!PlayerPrefs.HasKey(CLAVE_GUARDADO))
        {
            Debug.LogWarning("No se encontró ninguna partida guardada.");
            return null;
        }

        string json = PlayerPrefs.GetString(CLAVE_GUARDADO);
        DatosPartida datos = JsonUtility.FromJson<DatosPartida>(json);
        if (datos == null)
        {
            throw new InvalidOperationException("El archivo guardado no contiene datos válidos.");
        }

        Debug.Log("Partida cargada exitosamente.");
        return datos;
    }

    public void BorrarPartida()
    {
        if (PlayerPrefs.HasKey(CLAVE_GUARDADO))
        {
            PlayerPrefs.DeleteKey(CLAVE_GUARDADO);
            PlayerPrefs.Save();
            Debug.Log("Partida borrada del sistema.");
        }
    }
}