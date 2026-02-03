using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack = 1;
    public int health = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Se le quita la cantidad de daño a la cantidad de vida
        if (health <= 0) // Si tiene 0 o menos vida
        {
            Die(); // Llama al método de muerte
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Restore")) // AL tocar el trigger invisible
        {
            health = 3; // La vida se restaura a 3
        }
    }


    private void Die()
    {
        Debug.Log("muerte");
    }
}
