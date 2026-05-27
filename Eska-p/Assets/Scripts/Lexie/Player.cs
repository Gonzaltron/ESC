using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Data;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int attack = 1;
    public int health = 3;
    private bool receivingDamage = false;
    public GameObject spawn;
    //private Vector3 respawnLocation;
    public GameObject player;
    public bool isDead;
    GameObject room1;
    GameObject room2;
    GameObject room3;
    GameObject room4;
    TMP_Text healthText;
    TMP_Text respawnText;
    int respawnCount;
    void Start()
    {
        //respawnLocation = player.transform.position;
        Time.timeScale = 1f;  // El juego se inciia, esto deber� estar en gamemanager pero por ahora aqu�
        isDead = false;
        respawnCount = 2;
        room1 = GameObject.Find("Level1");
        room2 = GameObject.Find("Level2");
        room3 = GameObject.Find("Level3");
        room4 = GameObject.Find("Level4");
        healthText = GameObject.Find("Vida").GetComponent<TMP_Text>();
        respawnText = GameObject.Find("Reapariciones").GetComponent<TMP_Text>();
        healthText.text = "Vida: " + health.ToString() + "/3";
        respawnText.text = "Reapariciones restantes: " + respawnCount.ToString() + "/2";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        if (receivingDamage)
        {
            return;
        }

        receivingDamage = true;

        health -= damage; // Se le quita la cantidad de da�o a la cantidad de vida
        healthText.text = "Vida: " + health.ToString() + "/3";

        if (health <= 0)// Si tiene 0 o menos vida
        {
            DeleteChars();
            Die();  // Llama al m�todo de muerte
        }
        else
        {
            StartCoroutine(Damage());
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
        health = 3;
        healthText.text = "Vida: " + health.ToString() + "/3";
        Spawn.Instance.Respawn();
        receivingDamage = true;
        StartCoroutine(Damage());
        if(respawnCount <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
        respawnCount--;
        respawnText.text = "Reapariciones restantes: " + respawnCount.ToString() + "/2";
    }
    IEnumerator Damage() // Corrutina para que no pueda recibir da�o doble al mismo momento, igual hay que auemntar los segundosen el futuro
    {
        yield return new WaitForSeconds(2f); 
        receivingDamage = false; 
    }

    void DeleteChars()
    {
        room1.GetComponent<WordManager>().DeleteList();
        room2.GetComponent<WordManager>().DeleteList();
        room3.GetComponent<WordManager>().DeleteList();
        room4.GetComponent<WordManager>().DeleteList();
    }
}
