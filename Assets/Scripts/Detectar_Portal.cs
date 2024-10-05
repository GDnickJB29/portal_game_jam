using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectar_Portal : MonoBehaviour
{
    // Variable para rastrear la escena actual
    private string escena_actual;
    private bool esta_en_portal = false; // Booleano para verificar si el jugador está en el portal

    public void Start()
    {
        // Obtener el nombre de la escena actual
        escena_actual = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        // Si el jugador está en el portal y presiona la tecla "E", cambiamos de escena
        if (esta_en_portal && Input.GetKeyDown(KeyCode.E))
        {
            guardar_posicion_personaje();
            Cambiar_Escena(); // Cambia de escena
        }
    }

    // Este método se llama cuando el jugador entra en el trigger del portal
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Portal")
        {
            Debug.Log("Entraste en el portal");
            esta_en_portal = true; // Indica que el jugador está en el portal
        }
    }

    // Este método se llama cuando el jugador sale del trigger del portal
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Portal")
        {
            Debug.Log("Saliste del portal");
            esta_en_portal = false; // Indica que el jugador salió del portal
        }
    }

    public void Cambiar_Escena()
    {
        // Comprueba qué escena está actualmente activa y cambia
        if (escena_actual == "normal")
        {
            SceneManager.LoadScene("cambio");
            escena_actual = "cambio"; // Actualiza la escena actual
        }
        else if (escena_actual == "cambio")
        {
            SceneManager.LoadScene("normal");
            escena_actual = "normal"; // Actualiza la escena actual
        }
    }

    void guardar_posicion_personaje()
    {
        PlayerPrefs.SetFloat("JugadorX", transform.position.x);
        PlayerPrefs.SetFloat("JugadorY", transform.position.y);
        PlayerPrefs.SetFloat("JugadorZ", transform.position.z);
        PlayerPrefs.Save();
    }
}
