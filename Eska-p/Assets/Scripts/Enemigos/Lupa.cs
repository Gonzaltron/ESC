using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lupa : MonoBehaviour
{
    private bool isAttacking = false;

    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") && isAttacking == false)
        {
            isAttacking = true;
            collision.gameObject.GetComponent<Player>().TakeDamage(1); // Hace dos de da�o al jugador
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
