using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;
    public float spawnDistance = 10f; // Distancia desde el jugador
    private int spawnedEnemies; // El máximo de enemigos que puede haber a la vez
    private bool isSpawning = false; // Booleano para la corrutina, para que no spawneeen los enemigos a la vez
    public Transform spawnCenter;
    public GameObject[] enemiesList;

    void Start()
    {
        isSpawning = false;
    }

    void Update()
    {
        if (!isSpawning) // Si no se está spawneando
        {
            StartSpawn(); // Se Llama a la función
        }
    }
    public void StartSpawn()
    {
        if (spawnedEnemies < 3) // Si la cantidad de enemigos en pantalla es menor a 2
        {
            StartCoroutine(Spawn()); // Se llama a la corrutina para que aparezcan
        }
    }

    IEnumerator Spawn()
    {
        isSpawning = true; // Se activa ell booleano para que no se esté llamando sin parar la corrutina
        yield return new WaitForSeconds(1f); // Se espera un segundo
        if (spawnedEnemies < 3) // Se vuelve a comprobar que haya menos de 2 enemigos en pantalla
        {
            spawnedEnemies++; // Se suma 1 a la cantidad de enemigos que hay en 
            Vector3 randomDirection = Random.onUnitSphere; // Da un punto aleatorio del radio de una esfera, es decir, no da lejanía sino que hace que pueda aparecer a la izquierda, derecha etc.
            Vector3 randomSpawnPosition = spawnCenter.position + (Random.insideUnitSphere * spawnDistance);
            Instantiate(enemy, randomSpawnPosition, Quaternion.identity); // Se instancia el prefab enemigo en la posición 
        }
        isSpawning = false; // Se pone en false para que lal corrutina se pueda volver a llamar
    }
}
