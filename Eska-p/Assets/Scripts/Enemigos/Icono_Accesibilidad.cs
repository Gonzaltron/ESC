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
    public float escapingAttackDistance;
    private bool isAttacking = false;
    public GameObject player;
    public bool receivingDamage;
    public int health;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); // Para poder usar el NavMeshAgent
    }
    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>(); // Encuentra la posición del jugador
        player = playerT.gameObject; // Consigo direcamente el player 
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, playerT.position);
        if (!isAttacking)
        {
            agent.GetComponent<NavMeshAgent>().enabled = true;
            Persecution();
        }
        if (isAttacking)
        {
            StartAttack();
        }
    }

    public void Persecution()
    {
        if (playerT == null) // Para evitar que pete si no encuentra al jugador
        {
            return;
        }
        else
        {
             // La distancia se calcula entre la posicion del transform del enemigo y la posicion del jugador
            if (distance < attackDistance) // Si la distancia es menor que la distancia de ataque
            {
                isAttacking = true;
            }
            else // Si el jugador se aleja
            {
                isAttacking = false;
                agent.destination = playerT.position; // El enemigo sigue al jugador
            }
        }
    }
    public void StartAttack()
    {
        StartCoroutine(Attack());
    }
    public void TakeDamage(int damage)
    {
        if (!receivingDamage)
        {
            health -= damage; // Se le quita la cantidad de daño a la cantidad de vida
            if (health <= 0) // Si tiene 0 o menos vida
            {
                //Die(); // Llama al método de muerte
            }

        }
    }
    IEnumerator Attack()
    {
        agent.GetComponent<NavMeshAgent>().enabled = false;
        isAttacking = true; // Estado de ataque activado
        var playerHp = player.GetComponent<Player>(); // Variable llamada playerHp para guardar el script del jugador

        if (playerHp.health > 0) // Mientras la vida del jugador sea mayor que 0
        {
            yield return null;
            if (distance < escapingAttackDistance) // Si la distancia es menor que lla distancia de ataque
            {
                playerHp.TakeDamage(1); // Llama a la función de takeDamage del script del
                if (playerHp.health <= 0) // Si la vida es igual o menor a 0
                {
                    StopAllCoroutines();
                }
                StopAllCoroutines();
            }
            else 
            {
                StopAllCoroutines();
            }
        }
        isAttacking = false; // Como se sale del bucle, el jugador está muerto o fuera de rango así que cambia el estado de ataque a falso     
    }
}
