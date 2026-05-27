using System.Collections;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnCenter;

    public float spawnDistance = 10f; // Distancia desde el jugador
    public int maxEnemies = 3; 

    private int spawnedEnemies = 0; // El máximo de enemigos que puede haber a la vez
    private bool isSpawning = false; // Booleano para la corrutina, para que no spawneeen los enemigos a la vez

    void Update()
    {
        if (!isSpawning && spawnedEnemies < maxEnemies)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        isSpawning = true;

        yield return new WaitForSeconds(3f);

        if (spawnedEnemies < maxEnemies)
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnDistance;

            Vector3 spawnPos = new Vector3(spawnCenter.position.x + randomCircle.x, spawnCenter.position.y, spawnCenter.position.z + randomCircle.y);

            GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);

            newEnemy.GetComponent<Icono_Accesibilidad>().SetSpawner(this);

            spawnedEnemies++;
        }

        isSpawning = false;
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