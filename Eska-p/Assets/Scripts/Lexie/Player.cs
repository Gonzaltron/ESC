using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Data;

public class Player : MonoBehaviour
{
    public int attack = 1;
    public int health = 3;
    private bool receivingDamage = false;
    public GameObject spawn;
    //private Vector3 respawnLocation;
    public GameObject player;
    public bool isDead;
    void Start()
    {
        //respawnLocation = player.transform.position;
        Time.timeScale = 1f;  // El juego se inciia, esto deberá estar en gamemanager pero por ahora aquí
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!receivingDamage)
        {
            receivingDamage = true;
            health -= damage; // Se le quita la cantidad de daño a la cantidad de vida
            if (health <= 0) // Si tiene 0 o menos vida
            {
                Die(); // Llama al método de muerte
            }
            else
            {
                DeactivateDamage();
            }      
        }
    }

    public void DeactivateDamage()
    {
        if (receivingDamage)
        {
            StartCoroutine(Damage());
        }
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Restore")) // AL tocar el trigger invisible
        {
            health = 3; // La vida se restaura a 3
        }
        else if (other.gameObject.CompareTag("reinicio"))
        {
            TakeDamage(2);
        }
        else if (other.gameObject.CompareTag("configuracion") || other.gameObject.CompareTag("lupa"))
        {
            TakeDamage(1);
        }
        
    }

    public void Die()
    {
        isDead = true;
        Spawn.Instance.Respawn();
    }
    IEnumerator Damage() // Corrutina para que no pueda recibir daño doble al mismo momento, igual hay que auemntar los segundosen el futuro
    {
        yield return new WaitForSeconds(1f); 
        receivingDamage = false; 
    }
}
