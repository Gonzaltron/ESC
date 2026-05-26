using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;
    public float spawnDistance = 10f; // Distancia desde el jugador
    private int spawnedEnemies; // El máximo de enemigos que puede haber a la vez
    private bool isSpawning = false; // Booleano para la corrutina, para que no spawneeen los enemigos a la vez
    public Transform spawnCenter;
    public GameObject[] enemiesList;
    public static SpawnEnemigos Instance;
    void Awake()
    {
        Instance = this;
    }
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
        yield return new WaitForSeconds(3f); // Se espera un segundo
        if (spawnedEnemies < 3) // Se vuelve a comprobar que haya menos de 2 enemigos en pantalla
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnDistance;

            Vector3 randomSpawnPosition = new Vector3(spawnCenter.position.x + randomCircle.x,spawnCenter.position.y,spawnCenter.position.z + randomCircle.y);
            Instantiate(enemy, randomSpawnPosition, Quaternion.identity); // Se instancia el prefab enemigo en la posición 
            spawnedEnemies++;// Se suma 1 a la cantidad de enemigos que hay en 

        }
        isSpawning = false; // Se pone en false para que lal corrutina se pueda volver a llamar
    }
    public void EnemyDied()
    {
        spawnedEnemies--;

        if (spawnedEnemies < 0)
        {
            spawnedEnemies = 0;
        }
    }
}
