using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Icono_Accesibilidad : MonoBehaviour
{
    public Transform playerT; // Referencia a player para que lo siga
    public float speed = 2;
    private NavMeshAgent agent; // Referencia del enemigo 
    private float distance; 
    public float attackDistance;
    private bool isAttacking;
    public GameObject player;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // Para poder usar el NavMeshAgent
        playerT = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>(); // Encuentra la posición del jugador
    }

    // Update is called once per frame
    void Update()
    {
        Persecution();
    }

    public void Persecution()
    {
        if (playerT == null) // Para evitar que pete si no encuentra al jugador
        {
            return;
        }
        else
        {
            distance = Vector3.Distance(agent.transform.position, playerT.position); // La distancia se calcula entre la posicion del transform del enemigo y la posicion del jugador
            if (distance < attackDistance) // Si la distancia es menor que la distancia de ataque
            {
                StartAttack();
            }
            else // Si el jugador se aleja
            {
                isAttacking = false;
                agent.isStopped = false; // El enemigo se puede volver a mover
                agent.destination = playerT.position; // El enemigo sigue al jugador
            }
        }
    }

    public void StartAttack()
    {
        if (!isAttacking) // Si no está atacando
        {
            StartCoroutine("Attack"); 
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true; // Estado de ataque activado
        agent.isStopped = true; // Se para el enemigo para atacar
        var playerHp = player.GetComponent<Player>(); // Variable llamada playerHp para guardar el script del jugador
        
        while (playerHp.health > 0) // Mientras la vida del jugador sea mayor que 0
        {
            if (distance > attackDistance) // Si la distancia es mayor que lla distancia de ataque
            {
                agent.isStopped = false;
                break; // Se para la corrutina y no se ataca
            }
            else
            {
                Debug.Log("ataque");
                playerHp.TakeDamage(1); // Llama a la función de takeDamage del script del jugador
                if (playerHp.health <= 0) // Si la vida es igual o menor a 0
                {
                    break; // Se para a la corrutina y no se ataca
                }
                yield return new WaitForSeconds(3f); // Espera de 3 segundo de ataque en ataque
            }
        }
        isAttacking = false; // Como se sale del bucle, el jugador está muerto o fuera de rango así que cambia el estado de ataque a falso     
    }
}
