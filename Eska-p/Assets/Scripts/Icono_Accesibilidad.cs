using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Icono_Accesibilidad : MonoBehaviour
{
    public Transform player = null; // Referencia a player para que lo siga
    public float speed = 2;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>(); // Encuentra la posición del jugador
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) // Para evitar que pete si no encuentra al jugador
        {
            return;
        }

        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // La dirección a la que se va a mover el enemigo para seguir al jugador
            Vector3 directionToFollow = player.position - transform.position; // La dirección a la que el enemigo va a rotar
        }

    }
}
