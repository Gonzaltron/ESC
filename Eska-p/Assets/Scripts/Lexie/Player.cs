using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public int attack = 1;
    public int health = 3;
    private bool receivingDamage = false;

    void Start()
    {
        Time.timeScale = 1f;  // El juego se inciia, esto deberá estar en gamemanager pero por ahora aquí
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!receivingDamage)
        {
            health -= damage; // Se le quita la cantidad de daño a la cantidad de vida
            if (health <= 0) // Si tiene 0 o menos vida
            {
                Die(); // Llama al método de muerte
            }
            else
            {
                receivingDamage = true;
                DeactivateDamage();
            }      
        }
    }

    public void DeactivateDamage()
    {
        if (receivingDamage)
        {
            StartCoroutine("Damage");
        }
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Restore")) // AL tocar el trigger invisible
        {
            health = 3; // La vida se restaura a 3
        }
    }

    public void Die()
    {
        Time.timeScale = 0f;
    }

    IEnumerator Damage() // Corrutina para que no pueda recibir daño doble al mismo momento, igual hay que auemntar los segundosen el futuro
    {
        yield return new WaitForSeconds(1f); 
        receivingDamage = false; 
    }
}
