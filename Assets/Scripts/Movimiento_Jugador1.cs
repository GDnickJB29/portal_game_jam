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
    //Todo el codigo aqui
    void Start()
    {
        controlador_del_jugador = GetComponent<CharacterController>();

        puede_saltar = false;
    }
    void Update()
    {
        //asginar que toco el suelo
        toca_el_suelo = controlador_del_jugador.isGrounded;


        Cambiar_Escena("cambio");
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nombre_de_escena);
        }
    }


    /*
       private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Vector3 direccion_de_empuje = Vector3.zero;
        float mueve_x = hit.moveDirection.x;
        float mueve_z = hit.moveDirection.z;

        // Obtenemos el Rigidbody del objeto con el que chocó el CharacterController
        Rigidbody body = hit.collider.attachedRigidbody;

        // Verificamos que el objeto tenga un Rigidbody y que no sea kinematic
        if (body == null || body.isKinematic)
        {
            return;
        }

        // Si el personaje está golpeando el objeto desde abajo o desde arriba, no empujar
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        // Variables para indicar si hay movimiento en X o Z
        bool mueve_horizontal = Mathf.Abs(mueve_x) > Mathf.Epsilon;
        bool mueve_vertical = Mathf.Abs(mueve_z) > Mathf.Epsilon;

        // Solo permitir empuje en una dirección a la vez
        if (mueve_horizontal && !mueve_vertical)
        {
            direccion_de_empuje = new Vector3(mueve_x, 0f, 0f).normalized;
        }
        else if (mueve_vertical && !mueve_horizontal)
        {
            direccion_de_empuje = new Vector3(0f, 0f, mueve_z).normalized;
        }

        // Si hay dirección de empuje, aplicar la fuerza
        if (direccion_de_empuje != Vector3.zero)
        {
            // Configuraciones adicionales para evitar que atraviese objetos
            body.collisionDetectionMode = CollisionDetectionMode.Continuous;
            body.interpolation = RigidbodyInterpolation.Interpolate;

            // Aplicamos la fuerza de forma controlada
            float fuerza = fuerza_de_empuje * body.mass;
            body.AddForce(direccion_de_empuje * fuerza, ForceMode.Impulse);
        }
    }
    */


}