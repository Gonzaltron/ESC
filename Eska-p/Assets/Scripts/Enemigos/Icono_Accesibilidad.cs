using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Icono_Accesibilidad : MonoBehaviour
{
    public Transform playerT;
    public float speed = 2;

    private NavMeshAgent agent;
    private float distance;

    public float attackDistance;
    public float escapingAttackDistance;

    private bool isAttacking = false;
    private bool attackCoroutineRunning = false;

    public GameObject player;

    public bool receivingDamage;
    public int health = 1;

    private SpawnEnemigos spawner;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("player").transform;
        player = playerT.gameObject;
    }

    void Update()
    {

        Vector3 enemyPos = transform.position;
        Vector3 playerPos = playerT.position;

        enemyPos.y = 0;
        playerPos.y = 0;

        distance = Vector3.Distance(enemyPos, playerPos);

        if (!isAttacking)
        {
            Persecution();
        }
        else
        {
            StartAttack();
        }
    }

    public void SetSpawner(SpawnEnemigos spawn)
    {
        spawner = spawn;
    }

    public void Persecution()
    {
        if (distance < attackDistance)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
            agent.destination = playerT.position;
        }
    }

    public void StartAttack()
    {
        if (!attackCoroutineRunning)
        {
            StartCoroutine(Attack());
        }
    }

    public void TakeDamage(int damage)
    {
        if (receivingDamage)
        {
            return;
        }

        receivingDamage = true;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator Attack()
    {
        attackCoroutineRunning = true;

        Player playerHp = player.GetComponent<Player>();

        if (playerHp.health > 0)
        {
            yield return new WaitForSeconds(0.2f);

            if (distance < escapingAttackDistance)
            {
                playerHp.TakeDamage(1);
            }
        }

        yield return new WaitForSeconds(1f);

        isAttacking = false;
        attackCoroutineRunning = false;
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        receivingDamage = false;
    }

    public void Die()
    {
        spawner.EnemyDied();
        Destroy(gameObject);
    }
}