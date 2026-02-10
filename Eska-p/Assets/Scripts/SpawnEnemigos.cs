using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;
    public float spawnDistance = 10f; // Distancia desde el jugador
    public int spawnedEnemies; // El máximo de enemigos que puede haber a la vez
    public bool isSpawning = false; // Booleano para la corrutina, para que no spawneeen los enemigos a la vez

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
        if (spawnedEnemies < 2) // Si la cantidad de enemigos en pantalla es menor a 2
        {
            StartCoroutine("Spawn"); // Se llama a la corrutina para que aparezcan
        }
    }

    IEnumerator Spawn()
    {
        isSpawning = true; // Se activa ell booleano para que no se esté llamando sin parar la corrutina
        yield return new WaitForSeconds(1f); // Se espera un segundo
        if (spawnedEnemies < 2) // Se vuelve a comprobar que haya menos de 2 enemigos en pantalla
        {
            spawnedEnemies++; // Se suma 1 a la cantidad de enemigos que hay en 
            Vector3 randomDirection = Random.onUnitSphere; // Da un punto aleatorio del radio de una esfera, es decir, no da lejanía sino que hace que pueda aparecer a la izquierda, derecha etc.
            Vector3 randomSpawnPosition = player.position + (randomDirection * spawnDistance); // La posición final se consigue sumando la posición del jugador con la multiplicación de un punto aleatorio del radio y la distancia mínima para que aparezca alejado del jugador
            Instantiate(enemy, randomSpawnPosition, Quaternion.identity); // Se instancia el prefab enemigo en la posición aleatorio
        }
        isSpawning = false; // Se pone en false para que lal corrutina se pueda volver a llamar
    }
}
