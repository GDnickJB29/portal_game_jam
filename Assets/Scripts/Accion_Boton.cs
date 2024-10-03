using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionBoton : MonoBehaviour
{
    public Animator boton;
    public Animator puerta;
    private int contadorObjetosDentro = 0; // Contador para rastrear cuántos objetos están dentro del collider

    void Start()
    {
        // Inicializar los estados de los animadores en falso
        boton.SetBool("presionar", false);
        puerta.SetBool("subir", false);
    }

    // Detectar cuando un objeto entra en el trigger del collider
    void OnTriggerEnter(Collider otro)
    {
        // Solo incrementar si es la primera vez que un objeto entra en el trigger
        contadorObjetosDentro++;

        // Si al menos un objeto está dentro, activa el botón y la puerta
        if (contadorObjetosDentro > 0)
        {
            boton.SetBool("presionar", true);
            puerta.SetBool("subir", true);
        }
    }

/*
    // Detectar cuando un objeto sale del trigger del collider
    void OnTriggerExit(Collider otro)
    {
        // Disminuir el contador cuando un objeto sale del trigger
        contadorObjetosDentro--;

        // Si ya no hay objetos dentro, restablecer el botón y la puerta a falso
        if (contadorObjetosDentro <= 0)
        {
            boton.SetBool("presionar", false);
            puerta.SetBool("subir", false);
            contadorObjetosDentro = 0; // Asegurarse de que el contador no baje de 0
        }
    }
    */
}
