using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Icono_Accesibilidad : MonoBehaviour
{
    public Transform player; // Referencia a player para que lo siga
    public float speed = 2;
    private NavMeshAgent agent; // Referencia del enemigo 
    private float distance; 
    public float attackDistance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // Para poder usar el NavMeshAgent
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
            distance = Vector3.Distance(agent.transform.position, player.position); // La distancia se calcula entre la posicion del transform del enemigo y la posicion del jugador
            if (distance < attackDistance) // Si la distancia es menor que la distancia de ataque
            {
                agent.isStopped = true; // Se para el enemigo
            }
            else // Si el jugador se aleja
            {
                agent.isStopped = false; // El enemigo se puede volver  a mover
                agent.destination = player.position; // El enemigo sigue al jugador
            }
        }
    }
}
