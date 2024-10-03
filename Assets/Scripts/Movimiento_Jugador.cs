using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento_Jugador : MonoBehaviour
{
    //Declaracion de Variables

    //variables privadas de uso en el movimiento y demas
    private float contador_tiempo_coyote;
    private float movimiento_salto;
    private bool puede_saltar;
    private bool toca_el_suelo;

    //variables movimiento y reaccion del jugador
    public float velocidad_de_movimiento;
    public float fuerza_del_salto;
    public float tiempo_del_coyote;
    public float gravedad;
    public float fuerza_de_empuje;

    //control del Jugador
    public CharacterController controlador_del_jugador;
    private Vector3 direccion_de_movimiento;
    
    // Variable para rastrear la escena actual
    private string escena_actual;

    void Start()
    {
        // Obtener el nombre de la escena actual
        escena_actual = SceneManager.GetActiveScene().name;

        controlador_del_jugador = GetComponent<CharacterController>();
        puede_saltar = false;

        float x = PlayerPrefs.GetFloat("JugadorX");
        float y = PlayerPrefs.GetFloat("JugadorY");
        float z = PlayerPrefs.GetFloat("JugadorZ");
        transform.position = new Vector3(x, y, z);
    }

    void Update()
    {
        //asginar que toco el suelo
        toca_el_suelo = controlador_del_jugador.isGrounded;

        if (Input.GetKeyDown(KeyCode.E)) // Cambia la escena al presionar "E"
        {
            guardar_posicion_personaje();
            Cambiar_Escena("normal"); // Cambia de escena
        }

        CoyoteTime();
        Salto();

        direccion_de_movimiento = Movimiento(movimiento_salto, velocidad_de_movimiento);
        controlador_del_jugador.Move(direccion_de_movimiento * Time.deltaTime);
    }

    private void CoyoteTime()
    {
        //logica del "coyote time" hay un contador que se reinicia si toca el suelo
        if (!toca_el_suelo)
        {
            contador_tiempo_coyote += Time.deltaTime;
            if (contador_tiempo_coyote > tiempo_del_coyote)
            {
                puede_saltar = false;
            }
        }
        else
        {
            contador_tiempo_coyote = 0f;
            puede_saltar = true;
        }
    }

    private void Salto()
    {
        //asginar que toco el suelo
        toca_el_suelo = controlador_del_jugador.isGrounded;

        //logica del salto, si toca el suelo puede saltar con la tecla jump o si no le afecta la gravedad
        if (toca_el_suelo || puede_saltar)
        {
            movimiento_salto = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                movimiento_salto = fuerza_del_salto;
                puede_saltar = false;
            }
        }
        else
        {
            movimiento_salto -= gravedad * Time.deltaTime;
        }
    }



    private Vector3 Movimiento(float salto, float velocidad)
    {
        Vector3 direccion;
        float horizontal, vertical;
        horizontal = Input.GetAxis("Horizontal") * velocidad;
        vertical = Input.GetAxis("Vertical") * velocidad;
        direccion = new Vector3(horizontal, salto, vertical);
        return direccion;
    }


    public void Cambiar_Escena(string nombre_de_escena)
    {
        // Comprueba qué escena está actualmente activa
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