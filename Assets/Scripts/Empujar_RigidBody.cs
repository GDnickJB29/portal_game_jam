using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujar_RigidBody : MonoBehaviour
{
    public float fuerza_empuje = 5.0f;

    private void OnControllerColliderHit(ControllerColliderHit colicion)
    {
        Rigidbody cuerpo = colicion.collider.attachedRigidbody;

        if (cuerpo == null || cuerpo.isKinematic)
        {
            return;
        }

        // Evita empujar si el jugador está moviéndose hacia abajo
        if (colicion.moveDirection.y < -0.3)
        {
            return;
        }

        // Crear la dirección de empuje basada en el movimiento horizontal
        Vector3 direccion_empuje = new Vector3(colicion.moveDirection.x, 0, colicion.moveDirection.z);
        cuerpo.velocity = direccion_empuje * fuerza_empuje;
    }
}
