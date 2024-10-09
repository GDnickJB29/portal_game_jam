using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detectar_Salida: MonoBehaviour
{
  // Variable para rastrear la escena actual
  private string escena_actual;
  // Referencia al GameObject Menu_Salida
  public GameObject Menu_Salida;
  private bool esta_en_salida = false; // Booleano para verificar si el jugador está en la salida

  public void Start()
  {
    // Obtener el nombre de la escena actual
    escena_actual = SceneManager.GetActiveScene().name;
  }

  void Update()
  {
    // Si el jugador está en el portal  de salida
    if (esta_en_salida)
    {
      //Agrega el GO de interfaz, siguiente nivel, menu
      Mostrar_Menu_Final();
    }
  }

  // Este método se llama cuando el jugador entra en el trigger del portal
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Salida")
    {
      Debug.Log("Entraste en el portal");
      esta_en_salida= true; // Indica que el jugador entro del portal
      Mostrar_Menu_Final();
    }
  }

  public void Mostrar_Menu_Final()
  {
    Menu_Salida.SetActive(true);  // Activa el GameObject
  }
}

