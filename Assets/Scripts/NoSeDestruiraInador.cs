using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSeDestruiraInador : MonoBehaviour
{
    private static List<string> instanceIDs = new List<string>();

    private void Awake()
    {
        // Usa el nombre del objeto como un "ID"
        string objectID = gameObject.name;

        // Verifica si el "ID" ya existe en la lista
        if (instanceIDs.Contains(objectID))
        {
            // Si ya existe, destruye este objeto
            Destroy(gameObject);
        }
        else
        {
            // Si no existe, añade el "ID" a la lista
            instanceIDs.Add(objectID);

            // No destruir al cargar nuevas escenas
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Eliminar el "ID" de la lista al destruir el objeto
        string objectID = gameObject.name;
        instanceIDs.Remove(objectID);
    }
}
