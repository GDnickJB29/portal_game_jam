using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSeDestruiraInador : MonoBehaviour
{
    private static List<int> instanceIDs = new List<int>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Buscar todos los GameObjects en la escena
        GameObject[] gameObjectsExistentes = GameObject.FindGameObjectsWithTag("Player"); // Cambia "GameObjectTag" por la etiqueta correspondiente
GameObject[] gameObjectsExistentes1 = GameObject.FindGameObjectsWithTag("Caja"); // Cambia "GameObjectTag" por la etiqueta correspondiente

        if (gameObjectsExistentes.Length > 1 || gameObjectsExistentes1.Length > 1)
        {
            Debug.Log("Hay más de un GameObject en la escena");
            // Comprobar si ya existe otro GameObject con el mismo nombre
            if (gameObjectsExistentes[1] != null || gameObjectsExistentes1[1] != null)
            {
                // Ya existe un objeto con el nombre
                Destroy(gameObject); // Destruir el nuevo si ya existe otro
            }
        }
    }

    private void OnDestroy()
    {
        // Eliminar el "ID" de la lista al destruir el objeto
        int objectID = gameObject.GetInstanceID();
        instanceIDs.Remove(objectID);
    }
}
