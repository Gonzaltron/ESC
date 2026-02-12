using UnityEngine;

public class Boton_Configuracion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(2); // Hace dos de daño al jugador
        }
    }
}
